using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CLAN_MATCH_RESULT_CONTEXT_ACK : SendPacket
    {
        private int matchCount;

        public PROTOCOL_CS_CLAN_MATCH_RESULT_CONTEXT_ACK(int count)
        {
            matchCount = count;
        }

        public override void write()
        {
            writeH(1955);
            writeC((byte)matchCount);
            writeC(13);
            writeC((byte)Math.Ceiling(matchCount / 13d));
        }
    }
}