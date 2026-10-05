using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CLIENT_LEAVE_ACK : SendPacket
    {
        public PROTOCOL_CS_CLIENT_LEAVE_ACK()
        {

        }

        public override void write()
        {
            writeH(1796);
            writeD(0);
        }
    }
}