using ProjectBlackout.Core;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_USER_LEAVE_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_USER_LEAVE_REQ(GameClient client, byte[] data)
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
                _client.SendPacket(new PROTOCOL_BASE_USER_LEAVE_ACK(0));
                _client.Close(0);
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
        }
    }
}