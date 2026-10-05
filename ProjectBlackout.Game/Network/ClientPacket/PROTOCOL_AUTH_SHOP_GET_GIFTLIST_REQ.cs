using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_SHOP_GET_GIFTLIST_REQ : ReceivePacket
    {
        public PROTOCOL_AUTH_SHOP_GET_GIFTLIST_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {

        }

        public override void run()
        {
            try
            {
                _client.SendPacket(new PROTOCOL_AUTH_SHOP_GET_GIFTLIST_ACK(2148110592));
            }
            catch
            {

            }
        }
    }
}
