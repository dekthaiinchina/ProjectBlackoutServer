using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_INVENTORY_ENTER_ACK : SendPacket
    {
        public PROTOCOL_INVENTORY_ENTER_ACK()
        {

        }

        public override void write()
        {
            writeH(3330);
            writeD(int.Parse(DateTime.Now.AddYears(-10).ToString("yyMMddHHmm")));
        }
    }
}