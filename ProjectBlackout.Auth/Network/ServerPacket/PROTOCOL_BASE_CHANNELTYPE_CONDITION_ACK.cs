using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_CHANNELTYPE_CONDITION_ACK : SendPacket
    {
        public PROTOCOL_BASE_CHANNELTYPE_CONDITION_ACK()
        {

        }

        public override void write()
        {
            writeH(694); //693
            writeB(new byte[888]);
        }

        /*public override void write()
        {
            writeH(692); //692
            writeB(new byte[888]); //888
        }*/
    }
}
