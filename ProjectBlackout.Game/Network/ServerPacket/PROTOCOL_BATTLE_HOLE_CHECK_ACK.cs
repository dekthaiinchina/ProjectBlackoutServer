using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_HOLE_CHECK_ACK : SendPacket
    {
        public PROTOCOL_BATTLE_HOLE_CHECK_ACK()
        {

        }

        public override void write()
        {
            writeH(4098);
            writeD(0);
        }
    }
}