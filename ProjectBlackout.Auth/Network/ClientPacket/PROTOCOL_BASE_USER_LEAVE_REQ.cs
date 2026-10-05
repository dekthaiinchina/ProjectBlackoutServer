using ProjectBlackout.Core;
using ProjectBlackout.Auth.Network.ServerPacket;
using System;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_USER_LEAVE_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_USER_LEAVE_REQ(AuthClient client, byte[] data)
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
                if (_client == null || _client._player == null)
                {
                    return;
                }
                _client.SendPacket(new PROTOCOL_BASE_USER_LEAVE_ACK(0));
                _client.Close(0, false);
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
        }
    }
}