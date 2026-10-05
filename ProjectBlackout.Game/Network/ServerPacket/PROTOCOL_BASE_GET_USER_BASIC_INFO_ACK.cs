using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_GET_USER_BASIC_INFO_ACK : SendPacket
    {
        private uint Error;

        public PROTOCOL_BASE_GET_USER_BASIC_INFO_ACK(uint Error)
        {
            this.Error = Error;
        }

        public override void write()
        {
            writeD(Error);
        }
    }
}
