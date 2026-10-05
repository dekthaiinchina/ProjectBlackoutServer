using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_INFO_LEAVE_ACK : SendPacket
    {
        public PROTOCOL_ROOM_INFO_LEAVE_ACK()
        {

        }

        public override void write()
        {
            writeH(3928);
            writeD(0);
        }
    }
}