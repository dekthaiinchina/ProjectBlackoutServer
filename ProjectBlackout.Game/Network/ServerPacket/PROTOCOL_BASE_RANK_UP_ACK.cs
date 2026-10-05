using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_RANK_UP_ACK : SendPacket
    {
        private int _rank, _allExp;

        public PROTOCOL_BASE_RANK_UP_ACK(int rank, int allExp)
        {
            _rank = rank;
            _allExp = allExp;
        }

        public override void write()
        {
            writeH(551);
            writeD(_rank);
            writeD(_rank);
            writeD(_allExp); //EXP
        }
    }
}