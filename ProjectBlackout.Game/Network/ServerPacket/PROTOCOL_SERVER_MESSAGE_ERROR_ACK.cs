using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_SERVER_MESSAGE_ERROR_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_SERVER_MESSAGE_ERROR_ACK(uint err)
        {
            _erro = err;
        }

        public override void write()
        {
            writeH(2566);
            writeD(uint.Parse(DateTime.Now.ToString("MMddHHmmss")));
            writeD(_erro);
            /*
             * 0x800010AD STBL_IDX_EP_GAME_EXIT_HACKUSER
             * 0x800010AE STBL_IDX_EP_GAMEGUARD_ERROR (Ocorreu um problema no HackShield)
             * 0x800010AF STBL_IDX_EP_GAME_EXIT_ASSERT_E
             * 0x800010B0 STBL_IDX_EP_GAME_EXIT_ASSERT_E
             */
        }
    }
}