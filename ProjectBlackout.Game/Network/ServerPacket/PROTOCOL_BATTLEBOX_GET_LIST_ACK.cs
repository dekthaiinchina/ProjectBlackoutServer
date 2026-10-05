using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLEBOX_GET_LIST_ACK : SendPacket
    {
        public PROTOCOL_BATTLEBOX_GET_LIST_ACK()
        {

        }

        public override void write()
        {
            writeH(7426);
            writeD(1);
            writeD(1);
            writeD(0);
            writeD(2800001);
            writeH(0);
            writeC(0);
            writeD(585);
        }
    }
}
