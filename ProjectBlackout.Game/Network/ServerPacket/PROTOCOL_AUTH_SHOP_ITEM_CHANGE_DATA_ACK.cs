using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_SHOP_ITEM_CHANGE_DATA_ACK : SendPacket
    {
        private uint Error;

        public PROTOCOL_AUTH_SHOP_ITEM_CHANGE_DATA_ACK(uint Error)
        {
            this.Error = Error;
        }

        public override void write()
        {
            writeH(1088);
            writeD(Error);
        }
    }
}
