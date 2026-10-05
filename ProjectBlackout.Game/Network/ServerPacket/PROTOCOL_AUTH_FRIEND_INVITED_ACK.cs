using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_FRIEND_INVITED_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_AUTH_FRIEND_INVITED_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(788);
            writeD(_erro);
            /*
             * 2147495938 STR_TBL_NETWORK_FAIL_INVITED_USER
             * 2147495939 STR_TBL_NETWORK_FAIL_INVITED_USER_IN_CLAN_MATCH
             */
        }
    }
}