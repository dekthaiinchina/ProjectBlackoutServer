using ProjectBlackout.Core;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class KickAllPlayers
    {
        public static string KickPlayers()
        {
            int succ = 0;
            using (PROTOCOL_AUTH_ACCOUNT_KICK_ACK packet = new PROTOCOL_AUTH_ACCOUNT_KICK_ACK(0))
            {
                if (GameManager._socketList.Count > 0)
                {
                    byte[] data = packet.GetCompleteBytes("KickAllPlayers.genCode");
                    foreach (GameClient client in GameManager._socketList.Values)
                    {
                        Account p = client._player;
                        if (p != null && p._isOnline && (int)p.access <= 2)
                        {
                            p.SendCompletePacket(data);
                            p.Close(1000, true);
                            succ++;
                        }
                    }
                }
            }
            return Translation.GetLabel("KickAllWarn", succ);
        }
    }
}