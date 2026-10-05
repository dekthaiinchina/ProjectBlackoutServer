using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;

using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Model;
using System;

namespace ProjectBlackout.Game.Data.Sync.Client
{
    public static class RoomC4
    {
        public static void Load(ReceiveGPacket p)
        {
            int roomId = p.readH();
            int channelId = p.readH();
            int type = p.readC();
            int slotIdx = p.readC();
            int areaId = 0;
            float x = 0, y = 0, z = 0;
            if (type == 0)
            {
                areaId = p.readC();
                x = p.readT();
                y = p.readT();
                z = p.readT();
                if (p.getBuffer().Length > 21)
                {
                    Logger.warning("Invalid Bomb: " + BitConverter.ToString(p.getBuffer()));
                }
            }
            else if (type == 1)
            {
                if (p.getBuffer().Length > 8)
                {
                    Logger.warning("Invalid Bomb Type[1]: " + BitConverter.ToString(p.getBuffer()));
                }
            }
            Channel ch = ChannelsXml.getChannel(channelId);
            if (ch == null)
            {
                return;
            }
            Room room = ch.getRoom(roomId);
            if (room != null && room.round.Timer == null && room.RoomState == RoomState.Battle)
            {
                Slot slot = room.getSlot(slotIdx);
                if (slot == null || slot.state != SlotState.BATTLE)
                {
                    return;
                }
                if (type == 0)
                {
                    InstallBomb(room, slot, areaId, x, y, z);
                }
                else if (type == 1)
                {
                    UninstallBomb(room, slot);
                }
            }
        }

        public static void InstallBomb(Room room, Slot slot, int areaId, float x, float y, float z)
        {
            if (room.C4_actived)
            {
                return;
            }
            using (PROTOCOL_BATTLE_MISSION_BOMB_INSTALL_ACK packet = new PROTOCOL_BATTLE_MISSION_BOMB_INSTALL_ACK(slot._id, (byte)areaId, x, y, z))
            {
                room.SendPacketToPlayers(packet, SlotState.BATTLE, 0);
            }
            if (room.RoomType != RoomType.Tutorial)
            {
                room.C4_actived = true;
                slot.objects++;
                AllUtils.CompleteMission(room, slot, MissionType.C4_PLANT, 0);
                room.StartBomb();
            }
            else
            {
                room.C4_actived = true;
            }
        }

        public static void UninstallBomb(Room room, Slot slot)
        {
            if (!room.C4_actived)
            {
                return;
            }
            using (PROTOCOL_BATTLE_MISSION_BOMB_UNINSTALL_ACK packet = new PROTOCOL_BATTLE_MISSION_BOMB_UNINSTALL_ACK(slot._id))
            {
                room.SendPacketToPlayers(packet, SlotState.BATTLE, 0);
            }
            if (room.RoomType != RoomType.Tutorial)
            {
                slot.objects++;
                room.blue_rounds++;
                AllUtils.CompleteMission(room, slot, MissionType.C4_DEFUSE, 0);
                AllUtils.BattleEndRound(room, 1, RoundEndType.Uninstall);
            }
            else
            {
                room.C4_actived = false;
            }
        }
    }
}