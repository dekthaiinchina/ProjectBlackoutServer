using ProjectBlackout.Auth.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_GAMEGUARD_REQ : ReceivePacket
    {
        private string ClientVersion;

        public PROTOCOL_BASE_GAMEGUARD_REQ(AuthClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            readB(48);
            ClientVersion = readC() + "." + readH();
        }

        public override void run()
        {
            _client.SendPacket(new PROTOCOL_BASE_GAMEGUARD_ACK());
        }
    }
}
