using ProjectBlackout.Core.Network;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_MESSENGER_NOTE_CHECK_READED_ACK : SendPacket
    {
        private List<int> msgs;

        public PROTOCOL_MESSENGER_NOTE_CHECK_READED_ACK(List<int> msgs)
        {
            this.msgs = msgs;
        }

        public override void write()
        {
            writeH(935);
            writeC((byte)msgs.Count);
            for (int i = 0; i < msgs.Count; i++)
            {
                writeD(msgs[i]);
            }
        }
    }
}