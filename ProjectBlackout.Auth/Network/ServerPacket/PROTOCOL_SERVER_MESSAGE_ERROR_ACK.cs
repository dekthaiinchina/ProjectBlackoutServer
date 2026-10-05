using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_SERVER_MESSAGE_ERROR_ACK : SendPacket
    {
        private uint _er;

        public PROTOCOL_SERVER_MESSAGE_ERROR_ACK(uint er)
        {
            _er = er;
        }

        public override void write()
        {
            writeH(2566);
            writeD(_er);
            /*
             * 0x800010AD STBL_IDX_EP_GAME_EXIT_HACKUSER
             * 0x800010AE STBL_IDX_EP_GAMEGUARD_ERROR (Ocorreu um problema no HackShield)
             * 0x800010AF STBL_IDX_EP_GAME_EXIT_ASSERT_E
             * 0x800010B0 STBL_IDX_EP_GAME_EXIT_ASSERT_E
             */
        }
    }
}