using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_REPLACE_MARKEFFECT_RESULT_ACK : SendPacket
    {
        private int Effect;

        public PROTOCOL_CS_REPLACE_MARKEFFECT_RESULT_ACK(int Effect)
        {
            this.Effect = Effect;
        }

        public override void write()
        {
            writeH(1994);
            writeC((byte)Effect);
        }
    }
}
