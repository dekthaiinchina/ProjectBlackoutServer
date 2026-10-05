using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CHANGE_CLAN_EXP_RANK_ACK : SendPacket
    {
        private int Exp;

        public PROTOCOL_CS_CHANGE_CLAN_EXP_RANK_ACK(int Exp)
        {
            this.Exp = Exp;
        }

        public override void write()
        {
            writeH(1904);
            writeC((byte)Exp);
        }
    }
}
