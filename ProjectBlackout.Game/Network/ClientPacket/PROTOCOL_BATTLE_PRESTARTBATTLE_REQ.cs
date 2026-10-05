using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_PRESTARTBATTLE_REQ : ReceivePacket
    {
        private int stage, rule;
        private MapIdEnum mapId;
        private RoomType room_type;

        public PROTOCOL_BATTLE_PRESTARTBATTLE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            mapId = (MapIdEnum)readC();
            rule = readC();
            stage = readC();
            room_type = (RoomType)readC();
        }

        public override void run()
        {
            try
            {
                if (_client == null)
                {
                    Console.WriteLine("Client null");
                    return;
                }
                Account p = _client._player;
                Room room = p == null ? null : p._room;
                if (room != null && (room.stage == stage && room.RoomType == room_type && room.mapId == mapId && room.rule == rule))
                {
                    Slot slot = room._slots[p._slotId];
                    if (room.isPreparing() && room.UdpServer != null && (int)slot.state >= 10)
                    {
                        Account leader = room.getLeader();
                        if (leader != null)
                        {
                            if (string.IsNullOrEmpty(p.PublicIP.ToString()))
                            {
                                Console.WriteLine("IsNullOrEmptyl");
                                _client.SendPacket(new PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK(EventErrorEnum.BATTLE_NO_REAL_IP));
                                _client.SendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(p, 0));
                                room.changeSlotState(slot, SlotState.NORMAL, true);
                                AllUtils.BattleEndPlayersCount(room, room.isBotMode());
                                slot.StopTiming();
                                return;
                            }
                            if (slot._id == room._leader)
                            {
                                Console.WriteLine("PreBattle");
                                room.RoomState = RoomState.PreBattle;
                                room.updateRoomInfo();
                            }
                            slot.preStartDate = DateTime.Now;
                            room.StartCounter(1, p, slot);
                            room.changeSlotState(slot, SlotState.PRESTART, true);
                            _client.SendPacket(new PROTOCOL_BATTLE_PRESTARTBATTLE_ACK(p, leader, true));
                            if (slot._id != room._leader)
                            {
                                Console.WriteLine("0x1");
                                leader.SendPacket(new PROTOCOL_BATTLE_PRESTARTBATTLE_ACK(p, leader, false));
                            }
                            slot.state = SlotState.BATTLE;
                            room.updateSlotsInfo();
                        }
                        else
                        {
                            Console.WriteLine("0x2");
                            _client.SendPacket(new PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK(EventErrorEnum.BATTLE_FIRST_HOLE));
                            _client.SendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(p, 0));
                            room.changeSlotState(slot, SlotState.NORMAL, true);
                            AllUtils.BattleEndPlayersCount(room, room.isBotMode());
                            slot.StopTiming();
                        }
                    }
                    else
                    {
                        Console.WriteLine("0x3");
                        room.changeSlotState(slot, SlotState.NORMAL, true);
                        _client.SendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK());
                        AllUtils.BattleEndPlayersCount(room, room.isBotMode());
                        slot.StopTiming();
                    }
                }
                else
                {
                    Console.WriteLine("0x4");
                    _client.SendPacket(new PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK(EventErrorEnum.BATTLE_FIRST_MAINLOAD));
                    _client.SendPacket(new PROTOCOL_BATTLE_PRESTARTBATTLE_ACK());
                    if (room != null)
                    {
                        Console.WriteLine("0x5");
                        room.changeSlotState(p._slotId, SlotState.NORMAL, true);
                        AllUtils.BattleEndPlayersCount(room, room.isBotMode());
                    }
                    else
                    {
                        Console.WriteLine("0x6");
                        _client.SendPacket(new PROTOCOL_LOBBY_ENTER_ACK());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_BATTLE_PRESTARTBATTLE_REQ: " + ex.ToString());
            }
        }
    }
}