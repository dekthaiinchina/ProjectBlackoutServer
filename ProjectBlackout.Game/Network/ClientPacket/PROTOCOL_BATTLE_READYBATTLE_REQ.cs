using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Map;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_READYBATTLE_REQ : ReceivePacket
    {
        private int Error;

        public PROTOCOL_BATTLE_READYBATTLE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            readC();
            Error = readD(); // 0 - NORMAL || 1 - OBSERVER (GM)
        }

        public override void run()
        {
            try
            {
                Account player = _client._player;
                if (player == null)
                {
                    return;
                }
                Room room = player._room;
                Channel ch;
                Slot slot;
                if (room == null || room.getLeader() == null || !room.getChannel(out ch) || !room.getSlot(player._slotId, out slot))
                {
                    return;
                }
                if (slot._equip == null)
                { 
                    _client.SendPacket(new PROTOCOL_BATTLE_READYBATTLE_ACK(0x800010AB)); //STBL_IDX_EP_ROOM_ERROR_READY_WEAPON_EQUIP
                    return;
                }
                bool isBotMode = room.isBotMode();
                if (Error == 1 && player.IsGM())
                {
                    slot.specGM = true;
                }
                else
                {
                    slot.specGM = false;
                }
                player.DebugPing = false;
                if (room._leader == player._slotId)
                {
                    if (room.RoomState != RoomState.Ready && room.RoomState != RoomState.CountDown)
                    {
                        return;
                    }
                    int TotalEnemys = 0, redPlayers = 0, bluePlayers = 0;
                    GetReadyPlayers(room, ref redPlayers, ref bluePlayers, ref TotalEnemys);
                    if (GameConfig.isTestMode && GameConfig.udpType == UdpState.RELAY)
                    {
                        TotalEnemys = 1;
                    }
                    int count = 0;
                    MapMatch Match = MapModel.Matchs.Find(x => x.Id == (int)room.mapId && MapModel.getRule(x.Mode).Rule == room.rule);
                    if (Match != null)
                    {
                        count = Match.Limit;
                    }
                    if (count == 8 && (redPlayers >= 4 || bluePlayers >= 4) && ch._type != 4)
                    {
                        _client.SendPacket(new PROTOCOL_ROOM_UNREADY_4VS4_ACK());
                        return;
                    }
                    if (ClanMatchCheck(room, ch._type, TotalEnemys))
                    {
                        return;
                    }
                    if (isBotMode || room.RoomType == RoomType.Tutorial || TotalEnemys > 0 && !isBotMode)
                    {
                        room.changeSlotState(slot, SlotState.READY, false);
                        if (room.RoomState != RoomState.CountDown)
                        {
                            TryBalanceTeams(room, isBotMode);
                        }
                        if (room.thisModeHaveCD())
                        {
                            if (room.RoomState == RoomState.Ready)
                            {
                                room.RoomState = RoomState.CountDown;
                                room.updateRoomInfo();
                                room.StartCountDown();
                            }
                            else if (room.RoomState == RoomState.CountDown)
                            {
                                room.changeSlotState(room._leader, SlotState.NORMAL, false);
                                room.StopCountDown(CountDownEnum.StopByHost);
                            }
                        }
                        else
                        {
                            room.StartBattle(false);
                        }
                        room.updateSlotsInfo();
                    }
                    else if (TotalEnemys == 0 && !isBotMode)
                    {
                        _client.SendPacket(new PROTOCOL_BATTLE_READYBATTLE_ACK(0x80001009));
                    }
                }
                else if ((int)room._slots[room._leader].state >= 10)
                {
                    if (slot.state == SlotState.NORMAL)
                    {
                        if (room.BalanceType == 1 && !isBotMode)
                        {
                            AllUtils.TryBalancePlayer(room, player, true, ref slot);
                        }
                        room.changeSlotState(slot, SlotState.LOAD, true);
                        slot.SetMissionsClone(player._mission);
                        _client.SendPacket(new PROTOCOL_BATTLE_READYBATTLE_ACK((uint)slot.state));
                        _client.SendPacket(new PROTOCOL_BATTLE_START_GAME_ACK(room));
                        using (PROTOCOL_BATTLE_START_GAME_TRANS_ACK packet = new PROTOCOL_BATTLE_START_GAME_TRANS_ACK(room, slot, player._titles))
                        {
                            room.SendPacketToPlayers(packet, SlotState.READY, 1, slot._id);
                        }
                    }
                }
                else if ((int)slot.state == 8)
                {
                    room.changeSlotState(slot, SlotState.NORMAL, true); //READY
                    if (room.RoomState == RoomState.CountDown)
                    {
                        TryBalanceTeams(room, isBotMode);
                    }
                }
                else if ((int)slot.state == 9)
                {
                    room.changeSlotState(slot, SlotState.READY, false); //NORMAL
                    if (room.RoomState == RoomState.CountDown && room.getPlayingPlayers(room._leader % 2 == 0 ? 1 : 0, SlotState.READY, 0) == 0)
                    {
                        room.changeSlotState(room._leader, SlotState.READY, false);
                        room.StopCountDown(CountDownEnum.StopByPlayer);
                    }
                    room.updateSlotsInfo();
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_BATTLE_READYBATTLE_REQ: " + ex.ToString());
            }
        }

        private void GetReadyPlayers(Room room, ref int redPlayers, ref int bluePlayers, ref int TotalEnemys)
        {
            for (int i = 0; i < 16; i++)
            {
                Slot slot = room._slots[i];
                if ((int)slot.state == 9)
                {
                    if (slot._team == 0)
                    {
                        redPlayers++;
                    }
                    else
                    {
                        bluePlayers++;
                    }
                }
            }
            if (room._leader % 2 == 0)
            {
                TotalEnemys = bluePlayers;
            }
            else
            {
                TotalEnemys = redPlayers;
            }
        }

        private bool ClanMatchCheck(Room room, int type, int TotalEnemys)
        {
            if (GameConfig.isTestMode || type != 4)
            {
                return false;
            }

            if (!AllUtils.Have2ClansToClanMatch(room))
            {
                _client.SendPacket(new PROTOCOL_BATTLE_READYBATTLE_ACK(0x80001071)); //STBL_IDX_EP_ROOM_NO_START_FOR_NO_CLAN_TEAM
                return true;
            }

            if (TotalEnemys > 0 && !AllUtils.HavePlayersToClanMatch(room))
            {
                _client.SendPacket(new PROTOCOL_BATTLE_READYBATTLE_ACK(0x80001072)); //STBL_IDX_EP_ROOM_NO_START_FOR_TEAM_NOTFULL
                return true;
            }
            return false;
        }

        private void TryBalanceTeams(Room room, bool isBotMode)
        {
            if (room.BalanceType != 1 || isBotMode)
            {
                return;
            }
            int TeamIdx = AllUtils.getBalanceTeamIdx(room, false, -1);
            if (TeamIdx == -1)
            {
                return;
            }
            int[] teamArray = TeamIdx == 1 ? room.RED_TEAM : room.BLUE_TEAM;
            Slot LastSlot = null;
            for (int i = teamArray.Length - 1; i >= 0; i--)
            {
                Slot slot = room._slots[teamArray[i]];
                if ((int)slot.state == 9 && room._leader != slot._id)
                {
                    LastSlot = slot;
                    break;
                }
            }
            Account player;
            if (LastSlot != null && room.getPlayerBySlot(LastSlot, out player))
            {
                AllUtils.TryBalancePlayer(room, player, false, ref LastSlot);
            }
        }
    }
}