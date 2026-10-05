using PointBlank.Core.Network;
using System;

namespace PointBlank.Auth.Network.ServerPacket
{
    public class PROTOCOL_SERVER_MESSAGE_EVENT_RANKUP_ACK : SendPacket
    {
        public PROTOCOL_SERVER_MESSAGE_EVENT_RANKUP_ACK()
        {

        }

        public override void write()
        {
            writeH(2616);
        }
    }
}