using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CHECK_MARK_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_CS_CHECK_MARK_ACK(uint er)
        {
            _erro = er;
        }

        public override void write()
        {
            writeH(1881);
            writeD(_erro);
        }
    }
}