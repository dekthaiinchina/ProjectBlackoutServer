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
    public static class RoomPassPortal
    {
        public static void Load(ReceiveGPacket p)
        {
            int roomId = p.readH();
            int channelId = p.readH();
            int slotId = p.readC(); //player
            int portalId = p.readC(); //portal
            Channel ch = ChannelsXml.getChannel(channelId);
            if (ch == null)
            {
                return;
            }
            Room room = ch.getRoom(roomId);
            if (room != null && room.round.Timer == null && room.RoomState == RoomState.Battle && room.RoomType == RoomType.Boss)
            {
                Slot slot = room.getSlot(slotId);
                if (slot != null && slot.state == SlotState.BATTLE)
                {
                    ++slot.passSequence;
                    if (slot._team == 0)
                    {
                        room.red_dino += 5;
                    }
                    else
                    {
                        room.blue_dino += 5;
                    }
                    CompleteMission(room, slot);
                    using (PROTOCOL_BATTLE_MISSION_TOUCHDOWN_ACK packet = new PROTOCOL_BATTLE_MISSION_TOUCHDOWN_ACK(room, slot))
                    {
                        using (PROTOCOL_BATTLE_MISSION_TOUCHDOWN_COUNT_ACK packet2 = new PROTOCOL_BATTLE_MISSION_TOUCHDOWN_COUNT_ACK(room))
                        {
                            room.SendPacketToPlayers(packet, packet2, SlotState.BATTLE, 0);
                        }
                    }
                }
            }
            if (p.getBuffer().Length > 8)
            {
                Logger.warning("Invalid Portal: " + BitConverter.ToString(p.getBuffer()));
            }
        }

        private static void CompleteMission(Room room, Slot slot)
        {
            MissionType mission = MissionType.NA;
            if (slot.passSequence == 1)
            {
                mission = MissionType.TOUCHDOWN;
            }
            else if (slot.passSequence == 2)
            {
                mission = MissionType.TOUCHDOWN_ACE_ATTACKER;
            }
            else if (slot.passSequence == 3)
            {
                mission = MissionType.TOUCHDOWN_HATTRICK;
            }
            else if (slot.passSequence >= 4)
            {
                mission = MissionType.TOUCHDOWN_GAME_MAKER;
            }
            if (mission != MissionType.NA)
            {
                AllUtils.CompleteMission(room, slot, mission, 0);
            }
        }
    }
}