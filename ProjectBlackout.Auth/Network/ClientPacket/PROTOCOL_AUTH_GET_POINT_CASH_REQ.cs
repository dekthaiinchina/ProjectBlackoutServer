using ProjectBlackout.Auth.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_AUTH_GET_POINT_CASH_REQ : ReceivePacket
    {
        public PROTOCOL_AUTH_GET_POINT_CASH_REQ(AuthClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            
        }

        public override void run()
        {
            if (_client._player != null)
            {
                _client.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, _client._player._gp, _client._player._money, _client._player._tag));
            }
        }
    }
}
