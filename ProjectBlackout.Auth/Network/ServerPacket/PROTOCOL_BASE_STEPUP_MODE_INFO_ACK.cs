using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_STEPUP_MODE_INFO_ACK : SendPacket
    {
        public PROTOCOL_BASE_STEPUP_MODE_INFO_ACK()
        {

        }

        public override void write()
        {
            writeH(692);
            writeD(0);
        }
    }
}
