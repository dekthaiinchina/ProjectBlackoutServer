using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_GET_USER_BASIC_INFO_REQ : ReceivePacket
    {
        private string Name;

        public PROTOCOL_BASE_GET_USER_BASIC_INFO_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            Name = readUnicode(33);
        }

        public override void run()
        {
            try
            {
                Account Player = _client._player;
                if (Player == null || Player.player_name.Length == 0 || Player.player_name == Name)
                {
                    return;
                }
                Account user = AccountManager.getAccount(Name, 1, 0);
                _client.SendPacket(new PROTOCOL_BASE_GET_USER_BASIC_INFO_ACK(user == null ? 2147489795 : 0));
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}
