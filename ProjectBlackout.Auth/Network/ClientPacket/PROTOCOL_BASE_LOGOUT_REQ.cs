using ProjectBlackout.Core;
using ProjectBlackout.Auth.Network.ServerPacket;
using System;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_LOGOUT_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_LOGOUT_REQ(AuthClient lc, byte[] buff)
        {
            makeme(lc, buff);
        }

        public override void read()
        {

        }

        public override void run()
        {
            try
            {
                _client.SendPacket(new PROTOCOL_BASE_LOGOUT_ACK());
                _client.Close(5000, true);
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_BASE_LOGOUT_REQ: " + ex.ToString());
            }
        }
    }
}