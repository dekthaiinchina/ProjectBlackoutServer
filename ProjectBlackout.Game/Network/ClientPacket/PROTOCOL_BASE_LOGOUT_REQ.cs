using ProjectBlackout.Core;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_LOGOUT_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_LOGOUT_REQ(GameClient client, byte[] data)
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
                _client.SendPacket(new PROTOCOL_BASE_LOGOUT_ACK());
                _client.Close(1000);
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
                _client.Close(0);
            }
        }
    }
}