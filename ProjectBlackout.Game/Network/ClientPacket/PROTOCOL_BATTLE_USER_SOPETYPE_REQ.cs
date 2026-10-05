using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_USER_SOPETYPE_REQ : ReceivePacket
    {
        private int Sight;

        public PROTOCOL_BATTLE_USER_SOPETYPE_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            Sight = readC();
        }

        public override void run()
        {
            Account Player = _client._player;
            Room Room = Player._room;
            if (Player != null)
            {
                Player.Sight = Sight;
                if (Room != null)
                {
                    //Room.SendPacketToPlayers(new PROTOCOL_BATTLE_USER_SOPETYPE_ACK(Player));
                }
            }
        }
    }
}
