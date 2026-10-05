using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_CHANGE_ROOMINFO_REQ : ReceivePacket
    {
        public PROTOCOL_ROOM_CHANGE_ROOMINFO_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            try
            {
                Account player = _client._player;
                Room room = player == null ? null : player._room;
                if (room == null || room.RoomState != RoomState.Ready || room._leader != player._slotId)
                {
                    return;
                }
                readD();
                room.name = readUnicode(46);
                room.mapId = (MapIdEnum)readC();
                room.rule = readC();
                room.stage = readC();
                room.RoomType = (RoomType)readC();
                readC(); //Room state
                readC();
                room.initSlotCount(readC(), true);
                room._ping = readC();
                RoomWeaponsFlag weaponsFlag = (RoomWeaponsFlag)readH();
                room.Flag = (RoomStageFlag)readD();
                readC();
                readC();
                readC();
                readB(4);
                readB(66);
                room.killtime = readD();
                room.Limit = readC();
                room.WatchRuleFlag = readC();
                room.BalanceType = readH();
                room.RandomMaps = readB(16);
                room.RoomLeaderIP = readB(4);
                room.KillCam = readC();
                room.aiCount = readC();
                room.aiLevel = readC();
                if (weaponsFlag != room.weaponsFlag)
                {
                    if (room.SniperMode)
                    {
                        room.weaponsFlag = weaponsFlag + 32;
                    }
                    if (room.ShotgunMode)
                    {
                        room.weaponsFlag = weaponsFlag + 64;
                    }
                    if (!room.ShotgunMode && !room.SniperMode)
                    {
                        room.weaponsFlag = weaponsFlag;
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        Slot slot = room._slots[i];
                        if ((int)slot.state == 9)
                        {
                            slot.state = SlotState.NORMAL;
                        }
                    }
                }
                room.SetSeed();
                room.updateRoomInfo();
                using (PROTOCOL_ROOM_CHANGE_ROOM_OPTIONINFO_ACK packet = new PROTOCOL_ROOM_CHANGE_ROOM_OPTIONINFO_ACK(room, room.getLeader().player_name))
                {
                    room.SendPacketToPlayers(packet);
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_BATTLE_CHANGE_ROOMINFO_REQ: " + ex.ToString());
            }
        }

        public override void run()
        {

        }
    }
}