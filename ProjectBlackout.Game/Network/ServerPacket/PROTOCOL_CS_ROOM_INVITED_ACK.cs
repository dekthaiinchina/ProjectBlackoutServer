using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_ROOM_INVITED_ACK : SendPacket
    {
        private int Error;

        public PROTOCOL_CS_ROOM_INVITED_ACK(int Error)
        {
            this.Error = Error;
        }

        public override void write()
        {
            writeH(1902);
            writeD(Error);
        }
    }
}
