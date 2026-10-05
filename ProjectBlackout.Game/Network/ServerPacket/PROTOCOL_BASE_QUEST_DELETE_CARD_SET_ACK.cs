using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_QUEST_DELETE_CARD_SET_ACK : SendPacket
    {
        private uint erro;
        private Account p;

        public PROTOCOL_BASE_QUEST_DELETE_CARD_SET_ACK(uint erro, Account player)
        {
            this.erro = erro;
            this.p = player;
        }

        public override void write()
        {
            writeH(575);
            writeD(erro);
            if (erro == 0)
            {
                writeC((byte)p._mission.actualMission);
                writeC((byte)p._mission.card1);
                writeC((byte)p._mission.card2);
                writeC((byte)p._mission.card3);
                writeC((byte)p._mission.card4);
                writeB(ComDiv.getCardFlags(p._mission.mission1, p._mission.list1));
                writeB(ComDiv.getCardFlags(p._mission.mission2, p._mission.list2));
                writeB(ComDiv.getCardFlags(p._mission.mission3, p._mission.list3));
                writeB(ComDiv.getCardFlags(p._mission.mission4, p._mission.list4));
                writeC((byte)p._mission.mission1);
                writeC((byte)p._mission.mission2);
                writeC((byte)p._mission.mission3);
                writeC((byte)p._mission.mission4);
            }
        }
    }
}