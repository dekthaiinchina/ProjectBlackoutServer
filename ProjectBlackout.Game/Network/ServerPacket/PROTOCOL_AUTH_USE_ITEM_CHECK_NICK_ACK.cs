using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(1062);
            writeD(_erro);
        }
    }
}