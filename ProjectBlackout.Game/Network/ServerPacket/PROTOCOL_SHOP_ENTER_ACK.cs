using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_SHOP_ENTER_ACK : SendPacket
    {
        public PROTOCOL_SHOP_ENTER_ACK()
        {

        }

        public override void write()
        {
            writeH(1026);
            writeD(0);
            writeD(int.Parse(DateTime.Now.AddYears(-10).ToString("yyMMddHHmm")));
        }
    }
}