using ProjectBlackout.Core;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_USER_ENTER7681_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_USER_ENTER7681_REQ(GameClient client, byte[] data)
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
                _client.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK("(7671) 0xc1d1nah61 Not implemented... \n Work in progress :) (C) EmpireB"));
                _client.Close(0);
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
        }
    }
}