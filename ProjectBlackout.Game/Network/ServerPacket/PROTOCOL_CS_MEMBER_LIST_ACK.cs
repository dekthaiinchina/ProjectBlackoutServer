using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_MEMBER_LIST_ACK : SendPacket
    {
        private byte[] array;
        private int erro, page, count;

        public PROTOCOL_CS_MEMBER_LIST_ACK(int page, int count, byte[] array)
        {
            this.page = page;
            this.count = count;
            this.array = array;
        }

        public PROTOCOL_CS_MEMBER_LIST_ACK(int erro)
        {
            this.erro = erro;
        }

        public override void write()
        {
            writeH(1829);
            writeD(erro);
            if (erro < 0)
            {
                return;
            }
            writeC((byte)page);
            writeC((byte)count);
            writeB(array);
        }
    }
}