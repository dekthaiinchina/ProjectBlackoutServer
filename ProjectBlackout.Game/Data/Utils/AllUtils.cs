using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Managers.Events;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Account.Mission;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Sql;
using ProjectBlackout.Core.Xml;
using Npgsql;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Sync;
using ProjectBlackout.Game.Data.Sync.Server;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Game.Data.Utils
{
    public static class AllUtils
    {
        public static int getKillScore(KillingMessage msg)
        {
            int score = 0;
            if (msg == KillingMessage.MassKill || msg == KillingMessage.PiercingShot)
            {
                score += 6;
            }
            else if (msg == KillingMessage.ChainStopper)
            {
                score += 8;
            }
            else if (msg == KillingMessage.Headshot)
            {
                score += 10;
            }
            else if (msg == KillingMessage.ChainHeadshot)
            {
                score += 14;
            }
            else if (msg == KillingMessage.ChainSlugger)
            {
                score += 6;
            }
            else if (msg == KillingMessage.ObjectDefense)
            {
                score += 7;
            }
            else if (msg != KillingMessage.Suicide)
            {
                score += 5;
            }
            return score;
        }

        public static void CompleteMission(Room room, Slot slot, FragInfos kills, MissionType autoComplete, int moreInfo)
        {
            try
            {
                Account player = room.getPlayerBySlot(slot);
                if (player == null)
                {
                    return;
                }
                MissionCompleteBase(room, player, slot, kills, autoComplete, moreInfo);
            }
            catch (Exception ex)
            {
                Logger.error("[AllUtils.CompleteMission1] " + ex.ToString());
            }
        }

        public static void CompleteMission(Room room, Slot slot, MissionType autoComplete, int moreInfo)
        {
            try
            {
                Account player = room.getPlayerBySlot(slot);
                if (player == null)
                {
                    return;
                }
                MissionCompleteBase(room, player, slot, autoComplete, moreInfo);
            }
            catch (Exception ex)
            {
                Logger.error("[AllUtils.CompleteMission2] " + ex.ToString());
            }
        }

        public static void CompleteMission(Room room, Account player, Slot slot, FragInfos kills, MissionType autoComplete, int moreInfo)
        {
            MissionCompleteBase(room, player, slot, kills, autoComplete, moreInfo);
        }

        public static void CompleteMission(Room room, Account player, Slot slot, MissionType autoComplete, int moreInfo)
        {
            MissionCompleteBase(room, player, slot, autoComplete, moreInfo);
        }

        private static void MissionCompleteBase(Room room, Account pR, Slot slot, FragInfos kills, MissionType autoComplete, int moreInfo)
        {
            try
            {
                PlayerMissions missions = slot.Missions;
                if (missions == null)
                {
                    //Logger.error("Missions[1] null! by PlayerId: " + slot._playerId);
                    return;
                }
                int cmId = missions.getCurrentMissionId(), cardId = missions.getCurrentCard();
                if (cmId <= 0 || missions.selectedCard)
                {
                    return;
                }
                List<Card> cards = MissionCardXml.getCards(cmId, cardId);
                if (cards.Count == 0)
                {
                    return;
                }
                KillingMessage km = kills.GetAllKillFlags();
                byte[] missionArray = missions.getCurrentMissionList();

                ClassType weaponClass = ComDiv.getIdClassType(kills.weapon);
                ClassType convertedClass = ConvertWeaponClass(weaponClass);
                int weaponId = ComDiv.getIdStatics(kills.weapon, 3);
                ClassType moreClass = moreInfo > 0 ? ComDiv.getIdClassType(moreInfo) : 0;
                ClassType moreConvClass = moreInfo > 0 ? ConvertWeaponClass(moreClass) : 0;
                int moreId = moreInfo > 0 ? ComDiv.getIdStatics(moreInfo, 3) : 0;

                foreach (Card card in cards)
                {
                    int count = 0;
                    if (card._mapId == 0 || card._mapId == (int)room.mapId)
                    {
                        if (kills.frags.Count > 0)
                        {
                            if (card._missionType == MissionType.KILL ||
                                card._missionType == MissionType.CHAINSTOPPER && km.HasFlag(KillingMessage.ChainStopper) ||
                                card._missionType == MissionType.CHAINSLUGGER && km.HasFlag(KillingMessage.ChainSlugger) ||
                                card._missionType == MissionType.CHAINKILLER && slot.killsOnLife >= 4 ||
                                card._missionType == MissionType.TRIPLE_KILL && slot.killsOnLife == 3 ||
                                card._missionType == MissionType.DOUBLE_KILL && slot.killsOnLife == 2 ||
                                card._missionType == MissionType.HEADSHOT && (km.HasFlag(KillingMessage.Headshot) || km.HasFlag(KillingMessage.ChainHeadshot)) ||
                                card._missionType == MissionType.CHAINHEADSHOT && km.HasFlag(KillingMessage.ChainHeadshot) ||
                                card._missionType == MissionType.PIERCING && km.HasFlag(KillingMessage.PiercingShot) ||
                                card._missionType == MissionType.MASS_KILL && km.HasFlag(KillingMessage.MassKill) ||
                                card._missionType == MissionType.KILL_MAN && (room.RoomType == RoomType.Boss || room.RoomType == RoomType.CrossCounter) && (slot._team == 1 && room.rounds == 2 || slot._team == 0 && room.rounds == 1))
                            {
                                count = CheckPlayersClass1(card, weaponClass, convertedClass, weaponId, kills);
                            }
                            else if (card._missionType == MissionType.KILL_WEAPONCLASS || card._missionType == MissionType.DOUBLE_KILL_WEAPONCLASS && slot.killsOnLife == 2 || card._missionType == MissionType.TRIPLE_KILL_WEAPONCLASS && slot.killsOnLife == 3)
                            {
                                count = CheckPlayersClass2(card, kills);
                            }
                        }
                        else if (card._missionType == MissionType.DEATHBLOW && autoComplete == MissionType.DEATHBLOW)
                        {
                            count = CheckPlayerClass(card, moreClass, moreConvClass, moreId);
                        }
                        else if (card._missionType == autoComplete)
                        {
                            count = 1;
                        }
                    }
                    if (count == 0)
                    {
                        continue;
                    }

                    int ArrayIdx = card._arrayIdx;
                    if (missionArray[ArrayIdx] + 1 > card._missionLimit)
                    {
                        continue;
                    }
                    slot.MissionsCompleted = true;
                    missionArray[ArrayIdx] += (byte)count;
                    if (missionArray[ArrayIdx] > card._missionLimit)
                    {
                        missionArray[ArrayIdx] = (byte)card._missionLimit;
                    }

                    int progress = missionArray[ArrayIdx];
                    pR.SendPacket(new PROTOCOL_BASE_QUEST_CHANGE_ACK(progress, card));
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private static void MissionCompleteBase(Room room, Account pR, Slot slot, MissionType autoComplete, int moreInfo)
        {
            try
            {
                PlayerMissions missions = slot.Missions;
                if (missions == null)
                {
                    //Logger.error("Missions[2] null! by PlayerId: " + slot._playerId);
                    return;
                }
                int cmId = missions.getCurrentMissionId(), cardId = missions.getCurrentCard();
                if (cmId <= 0 || missions.selectedCard)
                {
                    return;
                }
                List<Card> cards = MissionCardXml.getCards(cmId, cardId);
                if (cards.Count == 0)
                {
                    return;
                }
                byte[] missionArray = missions.getCurrentMissionList();

                ClassType moreClass = moreInfo > 0 ? ComDiv.getIdClassType(moreInfo) : 0;
                ClassType moreConvClass = moreInfo > 0 ? ConvertWeaponClass(moreClass) : 0;
                int moreId = moreInfo > 0 ? ComDiv.getIdStatics(moreInfo, 3) : 0;

                foreach (Card card in cards)
                {
                    int count = 0;
                    if (card._mapId == 0 || card._mapId == (int)room.mapId)
                    {
                        if (card._missionType == MissionType.DEATHBLOW && autoComplete == MissionType.DEATHBLOW)
                        {
                            count = CheckPlayerClass(card, moreClass, moreConvClass, moreId);
                        }
                        else if (card._missionType == autoComplete)
                        {
                            count = 1;
                        }
                    }
                    if (count == 0)
                    {
                        continue;
                    }

                    int ArrayIdx = card._arrayIdx;
                    if (missionArray[ArrayIdx] + 1 > card._missionLimit)
                    {
                        continue;
                    }
                    slot.MissionsCompleted = true;
                    missionArray[ArrayIdx] += (byte)count;
                    if (missionArray[ArrayIdx] > card._missionLimit)
                    {
                        missionArray[ArrayIdx] = (byte)card._missionLimit;
                    }

                    int progress = missionArray[ArrayIdx];
                    pR.SendPacket(new PROTOCOL_BASE_QUEST_CHANGE_ACK(progress, card));
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private static int CheckPlayersClass1(Card card, ClassType weaponClass, ClassType convertedClass, int weaponId, FragInfos infos)
        {
            int count = 0;
            if ((card._weaponReqId == 0 || card._weaponReqId == weaponId) && (card._weaponReq == ClassType.Unknown || card._weaponReq == weaponClass || card._weaponReq == convertedClass))
            {
                foreach (Frag f in infos.frags)
                {
                    if (f.VictimSlot % 2 != infos.killerIdx % 2)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static int CheckPlayersClass2(Card card, FragInfos infos)
        {
            int count = 0;
            foreach (Frag f in infos.frags)
            {
                if (f.VictimSlot % 2 != infos.killerIdx % 2 &&
                    (card._weaponReq == ClassType.Unknown ||
                    card._weaponReq == (ClassType)f.victimWeaponClass ||
                    card._weaponReq == ConvertWeaponClass((ClassType)f.victimWeaponClass)))
                {
                    count++;
                }
            }
            return count;
        }

        private static int CheckPlayerClass(Card card, ClassType weaponClass, ClassType convertedClass, int weaponId, int killerId, Frag frag)
        {
            if ((card._weaponReqId == 0 || card._weaponReqId == weaponId) && (card._weaponReq == ClassType.Unknown || card._weaponReq == weaponClass || card._weaponReq == convertedClass))
            {
                if (frag.VictimSlot % 2 != killerId % 2)
                {
                    return 1;
                }
            }
            return 0;
        }

        private static int CheckPlayerClass(Card card, ClassType weaponClass, ClassType convertedClass, int weaponId)
        {
            if ((card._weaponReqId == 0 || card._weaponReqId == weaponId) && (card._weaponReq == ClassType.Unknown || card._weaponReq == weaponClass || card._weaponReq == convertedClass))
            {
                return 1;
            }
            return 0;
        }

        private static ClassType ConvertWeaponClass(ClassType weaponClass)
        {
            if (weaponClass == ClassType.DualSMG)
            {
                return ClassType.SMG;
            }
            else if (weaponClass == ClassType.DualHandGun)
            {
                return ClassType.HandGun;
            }
            else if (weaponClass == ClassType.DualKnife || weaponClass == ClassType.Knuckle)
            {
                return ClassType.Knife;
            }
            else if (weaponClass == ClassType.DualShotgun)
            {
                return ClassType.Shotgun;
            }
            return weaponClass;
        }

        public static TeamResultType GetWinnerTeam(Room room)
        {
            if (room == null)
            {
                return TeamResultType.TeamDraw;
            }
            byte value = 0;
            if (room.RoomType == RoomType.Bomb || room.RoomType == RoomType.Destroy || room.RoomType == RoomType.Annihilation || room.RoomType == RoomType.Defense || room.RoomType == RoomType.Convoy)
            {
                if (room.blue_rounds == room.red_rounds)
                {
                    value = 2;
                }
                else if (room.blue_rounds > room.red_rounds)
                {
                    value = 1;
                }
                else if (room.blue_rounds < room.red_rounds)
                {
                    value = 0;
                }
            }
            else if (room.RoomType == RoomType.Boss)
            {
                if (room.blue_dino == room.red_dino)
                {
                    value = 2;
                }
                else if (room.blue_dino > room.red_dino)
                {
                    value = 1;
                }
                else if (room.blue_dino < room.red_dino)
                {
                    value = 0;
                }
            }
            else
            {
                if (room._blueKills == room._redKills)
                {
                    value = 2;
                }
                else if (room._blueKills > room._redKills)
                {
                    value = 1;
                }
                else if (room._blueKills < room._redKills)
                {
                    value = 0;
                }
            }
            return (TeamResultType)value;
        }

        public static TeamResultType GetWinnerTeam(Room room, int RedPlayers, int BluePlayers)
        {
            if (room == null)
            {
                return TeamResultType.TeamDraw;
            }
            byte value = 2;
            if (RedPlayers == 0)
            {
                value = 1;
            }
            else if (BluePlayers == 0)
            {
                value = 0;
            }
            return (TeamResultType)value;
        }

        public static void endMatchMission(Room room, Account player, Slot slot, TeamResultType winnerTeam)
        {
            if (winnerTeam != TeamResultType.TeamDraw)
            {
                CompleteMission(room, player, slot, slot._team == (int)winnerTeam ? MissionType.WIN : MissionType.DEFEAT, 0);
            }
        }

        public static void updateMatchCount(bool WonTheMatch, Account p, int winnerTeam, DBQuery query)
        {
            if (winnerTeam == 2)
            {
                query.AddQuery("fights_draw", ++p._statistic.fights_draw);
            }
            else if (WonTheMatch)
            {
                query.AddQuery("fights_win", ++p._statistic.fights_win);
            }
            else
            {
                query.AddQuery("fights_lost", ++p._statistic.fights_lost);
            }
            query.AddQuery("fights", ++p._statistic.fights);
            query.AddQuery("totalfights_count", ++p._statistic.totalfights_count);
        }

        public static void UpdateDailyRecord(bool WonTheMatch, Account p, int winnerTeam, DBQuery query)
        {
            if (winnerTeam == 2)
            {
                query.AddQuery("draws", ++p.Daily.Draws);
            }
            else if (WonTheMatch)
            {
                query.AddQuery("wins", ++p.Daily.Wins);
            }
            else
            {
                query.AddQuery("loses", ++p.Daily.Loses);
            }
            query.AddQuery("total", ++p.Daily.Total);
        }

        public static void updateMatchCountFreeForAll(Room Room, Account p, int SlotWin, DBQuery query)
        {
            int SlotIndex = 0;
            int[] Array = new int[16];
            for (int i = 0; i < Array.Length; i++)
            {
                Slot Slot = Room._slots[i];
                if (Slot._playerId != 0)
                {
                    Array[i] = Slot.allKills;
                }
                else
                {
                    Array[i] = 0;
                }
            }
            int SlotKills = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] > Array[SlotKills])
                {
                    SlotKills = i;
                }
            }
            SlotIndex = Array[SlotKills];

            if (SlotIndex == SlotWin)
            {
                query.AddQuery("fights_win", ++p._statistic.fights_win);
            }
            else
            {
                query.AddQuery("fights_lost", ++p._statistic.fights_lost);
            }
            query.AddQuery("fights", ++p._statistic.fights);
            query.AddQuery("totalfights_count", ++p._statistic.totalfights_count);
        }

        public static void UpdateMatchDailyRecordFreeForAll(Room Room, Account p, int SlotWin, DBQuery query)
        {
            int SlotIndex = 0;
            int[] Array = new int[16];
            for (int i = 0; i < Array.Length; i++)
            {
                Slot Slot = Room._slots[i];
                if (Slot._playerId != 0)
                {
                    Array[i] = Slot.allKills;
                }
                else
                {
                    Array[i] = 0;
                }
            }
            int SlotKills = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] > Array[SlotKills])
                {
                    SlotKills = i;
                }
            }
            SlotIndex = Array[SlotKills];

            if (SlotIndex == SlotWin)
            {
                query.AddQuery("wins", ++p.Daily.Wins);
            }
            else
            {
                query.AddQuery("loses", ++p.Daily.Loses);
            }
            query.AddQuery("total", ++p.Daily.Total);
        }

        public static void GenerateMissionAwards(Account player, DBQuery query)
        {
            try
            {
                PlayerMissions missions = player._mission;
                int activeM = missions.actualMission, missionId = missions.getCurrentMissionId(), cardId = missions.getCurrentCard();
                if (missionId <= 0 || missions.selectedCard)
                {
                    return;
                }
                int CompletedLastCardCount = 0, allCompletedCount = 0;
                byte[] missionL = missions.getCurrentMissionList();
                List<Card> cards = MissionCardXml.getCards(missionId, -1);
                foreach (Card card in cards)
                {
                    if (missionL[card._arrayIdx] >= card._missionLimit)
                    {
                        allCompletedCount++;
                        if (card._cardBasicId == cardId)
                        {
                            CompletedLastCardCount++;
                        }
                    }
                }
                if (allCompletedCount >= 40)
                {
                    int blueOrder = player.blue_order, brooch = player.brooch, medal = player.medal, insignia = player.insignia;
                    CardAwards c = MissionCardXml.getAward(missionId, cardId);
                    if (c != null)
                    {
                        player.brooch += c._brooch;
                        player.medal += c._medal;
                        player.insignia += c._insignia;
                        player._gp += c._gp;
                        player._exp += c._exp;
                    }
                    MissionAwards m = MissionAwardsXml.getAward(missionId);
                    if (m != null)
                    {
                        player.blue_order += m._blueOrder;
                        player._exp += m._exp;
                        player._gp += m._gp;
                    }
                    List<ItemsModel> items = MissionCardXml.getMissionAwards(missionId);
                    if (items.Count > 0)
                    {
                        foreach (ItemsModel Item in items)
                        {
                            if (Item._id != 0)
                            {
                                player.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, player, Item));
                            }
                        }
                    }
                    player.SendPacket(new PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_ACK(273, 4, player));
                    if (player.brooch != brooch)
                    {
                        query.AddQuery("brooch", player.brooch);
                    }
                    if (player.insignia != insignia)
                    {
                        query.AddQuery("insignia", player.insignia);
                    }
                    if (player.medal != medal)
                    {
                        query.AddQuery("medal", player.medal);
                    }
                    if (player.blue_order != blueOrder)
                    {
                        query.AddQuery("blue_order", player.blue_order);
                    }
                    query.AddQuery("mission_id" + (activeM + 1), 0);
                    ComDiv.updateDB("player_missions", "owner_id", player.player_id, new string[] { "card" + (activeM + 1), "mission" + (activeM + 1) }, 0, new byte[0]);

                    if (activeM == 0)
                    {
                        missions.mission1 = 0;
                        missions.card1 = 0;
                        missions.list1 = new byte[40];
                    }
                    else if (activeM == 1)
                    {
                        missions.mission2 = 0;
                        missions.card2 = 0;
                        missions.list2 = new byte[40];
                    }
                    else if (activeM == 2)
                    {
                        missions.mission3 = 0;
                        missions.card3 = 0;
                        missions.list3 = new byte[40];
                    }
                    else if (activeM == 3)
                    {
                        missions.mission4 = 0;
                        missions.card4 = 0;
                        missions.list4 = new byte[40];
                        if (player._event != null)
                        {
                            player._event.LastQuestFinish = 1;
                            ComDiv.updateDB("player_events", "last_quest_finish", 1, "player_id", player.player_id);
                        }
                    }
                }
                else if (CompletedLastCardCount == 4 && !missions.selectedCard)
                {
                    CardAwards c = MissionCardXml.getAward(missionId, cardId);
                    if (c != null)
                    {
                        int brooch = player.brooch, medal = player.medal, insignia = player.insignia;
                        player.brooch += c._brooch;
                        player.medal += c._medal;
                        player.insignia += c._insignia;
                        player._gp += c._gp;
                        player._exp += c._exp;
                        if (player.brooch != brooch)
                        {
                            query.AddQuery("brooch", player.brooch);
                        }
                        if (player.insignia != insignia)
                        {
                            query.AddQuery("insignia", player.insignia);
                        }
                        if (player.medal != medal)
                        {
                            query.AddQuery("medal", player.medal);
                        }
                    }
                    missions.selectedCard = true;
                    player.SendPacket(new PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_ACK(1, 1, player));
                }
            }
            catch
            {
                Logger.error("AllUtils.GenerateMissionAwards");
            }
        }

        public static void ResetSlotInfo(Room room, Slot slot, bool updateInfo)
        {
            if ((int)slot.state >= 10)
            {
                room.changeSlotState(slot, SlotState.NORMAL, updateInfo);
                slot.ResetSlot();
            }
        }

        public static void votekickResult(Room room)
        {
            Core.Models.Room.VoteKick votekick = room.votekick;
            if (votekick != null)
            {
                int Count = votekick.GetInGamePlayers();
                if (votekick.kikar > votekick.deixar && votekick.enemys > 0 && votekick.allies > 0 && votekick._votes.Count >= Count / 2)
                {
                    Account j = room.getPlayerBySlot(votekick.victimIdx);
                    if (j != null)
                    {
                        j.SendPacket(new PROTOCOL_BATTLE_NOTIFY_BE_KICKED_BY_KICKVOTE_ACK());
                        room.kickedPlayers.Add(j.player_id);
                        room.RemovePlayer(j, true, 2);
                    }
                }
                uint erro = 0;
                if (votekick.allies == 0)
                {
                    erro = 2147488001;
                }
                else if (votekick.enemys == 0)
                {
                    erro = 2147488002;
                }
                else if (votekick.deixar < votekick.kikar || votekick._votes.Count < Count / 2)
                {
                    erro = 2147488000;
                }

                using (PROTOCOL_BATTLE_NOTIFY_KICKVOTE_RESULT_ACK packet = new PROTOCOL_BATTLE_NOTIFY_KICKVOTE_RESULT_ACK(erro, votekick))
                {
                    room.SendPacketToPlayers(packet, SlotState.BATTLE, 0);
                }
                //LogVotekickResult(room);
            }
            room.votekick = null;
        }

        public static void resetBattleInfo(Room room)
        {
            //LogRoomResult(room);
            foreach (Slot slot in room._slots)
            {
                if (slot._playerId > 0 && (int)slot.state >= 10)
                {
                    slot.state = SlotState.NORMAL;
                    slot.ResetSlot();
                }
            }
            room.blockedClan = false;
            room.rounds = 1;
            room.spawnsCount = 0;
            room._redKills = 0;
            room._redAssists = 0;
            room._redDeaths = 0;
            room._blueKills = 0;
            room._blueAssists = 0;
            room._blueDeaths = 0;
            room.red_dino = 0;
            room.blue_dino = 0;
            room.red_rounds = 0;
            room.blue_rounds = 0;
            room.BattleStart = new DateTime();
            room._timeRoom = 0;
            room.Bar1 = 0;
            room.Bar2 = 0;
            room.swapRound = false;
            room.IngameAiLevel = 0;
            room.RoomState = RoomState.Ready;
            room.updateRoomInfo();
            room.votekick = null;
            room.UdpServer = null;
            if (room.round.Timer != null)
            {
                room.round.Timer = null;
            }
            if (room.vote.Timer != null)
            {
                room.vote.Timer = null;
            }
            if (room.bomb.Timer != null)
            {
                room.bomb.Timer = null;
            }
            room.updateSlotsInfo();
        }

        public static List<int> getDinossaurs(Room room, bool forceNewTRex, int forceRexIdx)
        {
            List<int> dinos = new List<int>();
            if (room.RoomType == RoomType.Boss || room.RoomType == RoomType.CrossCounter)
            {
                int teamIdx = room.rounds == 1 ? 0 : 1;
                int[] array = room.GetTeamArray(teamIdx);
                for (int i = 0; i < array.Length; i++)
                {
                    int slotIdx = array[i];
                    Slot slot = room._slots[slotIdx];
                    if ((int)slot.state == 15 && !slot.specGM)
                    {
                        dinos.Add(slotIdx);
                    }
                }
                if ((room.TRex == -1 || (int)room._slots[room.TRex].state <= 14 || forceNewTRex) && dinos.Count > 1 && room.RoomType == RoomType.Boss)
                {
                    //Logger.warning("Trex: " + room.TRex);
                    if (forceRexIdx >= 0 && dinos.Contains(forceRexIdx))
                    {
                        room.TRex = forceRexIdx;
                    }
                    else if (forceRexIdx == -2)
                    {
                        room.TRex = dinos[new Random().Next(0, dinos.Count)];
                    }
                    //Logger.warning("ForceRexIdx: " + forceRexIdx + " Force: " + forceNewTRex + " TeamIdx: " + teamIdx + " Trex: " + room.TRex);
                }
            }
            return dinos;
        }

        public static void BattleEndPlayersCount(Room room, bool isBotMode)
        {
            if (room == null || isBotMode || !room.isPreparing())
            {
                return;
            }
            int blue = 0, red = 0, blue2 = 0, red2 = 0;
            foreach (Slot slot in room._slots)
            {
                if ((int)slot.state == 15)
                {
                    if (slot._team == 0)
                    {
                        red++;
                    }
                    else
                    {
                        blue++;
                    }
                }
                else if ((int)slot.state >= 10)
                {
                    if (slot._team == 0)
                    {
                        red2++;
                    }
                    else
                    {
                        blue2++;
                    }
                }
            }
            if ((red == 0 || blue == 0) && room.RoomState == RoomState.Battle || (red2 == 0 || blue2 == 0) && room.RoomState <= RoomState.PreBattle)
            {
                EndBattle(room, isBotMode);
            }
        }

        public static void EndBattle(Room room)
        {
            EndBattle(room, room.isBotMode());
        }

        public static void EndBattle(Room room, bool isBotMode)
        {
            TeamResultType winnerTeam = GetWinnerTeam(room);
            EndBattle(room, isBotMode, winnerTeam);
        }

        public static void EndBattleNoPoints(Room room)
        {
            List<Account> players = room.getAllPlayers(SlotState.READY, 1);
            if (players.Count == 0)
            {
                goto EndLabel;
            }

            ushort inBattle, missionCompletes;
            getBattleResult(room, out missionCompletes, out inBattle);
            bool isBotMode = room.isBotMode();
            foreach (Account pR in players)
            {
                pR.SendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(pR, TeamResultType.TeamDraw, inBattle, missionCompletes, isBotMode));
            }
        EndLabel:
            resetBattleInfo(room);
        }

        public static void EndBattle(Room room, bool isBotMode, TeamResultType winnerTeam)
        {
            List<Account> players = room.getAllPlayers(SlotState.READY, 1);
            if (players.Count == 0)
            {
                goto EndLabel;
            }

            room.CalculateResult(winnerTeam, isBotMode);
            ushort inBattle, missionCompletes;
            getBattleResult(room, out missionCompletes, out inBattle);
            foreach (Account pR in players)
            {
                pR.SendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(pR, winnerTeam, inBattle, missionCompletes, isBotMode));
            }

        EndLabel:
            resetBattleInfo(room);
        }

        public static int percentage(int total, int percent)
        {
            return total * percent / 100;
        }

        public static void BattleEndRound(Room room, int winner, bool forceRestart)
        {
            int roundsByMask = room.getRoundsByMask();
            if (room.red_rounds >= roundsByMask || room.blue_rounds >= roundsByMask)
            {
                room.StopBomb();
                using (PROTOCOL_BATTLE_MISSION_ROUND_END_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_END_ACK(room, winner, RoundEndType.AllDeath))
                {
                    room.SendPacketToPlayers(packet, SlotState.BATTLE, 0);
                }
                EndBattle(room, room.isBotMode(), (TeamResultType)winner);
            }
            else if (!room.C4_actived || forceRestart)
            {
                room.StopBomb();
                room.rounds++;
                GameSync.SendUDPRoundSync(room);
                using (PROTOCOL_BATTLE_MISSION_ROUND_END_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_END_ACK(room, winner, RoundEndType.AllDeath))
                {
                    room.SendPacketToPlayers(packet, SlotState.BATTLE, 0);
                }
                room.RoundRestart();
            }
        }

        public static void BattleEndRound(Room room, int winner, RoundEndType motive)
        {
            using (PROTOCOL_BATTLE_MISSION_ROUND_END_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_END_ACK(room, winner, motive))
            {
                room.SendPacketToPlayers(packet, SlotState.BATTLE, 0);
            }
            room.StopBomb();
            int roundsByMask = room.getRoundsByMask();
            if (room.red_rounds >= roundsByMask || room.blue_rounds >= roundsByMask)
            {
                EndBattle(room, room.isBotMode(), (TeamResultType)winner);
            }
            else
            {
                room.rounds++;
                GameSync.SendUDPRoundSync(room);
                room.RoundRestart();
            }
        }

        public static int AddFriend(Account owner, Account friend, int state)
        {
            if (owner == null || friend == null)
            {
                return -1;
            }
            try
            {
                Friend f = owner.FriendSystem.GetFriend(friend.player_id);
                if (f == null)
                {
                    using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                    {
                        NpgsqlCommand command = connection.CreateCommand();
                        connection.Open();
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@friend", friend.player_id);
                        command.Parameters.AddWithValue("@owner", owner.player_id);
                        command.Parameters.AddWithValue("@state", state);
                        command.CommandText = "INSERT INTO player_friends(friend_id,owner_id,state)VALUES(@friend,@owner,@state)";
                        command.ExecuteNonQuery();
                        command.Dispose();
                        connection.Dispose();
                        connection.Close();
                    }
                    lock (owner.FriendSystem._friends)
                    {
                        Friend friendM = new Friend(friend.player_id, friend._rank, friend.name_color, friend.player_name, friend._isOnline, friend._status)
                        {
                            state = state,
                            removed = false
                        };
                        owner.FriendSystem._friends.Add(friendM);
                        SendFriendInfo.Load(owner, friendM, 0);
                    }
                    return 0;
                }
                else
                {
                    if (f.removed)
                    {
                        f.removed = false;
                        PlayerManager.UpdateFriendBlock(owner.player_id, f);
                        SendFriendInfo.Load(owner, f, 1);
                    }
                    return 1;
                }
            }
            catch (Exception ex)
            {
                Logger.info("[AllUtils.AddFriend] " + ex.ToString());
                return -1;
            }
        }

        public static void syncPlayerToFriends(Account p, bool all)
        {
            if (p == null || p.FriendSystem._friends.Count == 0)
            {
                return;
            }
            PlayerInfo info = new PlayerInfo(p.player_id, p._rank, p.name_color, p.player_name, p._isOnline, p._status);
            for (int i = 0; i < p.FriendSystem._friends.Count; i++)
            {
                Friend friend = p.FriendSystem._friends[i];
                if (all || friend.state == 0 && !friend.removed)
                {
                    Account f1 = AccountManager.getAccount(friend.player_id, 32);
                    if (f1 != null)
                    {
                        int idx = -1;
                        Friend f2 = f1.FriendSystem.GetFriend(p.player_id, out idx);
                        if (f2 != null)
                        {
                            f2.player = info;
                            f1.SendPacket(new PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(FriendChangeState.Update, f2, idx), false);
                        }
                    }
                }
            }
        }

        public static void syncPlayerToClanMembers(Account player)
        {
            if (player == null || player.clanId <= 0)
            {
                return;
            }
            using (PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK packet = new PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK(player))
            {
                ClanManager.SendPacket(packet, player.clanId, player.player_id, true, true);
            }
        }

        public static void updateSlotEquips(Account p)
        {
            Room room = p._room;
            if (room != null)
            {
                updateSlotEquips(p, room);
            }
        }

        public static void updateSlotEquips(Account p, Room room)
        {
            Slot slot;
            if (room.getSlot(p._slotId, out slot))
            {
                slot._equip = p._equip;
            }
        }

        public static ushort getSlotsFlag(Room Room, bool OnlyNoSpectators, bool MissionSuccess)
        {
            if (Room == null)
            {
                return 0;
            }
            int Flags = 0;
            foreach (Slot Slot in Room._slots)
            {
                if ((int)Slot.state >= 10 && (MissionSuccess && Slot.MissionsCompleted || !MissionSuccess && (!OnlyNoSpectators || !Slot.espectador)))
                {
                    Flags += Slot.Flag;
                }
            }
            return (ushort)Flags;
        }

        public static void getBattleResult(Room Room, out ushort MissionFlag, out ushort SlotFlag)
        {
            MissionFlag = 0;
            SlotFlag = 0;
            if (Room == null)
            {
                return;
            }
            foreach (Slot Slot in Room._slots)
            {
                if ((int)Slot.state >= 10)
                {
                    ushort Flag = (ushort)Slot.Flag;
                    if (Slot.MissionsCompleted)
                    {
                        MissionFlag += Flag;
                    }
                    SlotFlag += Flag;
                }
            }

            /*using (SendGPacket p1 = new SendGPacket())
            {
                for (int i = 0; i < 16; i++)
                {
                    Slot slot = room._slots[i];
                    if ((int)slot.state >= 10)
                    {
                        ushort flag = (ushort)slot._flag;
                        if (slot.MissionsCompleted)
                        {
                            result1 += flag;
                        }
                        result2 += flag;
                    }
                    p1.writeH(0 + (i * 2), (ushort)slot.exp);
                    p1.writeH(32 + (i * 2), (ushort)slot.gp);
                    p1.writeC(64 + (i), (byte)slot.bonusFlags);
                    p1.writeH(80 + (i * 2), (ushort)slot.BonusCafeExp);
                    p1.writeH(112 + (i * 2), (ushort)slot.BonusEventExp);
                    p1.writeH(144 + (i * 2), (ushort)slot.BonusItemExp);
                    p1.writeH(176 + (i * 2), (ushort)slot.BonusCafePoint);
                    p1.writeH(208 + (i * 2), (ushort)slot.BonusEventPoint);
                    p1.writeH(240 + (i * 2), (ushort)slot.BonusItemPoint);
                }
                data = p1.mstream.ToArray();
            }*/
        }

        public static void DiscountPlayerItems(Slot slot, Account p)
        {
            long data_atual = Convert.ToInt64(DateTime.Now.ToString("yyMMddHHmm"));
            bool loadCode = false, updEffect = false;
            List<ItemsModel> UpdateList = new List<ItemsModel>();
            List<object> RemoveList = new List<object>();
            List<object> RemoveChar = new List<object>();
            PlayerBonus bonus = p._bonus;
            int bonuses = bonus != null ? bonus.bonuses : 0, freepass = bonus != null ? bonus.freepass : 0;
            lock (p._inventory._items)
            {
                for (int i = 0; i < p._inventory._items.Count; i++)
                {
                    ItemsModel item = p._inventory._items[i];
                    if (item._equip == 1 && slot.armas_usadas.Contains(item._id) && !slot.specGM)
                    {
                        if (--item._count < 1)
                        {
                            RemoveList.Add(item._objId);
                            p._inventory._items.RemoveAt(i--);
                        }
                        else
                        {
                            UpdateList.Add(item);
                            ComDiv.updateDB("player_items", "count", item._count, "object_id", item._objId, "owner_id", p.player_id);
                        }
                    }
                    else if (item._count <= data_atual & item._equip == 2)
                    {
                        if (item._category == 3 && ComDiv.getIdStatics(item._id, 1) == 16)
                        {
                            if (bonus == null)
                            {
                                continue;
                            }
                            bool changed = bonus.RemoveBonuses(item._id);
                            if (!changed)
                            {
                                if (item._id == 1600014)
                                {
                                    ComDiv.updateDB("player_bonus", "sightcolor", 4, "player_id", p.player_id);
                                    bonus.sightColor = 4;
                                    loadCode = true;
                                }
                                else if (item._id == 1600009)
                                {
                                    ComDiv.updateDB("player_bonus", "fakerank", 55, "player_id", p.player_id);
                                    bonus.fakeRank = 55;
                                    loadCode = true;
                                }
                            }
                            else if (item._id == 1600006)
                            {
                                ComDiv.updateDB("players", "name_color", 0, "player_id", p.player_id);
                                p.name_color = 0;
                                if (p._room != null)
                                {
                                    using (PROTOCOL_ROOM_GET_NICKNAME_ACK packet = new PROTOCOL_ROOM_GET_NICKNAME_ACK(slot._id, p.player_name, p.name_color))
                                    {
                                        p._room.SendPacketToPlayers(packet);
                                    }
                                }
                            }
                            else if (item._id == 1600187)
                            {
                                ComDiv.updateDB("player_bonus", "muzzle", 0, "player_id", p.player_id);
                                bonus.muzzle = 0;
                                loadCode = true;
                            }
                            CouponFlag cupom = CouponEffectManager.getCouponEffect(item._id);
                            if (cupom != null && cupom.EffectFlag > 0 && p.effects.HasFlag(cupom.EffectFlag))
                            {
                                p.effects -= cupom.EffectFlag;
                                updEffect = true;
                            }
                        }
                        else if (item._category == 2 && ComDiv.getIdStatics(item._id, 1) == 6)
                        {
                            Character Character = p.getCharacter(item._id);
                            if (Character != null)
                            {
                                int Index = 0;
                                for (int Slot = 0; Slot < p.Characters.Count; Slot++)
                                {
                                    Character Chara = p.Characters[Slot];
                                    if (Chara.Slot != Character.Slot)
                                    {
                                        Chara.Slot = Index;
                                        CharacterManager.Update(Index, Chara.ObjId);
                                        Index++;
                                    }
                                }
                                p.SendPacket(new PROTOCOL_CHAR_DELETE_CHARA_ACK(0, Character.Slot, p, item));
                                if (CharacterManager.Delete(Character.ObjId, p.player_id))
                                {
                                    p.Characters.Remove(Character);
                                }
                            }
                        }
                        if (ComDiv.getIdStatics(item._id, 1) == 6)
                        {
                            RemoveChar.Add(item._objId);
                        }
                        else
                        {
                            RemoveList.Add(item._objId);
                        }
                        p._inventory._items.RemoveAt(i--);
                    }
                }
            }
            if (bonus != null && (bonus.bonuses != bonuses || bonus.freepass != freepass))
            {
                PlayerManager.updatePlayerBonus(p.player_id, bonus.bonuses, bonus.freepass);
            }
            if (p.effects < 0)
            {
                p.effects = 0;
            }
            if (updEffect)
            {
                PlayerManager.updateCupomEffects(p.player_id, p.effects);
            }

            if (UpdateList.Count > 0)
            {
                for (int idx = 0; idx < UpdateList.Count; idx++)
                {
                    ItemsModel Item = UpdateList[idx];
                    if (Item._id != 0)
                    {
                        p.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(1, p, Item));
                    }
                }
            }
            for (int i = 0; i < RemoveList.Count; i++)
            {
                long objId = (long)RemoveList[i];
                p.SendPacket(new PROTOCOL_AUTH_SHOP_DELETE_ITEM_ACK(1, objId));
            }
            ComDiv.deleteDB("player_items", "object_id", RemoveList.ToArray(), "owner_id", p.player_id);
            ComDiv.deleteDB("player_items", "object_id", RemoveChar.ToArray(), "owner_id", p.player_id);

            RemoveList = null;
            RemoveChar = null;
            UpdateList = null;

            if (loadCode)
            {
                p.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(0, p));
            }
            if (p._equip == null)
            {
                Logger.warning("This is Null.");
            }
            int type = PlayerManager.CheckEquipedItems(p._equip, p._inventory._items);
            if (type > 0)
            {
                p.SendPacket(new PROTOCOL_SERVER_MESSAGE_CHANGE_INVENTORY_ACK(p));
                slot._equip = p._equip;
            }
        }

        public static void TryBalancePlayer(Room room, Account player, bool inBattle, ref Slot mySlot)
        {
            Slot oldSlot = room.getSlot(player._slotId);
            if (oldSlot == null)
            {
                return;
            }
            int PlayerTeamIdx = oldSlot._team;
            int TeamIdx = getBalanceTeamIdx(room, inBattle, PlayerTeamIdx);
            if (PlayerTeamIdx == TeamIdx || TeamIdx == -1)
            {
                return;
            }
            Slot newSlot = null;
            int[] teamArray = PlayerTeamIdx == 1 ? room.RED_TEAM : room.BLUE_TEAM;
            for (int i = 0; i < teamArray.Length; i++)
            {
                Slot slot = room._slots[teamArray[i]];
                if ((int)slot.state != 1 && slot._playerId == 0)
                {
                    newSlot = slot;
                    break;
                }
            }
            if (newSlot == null)
            {
                return;
            }

            List<SlotChange> changeList = new List<SlotChange>();
            lock (room._slots)
            {
                room.SwitchSlots(changeList, newSlot._id, oldSlot._id, false);
            }
            if (changeList.Count > 0)
            {
                //Logger.LogProblems("[AllUtils.TryBalancePlayer] Player: '" + player.player_id + "' '" + player.player_name + "'; OldSlot: " + player._slotId + "; NewSlot: " + newSlot._id, "ErrorC");
                player._slotId = oldSlot._id;
                mySlot = oldSlot;
                using (PROTOCOL_ROOM_TEAM_BALANCE_ACK packet = new PROTOCOL_ROOM_TEAM_BALANCE_ACK(changeList, room._leader, 1))
                {
                    room.SendPacketToPlayers(packet);
                }
                room.updateSlotsInfo();
            }
        }

        public static int getBalanceTeamIdx(Room room, bool inBattle, int PlayerTeamIdx)
        {
            int redPlayers = inBattle && PlayerTeamIdx == 0 ? 1 : 0, bluePlayers = inBattle && PlayerTeamIdx == 1 ? 1 : 0;
            foreach (Slot slot in room._slots)
            {
                if ((int)slot.state == 8 && !inBattle || (int)slot.state >= 10 && inBattle)
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
            return redPlayers + 1 < bluePlayers ? 0 : bluePlayers + 1 < redPlayers + 1 ? 1 : -1;
        }

        public static int getNewSlotId(int slotIdx)
        {
            return slotIdx % 2 == 0 ? (slotIdx + 1) : (slotIdx - 1);
        }

        public static void GetXmasReward(Account p)
        {
            EventXmasModel ev = EventXmasSyncer.getRunningEvent();
            if (ev == null)
            {
                return;
            }
            PlayerEvent pev = p._event;
            uint date = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
            if (pev != null && !(pev.LastXmasRewardDate > ev.startDate && pev.LastXmasRewardDate <= ev.endDate) && ComDiv.updateDB("player_events", "last_xmas_reward_date", (long)date, "player_id", p.player_id))
            {
                pev.LastXmasRewardDate = date;
                p.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, p, new ItemsModel(702001024, 1, "Xmas Event", 1, 100)));
            }
        }

        public static void BattleEndRoundPlayersCount(Room room)
        {
            if (room.round.Timer == null && (room.RoomType == RoomType.Bomb || room.RoomType == RoomType.Annihilation || room.RoomType == RoomType.Convoy))
            {
                int redDeaths, blueDeaths, redPlayers, bluePlayers;
                room.getPlayingPlayers(true, out redPlayers, out bluePlayers, out redDeaths, out blueDeaths);
                if (redDeaths == redPlayers)
                {
                    if (!room.C4_actived)
                    {
                        room.blue_rounds++;
                    }
                    BattleEndRound(room, 1, false);
                }
                else if (blueDeaths == bluePlayers)
                {
                    room.red_rounds++;
                    BattleEndRound(room, 0, true);
                }
            }
        }

        public static void BattleEndKills(Room room)
        {
            BaseEndByKills(room, room.isBotMode());
        }

        public static void BattleEndKills(Room room, bool isBotMode)
        {
            BaseEndByKills(room, isBotMode);
        }

        private static void BaseEndByKills(Room room, bool isBotMode)
        {
            int killsByMask = room.getKillsByMask();
            if (room._redKills < killsByMask && room._blueKills < killsByMask)
            {
                return;
            }
            List<Account> players = room.getAllPlayers(SlotState.READY, 1);
            if (players.Count == 0)
            {
                goto EndLabel;
            }
            TeamResultType winner = GetWinnerTeam(room);
            room.CalculateResult(winner, isBotMode);

            ushort inBattle, missionCompletes;
            getBattleResult(room, out missionCompletes, out inBattle);
            
            using (PROTOCOL_BATTLE_MISSION_ROUND_END_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_END_ACK(room, winner, RoundEndType.TimeOut))
            {
                byte[] data = packet.GetCompleteBytes("AllUtils.BaseEndByKills");
                foreach (Account pR in players)
                {
                    Slot slot = room.getSlot(pR._slotId);
                    if (slot != null)
                    {
                        if (slot.state == SlotState.BATTLE)
                        {
                            pR.SendCompletePacket(data);
                        }
                        pR.SendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(pR, winner, inBattle, missionCompletes, isBotMode));
                    }
                }
            }
        EndLabel:
            resetBattleInfo(room);
        }

        public static void BattleEndKillsFreeForAll(Room room)
        {
            BaseEndByKillsFreeForAll(room);
        }

        private static void BaseEndByKillsFreeForAll(Room room)
        {
            int killsByMask = room.getKillsByMask();
            int SlotWin = 0;
            int[] Array = new int[16];
            for (int i = 0; i < Array.Length; i++)
            {
                Slot Slot = room._slots[i];
                if (Slot._playerId != 0)
                {
                    Array[i] = Slot.allKills;
                }
                else
                {
                    Array[i] = 0;
                }
            }
            int SlotKills = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] > Array[SlotKills])
                {
                    SlotKills = i;
                }
            }
            SlotWin = SlotKills;

            if (Array[SlotKills] < killsByMask)
            {
                return;
            }

            List<Account> players = room.getAllPlayers(SlotState.READY, 1);
            if (players.Count == 0)
            {
                goto EndLabel;
            }
            //room.CalculateResultFreeForAll(SlotWin);
            ushort inBattle, missionCompletes;
            getBattleResult(room, out missionCompletes, out inBattle);
            using (PROTOCOL_BATTLE_MISSION_ROUND_END_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_END_ACK(room, SlotWin, RoundEndType.FreeForAll))
            {
                byte[] data = packet.GetCompleteBytes("AllUtils.BaseEndByKills");
                foreach (Account pR in players)
                {
                    Slot slot = room.getSlot(pR._slotId);
                    if (slot != null)
                    {
                        if (slot.state == SlotState.BATTLE)
                        {
                            pR.SendCompletePacket(data);
                        }
                        pR.SendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(pR, SlotWin, inBattle, missionCompletes, false));
                    }
                }
            }
        EndLabel:
            resetBattleInfo(room);
        }

        public static bool CheckClanMatchRestrict(Room room)
        {
            if (room._channelType == 4)
            {
                SortedList<int, ClanModel> clans = GetClanListMatchPlayers(room);
                foreach (ClanModel cm in clans.Values) 
                {
                    if (cm.RedPlayers >= 1 && cm.BluePlayers >= 1)
                    {
                        room.blockedClan = true;
                        Logger.warning("XP canceled in clan [Room: " + room._roomId + "; Channel: " + room._channelId + "; ClanId: " + cm.clanId + "]");
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool Have2ClansToClanMatch(Room room)
        {
            SortedList<int, ClanModel> clans = GetClanListMatchPlayers(room);
            return (clans.Count == 2);
        }

        public static bool HavePlayersToClanMatch(Room room)
        {
            SortedList<int, ClanModel> clans = GetClanListMatchPlayers(room);
            bool teamRed = false, teamBlue = false;
            foreach (ClanModel clan in clans.Values)
            {
                if (clan.RedPlayers >= 4)
                {
                    teamRed = true;
                }
                else if (clan.BluePlayers >= 4)
                {
                    teamBlue = true;
                }
            }
            return (teamRed && teamBlue);
        }

        private static SortedList<int, ClanModel> GetClanListMatchPlayers(Room room)
        {
            SortedList<int, ClanModel> clans = new SortedList<int, ClanModel>();
            for (int i = 0; i < room.getAllPlayers().Count; i++)
            {
                Account pR = room.getAllPlayers()[i];
                if (pR.clanId == 0)
                {
                    continue;
                }
                ClanModel model;
                if (clans.TryGetValue(pR.clanId, out model) && model != null)
                {
                    if (pR._slotId % 2 == 0)
                    {
                        model.RedPlayers++;
                    }
                    else
                    {
                        model.BluePlayers++;
                    }
                }
                else
                {
                    model = new ClanModel();
                    model.clanId = pR.clanId;
                    if (pR._slotId % 2 == 0)
                    {
                        model.RedPlayers++;
                    }
                    else
                    {
                        model.BluePlayers++;
                    }
                    clans.Add(pR.clanId, model);
                }
            }
            return clans;
        }

        public static void PlayTimeEvent(long playedTime, Account p, PlayTimeModel ptEvent, bool isBotMode)
        {
            Room room = p._room;
            PlayerEvent pev = p._event;
            if (room == null || isBotMode || pev == null)
            {
                return;
            }
            long value = pev.LastPlaytimeValue, finish = pev.LastPlaytimeFinish, date2 = pev.LastPlaytimeDate;
            if (pev.LastPlaytimeDate < ptEvent._startDate)
            {
                pev.LastPlaytimeFinish = 0;
                pev.LastPlaytimeValue = 0;
            }
            if (pev.LastPlaytimeFinish == 0)
            {
                pev.LastPlaytimeValue += playedTime;
                if (pev.LastPlaytimeValue >= ptEvent._time)
                {
                    pev.LastPlaytimeFinish = 1;
                }
                pev.LastPlaytimeDate = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
                if (pev.LastPlaytimeValue >= ptEvent._time)
                {
                    p.SendPacket(new PROTOCOL_BATTLE_PLAYER_TIME_ACK(0, ptEvent));
                }
                else
                {
                    p.SendPacket(new PROTOCOL_BATTLE_PLAYER_TIME_ACK(1, new PlayTimeModel { _time = ptEvent._time - pev.LastPlaytimeValue }));
                }
            }
            else if (pev.LastPlaytimeFinish == 1)
            {
                p.SendPacket(new PROTOCOL_BATTLE_PLAYER_TIME_ACK(0, ptEvent));
            }
            if (pev.LastPlaytimeValue != value || pev.LastPlaytimeFinish != finish || pev.LastPlaytimeDate != date2)
            {
                EventPlayTimeSyncer.ResetPlayerEvent(p.player_id, pev);
            }
        }

        /*public static void LogRoomBattleStart(Room room)
        {
            uint date = room.StartDate;
            uint info = room.UniqueRoomId;
            StringUtil str = new StringUtil();
            str.AppendLine("[Room] Unique RoomId: " + info);
            str.AppendLine("[Room] Room Id: " + string.Format("{0:0##}", room._roomId + 1));
            str.AppendLine("[Room] Channel Id: " + string.Format("{0:0##}", room._channelId + 1));
            str.AppendLine("[Room] Room Name: '" + room.name + "'");
            str.AppendLine("[Room] Room Type: " + (RoomType)room.RoomType);
            str.AppendLine("[Room] Room Special: " + (RoomSpecial)room.special);
            str.AppendLine("[Room] Room Weapons: " + (RoomWeaponsFlag)room.weaponsFlag);
            str.AppendLine("[Room] Map Mame: '" + room._mapName + "'");
            str.AppendLine("[Room] Actual players count: " + room.getPlayingPlayers(2, true));
            str.AppendLine("[Room] Started battle.");
            Logger.LogRoom(str.getString(), date, info);
        }

        public static void LogVotekickStart(Room room, Account p, Slot slot)
        {
            VoteKick vote = room.votekick;
            if (vote == null)
            {
                return;
            }

            uint date = room.StartDate;
            uint info = room.UniqueRoomId;
            Logger.LogRoom("[Room] Votekick has been started by " + slot._id + " (Id: " + (p.player_id) + "; Nick: " + (p.player_name) + "), (To: " + vote.victimIdx + "; Motive: " + (VoteKickMotive)vote.motive + ")", date, info);
        }

        public static void LogVotekickResult(Room room)
        {
            VoteKick vote = room.votekick;
            if (vote == null)
            {
                return;
            }

            uint date = room.StartDate;
            uint info = room.UniqueRoomId;
            Logger.LogRoom("[Room] Votekick result: (Allies: " + vote.allies + "; Enemys: " + vote.enemys + "); Total: (" + vote.kikar + "/" + vote.deixar + ")", date, info);
        }

        public static void LogRoomRoundRestart(Room room)
        {
            uint date = room.StartDate;
            uint info = room.UniqueRoomId;
            Logger.LogRoom("[Room] Round " + room.rodada + " has been started.", date, info);
        }

        public static void LogRoomResult(Room room)
        {
            uint date = room.StartDate;
            uint info = room.UniqueRoomId;
            StringUtil str = new StringUtil();
            str.AppendLine("[Room] ;------------------;");
            str.AppendLine("[Room] Battle is finished.");
            str.AppendLine("[Room] Unique RoomId: " + info);
            str.AppendLine("[Room] Used Spawn Count: " + room.spawnsCount);
            str.AppendLine("[Room] End Players Count: " + room.getPlayingPlayers(2, true));
            str.AppendLine("[Room] ;------------------;");
            str.AppendLine("[Room] Room result info.");
            for (int i = 0; i < 16; i++)
            {
                Slot slot = room._slots[i];
                if (slot.state == SlotState.BATTLE && slot._playerId > 0)
                {
                    str.AppendLine("[Room] Player (Id: " + slot._playerId + "; Slot: " + i + ") Exp: " + slot.exp + "; Point: " + slot.gp + "; KD: " + slot.allKills + "/" + slot.allDeaths + "; Score: " + slot.Score);
                }
            }
            Logger.LogRoom(str.getString(), date, info);
        }*/
    }
}