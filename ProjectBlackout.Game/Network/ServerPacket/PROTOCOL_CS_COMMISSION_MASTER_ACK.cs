using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_COMMISSION_MASTER_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_CS_COMMISSION_MASTER_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(1858);
            writeD(_erro);
        }
    }
}