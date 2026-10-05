using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_SHOP_TAG_INFO_ACK : SendPacket
    {
        public PROTOCOL_SHOP_TAG_INFO_ACK()
        {

        }

        public override void write()
        {
            writeH(1095);
            writeH(0);
            writeC(7);
            writeC(5);
            writeH(0);
            writeC(0);
            writeD(0);
            writeH(0);
            writeC(3);
            writeQ(0);
            writeC(0);
            writeC(4);
            writeQ(0);
            writeC(0);
            writeC(2);
            writeQ(0);
            writeC(0);
            writeC(6);
            writeQ(0);
            writeC(0);
            writeC(1);
            writeQ(0);
            writeD(0);
            writeC(0);
            writeC(255);
            writeC(255);
            writeC(255);
            writeC(0);
            writeC(255);
            writeC(1);
            writeC(7);
            writeC(2);
        }
    }
}