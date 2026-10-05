using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Threading;

namespace ProjectBlackout.Game.Data.Sync.Client
{
    public class ServerWarning
    {
        public static void LoadGMWarning(ReceiveGPacket p)
        {
            string login = p.readS(p.readC());
            string pass = p.readS(p.readC());
            string msg = p.readS(p.readH());

            Account pl = AccountManager.getAccount(login, 0, 0);
            if (pl != null && pl.password == ComDiv.gen5(pass) && (int)pl.access >= 4)
            {
                int count = 0;
                using (PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK packet = new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(msg))
                {
                    count = GameManager.SendPacketToAllClients(packet);
                }
                Logger.warning("Message sent to: " + count + " Player: " + msg + " Login: '" + login + "' Date: '" + DateTime.Now.ToString("dd/MM/yy HH:mm") + "'");
                Logger.LogCMD("Message sent to: " + count + " Player: " + msg + " Login: '" + login + "' Date: '" + DateTime.Now.ToString("dd/MM/yy HH:mm") + "'");
            }
        }

        public static void LoadShopRestart(ReceiveGPacket p)
        {
            int type = p.readC();
            ShopManager.Reset();
            ShopManager.Load(type);
            Logger.warning("Shop restarted. (Type: " + type + ")");
            Logger.LogCMD("Shop restarted. (Type: " + type + ") Date: '" + DateTime.Now.ToString("dd/MM/yy HH:mm") + "'");
        }

        public static void LoadServerUpdate(ReceiveGPacket p)
        {
            int serverId = p.readC();
            ServersXml.UpdateServer(serverId);
            Logger.warning("Server " + serverId + " updated.");
            Logger.LogCMD("Server " + serverId + " updated. Date: '" + DateTime.Now.ToString("dd/MM/yy HH:mm") + "'");
        }

        public static void LoadShutdown(ReceiveGPacket p)
        {
            string login = p.readS(p.readC());
            string pass = p.readS(p.readC());

            Account pl = AccountManager.getAccount(login, 0, 0);
            if (pl != null && pl.password == ComDiv.gen5(pass) && (int)pl.access >= 5)
            {
                int count = 0;
                foreach (GameClient client in GameManager._socketList.Values)
                {
                    client._client.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                    client.Close(5000);
                    count++;
                }
                Logger.warning("Offline Players: " + count + ". (" + login + ")");
                GameManager.ServerIsClosed = true;
                GameManager.mainSocket.Close(5000);
                Thread.Sleep(5000);
                GameSync.udp.Close();
                foreach (GameClient client in GameManager._socketList.Values)
                {
                    client.Close(0);
                }
                Logger.warning("Server was completely shut down.");
                Logger.LogCMD("Shutdown Server: " + count + " players disconnected Login: '" + login + "' Date: '" + DateTime.Now.ToString("dd/MM/yy HH:mm") + "'");
            }
        }
    }
}