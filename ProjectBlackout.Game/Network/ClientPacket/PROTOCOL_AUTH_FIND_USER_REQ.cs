using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_FIND_USER_REQ : ReceivePacket
    {
        private string name;

        public PROTOCOL_AUTH_FIND_USER_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            name = readUnicode(33);
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null || p.player_name.Length == 0 || p.player_name == name)
                {
                    return;
                }
                p.FindPlayer = name;
                Account user = AccountManager.getAccount(p.FindPlayer, 1, 0);
                _client.SendPacket(new PROTOCOL_AUTH_FIND_USER_ACK(user == null ? 2147489795 : 0, user));
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}