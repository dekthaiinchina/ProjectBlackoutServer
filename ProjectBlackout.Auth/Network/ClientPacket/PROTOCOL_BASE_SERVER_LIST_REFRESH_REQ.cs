using ProjectBlackout.Core;
using ProjectBlackout.Auth.Network.ServerPacket;
using System;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_SERVER_LIST_REFRESH_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_SERVER_LIST_REFRESH_REQ(AuthClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            try
            {
                if (_client != null)
                {
                    _client.SendPacket(new PROTOCOL_BASE_SERVER_LIST_REFRESH_ACK());
                }
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
        }
    }
}