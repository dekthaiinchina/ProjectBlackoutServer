using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_NEW_JOIN_ROOM_SCORE_ACK : SendPacket
    {
        private Room room;

        public PROTOCOL_BATTLE_NEW_JOIN_ROOM_SCORE_ACK(Room room)
        {
            this.room = room;
        }

        public override void write()
        {
            int remaining = room.getInBattleTime();
            int Value = 0;
            if (room.isBotMode())
            {
                Value = 3;
            }
            else if (room.RoomType == RoomType.DeathMatch && !room.isBotMode())
            {
                Value = 1;
            }
            else if (room.RoomType == RoomType.Boss || room.RoomType == RoomType.CrossCounter)
            {
                Value = 4;
            }
            else if (room.RoomType == RoomType.FreeForAll)
            {
                Value = 5;
            }
            else
            {
                Value = 2;
            }
            writeH(4239);
            writeD(Value);
            writeD((room.getTimeByMask() * 60) - remaining);
            if (room.RoomType == RoomType.Boss)
            {
                writeD(room.red_dino);
                writeD(room.blue_dino);
            }
            else if (room.RoomType == RoomType.DeathMatch)
            {
                writeD(room._redKills);
                writeD(room._blueKills);
            }
            else if (room.RoomType == RoomType.FreeForAll)
            {
                writeD(GetSlotKill());
                writeD(0);
            }
            else if (room.isBotMode())
            {
                writeD(room.IngameAiLevel);
                writeD(0);
            }
            else
            {
                writeD(room.red_rounds);
                writeD(room.blue_rounds);
            }
        }

        public int GetSlotKill()
        {
            int[] Array = new int[16];
            for (int i = 0; i < Array.Length; i++)
            {
                Slot Slot = room.getSlot(i);
                Array[i] = Slot.allKills;
            }
            int KillMax = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] > Array[KillMax])
                {
                    KillMax = i;
                }
            }
            return KillMax;
        }
    }
}