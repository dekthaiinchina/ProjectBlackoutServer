using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_SHOP_GET_SAILLIST_ACK : SendPacket
    {
        private bool Enable;

        public PROTOCOL_SHOP_GET_SAILLIST_ACK(bool Enable)
        {
            this.Enable = Enable;
        }

        public override void write()
        {
            writeH(1030);
            writeC((byte)(Enable ? 1 : 0));
            writeD(uint.Parse(DateTime.Now.ToString("yyMMddHHmm")));
        }
    }
}