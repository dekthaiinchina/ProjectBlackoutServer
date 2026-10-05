using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_NOTIFY_KICKVOTE_RESULT_ACK : SendPacket
    {
        private VoteKick vote;
        private uint erro;

        public PROTOCOL_BATTLE_NOTIFY_KICKVOTE_RESULT_ACK(uint erro, VoteKick vote)
        {
            this.erro = erro;
            this.vote = vote;
        }

        public override void write()
        {
            writeH(3403);
            writeC((byte)vote.victimIdx);
            writeC((byte)vote.kikar);
            writeC((byte)vote.deixar);
            writeD(erro);
            //[2147488000] - cancelou a votação
            //[2147488001] - Sem votos aliados
            //[2147488002] - Sem votos adversários
            //[2147488003] - Patente não pode abrir
            //
        }
    }
}