using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CHAR_CHANGE_EQUIP_ACK : SendPacket
    {
        private uint Error;

        public PROTOCOL_CHAR_CHANGE_EQUIP_ACK(uint Error)
        {
            this.Error = Error;
        }

        public override void write()
        {
            writeH(6150);
            writeH(0);
            writeD(Error);
        }
    }
}
