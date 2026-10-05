using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_GIVEUPBATTLE_REQ : ReceivePacket
    {
        private bool isFinished;
        private long objId;

        public PROTOCOL_BATTLE_GIVEUPBATTLE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            objId = readD(); //O bom perdedor (Unidade) - Se ele Usar o item retorna o OBJ do item.
            //0x18E21C00000000
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                Room room = p == null ? null : p._room;
                Slot slot;
                if (room != null && room.RoomState >= RoomState.Loading && room.getSlot(p._slotId, out slot) && (int)slot.state >= 10)
                {
                    bool isBotMode = room.isBotMode();
                    FreepassEffect(p, slot, room, isBotMode);
                    if (room.vote.Timer != null && room.votekick != null && room.votekick.victimIdx == slot._id)
                    {
                        room.vote.Timer = null;
                        room.votekick = null;
                        using (PROTOCOL_BATTLE_NOTIFY_KICKVOTE_CANCEL_ACK packet = new PROTOCOL_BATTLE_NOTIFY_KICKVOTE_CANCEL_ACK())
                        {
                            room.SendPacketToPlayers(packet, SlotState.BATTLE, 0, slot._id);
                        }
                    }
                    AllUtils.ResetSlotInfo(room, slot, true);
                    int red13 = 0, blue13 = 0, red9 = 0, blue9 = 0;
                    foreach (Slot slotR in room._slots)
                    {
                        if ((int)slotR.state >= 10)
                        {
                            if (slotR._team == 0)
                            {
                                red9++;
                            }
                            else
                            {
                                blue9++;
                            }
                            if (slotR.state == SlotState.BATTLE)
                            {
                                if (slotR._team == 0)
                                {
                                    red13++;
                                }
                                else
                                {
                                    blue13++;
                                }
                            }
                        }
                    }
                    if (slot._id == room._leader)
                    {
                        if (isBotMode)
                        {
                            if (red13 > 0 || blue13 > 0)
                            {
                                LeaveHostBOT_GiveBattle(room, p);
                            }
                            else
                            {
                                LeaveHostBOT_EndBattle(room, p);
                            }
                        }
                        else if (room.RoomState == RoomState.Battle && (red13 == 0 || blue13 == 0) || room.RoomState <= RoomState.PreBattle && (red9 == 0 || blue9 == 0))
                        {
                            LeaveHostNoBOT_EndBattle(room, p, red13, blue13);
                        }
                        else
                        {
                            LeaveHostNoBOT_GiveBattle(room, p);
                        }
                    }
                    else if (!isBotMode)
                    {
                        if (room.RoomState == RoomState.Battle && (red13 == 0 || blue13 == 0) || room.RoomState <= RoomState.PreBattle && (red9 == 0 || blue9 == 0))
                        {
                            LeavePlayerNoBOT_EndBattle(room, p, red13, blue13);
                        }
                        else
                        {
                            LeavePlayer_QuitBattle(room, p);
                        }
                    }
                    else
                    {
                        LeavePlayer_QuitBattle(room, p);
                    }
                    _client.SendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(p, 0));
                    if (!isFinished && room.RoomState == RoomState.Battle)
                    {
                        AllUtils.BattleEndRoundPlayersCount(room);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_BATTLE_GIVEUPBATTLE_REQ: " + ex.ToString());
            }
        }

        private void FreepassEffect(Account p, Slot slot, Room room, bool isBotMode)
        {
            DBQuery query = new DBQuery();
            if (p._bonus.freepass == 0 || p._bonus.freepass == 1 && room._channelType == 4)
            {
                if (isBotMode || slot.state < SlotState.BATTLE_READY)
                {
                    return;
                }

                if (p._gp > 0)
                {
                    p._gp -= 200;
                    if (p._gp < 0)
                    {
                        p._gp = 0;
                    }
                    query.AddQuery("gp", p._gp);
                }
                query.AddQuery("escapes", ++p._statistic.escapes);
            }
            else// if (ch._type != 4)
            {
                if (room.RoomState != RoomState.Battle)
                {
                    return;
                }
                int xp = 0, gp = 0;
                if (isBotMode)
                {
                    int level = room.IngameAiLevel * (150 + slot.allDeaths);
                    if (level == 0)
                    {
                        level++;
                    }
                    int reward = (slot.Score / level);
                    gp += reward;
                    xp += reward;
                }
                else
                {
                    int timePlayed = slot.allKills == 0 && slot.allDeaths == 0 ? 0 : (int)slot.inBattleTime(DateTime.Now);
                    if (room.RoomType == RoomType.Bomb || room.RoomType == RoomType.FreeForAll || room.RoomType == RoomType.Convoy) // New Mode
                    {
                        xp = (int)(slot.Score + (timePlayed / 2.5) + (slot.allDeaths * 2.2) + (slot.objects * 20));
                        gp = (int)(slot.Score + (timePlayed / 3.0) + (slot.allDeaths * 2.2) + (slot.objects * 20));
                    }
                    else
                    {
                        xp = (int)(slot.Score + (timePlayed / 2.5) + (slot.allDeaths * 1.8) + (slot.objects * 20));
                        gp = (int)(slot.Score + (timePlayed / 3.0) + (slot.allDeaths * 1.8) + (slot.objects * 20));
                    }
                }
                p._exp += GameConfig.maxBattleXP < xp ? GameConfig.maxBattleXP : xp;
                p._gp += GameConfig.maxBattleGP < gp ? GameConfig.maxBattleGP : gp;
                if (gp > 0)
                {
                    query.AddQuery("gp", p._gp);
                }
                if (xp > 0)
                {
                    query.AddQuery("exp", p._exp);
                }
            }
            ComDiv.updateDB("players", "player_id", p.player_id, query.GetTables(), query.GetValues());
        }

        private void LeaveHostBOT_GiveBattle(Room room, Account p)
        {
            List<Account> players = room.getAllPlayers(SlotState.READY, 1);
            if (players.Count == 0)
            {
                return;
            }
            int oldLeader = room._leader;
            room.setNewLeader(-1, 14, room._leader, true);
            using (PROTOCOL_BATTLE_GIVEUPBATTLE_ACK packet = new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(p, 0))
            using (PROTOCOL_BATTLE_LEAVEP2PSERVER_ACK packet2 = new PROTOCOL_BATTLE_LEAVEP2PSERVER_ACK(room))
            {
                byte[] data = packet.GetCompleteBytes("PROTOCOL_BATTLE_GIVEUPBATTLE_REQ-1");
                byte[] data2 = packet2.GetCompleteBytes("PROTOCOL_BATTLE_GIVEUPBATTLE_REQ-2");
                foreach (Account pR in players)
                {
                    Slot slot = room.getSlot(pR._slotId);
                    if (slot != null)
                    {
                        if (slot.state >= SlotState.PRESTART)
                        {
                            pR.SendCompletePacket(data2);
                        }
                        pR.SendCompletePacket(data);
                    }
                }
            }
        }

        private void LeaveHostBOT_EndBattle(Room room, Account p)
        {
            List<Account> players = room.getAllPlayers(SlotState.READY, 1);
            if (players.Count == 0)
            {
                goto EndLabel;
            }
            using (PROTOCOL_BATTLE_GIVEUPBATTLE_ACK packet = new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(p, 0))
            {
                byte[] data = packet.GetCompleteBytes("PROTOCOL_BATTLE_GIVEUPBATTLE_REQ-3");
                TeamResultType winnerTeam = AllUtils.GetWinnerTeam(room);
                ushort inBattle, missionCompletes;
                AllUtils.getBattleResult(room, out missionCompletes, out inBattle);
                foreach (Account pR in players)
                {
                    pR.SendCompletePacket(data);
                    pR.SendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(pR, winnerTeam, inBattle, missionCompletes, true));
                }
            }
        EndLabel:
            AllUtils.resetBattleInfo(room);
        }

        private void LeaveHostNoBOT_EndBattle(Room room, Account p, int red13, int blue13)
        {
            isFinished = true;
            List<Account> players = room.getAllPlayers(SlotState.READY, 1);
            if (players.Count == 0)
            {
                goto EndLabel;
            }
            TeamResultType winnerTeam = AllUtils.GetWinnerTeam(room, red13, blue13);
            if (room.RoomState == RoomState.Battle)
            {
                room.CalculateResult(winnerTeam, false);
            }
            using (PROTOCOL_BATTLE_GIVEUPBATTLE_ACK packet = new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(p, 0))
            {
                byte[] data = packet.GetCompleteBytes("PROTOCOL_BATTLE_GIVEUPBATTLE_REQ-4");
                ushort inBattle, missionCompletes;
                AllUtils.getBattleResult(room, out missionCompletes, out inBattle);
                foreach (Account pR in players)
                {
                    pR.SendCompletePacket(data);
                    pR.SendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(pR, winnerTeam, inBattle, missionCompletes, false));
                }
            }
        EndLabel:
            AllUtils.resetBattleInfo(room);
        }

        private void LeaveHostNoBOT_GiveBattle(Room room, Account p)
        {
            List<Account> players = room.getAllPlayers(SlotState.READY, 1);
            if (players.Count == 0)
            {
                return;
            }
            int oldLeader = room._leader;
            int state = (room.RoomState == RoomState.Battle ? 14 : 9);
            room.setNewLeader(-1, state, room._leader, true);
            using (PROTOCOL_BATTLE_LEAVEP2PSERVER_ACK packet = new PROTOCOL_BATTLE_LEAVEP2PSERVER_ACK(room))
            using (PROTOCOL_BATTLE_GIVEUPBATTLE_ACK packet2 = new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(p, 0))
            {
                byte[] data = packet.GetCompleteBytes("PROTOCOL_BATTLE_GIVEUPBATTLE_REQ-6");
                byte[] data2 = packet2.GetCompleteBytes("PROTOCOL_BATTLE_GIVEUPBATTLE_REQ-7");
                foreach (Account pR in players)
                {
                    if (room._slots[pR._slotId].state >= SlotState.PRESTART)
                    {
                        pR.SendCompletePacket(data);
                    }
                    pR.SendCompletePacket(data2);
                }
            }
        }

        private void LeavePlayerNoBOT_EndBattle(Room room, Account p, int red13, int blue13)
        {
            isFinished = true;
            TeamResultType winnerTeam = AllUtils.GetWinnerTeam(room, red13, blue13);
            List<Account> players = room.getAllPlayers(SlotState.READY, 1);
            if (players.Count == 0)
            {
                goto EndLabel;
            }
            if (room.RoomState == RoomState.Battle)
            {
                room.CalculateResult(winnerTeam, false);
            }
            using (PROTOCOL_BATTLE_GIVEUPBATTLE_ACK packet = new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(p, 0))
            {
                byte[] data = packet.GetCompleteBytes("PROTOCOL_BATTLE_GIVEUPBATTLE_REQ-8");
                ushort inBattle, missionCompletes;
                AllUtils.getBattleResult(room, out missionCompletes, out inBattle);
                foreach (Account pR in players)
                {
                    pR.SendCompletePacket(data);
                    pR.SendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(pR, winnerTeam, inBattle, missionCompletes, false));
                }
            }
        EndLabel:
            AllUtils.resetBattleInfo(room);
        }

        private void LeavePlayer_QuitBattle(Room room, Account p)
        {
            using (PROTOCOL_BATTLE_GIVEUPBATTLE_ACK packet = new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(p, 0))
            {
                room.SendPacketToPlayers(packet, SlotState.READY, 1);
            }
        }
    }
}