using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_MISSION_TOUCHDOWN_ACK : SendPacket
    {
        private Room r;
        private Slot slot;

        public PROTOCOL_BATTLE_MISSION_TOUCHDOWN_ACK(Room room, Slot slot)
        {
            r = room;
            this.slot = slot;
        }

        public override void write()
        {
            writeH(4155);
            writeH((ushort)r.red_dino);
            writeH((ushort)r.blue_dino);
            writeD(slot._id);
            writeH((short)slot.passSequence);
        }
    }
}