using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_ACK : SendPacket
    {
        private Account p;
        private uint erro;
        private int type;

        public PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_ACK(uint erro, int type, Account p)
        {
            this.erro = erro;
            this.type = type;
            this.p = p;
        }

        public override void write()
        {
            writeH(569);
            writeD(erro); 
            writeC((byte)type);
            if ((erro & 1) == 1)
            {
                writeD(p._exp);
                writeD(p._gp);
                writeD(p.brooch);
                writeD(p.insignia);
                writeD(p.medal);
                writeD(p.blue_order);
                writeD(p._rank);
            }
        }
    }
}