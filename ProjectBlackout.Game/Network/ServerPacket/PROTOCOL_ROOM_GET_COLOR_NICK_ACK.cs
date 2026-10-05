using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_GET_COLOR_NICK_ACK : SendPacket
    {
        private int Slot, Color;

        public PROTOCOL_ROOM_GET_COLOR_NICK_ACK(int Slot, int Color)
        {
            this.Slot = Slot;
            this.Color = Color;
        }

        public override void write()
        {
            writeH(3892);
            writeD(Slot);
            writeC((byte)Color);
        }
    }
}
