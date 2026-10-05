using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_QUEST_CHANGE_ACK : SendPacket
    {
        private int missionId, value;

        public PROTOCOL_BASE_QUEST_CHANGE_ACK(int progress, Card card)
        {
            missionId = card._missionBasicId;
            if (card._missionLimit == progress)
            {
                missionId += 240;
            }
            value = progress;
        }

        public override void write()
        {
            writeH(567);
            writeC((byte)missionId);
            writeC((byte)value);
        }
    }
}