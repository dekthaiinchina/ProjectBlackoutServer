using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CANCEL_REQUEST_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_CS_CANCEL_REQUEST_ACK(uint error)
        {
            _erro = error;
        }

        public override void write()
        {
            writeH(1839);
            writeD(_erro);
        }
    }
}