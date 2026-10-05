using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_CHANGE_DIFFICULTY_LEVEL_ACK : SendPacket
    {
        private Room room;

        public PROTOCOL_BATTLE_CHANGE_DIFFICULTY_LEVEL_ACK(Room room)
        {
            this.room = room;
        }

        public override void write()
        {
            writeH(4149);
            writeC(room.IngameAiLevel);
            for (int i = 0; i < 16; i++)
            {
                writeD(room._slots[i].aiLevel);
            }
        }
    }
}