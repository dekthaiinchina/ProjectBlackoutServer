using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_REQUEST_LIST_ACK : SendPacket
    {
        private int erro, page, count;
        private byte[] array;

        public PROTOCOL_CS_REQUEST_LIST_ACK(int erro, int count, int page, byte[] array)
        {
            this.erro = erro;
            this.count = count;
            this.page = page;
            this.array = array;
        }

        public PROTOCOL_CS_REQUEST_LIST_ACK(int erro)
        {
            this.erro = erro;
        }

        public override void write()
        {
            writeH(1843);
            writeD(erro);
            if (erro >= 0)
            {
                writeC((byte)page);
                writeC((byte)count);
                writeB(array);
            }
        }
    }
}