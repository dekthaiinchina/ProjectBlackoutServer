using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_USER_LEAVE_ACK : SendPacket
    {
        private int error;

        public PROTOCOL_BASE_USER_LEAVE_ACK(int error)
        {
            this.error = error;
        }

        public override void write()
        {
            writeH(537);
            writeD(error);
            //error < 0 = STBL_IDX_EP_SERVER_FAIL_MOVE
        }
    }
}