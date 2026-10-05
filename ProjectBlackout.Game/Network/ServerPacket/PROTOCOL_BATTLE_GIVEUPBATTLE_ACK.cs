using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_GIVEUPBATTLE_ACK : SendPacket
    {
        private Account p;
        private int type;

        public PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(Account p, int type)
        {
            this.p = p;
            this.type = type;
        }

        public override void write()
        {
            if (p == null)
            {
                return;
            }
            writeH(4110);
            writeD(p._slotId);
            writeC((byte)type);
            writeD(p._exp);
            writeD(p._rank);
            writeD(p._gp);
            writeD(p._statistic.escapes);
            writeD(p._statistic.escapes);
            writeD(0);
            writeC(0);
        }
    }
}