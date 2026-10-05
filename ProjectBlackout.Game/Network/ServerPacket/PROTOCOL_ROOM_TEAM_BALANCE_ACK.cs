using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_TEAM_BALANCE_ACK : SendPacket
    {
        private int _type, _leader;
        private List<SlotChange> _slots;

        public PROTOCOL_ROOM_TEAM_BALANCE_ACK(List<SlotChange> slots, int leader, int type)
        {
            _slots = slots;
            _leader = leader;
            _type = type;
        }

        public override void write()
        {
            writeH(3886);
            writeC((byte)_type);
            writeC((byte)_leader);
            writeC((byte)_slots.Count);
            for (int i = 0; i < _slots.Count; i++)
            {
                SlotChange slot = _slots[i];
                writeC((byte)slot.oldSlot._id);
                writeC((byte)slot.newSlot._id);
                writeC((byte)slot.oldSlot.state);
                writeC((byte)slot.newSlot.state);
            }
        }
    }
}