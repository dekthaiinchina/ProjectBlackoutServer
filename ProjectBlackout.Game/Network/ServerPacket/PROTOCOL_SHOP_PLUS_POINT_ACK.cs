using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_SHOP_PLUS_POINT_ACK : SendPacket
    {
        private int gp, _gpIncrease, type;

        public PROTOCOL_SHOP_PLUS_POINT_ACK(int increase, int gold, int type)
        {
            _gpIncrease = increase;
            gp = gold;
            this.type = type;
        }

        public override void write()
        {
            writeH(1072);
            writeH(0);
            writeC((byte)type);
            writeD(gp);
            writeD(_gpIncrease);
        }
    }
}