using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_MEMBER_CONTEXT_ACK : SendPacket
    {
        private int erro, playersCount;

        public PROTOCOL_CS_MEMBER_CONTEXT_ACK(int erro, int playersCount)
        {
            this.erro = erro;
            this.playersCount = playersCount;
        }

        public PROTOCOL_CS_MEMBER_CONTEXT_ACK(int erro)
        {
            this.erro = erro;
        }

        public override void write()
        {
            writeH(1827);
            writeD(erro);
            if (erro == 0)
            {
                writeC((byte)playersCount);
                writeC(14);
                writeC((byte)Math.Ceiling(playersCount / 14d));
                writeD(uint.Parse(DateTime.Now.ToString("MMddHHmmss")));
            }
        }
    }
}