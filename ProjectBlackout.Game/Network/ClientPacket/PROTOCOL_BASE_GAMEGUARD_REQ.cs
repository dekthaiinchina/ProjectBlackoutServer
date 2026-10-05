using ProjectBlackout.Core;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_GAMEGUARD_REQ : ReceivePacket
    {
        private byte[] Bytes;
        private string ClientVersion;

        public PROTOCOL_BASE_GAMEGUARD_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            Bytes = readB(48);
            ClientVersion = readC() + "." + readH();
        }

        public override void run()
        {
            try
            {
                _client.SendPacket(new PROTOCOL_BASE_GAMEGUARD_ACK());
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}
