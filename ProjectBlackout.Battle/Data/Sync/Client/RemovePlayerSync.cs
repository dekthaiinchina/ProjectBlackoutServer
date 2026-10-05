using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Network;

namespace ProjectBlackout.Battle.Data.Sync.Client
{
    public static class RemovePlayerSync
    {
        public static void Load(ReceivePacket p)
        {
            uint UniqueRoomId = p.readUD();
            uint Seed = p.readUD();
            int slotId = p.readC();
            int inBattleCount = p.readC();

            Room room = RoomsManager.getRoom(UniqueRoomId, Seed);
            if (room == null)
            {
                return;
            }

            if (inBattleCount == 0)
            {
                RoomsManager.RemoveRoom(UniqueRoomId);
            }
            else
            {
                Player player = room.getPlayer(slotId, false);
                if (player != null)
                {
                    player.ResetAllInfos();
                }
            }
        }
    }
}