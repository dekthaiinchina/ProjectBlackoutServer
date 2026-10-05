using PointBlank.Core.Network;
using System;

namespace PointBlank.Auth.Network.ServerPacket
{
    public class PROTOCOL_SERVER_MESSAGE_EVENT_QUEST_ACK : SendPacket
    {
        public PROTOCOL_SERVER_MESSAGE_EVENT_QUEST_ACK()
        {

        }

        public override void write()
        {
            writeH(2061);
        }
    }
}