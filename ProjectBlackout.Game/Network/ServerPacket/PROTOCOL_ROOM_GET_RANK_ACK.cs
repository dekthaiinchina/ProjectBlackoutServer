using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_GET_RANK_ACK : SendPacket
    {
        private int Slot, Rank;

        public PROTOCOL_ROOM_GET_RANK_ACK(int Slot, int Rank)
        {
            this.Slot = Slot;
            this.Rank = Rank;
        }

        public override void write()
        {
            writeH(3890);
            writeD(Slot);
            writeD(Rank);
        }
    }
}
