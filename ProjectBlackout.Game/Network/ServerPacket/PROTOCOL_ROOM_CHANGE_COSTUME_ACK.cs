using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_CHANGE_COSTUME_ACK : SendPacket
    {
        private Slot Slot;

        public PROTOCOL_ROOM_CHANGE_COSTUME_ACK(Slot Slot)
        {
            this.Slot = Slot;
        }

        public override void write()
        {
            writeH(3932);
            writeD(Slot._id);
            writeC((byte)Slot.Costume);
        }
    }
}
