using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Battle.Network
{
    public class RoomsManager
    {
        private static List<Room> list = new List<Room>();

        public static Room CreateOrGetRoom(uint UniqueRoomId, uint Seed)
        {
            lock (list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Room room = list[i];
                    if (room.UniqueRoomId == UniqueRoomId)
                    {
                        return room;
                    }
                }
                int serverId = AllUtils.GetRoomInfo(UniqueRoomId, 2), channelId = AllUtils.GetRoomInfo(UniqueRoomId, 1), roomId = AllUtils.GetRoomInfo(UniqueRoomId, 0);
                Room roomNew = new Room(serverId)
                {
                    UniqueRoomId = UniqueRoomId,
                    Seed = Seed,
                    RoomId = roomId,
                    ChannelId = channelId,
                    MapId = (MAP_STATE_ID)AllUtils.GetSeedInfo(Seed, 2),
                    RoomType = (ROOM_STATE_TYPE)AllUtils.GetSeedInfo(Seed, 0),
                    Rule = AllUtils.GetSeedInfo(Seed, 1)
                };
                list.Add(roomNew);
                return roomNew;
            }
        }

        public static Room getRoom(uint UniqueRoomId)
        {
            lock (list)
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    Room r = list[i];
                    if (r != null && r.UniqueRoomId == UniqueRoomId)
                    {
                        return r;
                    }
                }
                return null;
            }
        }

        public static Room getRoom(uint UniqueRoomId, uint Seed)
        {
            lock (list)
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    Room r = list[i];
                    if (r != null && r.UniqueRoomId == UniqueRoomId && r.Seed == Seed)
                    {
                        return r;
                    }
                }
                return null;
            }
        }

        public static bool getRoom(uint UniqueRoomId, out Room room)
        {
            room = null;
            lock (list)
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    Room r = list[i];
                    if (r != null && r.UniqueRoomId == UniqueRoomId)
                    {
                        room = r;
                        return true;
                    }
                }
            }
            return false;
        }

        public static void RemoveRoom(uint UniqueRoomId)
        {
            try
            {
                lock (list)
                {
                    for (int i = 0; i < list.Count; ++i)
                    {
                        Room r = list[i];
                        if (r.UniqueRoomId == UniqueRoomId)
                        {
                            list.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
        }
    }
}