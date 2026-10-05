using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CHECK_JOIN_AUTHORITY_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_CS_CHECK_JOIN_AUTHORITY_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(1835);
            writeD(_erro);
        }
    }
}