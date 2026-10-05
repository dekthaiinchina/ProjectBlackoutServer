using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_VOTE_KICKVOTE_ACK : SendPacket
    {
        private uint erro;

        public PROTOCOL_BATTLE_VOTE_KICKVOTE_ACK(uint erro)
        {
            this.erro = erro;
        }

        public override void write()
        {
            writeH(3401);
            writeD(erro);
        }
    }
}