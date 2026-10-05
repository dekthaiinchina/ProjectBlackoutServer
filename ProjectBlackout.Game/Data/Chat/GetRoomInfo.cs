using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class GetRoomInfo
    {
        public static string GetSlotStats(string str, Account player, Room room)
        {
            int slotIdx = (int.Parse(str.Substring(5)) - 1);
            string infos = "Infomation:";
            if (room != null)
            {
                Slot slot = room.getSlot(slotIdx);
                if (slot != null)
                {
                    infos += "\nIndex: " + slot._id;
                    infos += "\nTeam: " + slot._team;
                    infos += "\nFlag: " + slot.Flag;
                    infos += "\nAccountId: " + slot._playerId;
                    infos += "\nState: " + slot.state;
                    infos += "\nMissions: " + ((slot.Missions != null) ? "Valid" : "Null");
                    player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(infos));
                    return "Successfully generated slot logs. [Server]";
                }
                else
                {
                    return "Slot invalid. [Server]";
                }
            }
            else
            {
                return "Sala invalid. [Server]";
            }
        }
    }
}