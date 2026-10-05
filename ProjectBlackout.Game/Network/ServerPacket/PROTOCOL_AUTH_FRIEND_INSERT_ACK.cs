using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_FRIEND_INSERT_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_AUTH_FRIEND_INSERT_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(795);
            writeD(_erro);
            /*
             * 0x80001038 STR_TBL_GUI_BASE_FAIL_REQUEST_FRIEND_BY_LIMIT
             * 0x80001038 STR_TBL_GUI_BASE_NO_MORE_GET_FRIEND_STATE
             * 0x80001041 STR_TBL_GUI_BASE_ALREADY_REGIST_FRIEND_LIST
             * 
             */
        }
    }
}