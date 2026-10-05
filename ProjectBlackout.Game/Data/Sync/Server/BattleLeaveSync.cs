using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Sync.Server
{
    public class BattleLeaveSync
    {
        public static void SendUDPPlayerLeave(Room room, int slotId)
        {
            try
            {
                if (room == null)
                {
                    return;
                }
                int count = room.getPlayingPlayers(2, SlotState.BATTLE, 0, slotId);
                using (SendGPacket pk = new SendGPacket())
                {
                    pk.writeH(2);
                    pk.writeD(room.UniqueRoomId);
                    pk.writeD(room.Seed);
                    pk.writeC((byte)slotId);
                    pk.writeC((byte)count);
                    GameSync.SendPacket(pk.mstream.ToArray(), room.UdpServer.Connection);
                }
            }
            catch
            {

            }
        }
    }
}