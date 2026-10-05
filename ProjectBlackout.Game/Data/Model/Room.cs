using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Managers.Events;
using ProjectBlackout.Core.Managers.Server;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Account.Rank;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Map;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Sync;
using ProjectBlackout.Game.Data.Sync.Server;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProjectBlackout.Game.Data.Model
{
    public class Room
    {
        public Slot[] _slots = new Slot[16];
        public int seedvalue, _channelType, rounds = 1, TRex = -1, blue_rounds, blue_dino, red_rounds, red_dino, Bar1, Bar2, _ping = 5, _redKills, _redDeaths, _redAssists, _blueKills, _blueDeaths, _blueAssists, spawnsCount, rule, killtime, _roomId, _channelId, _leader, leaderip;
        public byte Limit, WatchRuleFlag, aiCount = 1, IngameAiLevel, aiLevel, aiType, stage, BattleCountdown, KillCam, State;
        public short BalanceType;
        public bool Countdown = false;
        public readonly int[] TIMES = new int[9]
        {
            //3, 3, 3, 5, 10, 15, 20, 25, 30, 25, 30
            3, 5, 7, 5, 10, 15, 20, 25, 30
        },
            KILLS = new int[6] { 60, 80, 100, 120, 140, 160 },
            ROUNDS = new int[6]
        {
            1, 2, 3, 5, 7, 9
        },
            RED_TEAM = new int[8]
        {
            0, 2, 4, 6, 8, 10, 12, 14
        },
            BLUE_TEAM = new int[8]
        {
            1, 3, 5, 7, 9, 11, 13, 15
        };
        public byte[] HitParts = new byte[35], DefaultParts = new byte[35]
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
            30, 31, 32, 33, 34
        };
        /*public readonly int[] TIMES = new int[11]
        {
        3, 3, 3, 5, 7, 5, 10, 15, 20, 25, 30
        },
            KILLS = new int[9]
        {
        15, 30, 50, 60, 80, 100, 120, 140, 160
        },
            ROUNDS = new int[6]
        {
        1, 2, 3, 5, 7, 9
        },
            RED_TEAM = new int[8]
        {
        0, 2, 4, 6, 8, 10, 12, 14
        },
            BLUE_TEAM = new int[8]
        {
        1, 3, 5, 7, 9, 11, 13, 15
        };
        public byte[] HitParts = new byte[35], DefaultParts = new byte[35]
        {
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
        16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
        30, 31, 32, 33, 34,
        };*/
        public byte[] RandomMaps, RoomLeaderIP;
        public uint _timeRoom, StartDate, UniqueRoomId, Seed;
        public long StartTick;
        public string name, password, _mapName, leader_name;
        public Core.Models.Room.VoteKick votekick;
        public MapIdEnum mapId;
        public RoomType RoomType;
        public RoomState RoomState;
        public GameRuleFlag RuleFlag = GameRuleFlag.None;
        public RoomStageFlag Flag = RoomStageFlag.NONE;
        public RoomWeaponsFlag weaponsFlag = RoomWeaponsFlag.None;
        public bool C4_actived, swapRound, changingSlots, blockedClan, ShotgunMode, SniperMode;
        public BattleServer UdpServer;
        public DateTime BattleStart, LastPingSync = DateTime.Now;
        public TimerState bomb = new TimerState(), countdown = new TimerState(), round = new TimerState(), vote = new TimerState(), countdownstart = new TimerState();
        public SafeList<long> kickedPlayers = new SafeList<long>(), requestHost = new SafeList<long>();
        public bool GameRuleActive = false;
        public bool ShotgunActive = false;
        public bool BarrettActive = false;
        public bool MaskActive = false;
        public bool RPG7Active = false;
        public bool GameRuleWCActive = false;
        public List<GameRule> GameRules = new List<GameRule>();

        public Room(int roomId, Channel ch)
        {
            _roomId = roomId;
            for (int i = 0; i < _slots.Length; i++)
            {
                _slots[i] = new Slot(i);
            }
            _channelId = ch._id;
            _channelType = ch._type;
            SetUniqueId();
            GameRules = GameRuleManager.getGameRules(GameConfig.ruleId);
        }

        public bool thisModeHaveCD()
        {
            RoomType stageType = RoomType;
            return (stageType == RoomType.Bomb ||
                    stageType == RoomType.Annihilation ||
                    stageType == RoomType.Boss ||
                    stageType == RoomType.CrossCounter ||
                    stageType == RoomType.Convoy ||
                    stageType == RoomType.Ace);
        }

        public bool thisModeHaveRounds()
        {
            RoomType stageType = RoomType;
            return (stageType == RoomType.Bomb ||
                    stageType == RoomType.Destroy ||
                    stageType == RoomType.Annihilation ||
                    stageType == RoomType.Defense ||
                    stageType == RoomType.Convoy ||
                    stageType == RoomType.Ace);
        }

        public int getFlag()
        {
            int Result = 0;
            if (Flag.HasFlag(RoomStageFlag.OBSERVER))
            {
                Result += 0;
            }
            if (Flag.HasFlag(RoomStageFlag.TEAM_SWAP))
            {
                Result += 1;
            }
            if (Flag.HasFlag(RoomStageFlag.RANDOM_MAP))
            {
                Result += 2;
            }
            if (Flag.HasFlag(RoomStageFlag.PASSWORD) || password.Length > 0)
            {
                Result += 4;
            }
            if (BalanceType == 1)
            {
                Result += 32;
            }
            if (Limit > 0 && RoomState > RoomState.Ready)
            {
                Result += 128;
            }
            Flag = (RoomStageFlag)Result;
            Console.WriteLine("Current room Flag = " + Flag);
            return Result;
        }

        public void LoadHitParts()
        {
            Random rnd = new Random();
            int next = rnd.Next(34);
            byte[] MyRandomArray = DefaultParts.OrderBy(x => x <= next).ToArray();

            Logger.warning("Idx: " + next + "/ Hits: " + BitConverter.ToString(MyRandomArray));
            HitParts = MyRandomArray;

            byte[] newarray = new byte[35];
            for (int i = 0; i < 35; i++)
            {
                byte valor = HitParts[i];
                newarray[((i + 8) % 35)] = valor;
            }
            Logger.warning("Array: " + BitConverter.ToString(newarray));
        }

        private void SetUniqueId()
        {
            UniqueRoomId = (uint)((GameConfig.serverId & 0xff) << 20 | (_channelId & 0xff) << 12 | _roomId & 0xfff);
        }
        public void SetSeed()
        {
            Seed = (uint)(((int)mapId & 0xff) << 20 | (rule & 0xff) << 12 | (int)RoomType & 0xfff);
        }
        public void SetBotLevel()
        {
            if (!isBotMode())
            {
                return;
            }
            IngameAiLevel = aiLevel;
            for (int i = 0; i < 16; i++)
            {
                _slots[i].aiLevel = IngameAiLevel;
            }
        }

        public bool isBotMode()
        {
            return stage == 2 || stage == 4 || stage == 6;
        }
        public bool isTutorialMode()
        {
            return mapId == MapIdEnum.Tutorial;
        }
        private void SetSpecialStage()
        {
            if (RoomType == RoomType.Defense)
            {
                if (mapId == MapIdEnum.BlackPanther)
                {
                    Bar1 = 6000;
                    Bar2 = 9000;
                }
            }
            else if (RoomType == RoomType.Destroy)
            {
                if (mapId == MapIdEnum.Hospital)
                {
                    Bar1 = 12000;
                    Bar2 = 12000;
                }
                else if (mapId == MapIdEnum.BreakDown)
                {
                    Bar1 = 6000;
                    Bar2 = 6000;
                }
            }
        }

        public int getInBattleTime()
        {
            int seconds = 0;
            if (BattleStart != new DateTime() && (RoomState == RoomState.Battle || RoomState == RoomState.PreBattle))
            {
                DateTime now = DateTime.Now;
                seconds = (int)(now - BattleStart).TotalSeconds;
                if (seconds < 0)
                {
                    seconds = 0;
                }
            }
            return seconds;
        }

        public int getInBattleTimeLeft()
        {
            int remaining = getInBattleTime();
            return ((getTimeByMask() * 60) - remaining);
        }

        public Channel getChannel()
        {
            return ChannelsXml.getChannel(_channelId);
        }

        public bool getChannel(out Channel ch)
        {
            ch = ChannelsXml.getChannel(_channelId);
            return ch != null;
        }

        public bool getSlot(int slotIdx, out Slot slot)
        {
            slot = null;
            lock (_slots)
            {
                if (slotIdx >= 0 && slotIdx <= 16)
                {
                    slot = _slots[slotIdx];
                }
                return slot != null;
            }
        }

        public Slot getSlot(int slotIdx)
        {
            lock (_slots)
            {
                if (slotIdx >= 0 && slotIdx <= 16)
                {
                    return _slots[slotIdx];
                }
                return null;
            }
        }

        public void StartCounter(int type, Account player, Slot slot)
        {
            int dueTime = 0;
            //EventErrorEnum error = 0;
            if (type == 0)
            {
                //error = EventErrorEnum.BATTLE_FIRST_MAINLOAD;
                //dueTime = 90000;
            }
            //else if (type == 1)
            //{
            //    error = EventErrorEnum.BATTLE_FIRST_HOLE;
            //    dueTime = 30000;
            //}
            else
            {
                return;
            }
            slot.timing.Start(dueTime, (callbackState) =>
            {
                //BaseCounter(error, player, slot);
                lock (callbackState)
                {
                    if (slot != null)
                    {
                        slot.StopTiming();
                    }
                }
            });
        }

        private void BaseCounter(EventErrorEnum error, Account player, Slot slot)
        {
            player.SendPacket(new PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK(error));
            player.SendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(player, 0));
            slot.state = SlotState.NORMAL;
            AllUtils.BattleEndPlayersCount(this, isBotMode());
            updateSlotsInfo();
        }

        public void StartBomb()
        {
            try
            {
                bomb.Start(42000, (callbackState) =>
                {
                    if (this != null && C4_actived)
                    {
                        red_rounds++;
                        C4_actived = false;
                        AllUtils.BattleEndRound(this, 0, RoundEndType.BombFire);
                    }
                    lock (callbackState)
                    {
                        bomb.Timer = null;
                    }
                });
            }
            catch (Exception ex)
            {
                Logger.warning("StartBomb: " + ex.ToString());
            }
        }

        public void StartVote()
        {
            try
            {
                if (votekick == null)
                {
                    return;
                }

                vote.Start(20000, (callbackState) =>
                {
                    AllUtils.votekickResult(this);
                    lock (callbackState)
                    {
                        vote.Timer = null;
                    }
                });
            }
            catch (Exception ex)
            {
                Logger.warning("StartVote: " + ex.ToString());
                if (vote.Timer != null)
                {
                    vote.Timer = null;
                }
                votekick = null;
            }
        }

        public void RoundRestart()
        {
            try
            {
                StopBomb();
                foreach (Slot s in _slots)
                {
                    if (s._playerId > 0 && (int)s.state == 15)
                    {
                        if (!s._deathState.HasFlag(DeadEnum.UseChat))
                        {
                            s._deathState |= DeadEnum.UseChat;
                        }
                        if (s.espectador)
                        {
                            s.espectador = false;
                        }
                        if (s.killsOnLife >= 3 && RoomType == RoomType.Annihilation)
                        {
                            s.objects++;
                        }
                        if (s.killsOnLife >= 3 && RoomType == RoomType.Ace)
                        {
                            s.objects++;
                        }
                        s.killsOnLife = 0;
                        s.lastKillState = 0;
                        s.repeatLastState = false;
                        s.damageBar1 = 0;
                        s.damageBar2 = 0;
                    }
                }
                round.Start(8000, (callbackState) =>
                {
                    foreach (Slot s in _slots)
                    {
                        if (s._playerId > 0)
                        {
                            if (!s._deathState.HasFlag(DeadEnum.UseChat))
                            {
                                s._deathState |= DeadEnum.UseChat;
                            }
                            if (s.espectador)
                            {
                                s.espectador = false;
                            }
                        }
                    }
                    StopBomb();
                    DateTime now = DateTime.Now;
                    if (RoomState == RoomState.Battle)
                    {
                        BattleStart = RoomType == RoomType.Boss || RoomType == RoomType.CrossCounter ? now.AddSeconds(5) : now;
                    }
                    using (PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK(this))
                    {
                        using (PROTOCOL_BATTLE_MISSION_ROUND_START_ACK packet2 = new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(this))
                        {
                            SendPacketToPlayers(packet, packet2, SlotState.BATTLE, 0);
                        }
                    }
                    StopBomb();
                    swapRound = false;
                    //AllUtils.LogRoomRoundRestart(this);
                    lock (callbackState)
                    {
                        round.Timer = null;
                    }
                });
            }
            catch (Exception ex)
            {
                Logger.warning("[Room.RoundRestart] " + ex.ToString());
            }
        }

        public void StopBomb()
        {
            if (!C4_actived)
            {
                return;
            }
            C4_actived = false;
            if (bomb != null)
            {
                bomb.Timer = null;
            }
        }

        public void StartBattle(bool updateInfo)
        {
            Monitor.Enter(_slots);
            RoomState = RoomState.Loading;
            requestHost.Clear();
            UdpServer = BattleServerXml.GetRandomServer();
            StartTick = DateTime.Now.Ticks;
            StartDate = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
            SetBotLevel();
            AllUtils.CheckClanMatchRestrict(this);

            using (PROTOCOL_BATTLE_START_GAME_ACK packet = new PROTOCOL_BATTLE_START_GAME_ACK(this))
            {
                byte[] data = packet.GetCompleteBytes("Room.StartBattle");
                foreach (Account pR in getAllPlayers(SlotState.READY, 0))
                {
                    Slot slot = getSlot(pR._slotId);
                    if (slot != null)
                    {
                        slot.withHost = true;
                        slot.state = SlotState.LOAD;
                        slot.SetMissionsClone(pR._mission);
                        pR.SendCompletePacket(data);
                    }
                }
            }
            if (updateInfo)
            {
                updateSlotsInfo();
            }
            updateRoomInfo();
            Monitor.Exit(_slots);
        }

        public void StartCountDown()
        {
            using (PROTOCOL_BATTLE_START_COUNTDOWN_ACK packet = new PROTOCOL_BATTLE_START_COUNTDOWN_ACK(CountDownEnum.Start))
            {
                SendPacketToPlayers(packet);
            }
            countdown.Start(5250, (callbackState) =>
            {
                try
                {
                    if (_slots[_leader].state == SlotState.READY && RoomState == RoomState.CountDown)
                    {
                        StartBattle(true);
                    }
                    else
                    {
                        Logger.warning("[Room.StartCountDown] Room: " + _roomId + "; Canal: " + _channelId + "; state: " + RoomState + "; leader: " + _slots[_leader].state);
                        Logger.warning("[Data: " + DateTime.Now.ToString("dd/MM/yy HH:mm:ss"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.warning("[Room.StartCountDown] " + ex.ToString());
                }
                lock (callbackState)
                {
                    countdown.Timer = null;
                }
            });
        }

        public void StopCountDown(CountDownEnum motive, bool refreshRoom = true)
        {
            RoomState = RoomState.Ready;
            if (refreshRoom)
            {
                updateRoomInfo();
            }
            countdown.Timer = null;
            using (PROTOCOL_BATTLE_START_COUNTDOWN_ACK packet = new PROTOCOL_BATTLE_START_COUNTDOWN_ACK(motive))
            {
                SendPacketToPlayers(packet);
            }
        }

        public void StopCountDown(int slotId)
        {
            if (RoomState != RoomState.CountDown)
            {
                return;
            }
            if (slotId == _leader)
            {
                StopCountDown(CountDownEnum.StopByHost);
            }
            else if (getPlayingPlayers(_leader % 2 == 0 ? 1 : 0, SlotState.READY, 0) == 0)
            {
                changeSlotState(_leader, SlotState.NORMAL, false);
                StopCountDown(CountDownEnum.StopByPlayer);
            }
        }

        public void CalculateResult()
        {
            lock (_slots)
            {
                BaseResultGame(AllUtils.GetWinnerTeam(this), isBotMode());
            }
        }

        public void CalculateResult(TeamResultType resultType)
        {
            lock (_slots)
            {
                BaseResultGame(resultType, isBotMode());
            }
        }

        public void CalculateResult(TeamResultType resultType, bool isBotMode)
        {
            lock (_slots)
            {
                BaseResultGame(resultType, isBotMode);
            }
        }

        public void CalculateResultFreeForAll(int SlotWin)
        {
            lock (_slots)
            {
                BaseResultGameFreeForAll(SlotWin);
            }
        }

        private void BaseResultGame(TeamResultType winnerTeam, bool isBotMode)
        {
            ServerConfig cfg = GameManager.Config;
            EventUpModel evUp = EventRankUpSyncer.getRunningEvent();
            EventMapModel evMap = EventMapSyncer.getRunningEvent();
            bool mapEvUse = EventMapSyncer.EventIsValid(evMap, (int)mapId, (int)RoomType);
            PlayTimeModel evPt = EventPlayTimeSyncer.getRunningEvent();
            DateTime finishDate = DateTime.Now;
            if (cfg == null)
            {
                Logger.error("Server Config Null. RoomResult canceled.");
                return;
            }
            foreach (Slot slot in _slots)
            {
                Account player;
                if (!slot.check && slot.state == SlotState.BATTLE && getPlayerBySlot(slot, out player))
                {
                    DBQuery query = new DBQuery();
                    DBQuery query2 = new DBQuery();
                    slot.check = true;
                    double inBattleTime = slot.inBattleTime(finishDate);
                    int gp = player._gp, xp = player._exp, my = player._money;
                    if (!isBotMode)
                    {
                        if (cfg.missions)
                        {
                            AllUtils.endMatchMission(this, player, slot, winnerTeam);
                            if (slot.MissionsCompleted)
                            {
                                player._mission = slot.Missions;
                                MissionManager.getInstance().updateCurrentMissionList(player.player_id, player._mission);
                            }
                            AllUtils.GenerateMissionAwards(player, query);
                        }
                        int timePlayed = slot.allKills == 0 && slot.allDeaths == 0 ? (int)(inBattleTime / 3) : (int)inBattleTime;

                        if (RoomType == RoomType.Bomb || RoomType == RoomType.Annihilation)
                        {
                            slot.exp = (int)(slot.Score + (timePlayed / 2.5) + (slot.allDeaths * 2.2) + (slot.objects * 20));
                            slot.gp = (int)(slot.Score + (timePlayed / 3.0) + (slot.allDeaths * 2.2) + (slot.objects * 20));
                            slot.money = (int)((slot.Score / 2) + (timePlayed / 6.5) + (slot.allDeaths * 1.5) + (slot.objects * 10));
                        }
                        else
                        {
                            slot.exp = (int)(slot.Score + (timePlayed / 2.5) + (slot.allDeaths * 1.8) + (slot.objects * 20));
                            slot.gp = (int)(slot.Score + (timePlayed / 3.0) + (slot.allDeaths * 1.8) + (slot.objects * 20));
                            slot.money = (int)((slot.Score / 1.5) + (timePlayed / 4.5) + (slot.allDeaths * 1.1) + (slot.objects * 20));
                        }
                        bool WonTheMatch = (slot._team == (int)winnerTeam);
                        if (rule != 80 && rule != 32)
                        {
                            player._statistic.headshots_count += slot.headshots;
                            player._statistic.kills_count += slot.allKills;
                            player._statistic.totalkills_count += slot.allKills;
                            player._statistic.deaths_count += slot.allDeaths;
                            player._statistic.assist += slot.allAssists;
                            AddKDInfosToQuery(slot, player._statistic, query);
                            AllUtils.updateMatchCount(WonTheMatch, player, (int)winnerTeam, query);
                            if (player.Daily != null)
                            {
                                player.Daily.Kills += slot.allKills;
                                player.Daily.Deaths += slot.allDeaths;
                                player.Daily.Headshots += slot.headshots;
                                AddDailyToQuery(slot, player.Daily, query2);
                                AllUtils.UpdateDailyRecord(WonTheMatch, player, (int)winnerTeam, query2);
                            }
                        }
                        if (WonTheMatch)
                        {
                            slot.gp += AllUtils.percentage(slot.gp, 15);
                            slot.exp += AllUtils.percentage(slot.exp, 20);
                        }
                        if (slot.earnedXP > 0)
                        {
                            slot.exp += slot.earnedXP * 5;
                        }
                    }
                    else
                    {
                        slot.gp += 300;
                        slot.exp += 300;
                    }
                    slot.exp = slot.exp > GameConfig.maxBattleXP ? GameConfig.maxBattleXP : slot.exp;
                    slot.gp = slot.gp > GameConfig.maxBattleGP ? GameConfig.maxBattleGP : slot.gp;
                    slot.money = slot.money > GameConfig.maxBattleMY ? GameConfig.maxBattleMY : slot.money;
                    if (slot.exp < 0 || slot.gp < 0 || slot.money < 0)
                    {
                        slot.exp = 2;
                        slot.gp = 2;
                        slot.money = 2;
                    }
                    if (RoomType == RoomType.Ace)
                    {
                        if (player._slotId != 0 && player._slotId != 1)
                        {
                            slot.exp = 0;
                            slot.gp = 0;
                            slot.money = 0;
                        }
                    }
                    int ItemExp = 0, ItemPoint = 0, EventExp = 0, EventPoint = 0;
                    if (evUp != null || mapEvUse)
                    {
                        if (evUp != null)
                        {
                            EventExp += evUp._percentXp;
                            EventPoint += evUp._percentGp;
                        }
                        if (mapEvUse)
                        {
                            EventExp += evMap._percentXp;
                            EventPoint += evMap._percentGp;
                        }
                        if (!slot.bonusFlags.HasFlag(ResultIcon.Event))
                        {
                            slot.bonusFlags |= ResultIcon.Event;
                        }
                    }
                    PlayerBonus c = player._bonus;
                    if (c != null && c.bonuses > 0)
                    {
                        if ((c.bonuses & 8) == 8)
                        {
                            ItemExp += 100;
                        }
                        if ((c.bonuses & 128) == 128)
                        {
                            ItemPoint += 100;
                        }
                        if ((c.bonuses & 4) == 4)
                        {
                            ItemExp += 50;
                        }
                        if ((c.bonuses & 64) == 64)
                        {
                            ItemPoint += 50;
                        }
                        if ((c.bonuses & 2) == 2)
                        {
                            ItemExp += 30;
                        }
                        if ((c.bonuses & 32) == 32)
                        {
                            ItemPoint += 30;
                        }
                        if ((c.bonuses & 1) == 1)
                        {
                            ItemExp += 10;
                        }
                        if ((c.bonuses & 16) == 16)
                        {
                            ItemPoint += 10;
                        }
                        if (!slot.bonusFlags.HasFlag(ResultIcon.Item))
                        {
                            slot.bonusFlags |= ResultIcon.Item;
                        }
                        slot.BonusItemExp += ItemExp;
                        slot.BonusItemPoint += ItemPoint;
                    }

                    if (isBotMode)
                    {
                        if (slot.BonusItemExp > 300)
                        {
                            slot.BonusItemExp = 300;
                        }
                        if (slot.BonusItemPoint > 300)
                        {
                            slot.BonusItemPoint = 300;
                        }
                        if (slot.BonusCafeExp > 300)
                        {
                            slot.BonusCafeExp = 300;
                        }
                        if (slot.BonusCafePoint > 300)
                        {
                            slot.BonusCafePoint = 300;
                        }
                        if (slot.BonusEventExp > 300)
                        {
                            slot.BonusEventExp = 300;
                        }
                        if (slot.BonusEventPoint > 300)
                        {
                            slot.BonusEventPoint = 300;
                        }
                    }
                    int BonusAllexp = EventExp + slot.BonusCafeExp + slot.BonusItemExp;
                    int BonusAllPoint = EventPoint + slot.BonusCafePoint + slot.BonusItemPoint;
                    slot.BonusEventExp = AllUtils.percentage(slot.exp, BonusAllexp);
                    slot.BonusEventPoint = AllUtils.percentage(slot.gp, BonusAllPoint);
                    player._gp += slot.gp + slot.BonusEventPoint;
                    player._exp += slot.exp + slot.BonusEventExp;
                    if (player.Daily != null)
                    {
                        player.Daily.Point += slot.gp + slot.BonusCafePoint + slot.BonusItemPoint + slot.BonusEventPoint;
                        player.Daily.Exp += slot.exp + slot.BonusCafeExp + slot.BonusItemExp + slot.BonusEventExp;
                        query2.AddQuery("point", player.Daily.Point);
                        query2.AddQuery("exp", player.Daily.Exp);
                    }
                    if (GameConfig.winCashPerBattle)
                    {
                        player._money += slot.money;
                    }
                    RankModel rank = RankXml.getRank(player._rank);
                    RankModel rank_61 = RankXml.getRank(61);
                    if (rank != null && player._exp >= (rank._onNextLevel + rank._onAllExp) && player._rank <= 50)
                    {
                        List<ItemsModel> items = RankXml.getAwards(player._rank);
                        if (items.Count > 0)
                        {
                            for (int idx = 0; idx < items.Count; idx++)
                            {
                                ItemsModel Item = items[idx];
                                if (Item._id != 0)
                                {
                                    player.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, player, Item));
                                }
                            }
                        }
                        player._gp += rank._onGPUp;
                        player.LastRankUpDate = uint.Parse(finishDate.ToString("yyMMddHHmm"));
                        player.SendPacket(new PROTOCOL_BASE_RANK_UP_ACK(++player._rank, rank._onNextLevel));
                        query.AddQuery("last_rankup_date", (long)player.LastRankUpDate);
                        query.AddQuery("rank", player._rank);
                    }
                    if (evPt != null)
                    {
                        AllUtils.PlayTimeEvent((long)inBattleTime, player, evPt, isBotMode);
                    }
                    AllUtils.DiscountPlayerItems(slot, player);
                    if (gp != player._gp)
                    {
                        query.AddQuery("gp", player._gp);
                    }
                    if (xp != player._exp)
                    {
                        query.AddQuery("exp", player._exp);
                    }
                    if (my != player._money)
                    {
                        query.AddQuery("money", player._money);
                    }
                    ComDiv.updateDB("players", "player_id", player.player_id, query.GetTables(), query.GetValues());
                    ComDiv.updateDB("player_dailyrecord", "player_id", player.player_id, query2.GetTables(), query2.GetValues());
                    if (GameConfig.winCashPerBattle && GameConfig.showCashReceiveWarn)
                    {
                        player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(Translation.GetLabel("CashReceived", slot.money)));
                    }
                }
            }
            updateSlotsInfo();
            CalculateClanMatchResult((int)winnerTeam);
        }

        private void BaseResultGameFreeForAll(int winner)
        {
            ServerConfig cfg = GameManager.Config;
            EventUpModel evUp = EventRankUpSyncer.getRunningEvent();
            EventMapModel evMap = EventMapSyncer.getRunningEvent();
            bool mapEvUse = EventMapSyncer.EventIsValid(evMap, (int)mapId, (int)RoomType);
            PlayTimeModel evPt = EventPlayTimeSyncer.getRunningEvent();
            DateTime finishDate = DateTime.Now;
            int[] Array = new int[16];
            int SlotWin = 0;
            if (cfg == null)
            {
                Logger.error("Server Config Null. RoomResult canceled.");
                return;
            }
            for (int i = 0; i < 16; i++)
            {
                Slot slot = _slots[i];
                if (slot._playerId != 0)
                {
                    Array[i] = slot.allKills;
                }
                else
                {
                    Array[i] = 0;
                }
                if (Array[i] > Array[SlotWin])
                {
                    SlotWin = i;
                }
                Account player;
                if (!slot.check && slot.state == SlotState.BATTLE && getPlayerBySlot(slot, out player))
                {
                    DBQuery query = new DBQuery();
                    DBQuery query2 = new DBQuery();
                    slot.check = true;
                    double inBattleTime = slot.inBattleTime(finishDate);
                    int gp = player._gp, xp = player._exp, my = player._money;
                    if (cfg.missions)
                    {
                        AllUtils.endMatchMission(this, player, slot, (winner == SlotWin) ? _slots[SlotWin]._team == 0 ? TeamResultType.TeamRedWin : TeamResultType.TeamBlueWin : TeamResultType.TeamDraw);
                        if (slot.MissionsCompleted)
                        {
                            player._mission = slot.Missions;
                            MissionManager.getInstance().updateCurrentMissionList(player.player_id, player._mission);
                        }
                        AllUtils.GenerateMissionAwards(player, query);
                    }
                    int timePlayed = slot.allKills == 0 && slot.allDeaths == 0 ? (int)(inBattleTime / 3) : (int)inBattleTime;
                    slot.exp = (int)(slot.Score + (timePlayed / 2.5) + (slot.allDeaths * 1.8) + (slot.objects * 20));
                    slot.gp = (int)(slot.Score + (timePlayed / 3.0) + (slot.allDeaths * 1.8) + (slot.objects * 20));
                    slot.money = (int)((slot.Score / 1.5) + (timePlayed / 4.5) + (slot.allDeaths * 1.1) + (slot.objects * 20));
                    if (rule != 80 && rule != 32)
                    {
                        player._statistic.headshots_count += slot.headshots;
                        player._statistic.kills_count += slot.allKills;
                        player._statistic.totalkills_count += slot.allKills;
                        player._statistic.deaths_count += slot.allDeaths;
                        player._statistic.assist += slot.allAssists;
                        AddKDInfosToQuery(slot, player._statistic, query);
                        AllUtils.updateMatchCountFreeForAll(this, player, SlotWin, query);
                        if (player.Daily != null)
                        {
                            player.Daily.Kills += slot.allKills;
                            player.Daily.Deaths += slot.allDeaths;
                            player.Daily.Headshots += slot.headshots;
                            AddDailyToQuery(slot, player.Daily, query2);
                            AllUtils.UpdateMatchDailyRecordFreeForAll(this, player, SlotWin, query2);
                        }
                    }
                    if (winner == SlotWin)
                    {
                        slot.gp += AllUtils.percentage(slot.gp, 15);
                        slot.exp += AllUtils.percentage(slot.exp, 20);
                    }
                    if (slot.earnedXP > 0)
                    {
                        slot.exp += slot.earnedXP * 5;
                    }
                    slot.exp = slot.exp > GameConfig.maxBattleXP ? GameConfig.maxBattleXP : slot.exp;
                    slot.gp = slot.gp > GameConfig.maxBattleGP ? GameConfig.maxBattleGP : slot.gp;
                    slot.money = slot.money > GameConfig.maxBattleMY ? GameConfig.maxBattleMY : slot.money;
                    if (slot.exp < 0 || slot.gp < 0 || slot.money < 0)
                    {
                        slot.exp = 2;
                        slot.gp = 2;
                        slot.money = 2;
                    }
                    int ItemExp = 0, ItemPoint = 0, EventExp = 0, EventPoint = 0;
                    if (evUp != null || mapEvUse)
                    {
                        if (evUp != null)
                        {
                            EventExp += evUp._percentXp;
                            EventPoint += evUp._percentGp;
                        }
                        if (mapEvUse)
                        {
                            EventExp += evMap._percentXp;
                            EventPoint += evMap._percentGp;
                        }
                        if (!slot.bonusFlags.HasFlag(ResultIcon.Event))
                        {
                            slot.bonusFlags |= ResultIcon.Event;
                        }
                        slot.BonusEventExp += AllUtils.percentage(EventExp, 100);
                        slot.BonusEventPoint += AllUtils.percentage(EventPoint, 100);
                    }
                    PlayerBonus c = player._bonus;
                    if (c != null && c.bonuses > 0)
                    {
                        if ((c.bonuses & 8) == 8)
                        {
                            ItemExp += 100;
                        }
                        if ((c.bonuses & 128) == 128)
                        {
                            ItemPoint += 100;
                        }
                        if ((c.bonuses & 4) == 4)
                        {
                            ItemExp += 50;
                        }
                        if ((c.bonuses & 64) == 64)
                        {
                            ItemPoint += 50;
                        }
                        if ((c.bonuses & 2) == 2)
                        {
                            ItemExp += 30;
                        }
                        if ((c.bonuses & 32) == 32)
                        {
                            ItemPoint += 30;
                        }
                        if ((c.bonuses & 1) == 1)
                        {
                            ItemExp += 10;
                        }
                        if ((c.bonuses & 16) == 16)
                        {
                            ItemPoint += 10;
                        }
                        if (!slot.bonusFlags.HasFlag(ResultIcon.Item))
                        {
                            slot.bonusFlags |= ResultIcon.Item;
                        }
                        slot.BonusItemExp += ItemExp;
                        slot.BonusItemPoint += ItemPoint;
                    }
                    int BonusAllexp = EventExp + slot.BonusCafeExp + slot.BonusItemExp;
                    int BonusAllPoint = EventPoint + slot.BonusCafePoint + slot.BonusItemPoint;
                    slot.BonusEventExp = AllUtils.percentage(slot.exp, BonusAllexp);
                    slot.BonusEventPoint = AllUtils.percentage(slot.gp, BonusAllPoint);
                    player._gp += slot.gp + slot.BonusEventPoint;
                    player._exp += slot.exp + slot.BonusEventExp;
                    if (player.Daily != null)
                    {
                        player.Daily.Point += slot.gp + slot.BonusEventPoint;
                        player.Daily.Exp += slot.exp + slot.BonusEventExp;
                        query2.AddQuery("point", player.Daily.Point);
                        query2.AddQuery("exp", player.Daily.Exp);
                    }
                    if (GameConfig.winCashPerBattle)
                    {
                        player._money += slot.money;
                    }
                    RankModel rank = RankXml.getRank(player._rank);
                    RankModel rank_61 = RankXml.getRank(61);
                    if (rank != null && player._exp >= (rank._onNextLevel + rank._onAllExp) && player._rank <= 50)
                    {
                        List<ItemsModel> items = RankXml.getAwards(player._rank);
                        if (items.Count > 0)
                        {
                            for (int idx = 0; idx < items.Count; idx++)
                            {
                                ItemsModel Item = items[idx];
                                if (Item._id != 0)
                                {
                                    player.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, player, Item));
                                }
                            }
                        }
                        player._gp += rank._onGPUp;
                        player.LastRankUpDate = uint.Parse(finishDate.ToString("yyMMddHHmm"));
                        player.SendPacket(new PROTOCOL_BASE_RANK_UP_ACK(++player._rank, rank._onNextLevel));
                        query.AddQuery("last_rankup_date", (long)player.LastRankUpDate);
                        query.AddQuery("rank", player._rank);
                    }
                    else if (rank != null && player._exp >= rank_61._onAllExp && player._rank == 51)
                    {
                        List<ItemsModel> items = RankXml.getAwards(player._rank);
                        if (items.Count > 0)
                        {
                            for (int idx = 0; idx < items.Count; idx++)
                            {
                                ItemsModel Item = items[idx];
                                if (Item._id != 0)
                                {
                                    player.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, player, Item));
                                }
                            }
                        }
                        player._gp += rank._onGPUp;
                        player.LastRankUpDate = uint.Parse(finishDate.ToString("yyMMddHHmm"));
                        player.SendPacket(new PROTOCOL_BASE_RANK_UP_ACK(61, rank._onNextLevel));
                        query.AddQuery("last_rankup_date", (long)player.LastRankUpDate);
                        query.AddQuery("rank", 61);
                    }
                    else if (rank != null && player._exp >= (rank._onNextLevel + rank._onAllExp) && player._rank <= 110 && player._rank >= 61)
                    {
                        List<ItemsModel> items = RankXml.getAwards(player._rank);
                        if (items.Count > 0)
                        {
                            for (int idx = 0; idx < items.Count; idx++)
                            {
                                ItemsModel Item = items[idx];
                                if (Item._id != 0)
                                {
                                    player.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, player, Item));
                                }
                            }
                        }
                        player._gp += rank._onGPUp;
                        player.LastRankUpDate = uint.Parse(finishDate.ToString("yyMMddHHmm"));
                        player.SendPacket(new PROTOCOL_BASE_RANK_UP_ACK(++player._rank, rank._onNextLevel));
                        query.AddQuery("last_rankup_date", (long)player.LastRankUpDate);
                        query.AddQuery("rank", player._rank);
                    }
                    if (evPt != null)
                    {
                        AllUtils.PlayTimeEvent((long)inBattleTime, player, evPt, false);
                    }
                    AllUtils.DiscountPlayerItems(slot, player);
                    if (gp != player._gp)
                    {
                        query.AddQuery("gp", player._gp);
                    }
                    if (xp != player._exp)
                    {
                        query.AddQuery("exp", player._exp);
                    }
                    if (my != player._money)
                    {
                        query.AddQuery("money", player._money);
                    }
                    ComDiv.updateDB("players", "player_id", player.player_id, query.GetTables(), query.GetValues());
                    ComDiv.updateDB("player_dailyrecord", "player_id", player.player_id, query2.GetTables(), query2.GetValues());
                    if (GameConfig.winCashPerBattle && GameConfig.showCashReceiveWarn)
                    {
                        player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(Translation.GetLabel("CashReceived", slot.money)));
                    }
                }
            }
            updateSlotsInfo();
        }

        private void AddKDInfosToQuery(Slot slot, PlayerStats stats, DBQuery query)
        {
            if (slot.allKills > 0)
            {
                query.AddQuery("kills_count", stats.kills_count);
                query.AddQuery("totalkills_count", stats.totalkills_count);
            }
            if (slot.allAssists > 0)
            {
                query.AddQuery("assist", stats.assist);
            }
            if (slot.allDeaths > 0)
            {
                query.AddQuery("deaths_count", stats.deaths_count);
            }
            if (slot.headshots > 0)
            {
                query.AddQuery("headshots_count", stats.headshots_count);
            }
        }

        private void AddDailyToQuery(Slot slot, PlayerDailyRecord Daily, DBQuery query)
        {
            if (Daily.Kills > 0)
            {
                query.AddQuery("kills", Daily.Kills);
            }
            if (Daily.Deaths > 0)
            {
                query.AddQuery("deaths", Daily.Deaths);
            }
            if (Daily.Headshots > 0)
            {
                query.AddQuery("headshots", Daily.Headshots);
            }
        }

        private void CalculateClanMatchResult(int winnerTeam)
        {
            if (_channelType != 4 || blockedClan)
            {
                return;
            }
            SortedList<int, Clan> list = new SortedList<int, Clan>();
            foreach (Slot slot in _slots)
            {
                Account p;
                if (slot.state == SlotState.BATTLE && getPlayerBySlot(slot, out p))
                {
                    Clan clan = ClanManager.getClan(p.clanId);
                    if (clan._id == 0)
                    {
                        continue;
                    }
                    bool WonTheMatch = (slot._team == winnerTeam);
                    clan._exp += slot.exp;
                    clan.BestPlayers.SetBestExp(slot);
                    clan.BestPlayers.SetBestKills(slot);
                    clan.BestPlayers.SetBestHeadshot(slot);
                    clan.BestPlayers.SetBestWins(p._statistic, slot, WonTheMatch);
                    clan.BestPlayers.SetBestParticipation(p._statistic, slot);
                    if (!list.ContainsKey(p.clanId))
                    {
                        list.Add(p.clanId, clan);
                        if (winnerTeam == 2)
                        {
                            goto UpdateClanFights;
                        }
                        CalculateSpecialCM(clan, winnerTeam, slot._team);
                        if (WonTheMatch)
                        {
                            clan.vitorias++;
                        }
                        else
                        {
                            clan.derrotas++;
                        }
                        UpdateClanFights:
                        PlayerManager.updateClanBattles(clan._id, ++clan.partidas, clan.vitorias, clan.derrotas);
                    }
                }
            }
            foreach (Clan clan in list.Values)
            {
                PlayerManager.updateClanExp(clan._id, clan._exp);
                PlayerManager.updateClanPoints(clan._id, clan._pontos);
                PlayerManager.updateBestPlayers(clan);
                RankModel rankModel = ClanRankXml.getRank(clan._rank);
                if (rankModel != null && clan._exp >= rankModel._onNextLevel + rankModel._onAllExp)
                {
                    PlayerManager.updateClanRank(clan._id, ++clan._rank);
                }
            }
        }

        private void CalculateSpecialCM(Clan clan, int winnerTeam, int teamIdx)
        {
            if (winnerTeam == 2)
            {
                return;
            }
            if (winnerTeam == teamIdx)
            {
                float morePoints = 0;
                if (RoomType == RoomType.DeathMatch)
                {
                    morePoints = (teamIdx == 0 ? _redKills : _blueKills) / 20;
                }
                else
                {
                    morePoints = (teamIdx == 0 ? red_rounds : blue_rounds);
                }
                float POINTS = (25 + morePoints);
                //Logger.warning("Clan: " + clan._id + " Earned Points: " + POINTS);
                clan._pontos += POINTS;
                //Logger.warning("Clan: " + clan._id + " Final Points: " + clan._pontos);
            }
            else
            {
                if (clan._pontos == 0)
                {
                    //Logger.warning("Clã não perdeu Pontos devido a baixa pontuação.");
                    return;
                }
                float morePoints = 0;
                if (RoomType == RoomType.DeathMatch)
                {
                    morePoints = (teamIdx == 0 ? _redKills : _blueKills) / 20;
                }
                else
                {
                    morePoints = (teamIdx == 0 ? red_rounds : blue_rounds);
                }
                float POINTS = (40 - morePoints);
                //Logger.warning("Clan: " + clan._id + " Losed Points: " + POINTS);
                clan._pontos -= POINTS;
                //Logger.warning("Clan: " + clan._id + " Final Points: " + clan._pontos);
            }
        }

        public bool isStartingMatch()
        {
            return RoomState > RoomState.Ready;
        }

        public bool isPreparing()
        {
            return RoomState >= RoomState.Loading;
        }

        public void updateRoomInfo()
        {
            SetSeed();
            using (PROTOCOL_ROOM_CHANGE_ROOMINFO_ACK packet = new PROTOCOL_ROOM_CHANGE_ROOMINFO_ACK(this))
            {
                SendPacketToPlayers(packet);
            }
        }

        public void initSlotCount(int count, bool Change = false)
        {
            MapMatch Match = MapModel.Matchs.Find(x => x.Id == (int)mapId && MapModel.getRule(x.Mode).Rule == rule);
            if (Match != null)
            {
                count = Match.Limit;
            }
            for (int i = 0; i < MapModel.Matchs.Count; i++)
            {
                if (Match.Id == (int)mapId && MapModel.getRule(Match.Mode).Rule == rule)
                {
                    count = Match.Limit;
                }
            }
            if (RoomType == RoomType.Tutorial)
            {
                count = 1;
            }
            if (isBotMode())
            {
                count = 8;
            }
            if (count <= 0)
            {
                count = 1;
            }
            for (int index = 0; index < _slots.Length; ++index)
            {
                if (index >= count)
                {
                    _slots[index].state = SlotState.CLOSE;
                }
            }
            if (Change)
            {
                updateSlotsInfo();
            }
        }

        public int getSlotCount()
        {
            lock (_slots)
            {
                int count = 0;
                for (int index = 0; index < _slots.Length; ++index)
                {
                    if (_slots[index].state != SlotState.CLOSE)
                    {
                        ++count;
                    }
                }
                return count;
            }
        }
        public void SwitchNewSlot(List<SlotChange> slots, Account p, Slot old, int teamIdx, int slotIdx, bool Mode)
        {
            if (Mode)
            {
                Slot slot = _slots[teamIdx];
                if (slot._playerId == 0 && (int)slot.state == 0)
                {
                    slot.state = SlotState.NORMAL;
                    slot._playerId = p.player_id;
                    slot._equip = p._equip;

                    old.state = SlotState.EMPTY;
                    old._playerId = 0;
                    old._equip = null;

                    if (p._slotId == _leader)
                    {
                        _leader = teamIdx;
                    }
                    p._slotId = teamIdx;
                    slots.Add(new SlotChange { oldSlot = old, newSlot = slot });
                }
            }
            else if (slotIdx > 0)
            {
                for (int i = 0; i < GetTeamArray(teamIdx).Length; i++)
                {
                    int index = GetTeamArray(teamIdx)[i];
                    Slot slot = _slots[slotIdx];
                    if (slot._playerId == 0 && (int)slot.state == 0)
                    {
                        slot.state = SlotState.NORMAL;
                        slot._playerId = p.player_id;
                        slot._equip = p._equip;

                        old.state = SlotState.EMPTY;
                        old._playerId = 0;
                        old._equip = null;

                        if (p._slotId == _leader)
                        {
                            _leader = slotIdx;
                        }
                        //Logger.LogProblems("[Room.SwitchNewSlot] PlayerId '" + p.player_id + "' '" + p.player_name + "'; OldSlot: " + p._slotId + "; NewSlot: " + index, "ErrorC");
                        p._slotId = slotIdx;
                        slots.Add(new SlotChange { oldSlot = old, newSlot = slot });
                        break;
                    }
                }
            }
            else
            {
                Slot slot = _slots[slotIdx];
                if (slot._playerId == 0 && (int)slot.state == 0)
                {
                    slot.state = SlotState.NORMAL;
                    slot._playerId = p.player_id;
                    slot._equip = p._equip;

                    old.state = SlotState.EMPTY;
                    old._playerId = 0;
                    old._equip = null;

                    if (p._slotId == _leader)
                    {
                        _leader = slotIdx;
                    }
                    p._slotId = slotIdx;
                    slots.Add(new SlotChange { oldSlot = old, newSlot = slot });
                }
            }
        }

        public void SwitchSlots(List<SlotChange> slots, int newSlotId, int oldSlotId, bool changeReady)
        {
            Slot newSLOT = _slots[newSlotId];
            Slot oldSLOT = _slots[oldSlotId];

            if (changeReady)
            {
                if (newSLOT.state == SlotState.READY)
                {
                    newSLOT.state = SlotState.NORMAL;
                }
                if (oldSLOT.state == SlotState.READY)
                {
                    oldSLOT.state = SlotState.NORMAL;
                }
            }

            newSLOT.SetSlotId(oldSlotId);
            oldSLOT.SetSlotId(newSlotId);

            _slots[newSlotId] = oldSLOT;
            _slots[oldSlotId] = newSLOT;
            slots.Add(new SlotChange { oldSlot = newSLOT, newSlot = oldSLOT });
        }

        public void changeSlotState(int slotId, SlotState state, bool sendInfo)
        {
            Slot slot = getSlot(slotId);
            changeSlotState(slot, state, sendInfo);
        }

        public void changeSlotState(Slot slot, SlotState state, bool sendInfo)
        {
            if (slot == null || slot.state == state)
            {
                return;
            }
            slot.state = state;
            if ((int)state == 0 || (int)state == 1)
            {
                AllUtils.ResetSlotInfo(this, slot, false);
                slot._playerId = 0;
            }
            if (sendInfo)
            {
                updateSlotsInfo();
            }
        }

        public Account getPlayerBySlot(Slot slot)
        {
            try
            {
                long id = slot._playerId;
                return id > 0 ? AccountManager.getAccount(id, true) : null;
            }
            catch
            {
                return null;
            }
        }

        public Account getPlayerBySlot(int slotId)
        {
            try
            {
                long id = _slots[slotId]._playerId;
                return id > 0 ? AccountManager.getAccount(id, true) : null;
            }
            catch
            {
                return null;
            }
        }

        public bool getPlayerBySlot(int slotId, out Account player)
        {
            try
            {
                long id = _slots[slotId]._playerId;
                player = id > 0 ? AccountManager.getAccount(id, true) : null;
                return player != null;
            }
            catch
            {
                player = null;
                return false;
            }
        }

        public bool getPlayerBySlot(Slot slot, out Account player)
        {
            try
            {
                long id = slot._playerId;
                player = id > 0 ? AccountManager.getAccount(id, true) : null;
                return player != null;
            }
            catch
            {
                player = null;
                return false;
            }
        }

        public int getTimeByMask()
        {
            return TIMES[killtime >> 4];
        }

        public int getRoundsByMask()
        {
            return ROUNDS[killtime & 15];
        }

        public int getKillsByMask()
        {
            return KILLS[killtime & 15];
        }

        public void updateSlotsInfo()
        {
            using (PROTOCOL_ROOM_GET_SLOTINFO_ACK packet = new PROTOCOL_ROOM_GET_SLOTINFO_ACK(this))
            {
                SendPacketToPlayers(packet);
            }
        }

        public bool getLeader(out Account p)
        {
            p = null;
            if (getAllPlayers().Count <= 0)
            {
                return false;
            }
            if (_leader == -1)
            {
                setNewLeader(-1, 0, -1, false);
            }
            if (_leader >= 0)
            {
                p = AccountManager.getAccount(_slots[_leader]._playerId, true);
            }
            return p != null;
        }

        public Account getLeader()
        {
            if (getAllPlayers().Count <= 0)
            {
                return null;
            }
            if (_leader == -1)
            {
                setNewLeader(-1, 0, -1, false);
            }
            return _leader == -1 ? null : AccountManager.getAccount(_slots[_leader]._playerId, true);
        }

        public void setNewLeader(int leader, int state, int oldLeader, bool updateInfo)
        {
            Monitor.Enter(_slots);
            if (leader == -1)
            {
                for (int i = 0; i < 16; ++i)
                {
                    Slot slot = _slots[i];
                    if (i != oldLeader && slot._playerId > 0 && (int)slot.state > state)
                    {
                        _leader = i;
                        break;
                    }
                }
            }
            else
            {
                _leader = leader;
            }
            if (_leader != -1)
            {
                Slot slot = _slots[_leader];
                if ((int)slot.state == 9)
                {
                    slot.state = SlotState.NORMAL;
                }
                if (updateInfo)
                {
                    updateSlotsInfo();
                }
            }
            Monitor.Exit(_slots);
        }

        public void SendPacketToPlayers(SendPacket packet)
        {
            List<Account> players = getAllPlayers();
            if (players.Count == 0)
            {
                return;
            }

            byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket)");
            foreach (Account player in players)
            {
                player.SendCompletePacket(data);
            }
        }

        public void SendPacketToPlayers(SendPacket packet, long player_id)
        {
            List<Account> players = getAllPlayers(player_id);
            if (players.Count == 0)
            {
                return;
            }

            byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,long)");
            foreach (Account player in players)
            {
                player.SendCompletePacket(data);
            }
        }

        public void SendPacketToPlayers(SendPacket packet, SlotState state, int type)
        {
            List<Account> players = getAllPlayers(state, type);
            if (players.Count == 0)
            {
                return;
            }
            byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,SLOT_STATE,int)");
            for (int i = 0; i < players.Count; i++)
            {
                players[i].SendCompletePacket(data);
            }
        }

        public void SendPacketToPlayers(SendPacket packet, SendPacket packet2, SlotState state, int type)
        {
            List<Account> players = getAllPlayers(state, type);
            if (players.Count == 0)
            {
                return;
            }

            byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,SendPacket,SLOT_STATE,int)-1");
            byte[] data2 = packet2.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,SendPacket,SLOT_STATE,int)-2");
            foreach (Account pR in players)
            {
                pR.SendCompletePacket(data);
                pR.SendCompletePacket(data2);
            }
        }

        public void SendPacketToPlayers(SendPacket packet, SlotState state, int type, int exception)
        {
            List<Account> players = getAllPlayers(state, type, exception);
            if (players.Count == 0)
            {
                return;
            }

            byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,SLOT_STATE,int,int)");
            foreach (Account player in players)
            {
                player.SendCompletePacket(data);
            }
        }

        public void SendPacketToPlayers(SendPacket packet, SlotState state, int type, int exception, int exception2)
        {
            List<Account> players = getAllPlayers(state, type, exception, exception2);
            if (players.Count == 0)
            {
                return;
            }

            byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,SLOT_STATE,int,int,int)");
            foreach (Account player in players)
            {
                player.SendCompletePacket(data);
            }
        }

        public void RemovePlayer(Account player, bool WarnAllPlayers, int quitMotive = 0)
        {
            Slot slot;
            if (player == null || !getSlot(player._slotId, out slot))
            {
                return;
            }
            BaseRemovePlayer(player, slot, WarnAllPlayers, quitMotive);
        }

        public void RemovePlayer(Account player, Slot slot, bool WarnAllPlayers, int quitMotive = 0)
        {
            if (player == null || slot == null)
            {
                return;
            }
            BaseRemovePlayer(player, slot, WarnAllPlayers, quitMotive);
        }

        private void BaseRemovePlayer(Account player, Slot slot, bool WarnAllPlayers, int quitMotive)
        {
            Monitor.Enter(_slots);
            bool useRoomUpdate = false, hostChanged = false;
            if (player != null && slot != null)
            {
                if ((int)slot.state >= 10)
                {
                    if (_leader == slot._id)
                    {
                        int oldLeader = _leader, bestState = 1;
                        if (RoomState == RoomState.Battle)
                        {
                            bestState = 14;
                        }
                        else if (RoomState >= RoomState.Loading)
                        {
                            bestState = 9;
                        }
                        if (getAllPlayers(slot._id).Count >= 1)
                        {
                            setNewLeader(-1, bestState, _leader, false);
                        }
                        if (getPlayingPlayers(2, SlotState.READY, 1) >= 2)
                        {
                            using (PROTOCOL_BATTLE_LEAVEP2PSERVER_ACK packet = new PROTOCOL_BATTLE_LEAVEP2PSERVER_ACK(this))
                            {
                                SendPacketToPlayers(packet, SlotState.RENDEZVOUS, 1, slot._id);
                            }
                        }
                        hostChanged = true;
                    }
                    using (PROTOCOL_BATTLE_GIVEUPBATTLE_ACK packet = new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(player, quitMotive))
                    {
                        SendPacketToPlayers(packet, SlotState.READY, 1, !WarnAllPlayers ? slot._id : -1);
                    }
                    BattleLeaveSync.SendUDPPlayerLeave(this, slot._id);
                    slot.ResetSlot();
                    if (votekick != null)
                    {
                        votekick.TotalArray[slot._id] = false;
                    }
                }
                slot._playerId = 0;
                slot._equip = null;
                slot.state = SlotState.EMPTY;
                if (RoomState == RoomState.CountDown)
                {
                    if (slot._id == _leader)
                    {
                        RoomState = RoomState.Ready;
                        useRoomUpdate = true;
                        countdown.Timer = null;
                        using (PROTOCOL_BATTLE_START_COUNTDOWN_ACK packet = new PROTOCOL_BATTLE_START_COUNTDOWN_ACK(CountDownEnum.StopByHost))
                        {
                            SendPacketToPlayers(packet);
                        }
                    }
                    else if (getPlayingPlayers(slot._team, SlotState.READY, 0) == 0)
                    {
                        if (slot._id != _leader)
                        {
                            changeSlotState(_leader, SlotState.NORMAL, false);
                        }
                        StopCountDown(CountDownEnum.StopByPlayer, false);
                        useRoomUpdate = true;
                    }
                }
                else if (isPreparing())
                {
                    AllUtils.BattleEndPlayersCount(this, isBotMode());
                    if (RoomState == RoomState.Battle)
                    {
                        AllUtils.BattleEndRoundPlayersCount(this);
                    }
                }
                CheckToEndWaitingBattle(hostChanged);
                requestHost.Remove(player.player_id);
                if (vote.Timer != null && votekick != null && votekick.victimIdx == player._slotId && quitMotive != 2)
                {
                    vote.Timer = null;
                    votekick = null;
                    using (PROTOCOL_BATTLE_NOTIFY_KICKVOTE_CANCEL_ACK packet = new PROTOCOL_BATTLE_NOTIFY_KICKVOTE_CANCEL_ACK())
                    {
                        SendPacketToPlayers(packet, SlotState.BATTLE, 0);
                    }
                }
                Match match = player._match;
                if (match != null && player.matchSlot >= 0)
                {
                    match._slots[player.matchSlot].state = SlotMatchState.Normal;
                    using (PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK packet = new PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK(match))
                    {
                        match.SendPacketToPlayers(packet);
                    }
                }
                player._room = null;
                //Logger.LogProblems("[Room.RemovePlayer] PlayerId '" + player.player_id + "' '" + player.player_name + "'; OldSlot: " + player._slotId + "; NewSlot: -1", "ErrorC");
                player._slotId = -1;
                player._status.updateRoom(255);
                AllUtils.syncPlayerToClanMembers(player);
                AllUtils.syncPlayerToFriends(player, false);
                player.updateCacheInfo();
            }
            updateSlotsInfo();
            if (useRoomUpdate)
            {
                updateRoomInfo();
            }
            Monitor.Exit(_slots);
        }

        public int addPlayer(Account p)
        {
            lock (_slots)
            {
                for (int i = 0; i < 16; i++)
                {
                    Slot slot = _slots[i];
                    if (slot._playerId == 0 && (int)slot.state == 0)
                    {
                        slot._playerId = p.player_id;
                        slot.state = SlotState.NORMAL;
                        p._room = this;
                        //Logger.LogProblems("[Room.AddPlayer] PlayerId '" + p.player_id + "' '" + p.player_name + "'; OldSlot: " + p._slotId + "; NewSlot: " + i, "ErrorC");
                        p._slotId = i;
                        slot._equip = p._equip;
                        p._status.updateRoom((byte)_roomId);
                        AllUtils.syncPlayerToClanMembers(p);
                        AllUtils.syncPlayerToFriends(p, false);
                        p.updateCacheInfo();
                        return i;
                    }
                }
            }
            return -1;
        }

        public int addPlayer(Account p, int teamIdx)
        {
            int[] array = GetTeamArray(teamIdx);
            lock (_slots)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int SlotIdx = array[i];
                    Slot slot = _slots[SlotIdx];
                    if (slot._playerId == 0 && (int)slot.state == 0)
                    {
                        slot._playerId = p.player_id;
                        slot.state = SlotState.NORMAL;
                        p._room = this;
                        //Logger.LogProblems("[Room.AddPlayer] PlayerId '" + p.player_id + "' '" + p.player_name + "'; OldSlot: " + p._slotId + "; NewSlot: " + i, "ErrorC");
                        p._slotId = SlotIdx;
                        slot._equip = p._equip;
                        p._status.updateRoom((byte)_roomId);
                        AllUtils.syncPlayerToClanMembers(p);
                        AllUtils.syncPlayerToFriends(p, false);
                        p.updateCacheInfo();
                        return SlotIdx;
                    }
                }
            }
            return -1;
        }

        public int[] GetTeamArray(int index)
        {
            return (index == 0 ? RED_TEAM : BLUE_TEAM);
        }

        public List<Account> getAllPlayers(SlotState state, int type)
        {
            List<Account> list = new List<Account>();
            lock (_slots)
            {
                for (int i = 0; i < _slots.Length; ++i)
                {
                    Slot slot = _slots[i];
                    long id = slot._playerId;
                    if (id > 0 && (type == 0 && slot.state == state || type == 1 && slot.state > state))
                    {
                        Account player = AccountManager.getAccount(id, true);
                        if (player != null && player._slotId != -1)
                        {
                            list.Add(player);
                        }
                    }
                }
            }
            return list;
        }

        public List<Account> getAllPlayers(SlotState state, int type, int exception)
        {
            List<Account> list = new List<Account>();
            lock (_slots)
            {
                for (int i = 0; i < _slots.Length; ++i)
                {
                    Slot slot = _slots[i];
                    long id = slot._playerId;
                    if (id > 0 && i != exception && (type == 0 && slot.state == state || type == 1 && slot.state > state))
                    {
                        Account player = AccountManager.getAccount(id, true);
                        if (player != null && player._slotId != -1)
                        {
                            list.Add(player);
                        }
                    }
                }
            }
            return list;
        }

        public List<Account> getAllPlayers(SlotState state, int type, int exception, int exception2)
        {
            List<Account> list = new List<Account>();
            lock (_slots)
            {
                for (int i = 0; i < _slots.Length; ++i)
                {
                    Slot slot = _slots[i];
                    long id = slot._playerId;
                    if (id > 0 && i != exception && i != exception2 && (type == 0 && slot.state == state || type == 1 && slot.state > state))
                    {
                        Account player = AccountManager.getAccount(id, true);
                        if (player != null && player._slotId != -1)
                        {
                            list.Add(player);
                        }
                    }
                }
            }
            return list;
        }

        public List<Account> getAllPlayers(int exception)
        {
            List<Account> list = new List<Account>();
            lock (_slots)
            {
                for (int i = 0; i < _slots.Length; ++i)
                {
                    long id = _slots[i]._playerId;
                    if (id > 0 && i != exception)
                    {
                        Account player = AccountManager.getAccount(id, true);
                        if (player != null && player._slotId != -1)
                        {
                            list.Add(player);
                        }
                    }
                }
            }
            return list;
        }

        public List<Account> getAllPlayers(long exception)
        {
            List<Account> list = new List<Account>();
            lock (_slots)
            {
                for (int i = 0; i < _slots.Length; ++i)
                {
                    long id = _slots[i]._playerId;
                    if (id > 0 && id != exception)
                    {
                        Account player = AccountManager.getAccount(id, true);
                        if (player != null && player._slotId != -1)
                        {
                            list.Add(player);
                        }
                    }
                }
            }
            return list;
        }

        public List<Account> getAllPlayers()
        {
            List<Account> list = new List<Account>();
            lock (_slots)
            {
                for (int i = 0; i < _slots.Length; ++i)
                {
                    long id = _slots[i]._playerId;
                    if (id > 0)
                    {
                        Account player = AccountManager.getAccount(id, true);
                        if (player != null && player._slotId != -1)
                        {
                            list.Add(player);
                        }
                    }
                }
            }
            return list;
        }

        public int getPlayingPlayers(int team, bool inBattle)
        {
            int players = 0;
            lock (_slots)
            {
                foreach (Slot slot in _slots)
                {
                    if (slot._playerId > 0 && (slot._team == team || team == 2) && (inBattle && (int)slot.state == 13 && !slot.espectador || !inBattle && (int)slot.state >= 10))
                    {
                        players++;
                    }
                }
            }
            return players;
        }

        public int getPlayingPlayers(int team, SlotState state, int type)
        {
            int players = 0;
            lock (_slots)
            {
                foreach (Slot slot in _slots)
                {
                    if (slot._playerId > 0 && (type == 0 && slot.state == state || type == 1 && slot.state > state) && (team == 2 || slot._team == team))
                    {
                        players++;
                    }
                }
            }
            return players;
        }

        public int getPlayingPlayers(int team, SlotState state, int type, int exception)
        {
            int players = 0;
            lock (_slots)
            {
                for (int i = 0; i < 16; i++)
                {
                    Slot slot = _slots[i];
                    if (i != exception && slot._playerId > 0 && (type == 0 && slot.state == state || type == 1 && slot.state > state) && (team == 2 || slot._team == team))
                    {
                        players++;
                    }
                }
            }
            return players;
        }

        public void getPlayingPlayers(bool inBattle, out int RedPlayers, out int BluePlayers)
        {
            RedPlayers = 0;
            BluePlayers = 0;
            lock (_slots)
            {
                foreach (Slot slot in _slots)
                {
                    if (slot._playerId > 0 && (inBattle && (int)slot.state == 15 && !slot.espectador || !inBattle && (int)slot.state >= 11))
                    {
                        if (slot._team == 0)
                        {
                            RedPlayers++;
                        }
                        else
                        {
                            BluePlayers++;
                        }
                    }
                }
            }
        }

        public void getPlayingPlayers(bool inBattle, out int RedPlayers, out int BluePlayers, out int RedDeaths, out int BlueDeaths)
        {
            RedPlayers = 0;
            BluePlayers = 0;
            RedDeaths = 0;
            BlueDeaths = 0;
            lock (_slots)
            {
                foreach (Slot slot in _slots)
                {
                    if (slot._deathState.HasFlag(DeadEnum.Dead))
                    {
                        if (slot._team == 0)
                        {
                            RedDeaths++;
                        }
                        else
                        {
                            BlueDeaths++;
                        }
                    }
                    if (slot._playerId > 0 && (inBattle && (int)slot.state == 15 && !slot.espectador || !inBattle && (int)slot.state >= 11))
                    {
                        if (slot._team == 0)
                        {
                            RedPlayers++;
                        }
                        else
                        {
                            BluePlayers++;
                        }
                    }
                }
            }
        }

        public void CheckToEndWaitingBattle(bool host)
        {
            //Logger.warning("state: " + RoomState "; leader: " + _slots[_leader].state);
            if ((RoomState == RoomState.CountDown || RoomState == RoomState.Loading || RoomState == RoomState.Rendezvous) && (host || _slots[_leader].state == SlotState.BATTLE_READY))
            {
                AllUtils.EndBattleNoPoints(this);
            }
        }

        public void SpawnReadyPlayers()
        {
            lock (_slots)
            {
                BaseSpawnReadyPlayers(isBotMode());
            }
        }

        public void SpawnReadyPlayers(bool isBotMode)
        {
            lock (_slots)
            {
                BaseSpawnReadyPlayers(isBotMode);
            }
        }

        private void BaseSpawnReadyPlayers(bool isBotMode)
        {
            bool dinoStart = false;
            using (PROTOCOL_BATTLE_COUNT_DOWN_ACK packet5 = new PROTOCOL_BATTLE_COUNT_DOWN_ACK(0))
            {
                if (RoomState == RoomState.PreBattle && Countdown == false && isBotMode == false)
                {
                    Countdown = true;
                    SendPacketToPlayers(packet5);
                }
                countdownstart.Start(3250, (callbackState) =>
                {
                    try
                    {
                        DateTime date = DateTime.Now;
                        foreach (Slot slot in _slots)
                        {
                            if ((int)slot.state >= 14 && slot.isPlaying == 0 && slot._playerId > 0)
                            {
                                slot.isPlaying = 1;
                                slot.startTime = date;
                                slot.state = SlotState.BATTLE;
                                if (RoomState == RoomState.Battle && (RoomType == RoomType.Bomb || RoomType == RoomType.Annihilation || RoomType == RoomType.Convoy))
                                {
                                    slot.espectador = true;
                                }
                            }
                        }
                        updateSlotsInfo();
                        List<int> dinos = AllUtils.getDinossaurs(this, false, -1);
                        if (RoomState == RoomState.PreBattle)
                        {
                            BattleStart = RoomType == RoomType.Bomb || RoomType == RoomType.CrossCounter || RoomType == RoomType.Ace ? date.AddMinutes(5) : date;
                            SetSpecialStage();
                        }
                        using (PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK(this, dinos, isBotMode))
                        {
                            using (PROTOCOL_BATTLE_MISSION_ROUND_START_ACK packet2 = new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(this))
                            {
                                using (PROTOCOL_BATTLE_RECORD_ACK packet3 = new PROTOCOL_BATTLE_RECORD_ACK(this))
                                {
                                    byte[] data = packet.GetCompleteBytes("Room.BaseSpawnReadyPlayers-1");
                                    byte[] data2 = packet2.GetCompleteBytes("Room.BaseSpawnReadyPlayers-2");
                                    byte[] data3 = packet3.GetCompleteBytes("Room.BaseSpawnReadyPlayers-3");
                                    foreach (Slot slot in _slots)
                                    {
                                        Account player;
                                        if ((int)slot.state >= 15 && slot.isPlaying == 1 && getPlayerBySlot(slot, out player))
                                        {
                                            slot.isPlaying = 2;
                                            if (RoomState == RoomState.PreBattle)
                                            {
                                                using (PROTOCOL_BATTLE_STARTBATTLE_ACK packet4 = new PROTOCOL_BATTLE_STARTBATTLE_ACK(slot, player, dinos, isBotMode, true))
                                                {
                                                    SendPacketToPlayers(packet4, SlotState.READY, 1);
                                                }
                                                player.SendCompletePacket(data);
                                                if (RoomType == RoomType.Boss || RoomType == RoomType.CrossCounter)
                                                {
                                                    dinoStart = false;
                                                }
                                                else
                                                {
                                                    player.SendCompletePacket(data2);
                                                }
                                            }
                                            else if (RoomState == RoomState.Battle)
                                            {
                                                using (PROTOCOL_BATTLE_STARTBATTLE_ACK packet4 = new PROTOCOL_BATTLE_STARTBATTLE_ACK(slot, player, dinos, isBotMode, false))
                                                {
                                                    SendPacketToPlayers(packet4, SlotState.READY, 1);
                                                }
                                                if (RoomType == RoomType.Bomb || RoomType == RoomType.Annihilation || RoomType == RoomType.Ace || RoomType == RoomType.Convoy)
                                                {
                                                    GameSync.SendUDPPlayerSync(this, slot, 0, 1);
                                                }
                                                else
                                                {
                                                    player.SendCompletePacket(data);
                                                }
                                                player.SendCompletePacket(data2);
                                                player.SendCompletePacket(data3);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.warning("[Room.StartCountDown] " + ex.ToString());
                    }
                    lock (callbackState)
                    {
                        countdownstart.Timer = null;
                    }
                    if (RoomState == RoomState.PreBattle)
                    {
                        RoomState = RoomState.Battle;
                        updateRoomInfo();
                    }
                    if (dinoStart)
                    {
                        StartDinoRound();
                    }
                });
            }
        }
        private void StartDinoRound()
        {
            round.Start(5250, (callbackState) =>
            {
                if (RoomState == RoomState.Battle)
                {
                    using (PROTOCOL_BATTLE_MISSION_ROUND_START_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(this))
                    {
                        SendPacketToPlayers(packet, SlotState.BATTLE, 0);
                    }
                    swapRound = false;
                }
                lock (callbackState)
                {
                    round.Timer = null;
                }
            });
        }
    }
}
    
/*public class Room
{
    public Slot[] _slots = new Slot[16];
    public int seedvalue, _channelType, rounds = 1, TRex = -1, blue_rounds, blue_dino, red_rounds, red_dino, Bar1, Bar2, _ping = 5, _redKills, _redDeaths, _redAssists, _blueKills, _blueDeaths, _blueAssists, spawnsCount, rule, killtime, _roomId, _channelId, _leader, leaderip;
    public byte Limit, WatchRuleFlag, aiCount = 1, IngameAiLevel, aiLevel, aiType, stage, BattleCountdown, KillCam, State;
    public short BalanceType;
    public bool Countdown = false;
    public readonly int[] TIMES = new int[11]
    {
        3, 3, 3, 5, 7, 5, 10, 15, 20, 25, 30
    },
        KILLS = new int[9]
    {
        15, 30, 50, 60, 80, 100, 120, 140, 160
    },
        ROUNDS = new int[6]
    {
        1, 2, 3, 5, 7, 9
    },
        RED_TEAM = new int[8]
    {
        0, 2, 4, 6, 8, 10, 12, 14
    },
        BLUE_TEAM = new int[8]
    {
        1, 3, 5, 7, 9, 11, 13, 15
    };
    public byte[] HitParts = new byte[35], DefaultParts = new byte[35]
    {
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
        16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
        30, 31, 32, 33, 34,
    };
    public byte[] RandomMaps, RoomLeaderIP;
    public uint _timeRoom, StartDate, UniqueRoomId, Seed;
    public long StartTick;
    public string name, password, _mapName, leader_name;
    public Core.Models.Room.VoteKick votekick;
    public MapIdEnum mapId;
    public RoomType RoomType;
    public RoomState RoomState;
    public GameRuleFlag RuleFlag = GameRuleFlag.None;
    public RoomStageFlag Flag = RoomStageFlag.NONE;
    public RoomWeaponsFlag weaponsFlag = RoomWeaponsFlag.None;
    public bool C4_actived, swapRound, changingSlots, blockedClan, ShotgunMode, SniperMode;
    public BattleServer UdpServer;
    public DateTime BattleStart, LastPingSync = DateTime.Now;
    public TimerState bomb = new TimerState(), countdown = new TimerState(), round = new TimerState(), vote = new TimerState(), countdownstart = new TimerState();
    public SafeList<long> kickedPlayers = new SafeList<long>(), requestHost = new SafeList<long>();
    public bool GameRuleActive = false;
    public bool ShotgunActive = false;
    public bool BarrettActive = false;
    public bool MaskActive = false;
    public bool RPG7Active = false;
    public bool GameRuleWCActive = false;
    public List<GameRule> GameRules = new List<GameRule>();

    public Room(int roomId, Channel ch)
    {
        _roomId = roomId;
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i] = new Slot(i);
        }
        _channelId = ch._id;
        _channelType = ch._type;
        SetUniqueId();
        GameRules = GameRuleManager.getGameRules(GameConfig.ruleId);
    }

    public bool thisModeHaveCD()
    {
        RoomType stageType = RoomType;
        return (stageType == RoomType.Bomb ||
                stageType == RoomType.Annihilation ||
                stageType == RoomType.Boss ||
                stageType == RoomType.CrossCounter ||
                stageType == RoomType.Convoy ||
                stageType == RoomType.Ace);
    }

    public bool thisModeHaveRounds()
    {
        RoomType stageType = RoomType;
        return (stageType == RoomType.Bomb ||
                stageType == RoomType.Destroy ||
                stageType == RoomType.Annihilation ||
                stageType == RoomType.Defense ||
                stageType == RoomType.Convoy ||
                stageType == RoomType.Ace);
    }

    public int getFlag()
    {
        int Result = 0;
        if (Flag.HasFlag(RoomStageFlag.OBSERVER))
        {
            Result += 0;
        }
        if (Flag.HasFlag(RoomStageFlag.TEAM_SWAP))
        {
            Result += 1;
        }
        if (Flag.HasFlag(RoomStageFlag.RANDOM_MAP))
        {
            Result += 2;
        }
        if (Flag.HasFlag(RoomStageFlag.PASSWORD) || password.Length > 0)
        {
            Result += 4;
        }
        if (BalanceType == 1)
        {
            Result += 32;
        }
        if (Limit > 0 && RoomState > RoomState.Ready)
        {
            Result += 128;
        }
        Flag = (RoomStageFlag)Result;
        Console.WriteLine("Current room Flag = " + Flag);
        return Result;
    }

    public void LoadHitParts()
    {
        Random rnd = new Random();
        int next = rnd.Next(34);
        byte[] MyRandomArray = DefaultParts.OrderBy(x => x <= next).ToArray();

        Logger.warning("Idx: " + next + "/ Hits: " + BitConverter.ToString(MyRandomArray));
        HitParts = MyRandomArray;

        byte[] newarray = new byte[35];
        for (int i = 0; i < 35; i++)
        {
            byte valor = HitParts[i];
            newarray[((i + 8) % 35)] = valor;
        }
        Logger.warning("Array: " + BitConverter.ToString(newarray));
    }

    private void SetUniqueId()
    {
        UniqueRoomId = (uint)((GameConfig.serverId & 0xff) << 20 | (_channelId & 0xff) << 12 | _roomId & 0xfff);
    }
    public void SetSeed()
    {
        Seed = (uint)(((int)mapId & 0xff) << 20 | (rule & 0xff) << 12 | (int)RoomType & 0xfff);
    }
    public void SetBotLevel()
    {
        if (!isBotMode())
        {
            return;
        }
        IngameAiLevel = aiLevel;
        for (int i = 0; i < 16; i++)
        {
            _slots[i].aiLevel = IngameAiLevel;
        }
    }

    public bool isBotMode()
    {
        return stage == 2 || stage == 4 || stage == 6;
    }
    public bool isTutorialMode()
    {
        return mapId == MapIdEnum.Tutorial;
    }
    private void SetSpecialStage()
    {
        if (RoomType == RoomType.Defense)
        {
            if (mapId == MapIdEnum.BlackPanther)
            {
                Bar1 = 6000;
                Bar2 = 9000;
            }
        }
        else if (RoomType == RoomType.Destroy)
        {
            if (mapId == MapIdEnum.Hospital)
            {
                Bar1 = 12000;
                Bar2 = 12000;
            }
            else if (mapId == MapIdEnum.BreakDown)
            {
                Bar1 = 6000;
                Bar2 = 6000;
            }
        }
    }

    public int getInBattleTime()
    {
        int seconds = 0;
        if (BattleStart != new DateTime() && (RoomState == RoomState.Battle || RoomState == RoomState.PreBattle))
        {
            DateTime now = DateTime.Now;
            seconds = (int)(now - BattleStart).TotalSeconds;
            if (seconds < 0)
            {
                seconds = 0;
            }
        }
        return seconds;
    }

    public int getInBattleTimeLeft()
    {
        int remaining = getInBattleTime();
        return ((getTimeByMask() * 60) - remaining);
    }

    public Channel getChannel()
    {
        return ChannelsXml.getChannel(_channelId);
    }

    public bool getChannel(out Channel ch)
    {
        ch = ChannelsXml.getChannel(_channelId);
        return ch != null;
    }

    public bool getSlot(int slotIdx, out Slot slot)
    {
        slot = null;
        lock (_slots)
        {
            if (slotIdx >= 0 && slotIdx <= 16)
            {
                slot = _slots[slotIdx];
            }
            return slot != null;
        }
    }

    public Slot getSlot(int slotIdx)
    {
        lock (_slots)
        {
            if (slotIdx >= 0 && slotIdx <= 16)
            {
                return _slots[slotIdx];
            }
            return null;
        }
    }

    public void StartCounter(int type, Account player, Slot slot)
    {
        int dueTime = 0;
        //EventErrorEnum error = 0;
        if (type == 0)
        {
            //error = EventErrorEnum.BATTLE_FIRST_MAINLOAD;
            //dueTime = 90000;
        }
        //else if (type == 1)
        //{
        //    error = EventErrorEnum.BATTLE_FIRST_HOLE;
        //    dueTime = 30000;
        //}
        else
        {
            return;
        }
        slot.timing.Start(dueTime, (callbackState) =>
        {
            //BaseCounter(error, player, slot);
            lock (callbackState)
            {
                if (slot != null)
                {
                    slot.StopTiming();
                }
            }
        });
    }

    private void BaseCounter(EventErrorEnum error, Account player, Slot slot)
    {
        player.SendPacket(new PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK(error));
        player.SendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(player, 0));
        slot.state = SlotState.NORMAL;
        AllUtils.BattleEndPlayersCount(this, isBotMode());
        updateSlotsInfo();
    }

    public void StartBomb()
    {
        try
        {
            bomb.Start(42000, (callbackState) =>
            {
                if (this != null && C4_actived)
                {
                    red_rounds++;
                    C4_actived = false;
                    AllUtils.BattleEndRound(this, 0, RoundEndType.BombFire);
                }
                lock (callbackState)
                {
                    bomb.Timer = null;
                }
            });
        }
        catch (Exception ex)
        {
            Logger.warning("StartBomb: " + ex.ToString());
        }
    }

    public void StartVote()
    {
        try
        {
            if (votekick == null)
            {
                return;
            }

            vote.Start(20000, (callbackState) =>
            {
                AllUtils.votekickResult(this);
                lock (callbackState)
                {
                    vote.Timer = null;
                }
            });
        }
        catch (Exception ex)
        {
            Logger.warning("StartVote: " + ex.ToString());
            if (vote.Timer != null)
            {
                vote.Timer = null;
            }
            votekick = null;
        }
    }

    public void RoundRestart()
    {
        try
        {
            StopBomb();
            foreach (Slot s in _slots)
            {
                if (s._playerId > 0 && (int)s.state == 15)
                {
                    if (!s._deathState.HasFlag(DeadEnum.UseChat))
                    {
                        s._deathState |= DeadEnum.UseChat;
                    }
                    if (s.espectador)
                    {
                        s.espectador = false;
                    }
                    if (s.killsOnLife >= 3 && RoomType == RoomType.Annihilation)
                    {
                        s.objects++;
                    }
                    if (s.killsOnLife >= 3 && RoomType == RoomType.Ace)
                    {
                        s.objects++;
                    }
                    s.killsOnLife = 0;
                    s.lastKillState = 0;
                    s.repeatLastState = false;
                    s.damageBar1 = 0;
                    s.damageBar2 = 0;
                }
            }
            round.Start(8000, (callbackState) =>
            {
                foreach (Slot s in _slots)
                {
                    if (s._playerId > 0)
                    {
                        if (!s._deathState.HasFlag(DeadEnum.UseChat))
                        {
                            s._deathState |= DeadEnum.UseChat;
                        }
                        if (s.espectador)
                        {
                            s.espectador = false;
                        }
                    }
                }
                StopBomb();
                DateTime now = DateTime.Now;
                if (RoomState == RoomState.Battle)
                {
                    BattleStart = RoomType == RoomType.Boss || RoomType == RoomType.CrossCounter ? now.AddSeconds(5) : now;
                }
                using (PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK(this))
                {
                    using (PROTOCOL_BATTLE_MISSION_ROUND_START_ACK packet2 = new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(this))
                    {
                        SendPacketToPlayers(packet, packet2, SlotState.BATTLE, 0);
                    }
                }
                StopBomb();
                swapRound = false;
                //AllUtils.LogRoomRoundRestart(this);
                lock (callbackState)
                {
                    round.Timer = null;
                }
            });
        }
        catch (Exception ex)
        {
            Logger.warning("[Room.RoundRestart] " + ex.ToString());
        }
    }

    public void StopBomb()
    {
        if (!C4_actived)
        {
            return;
        }
        C4_actived = false;
        if (bomb != null)
        {
            bomb.Timer = null;
        }
    }

    public void StartBattle(bool updateInfo)
    {
        Monitor.Enter(_slots);
        RoomState = RoomState.Loading;
        requestHost.Clear();
        UdpServer = BattleServerXml.GetRandomServer();
        StartTick = DateTime.Now.Ticks;
        StartDate = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
        SetBotLevel();
        AllUtils.CheckClanMatchRestrict(this);

        using (PROTOCOL_BATTLE_START_GAME_ACK packet = new PROTOCOL_BATTLE_START_GAME_ACK(this))
        {
            byte[] data = packet.GetCompleteBytes("Room.StartBattle");
            foreach (Account pR in getAllPlayers(SlotState.READY, 0))
            {
                Slot slot = getSlot(pR._slotId);
                if (slot != null)
                {
                    slot.withHost = true;
                    slot.state = SlotState.LOAD;
                    slot.SetMissionsClone(pR._mission);
                    pR.SendCompletePacket(data);
                }
            }
        }
        if (updateInfo)
        {
            updateSlotsInfo();
        }
        updateRoomInfo();
        Monitor.Exit(_slots);
    }

    public void StartCountDown()
    {
        using (PROTOCOL_BATTLE_START_COUNTDOWN_ACK packet = new PROTOCOL_BATTLE_START_COUNTDOWN_ACK(CountDownEnum.Start))
        {
            SendPacketToPlayers(packet);
        }
        countdown.Start(5250, (callbackState) =>
        {
            try
            {
                if (_slots[_leader].state == SlotState.READY && RoomState == RoomState.CountDown)
                {
                    StartBattle(true);
                }
                else
                {
                    Logger.warning("[Room.StartCountDown] Room: " + _roomId + "; Canal: " + _channelId + "; state: " + RoomState + "; leader: " + _slots[_leader].state);
                    Logger.warning("[Data: " + DateTime.Now.ToString("dd/MM/yy HH:mm:ss"));
                }
            }
            catch (Exception ex)
            {
                Logger.warning("[Room.StartCountDown] " + ex.ToString());
            }
            lock (callbackState)
            {
                countdown.Timer = null;
            }
        });
    }

    public void StopCountDown(CountDownEnum motive, bool refreshRoom = true)
    {
        RoomState = RoomState.Ready;
        if (refreshRoom)
        {
            updateRoomInfo();
        }
        countdown.Timer = null;
        using (PROTOCOL_BATTLE_START_COUNTDOWN_ACK packet = new PROTOCOL_BATTLE_START_COUNTDOWN_ACK(motive))
        {
            SendPacketToPlayers(packet);
        }
    }

    public void StopCountDown(int slotId)
    {
        if (RoomState != RoomState.CountDown)
        {
            return;
        }
        if (slotId == _leader)
        {
            StopCountDown(CountDownEnum.StopByHost);
        }
        else if (getPlayingPlayers(_leader % 2 == 0 ? 1 : 0, SlotState.READY, 0) == 0)
        {
            changeSlotState(_leader, SlotState.NORMAL, false);
            StopCountDown(CountDownEnum.StopByPlayer);
        }
    }

    public void CalculateResult()
    {
        lock (_slots)
        {
            BaseResultGame(AllUtils.GetWinnerTeam(this), isBotMode());
        }
    }

    public void CalculateResult(TeamResultType resultType)
    {
        lock (_slots)
        {
            BaseResultGame(resultType, isBotMode());
        }
    }

    public void CalculateResult(TeamResultType resultType, bool isBotMode)
    {
        lock (_slots)
        {
            BaseResultGame(resultType, isBotMode);
        }
    }

    public void CalculateResultFreeForAll(int SlotWin)
    {
        lock (_slots)
        {
            BaseResultGameFreeForAll(SlotWin);
        }
    }

    private void BaseResultGame(TeamResultType winnerTeam, bool isBotMode)
    {
        ServerConfig cfg = GameManager.Config;
        EventUpModel evUp = EventRankUpSyncer.getRunningEvent();
        EventMapModel evMap = EventMapSyncer.getRunningEvent();
        bool mapEvUse = EventMapSyncer.EventIsValid(evMap, (int)mapId, (int)RoomType);
        PlayTimeModel evPt = EventPlayTimeSyncer.getRunningEvent();
        DateTime finishDate = DateTime.Now;
        if (cfg == null)
        {
            Logger.error("Server Config Null. RoomResult canceled.");
            return;
        }
        foreach (Slot slot in _slots)
        {
            Account player;
            if (/*!slot.check && slot.state == SlotState.BATTLE &&* getPlayerBySlot(slot, out player))
            {
                DBQuery query = new DBQuery();
                DBQuery query2 = new DBQuery();
                slot.check = true;
                double inBattleTime = slot.inBattleTime(finishDate);
                int gp = player._gp, xp = player._exp, my = player._money;
                if (!isBotMode)
                {
                    if (cfg.missions)
                    {
                        AllUtils.endMatchMission(this, player, slot, winnerTeam);
                        if (slot.MissionsCompleted)
                        {
                            player._mission = slot.Missions;
                            MissionManager.getInstance().updateCurrentMissionList(player.player_id, player._mission);
                        }
                        AllUtils.GenerateMissionAwards(player, query);
                    }
                    int timePlayed = slot.allKills == 0 && slot.allDeaths == 0 ? (int)(inBattleTime / 3) : (int)inBattleTime;

                    if (RoomType == RoomType.Bomb || RoomType == RoomType.Annihilation)
                    {
                        slot.exp = (int)(slot.Score + (timePlayed / 2.5) + (slot.allDeaths * 2.2) + (slot.objects * 20));
                        slot.gp = (int)(slot.Score + (timePlayed / 3.0) + (slot.allDeaths * 2.2) + (slot.objects * 20));
                        slot.money = (int)((slot.Score / 2) + (timePlayed / 6.5) + (slot.allDeaths * 1.5) + (slot.objects * 10));
                    }
                    else
                    {
                        slot.exp = (int)(slot.Score + (timePlayed / 2.5) + (slot.allDeaths * 1.8) + (slot.objects * 20));
                        slot.gp = (int)(slot.Score + (timePlayed / 3.0) + (slot.allDeaths * 1.8) + (slot.objects * 20));
                        slot.money = (int)((slot.Score / 1.5) + (timePlayed / 4.5) + (slot.allDeaths * 1.1) + (slot.objects * 20));
                    }
                    bool WonTheMatch = (slot._team == (int)winnerTeam);
                    if (rule != 80 && rule != 32)
                    {
                        player._statistic.headshots_count += slot.headshots;
                        player._statistic.kills_count += slot.allKills;
                        player._statistic.totalkills_count += slot.allKills;
                        player._statistic.deaths_count += slot.allDeaths;
                        player._statistic.assist += slot.allAssists;
                        AddKDInfosToQuery(slot, player._statistic, query);
                        AllUtils.updateMatchCount(WonTheMatch, player, (int)winnerTeam, query);
                        if (player.Daily != null)
                        {
                            player.Daily.Kills += slot.allKills;
                            player.Daily.Deaths += slot.allDeaths;
                            player.Daily.Headshots += slot.headshots;
                            AddDailyToQuery(slot, player.Daily, query2);
                            AllUtils.UpdateDailyRecord(WonTheMatch, player, (int)winnerTeam, query2);
                        }
                    }
                    if (WonTheMatch)
                    {
                        slot.gp += AllUtils.percentage(slot.gp, 15);
                        slot.exp += AllUtils.percentage(slot.exp, 20);
                    }
                    if (slot.earnedXP > 0)
                    {
                        slot.exp += slot.earnedXP * 5;
                    }
                }
                else
                {
                    slot.gp += 300;
                    slot.exp += 300;
                }
                slot.exp = slot.exp > GameConfig.maxBattleXP ? GameConfig.maxBattleXP : slot.exp;
                slot.gp = slot.gp > GameConfig.maxBattleGP ? GameConfig.maxBattleGP : slot.gp;
                slot.money = slot.money > GameConfig.maxBattleMY ? GameConfig.maxBattleMY : slot.money;
                if (slot.exp < 0 || slot.gp < 0 || slot.money < 0)
                {
                    slot.exp = 2;
                    slot.gp = 2;
                    slot.money = 2;
                }
                if (RoomType == RoomType.Ace)
                {
                    if (player._slotId != 0 && player._slotId != 1)
                    {
                        slot.exp = 0;
                        slot.gp = 0;
                        slot.money = 0;
                    }
                }
                int ItemExp = 0, ItemPoint = 0, EventExp = 0, EventPoint = 0;
                if (evUp != null || mapEvUse)
                {
                    if (evUp != null)
                    {
                        EventExp += evUp._percentXp;
                        EventPoint += evUp._percentGp;
                    }
                    if (mapEvUse)
                    {
                        EventExp += evMap._percentXp;
                        EventPoint += evMap._percentGp;
                    }
                    if (!slot.bonusFlags.HasFlag(ResultIcon.Event))
                    {
                        slot.bonusFlags |= ResultIcon.Event;
                    }
                }
                PlayerBonus c = player._bonus;
                if (c != null && c.bonuses > 0)
                {
                    if ((c.bonuses & 8) == 8)
                    {
                        ItemExp += 100;
                    }
                    if ((c.bonuses & 128) == 128)
                    {
                        ItemPoint += 100;
                    }
                    if ((c.bonuses & 4) == 4)
                    {
                        ItemExp += 50;
                    }
                    if ((c.bonuses & 64) == 64)
                    {
                        ItemPoint += 50;
                    }
                    if ((c.bonuses & 2) == 2)
                    {
                        ItemExp += 30;
                    }
                    if ((c.bonuses & 32) == 32)
                    {
                        ItemPoint += 30;
                    }
                    if ((c.bonuses & 1) == 1)
                    {
                        ItemExp += 10;
                    }
                    if ((c.bonuses & 16) == 16)
                    {
                        ItemPoint += 10;
                    }
                    if (!slot.bonusFlags.HasFlag(ResultIcon.Item))
                    {
                        slot.bonusFlags |= ResultIcon.Item;
                    }
                    slot.BonusItemExp += ItemExp;
                    slot.BonusItemPoint += ItemPoint;
                }

                if (isBotMode)
                {
                    if (slot.BonusItemExp > 300)
                    {
                        slot.BonusItemExp = 300;
                    }
                    if (slot.BonusItemPoint > 300)
                    {
                        slot.BonusItemPoint = 300;
                    }
                    if (slot.BonusCafeExp > 300)
                    {
                        slot.BonusCafeExp = 300;
                    }
                    if (slot.BonusCafePoint > 300)
                    {
                        slot.BonusCafePoint = 300;
                    }
                    if (slot.BonusEventExp > 300)
                    {
                        slot.BonusEventExp = 300;
                    }
                    if (slot.BonusEventPoint > 300)
                    {
                        slot.BonusEventPoint = 300;
                    }
                }
                int BonusAllexp = EventExp + slot.BonusCafeExp + slot.BonusItemExp;
                int BonusAllPoint = EventPoint + slot.BonusCafePoint + slot.BonusItemPoint;
                slot.BonusEventExp = AllUtils.percentage(slot.exp, BonusAllexp);
                slot.BonusEventPoint = AllUtils.percentage(slot.gp, BonusAllPoint);
                player._gp += slot.gp + slot.BonusEventPoint;
                player._exp += slot.exp + slot.BonusEventExp;
                if (player.Daily != null)
                {
                    player.Daily.Point += slot.gp + slot.BonusCafePoint + slot.BonusItemPoint + slot.BonusEventPoint;
                    player.Daily.Exp += slot.exp + slot.BonusCafeExp + slot.BonusItemExp + slot.BonusEventExp;
                    query2.AddQuery("point", player.Daily.Point);
                    query2.AddQuery("exp", player.Daily.Exp);
                }
                if (GameConfig.winCashPerBattle)
                {
                    player._money += slot.money;
                }
                RankModel rank = RankXml.getRank(player._rank);
                RankModel rank_61 = RankXml.getRank(61);
                if (rank != null && player._exp >= (rank._onNextLevel + rank._onAllExp) && player._rank <= 50)
                {
                    List<ItemsModel> items = RankXml.getAwards(player._rank);
                    if (items.Count > 0)
                    {
                        for (int idx = 0; idx < items.Count; idx++)
                        {
                            ItemsModel Item = items[idx];
                            if (Item._id != 0)
                            {
                                player.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, player, Item));
                            }
                        }
                    }
                    player._gp += rank._onGPUp;
                    player.LastRankUpDate = uint.Parse(finishDate.ToString("yyMMddHHmm"));
                    player.SendPacket(new PROTOCOL_BASE_RANK_UP_ACK(++player._rank, rank._onNextLevel));
                    query.AddQuery("last_rankup_date", (long)player.LastRankUpDate);
                    query.AddQuery("rank", player._rank);
                }
                if (evPt != null)
                {
                    AllUtils.PlayTimeEvent((long)inBattleTime, player, evPt, isBotMode);
                }
                AllUtils.DiscountPlayerItems(slot, player);
                if (gp != player._gp)
                {
                    query.AddQuery("gp", player._gp);
                }
                if (xp != player._exp)
                {
                    query.AddQuery("exp", player._exp);
                }
                if (my != player._money)
                {
                    query.AddQuery("money", player._money);
                }
                ComDiv.updateDB("players", "player_id", player.player_id, query.GetTables(), query.GetValues());
                ComDiv.updateDB("player_dailyrecord", "player_id", player.player_id, query2.GetTables(), query2.GetValues());
                if (GameConfig.winCashPerBattle && GameConfig.showCashReceiveWarn)
                {
                    player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(Translation.GetLabel("CashReceived", slot.money)));
                }
            }
        }
        updateSlotsInfo();
        CalculateClanMatchResult((int)winnerTeam);
    }

    private void BaseResultGameFreeForAll(int winner)
    {
        ServerConfig cfg = GameManager.Config;
        EventUpModel evUp = EventRankUpSyncer.getRunningEvent();
        EventMapModel evMap = EventMapSyncer.getRunningEvent();
        bool mapEvUse = EventMapSyncer.EventIsValid(evMap, (int)mapId, (int)RoomType);
        PlayTimeModel evPt = EventPlayTimeSyncer.getRunningEvent();
        DateTime finishDate = DateTime.Now;
        int[] Array = new int[16];
        int SlotWin = 0;
        if (cfg == null)
        {
            Logger.error("Server Config Null. RoomResult canceled.");
            return;
        }
        for (int i = 0; i < 16; i++)
        {
            Slot slot = _slots[i];
            if (slot._playerId != 0)
            {
                Array[i] = slot.allKills;
            }
            else
            {
                Array[i] = 0;
            }
            if (Array[i] > Array[SlotWin])
            {
                SlotWin = i;
            }
            Account player;
            if (!slot.check && slot.state == SlotState.BATTLE && getPlayerBySlot(slot, out player))
            {
                DBQuery query = new DBQuery();
                DBQuery query2 = new DBQuery();
                slot.check = true;
                double inBattleTime = slot.inBattleTime(finishDate);
                int gp = player._gp, xp = player._exp, my = player._money;
                if (cfg.missions)
                {
                    AllUtils.endMatchMission(this, player, slot, (winner == SlotWin) ? _slots[SlotWin]._team == 0 ? TeamResultType.TeamRedWin : TeamResultType.TeamBlueWin : TeamResultType.TeamDraw);
                    if (slot.MissionsCompleted)
                    {
                        player._mission = slot.Missions;
                        MissionManager.getInstance().updateCurrentMissionList(player.player_id, player._mission);
                    }
                    AllUtils.GenerateMissionAwards(player, query);
                }
                int timePlayed = slot.allKills == 0 && slot.allDeaths == 0 ? (int)(inBattleTime / 3) : (int)inBattleTime;
                slot.exp = (int)(slot.Score + (timePlayed / 2.5) + (slot.allDeaths * 1.8) + (slot.objects * 20));
                slot.gp = (int)(slot.Score + (timePlayed / 3.0) + (slot.allDeaths * 1.8) + (slot.objects * 20));
                slot.money = (int)((slot.Score / 1.5) + (timePlayed / 4.5) + (slot.allDeaths * 1.1) + (slot.objects * 20));
                if (rule != 80 && rule != 32)
                {
                    player._statistic.headshots_count += slot.headshots;
                    player._statistic.kills_count += slot.allKills;
                    player._statistic.totalkills_count += slot.allKills;
                    player._statistic.deaths_count += slot.allDeaths;
                    player._statistic.assist += slot.allAssists;
                    AddKDInfosToQuery(slot, player._statistic, query);
                    AllUtils.updateMatchCountFreeForAll(this, player, SlotWin, query);
                    if (player.Daily != null)
                    {
                        player.Daily.Kills += slot.allKills;
                        player.Daily.Deaths += slot.allDeaths;
                        player.Daily.Headshots += slot.headshots;
                        AddDailyToQuery(slot, player.Daily, query2);
                        AllUtils.UpdateMatchDailyRecordFreeForAll(this, player, SlotWin, query2);
                    }
                }
                if (winner == SlotWin)
                {
                    slot.gp += AllUtils.percentage(slot.gp, 15);
                    slot.exp += AllUtils.percentage(slot.exp, 20);
                }
                if (slot.earnedXP > 0)
                {
                    slot.exp += slot.earnedXP * 5;
                }
                slot.exp = slot.exp > GameConfig.maxBattleXP ? GameConfig.maxBattleXP : slot.exp;
                slot.gp = slot.gp > GameConfig.maxBattleGP ? GameConfig.maxBattleGP : slot.gp;
                slot.money = slot.money > GameConfig.maxBattleMY ? GameConfig.maxBattleMY : slot.money;
                if (slot.exp < 0 || slot.gp < 0 || slot.money < 0)
                {
                    slot.exp = 2;
                    slot.gp = 2;
                    slot.money = 2;
                }
                int ItemExp = 0, ItemPoint = 0, EventExp = 0, EventPoint = 0;
                if (evUp != null || mapEvUse)
                {
                    if (evUp != null)
                    {
                        EventExp += evUp._percentXp;
                        EventPoint += evUp._percentGp;
                    }
                    if (mapEvUse)
                    {
                        EventExp += evMap._percentXp;
                        EventPoint += evMap._percentGp;
                    }
                    if (!slot.bonusFlags.HasFlag(ResultIcon.Event))
                    {
                        slot.bonusFlags |= ResultIcon.Event;
                    }
                    slot.BonusEventExp += AllUtils.percentage(EventExp, 100);
                    slot.BonusEventPoint += AllUtils.percentage(EventPoint, 100);
                }
                PlayerBonus c = player._bonus;
                if (c != null && c.bonuses > 0)
                {
                    if ((c.bonuses & 8) == 8)
                    {
                        ItemExp += 100;
                    }
                    if ((c.bonuses & 128) == 128)
                    {
                        ItemPoint += 100;
                    }
                    if ((c.bonuses & 4) == 4)
                    {
                        ItemExp += 50;
                    }
                    if ((c.bonuses & 64) == 64)
                    {
                        ItemPoint += 50;
                    }
                    if ((c.bonuses & 2) == 2)
                    {
                        ItemExp += 30;
                    }
                    if ((c.bonuses & 32) == 32)
                    {
                        ItemPoint += 30;
                    }
                    if ((c.bonuses & 1) == 1)
                    {
                        ItemExp += 10;
                    }
                    if ((c.bonuses & 16) == 16)
                    {
                        ItemPoint += 10;
                    }
                    if (!slot.bonusFlags.HasFlag(ResultIcon.Item))
                    {
                        slot.bonusFlags |= ResultIcon.Item;
                    }
                    slot.BonusItemExp += ItemExp;
                    slot.BonusItemPoint += ItemPoint;
                }
                int BonusAllexp = EventExp + slot.BonusCafeExp + slot.BonusItemExp;
                int BonusAllPoint = EventPoint + slot.BonusCafePoint + slot.BonusItemPoint;
                slot.BonusEventExp = AllUtils.percentage(slot.exp, BonusAllexp);
                slot.BonusEventPoint = AllUtils.percentage(slot.gp, BonusAllPoint);
                player._gp += slot.gp + slot.BonusEventPoint;
                player._exp += slot.exp + slot.BonusEventExp;
                if (player.Daily != null)
                {
                    player.Daily.Point += slot.gp + slot.BonusEventPoint;
                    player.Daily.Exp += slot.exp + slot.BonusEventExp;
                    query2.AddQuery("point", player.Daily.Point);
                    query2.AddQuery("exp", player.Daily.Exp);
                }
                if (GameConfig.winCashPerBattle)
                {
                    player._money += slot.money;
                }
                RankModel rank = RankXml.getRank(player._rank);
                RankModel rank_61 = RankXml.getRank(61);
                if (rank != null && player._exp >= (rank._onNextLevel + rank._onAllExp) && player._rank <= 50)
                {
                    List<ItemsModel> items = RankXml.getAwards(player._rank);
                    if (items.Count > 0)
                    {
                        for (int idx = 0; idx < items.Count; idx++)
                        {
                            ItemsModel Item = items[idx];
                            if (Item._id != 0)
                            {
                                player.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, player, Item));
                            }
                        }
                    }
                    player._gp += rank._onGPUp;
                    player.LastRankUpDate = uint.Parse(finishDate.ToString("yyMMddHHmm"));
                    player.SendPacket(new PROTOCOL_BASE_RANK_UP_ACK(++player._rank, rank._onNextLevel));
                    query.AddQuery("last_rankup_date", (long)player.LastRankUpDate);
                    query.AddQuery("rank", player._rank);
                }
                else if (rank != null && player._exp >= rank_61._onAllExp && player._rank == 51)
                {
                    List<ItemsModel> items = RankXml.getAwards(player._rank);
                    if (items.Count > 0)
                    {
                        for (int idx = 0; idx < items.Count; idx++)
                        {
                            ItemsModel Item = items[idx];
                            if (Item._id != 0)
                            {
                                player.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, player, Item));
                            }
                        }
                    }
                    player._gp += rank._onGPUp;
                    player.LastRankUpDate = uint.Parse(finishDate.ToString("yyMMddHHmm"));
                    player.SendPacket(new PROTOCOL_BASE_RANK_UP_ACK(61, rank._onNextLevel));
                    query.AddQuery("last_rankup_date", (long)player.LastRankUpDate);
                    query.AddQuery("rank", 61);
                }
                else if (rank != null && player._exp >= (rank._onNextLevel + rank._onAllExp) && player._rank <= 110 && player._rank >= 61)
                {
                    List<ItemsModel> items = RankXml.getAwards(player._rank);
                    if (items.Count > 0)
                    {
                        for (int idx = 0; idx < items.Count; idx++)
                        {
                            ItemsModel Item = items[idx];
                            if (Item._id != 0)
                            {
                                player.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, player, Item));
                            }
                        }
                    }
                    player._gp += rank._onGPUp;
                    player.LastRankUpDate = uint.Parse(finishDate.ToString("yyMMddHHmm"));
                    player.SendPacket(new PROTOCOL_BASE_RANK_UP_ACK(++player._rank, rank._onNextLevel));
                    query.AddQuery("last_rankup_date", (long)player.LastRankUpDate);
                    query.AddQuery("rank", player._rank);
                }
                if (evPt != null)
                {
                    AllUtils.PlayTimeEvent((long)inBattleTime, player, evPt, false);
                }
                AllUtils.DiscountPlayerItems(slot, player);
                if (gp != player._gp)
                {
                    query.AddQuery("gp", player._gp);
                }
                if (xp != player._exp)
                {
                    query.AddQuery("exp", player._exp);
                }
                if (my != player._money)
                {
                    query.AddQuery("money", player._money);
                }
                ComDiv.updateDB("players", "player_id", player.player_id, query.GetTables(), query.GetValues());
                ComDiv.updateDB("player_dailyrecord", "player_id", player.player_id, query2.GetTables(), query2.GetValues());
                if (GameConfig.winCashPerBattle && GameConfig.showCashReceiveWarn)
                {
                    player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(Translation.GetLabel("CashReceived", slot.money)));
                }
            }
        }
        updateSlotsInfo();
    }

    private void AddKDInfosToQuery(Slot slot, PlayerStats stats, DBQuery query)
    {
        if (slot.allKills > 0)
        {
            query.AddQuery("kills_count", stats.kills_count);
            query.AddQuery("totalkills_count", stats.totalkills_count);
        }
        if (slot.allAssists > 0)
        {
            query.AddQuery("assist", stats.assist);
        }
        if (slot.allDeaths > 0)
        {
            query.AddQuery("deaths_count", stats.deaths_count);
        }
        if (slot.headshots > 0)
        {
            query.AddQuery("headshots_count", stats.headshots_count);
        }
    }

    private void AddDailyToQuery(Slot slot, PlayerDailyRecord Daily, DBQuery query)
    {
        if (Daily.Kills > 0)
        {
            query.AddQuery("kills", Daily.Kills);
        }
        if (Daily.Deaths > 0)
        {
            query.AddQuery("deaths", Daily.Deaths);
        }
        if (Daily.Headshots > 0)
        {
            query.AddQuery("headshots", Daily.Headshots);
        }
    }

    private void CalculateClanMatchResult(int winnerTeam)
    {
        if (_channelType != 4 || blockedClan)
        {
            return;
        }
        SortedList<int, Clan> list = new SortedList<int, Clan>();
        foreach (Slot slot in _slots)
        {
            Account p;
            if (slot.state == SlotState.BATTLE && getPlayerBySlot(slot, out p))
            {
                Clan clan = ClanManager.getClan(p.clanId);
                if (clan._id == 0)
                {
                    continue;
                }
                bool WonTheMatch = (slot._team == winnerTeam);
                clan._exp += slot.exp;
                clan.BestPlayers.SetBestExp(slot);
                clan.BestPlayers.SetBestKills(slot);
                clan.BestPlayers.SetBestHeadshot(slot);
                clan.BestPlayers.SetBestWins(p._statistic, slot, WonTheMatch);
                clan.BestPlayers.SetBestParticipation(p._statistic, slot);
                if (!list.ContainsKey(p.clanId))
                {
                    list.Add(p.clanId, clan);
                    if (winnerTeam == 2)
                    {
                        goto UpdateClanFights;
                    }
                    CalculateSpecialCM(clan, winnerTeam, slot._team);
                    if (WonTheMatch)
                    {
                        clan.vitorias++;
                    }
                    else
                    {
                        clan.derrotas++;
                    }
                    UpdateClanFights:
                    PlayerManager.updateClanBattles(clan._id, ++clan.partidas, clan.vitorias, clan.derrotas);
                }
            }
        }
        foreach (Clan clan in list.Values)
        {
            PlayerManager.updateClanExp(clan._id, clan._exp);
            PlayerManager.updateClanPoints(clan._id, clan._pontos);
            PlayerManager.updateBestPlayers(clan);
            RankModel rankModel = ClanRankXml.getRank(clan._rank);
            if (rankModel != null && clan._exp >= rankModel._onNextLevel + rankModel._onAllExp)
            {
                PlayerManager.updateClanRank(clan._id, ++clan._rank);
            }
        }
    }

    private void CalculateSpecialCM(Clan clan, int winnerTeam, int teamIdx)
    {
        if (winnerTeam == 2)
        {
            return;
        }
        if (winnerTeam == teamIdx)
        {
            float morePoints = 0;
            if (RoomType == RoomType.DeathMatch)
            {
                morePoints = (teamIdx == 0 ? _redKills : _blueKills) / 20;
            }
            else
            {
                morePoints = (teamIdx == 0 ? red_rounds : blue_rounds);
            }
            float POINTS = (25 + morePoints);
            //Logger.warning("Clan: " + clan._id + " Earned Points: " + POINTS);
            clan._pontos += POINTS;
            //Logger.warning("Clan: " + clan._id + " Final Points: " + clan._pontos);
        }
        else
        {
            if (clan._pontos == 0)
            {
                //Logger.warning("Clã não perdeu Pontos devido a baixa pontuação.");
                return;
            }
            float morePoints = 0;
            if (RoomType == RoomType.DeathMatch)
            {
                morePoints = (teamIdx == 0 ? _redKills : _blueKills) / 20;
            }
            else
            {
                morePoints = (teamIdx == 0 ? red_rounds : blue_rounds);
            }
            float POINTS = (40 - morePoints);
            //Logger.warning("Clan: " + clan._id + " Losed Points: " + POINTS);
            clan._pontos -= POINTS;
            //Logger.warning("Clan: " + clan._id + " Final Points: " + clan._pontos);
        }
    }

    public bool isStartingMatch()
    {
        return RoomState > RoomState.Ready;
    }

    public bool isPreparing()
    {
        return RoomState >= RoomState.Loading;
    }

    public void updateRoomInfo()
    {
        SetSeed();
        using (PROTOCOL_ROOM_CHANGE_ROOMINFO_ACK packet = new PROTOCOL_ROOM_CHANGE_ROOMINFO_ACK(this))
        {
            SendPacketToPlayers(packet);
        }
    }

    public void initSlotCount(int count, bool Change = false)
    {
        MapMatch Match = MapModel.Matchs.Find(x => x.Id == (int)mapId && MapModel.getRule(x.Mode).Rule == rule);
        if (Match != null)
        {
            count = Match.Limit;
        }
        for (int i = 0; i < MapModel.Matchs.Count; i++)
        {
            if (Match.Id == (int)mapId && MapModel.getRule(Match.Mode).Rule == rule)
            {
                count = Match.Limit;
            }
        }
        if (RoomType == RoomType.Tutorial)
        {
            count = 1;
        }
        if (isBotMode())
        {
            count = 8;
        }
        if (count <= 0)
        {
            count = 1;
        }
        for (int index = 0; index < _slots.Length; ++index)
        {
            if (index >= count)
            {
                _slots[index].state = SlotState.CLOSE;
            }
        }
        if (Change)
        {
            updateSlotsInfo();
        }
    }

    public int getSlotCount()
    {
        lock (_slots)
        {
            int count = 0;
            for (int index = 0; index < _slots.Length; ++index)
            {
                if (_slots[index].state != SlotState.CLOSE)
                {
                    ++count;
                }
            }
            return count;
        }
    }
    public void SwitchNewSlot(List<SlotChange> slots, Account p, Slot old, int teamIdx, int slotIdx, bool Mode)
    {
        if (Mode)
        {
            Slot slot = _slots[teamIdx];
            if (slot._playerId == 0 && (int)slot.state == 0)
            {
                slot.state = SlotState.NORMAL;
                slot._playerId = p.player_id;
                slot._equip = p._equip;

                old.state = SlotState.EMPTY;
                old._playerId = 0;
                old._equip = null;

                if (p._slotId == _leader)
                {
                    _leader = teamIdx;
                }
                p._slotId = teamIdx;
                slots.Add(new SlotChange { oldSlot = old, newSlot = slot });
            }
        }
        else if (slotIdx > 0)
        {
            for (int i = 0; i < GetTeamArray(teamIdx).Length; i++)
            {
                int index = GetTeamArray(teamIdx)[i];
                Slot slot = _slots[slotIdx];
                if (slot._playerId == 0 && (int)slot.state == 0)
                {
                    slot.state = SlotState.NORMAL;
                    slot._playerId = p.player_id;
                    slot._equip = p._equip;

                    old.state = SlotState.EMPTY;
                    old._playerId = 0;
                    old._equip = null;

                    if (p._slotId == _leader)
                    {
                        _leader = slotIdx;
                    }
                    //Logger.LogProblems("[Room.SwitchNewSlot] PlayerId '" + p.player_id + "' '" + p.player_name + "'; OldSlot: " + p._slotId + "; NewSlot: " + index, "ErrorC");
                    p._slotId = slotIdx;
                    slots.Add(new SlotChange { oldSlot = old, newSlot = slot });
                    break;
                }
            }
        }
        else
        {
            Slot slot = _slots[slotIdx];
            if (slot._playerId == 0 && (int)slot.state == 0)
            {
                slot.state = SlotState.NORMAL;
                slot._playerId = p.player_id;
                slot._equip = p._equip;

                old.state = SlotState.EMPTY;
                old._playerId = 0;
                old._equip = null;

                if (p._slotId == _leader)
                {
                    _leader = slotIdx;
                }
                p._slotId = slotIdx;
                slots.Add(new SlotChange { oldSlot = old, newSlot = slot });
            }
        }
    }

    public void SwitchSlots(List<SlotChange> slots, int newSlotId, int oldSlotId, bool changeReady)
    {
        Slot newSLOT = _slots[newSlotId];
        Slot oldSLOT = _slots[oldSlotId];

        if (changeReady)
        {
            if (newSLOT.state == SlotState.READY)
            {
                newSLOT.state = SlotState.NORMAL;
            }
            if (oldSLOT.state == SlotState.READY)
            {
                oldSLOT.state = SlotState.NORMAL;
            }
        }

        newSLOT.SetSlotId(oldSlotId);
        oldSLOT.SetSlotId(newSlotId);

        _slots[newSlotId] = oldSLOT;
        _slots[oldSlotId] = newSLOT;
        slots.Add(new SlotChange { oldSlot = newSLOT, newSlot = oldSLOT });
    }

    public void changeSlotState(int slotId, SlotState state, bool sendInfo)
    {
        Slot slot = getSlot(slotId);
        changeSlotState(slot, state, sendInfo);
    }

    public void changeSlotState(Slot slot, SlotState state, bool sendInfo)
    {
        if (slot == null || slot.state == state)
        {
            return;
        }
        slot.state = state;
        if ((int)state == 0 || (int)state == 1)
        {
            AllUtils.ResetSlotInfo(this, slot, false);
            slot._playerId = 0;
        }
        if (sendInfo)
        {
            updateSlotsInfo();
        }
    }

    public Account getPlayerBySlot(Slot slot)
    {
        try
        {
            long id = slot._playerId;
            return id > 0 ? AccountManager.getAccount(id, true) : null;
        }
        catch
        {
            return null;
        }
    }

    public Account getPlayerBySlot(int slotId)
    {
        try
        {
            long id = _slots[slotId]._playerId;
            return id > 0 ? AccountManager.getAccount(id, true) : null;
        }
        catch
        {
            return null;
        }
    }

    public bool getPlayerBySlot(int slotId, out Account player)
    {
        try
        {
            long id = _slots[slotId]._playerId;
            player = id > 0 ? AccountManager.getAccount(id, true) : null;
            return player != null;
        }
        catch
        {
            player = null;
            return false;
        }
    }

    public bool getPlayerBySlot(Slot slot, out Account player)
    {
        try
        {
            long id = slot._playerId;
            player = id > 0 ? AccountManager.getAccount(id, true) : null;
            return player != null;
        }
        catch
        {
            player = null;
            return false;
        }
    }

    public int getTimeByMask()
    {
        return TIMES[killtime >> 4];
    }

    public int getRoundsByMask()
    {
        return ROUNDS[killtime & 15];
    }

    public int getKillsByMask()
    {
        return KILLS[killtime & 15];
    }

    public void updateSlotsInfo()
    {
        using (PROTOCOL_ROOM_GET_SLOTINFO_ACK packet = new PROTOCOL_ROOM_GET_SLOTINFO_ACK(this))
        {
            SendPacketToPlayers(packet);
        }
    }

    public bool getLeader(out Account p)
    {
        p = null;
        if (getAllPlayers().Count <= 0)
        {
            return false;
        }
        if (_leader == -1)
        {
            setNewLeader(-1, 0, -1, false);
        }
        if (_leader >= 0)
        {
            p = AccountManager.getAccount(_slots[_leader]._playerId, true);
        }
        return p != null;
    }

    public Account getLeader()
    {
        if (getAllPlayers().Count <= 0)
        {
            return null;
        }
        if (_leader == -1)
        {
            setNewLeader(-1, 0, -1, false);
        }
        return _leader == -1 ? null : AccountManager.getAccount(_slots[_leader]._playerId, true);
    }

    public void setNewLeader(int leader, int state, int oldLeader, bool updateInfo)
    {
        Monitor.Enter(_slots);
        if (leader == -1)
        {
            for (int i = 0; i < 16; ++i)
            {
                Slot slot = _slots[i];
                if (i != oldLeader && slot._playerId > 0 && (int)slot.state > state)
                {
                    _leader = i;
                    break;
                }
            }
        }
        else
        {
            _leader = leader;
        }
        if (_leader != -1)
        {
            Slot slot = _slots[_leader];
            if ((int)slot.state == 9)
            {
                slot.state = SlotState.NORMAL;
            }
            if (updateInfo)
            {
                updateSlotsInfo();
            }
        }
        Monitor.Exit(_slots);
    }

    public void SendPacketToPlayers(SendPacket packet)
    {
        List<Account> players = getAllPlayers();
        if (players.Count == 0)
        {
            return;
        }

        byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket)");
        foreach (Account player in players)
        {
            player.SendCompletePacket(data);
        }
    }

    public void SendPacketToPlayers(SendPacket packet, long player_id)
    {
        List<Account> players = getAllPlayers(player_id);
        if (players.Count == 0)
        {
            return;
        }

        byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,long)");
        foreach (Account player in players)
        {
            player.SendCompletePacket(data);
        }
    }

    public void SendPacketToPlayers(SendPacket packet, SlotState state, int type)
    {
        List<Account> players = getAllPlayers(state, type);
        if (players.Count == 0)
        {
            return;
        }
        byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,SLOT_STATE,int)");
        for (int i = 0; i < players.Count; i++)
        {
            players[i].SendCompletePacket(data);
        }
    }

    public void SendPacketToPlayers(SendPacket packet, SendPacket packet2, SlotState state, int type)
    {
        List<Account> players = getAllPlayers(state, type);
        if (players.Count == 0)
        {
            return;
        }

        byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,SendPacket,SLOT_STATE,int)-1");
        byte[] data2 = packet2.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,SendPacket,SLOT_STATE,int)-2");
        foreach (Account pR in players)
        {
            pR.SendCompletePacket(data);
            pR.SendCompletePacket(data2);
        }
    }

    public void SendPacketToPlayers(SendPacket packet, SlotState state, int type, int exception)
    {
        List<Account> players = getAllPlayers(state, type, exception);
        if (players.Count == 0)
        {
            return;
        }

        byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,SLOT_STATE,int,int)");
        foreach (Account player in players)
        {
            player.SendCompletePacket(data);
        }
    }

    public void SendPacketToPlayers(SendPacket packet, SlotState state, int type, int exception, int exception2)
    {
        List<Account> players = getAllPlayers(state, type, exception, exception2);
        if (players.Count == 0)
        {
            return;
        }

        byte[] data = packet.GetCompleteBytes("Room.SendPacketToPlayers(SendPacket,SLOT_STATE,int,int,int)");
        foreach (Account player in players)
        {
            player.SendCompletePacket(data);
        }
    }

    public void RemovePlayer(Account player, bool WarnAllPlayers, int quitMotive = 0)
    {
        Slot slot;
        if (player == null || !getSlot(player._slotId, out slot))
        {
            return;
        }
        BaseRemovePlayer(player, slot, WarnAllPlayers, quitMotive);
    }

    public void RemovePlayer(Account player, Slot slot, bool WarnAllPlayers, int quitMotive = 0)
    {
        if (player == null || slot == null)
        {
            return;
        }
        BaseRemovePlayer(player, slot, WarnAllPlayers, quitMotive);
    }

    private void BaseRemovePlayer(Account player, Slot slot, bool WarnAllPlayers, int quitMotive)
    {
        Monitor.Enter(_slots);
        bool useRoomUpdate = false, hostChanged = false;
        if (player != null && slot != null)
        {
            if ((int)slot.state >= 10)
            {
                if (_leader == slot._id)
                {
                    int oldLeader = _leader, bestState = 1;
                    if (RoomState == RoomState.Battle)
                    {
                        bestState = 14;
                    }
                    else if (RoomState >= RoomState.Loading)
                    {
                        bestState = 9;
                    }
                    if (getAllPlayers(slot._id).Count >= 1)
                    {
                        setNewLeader(-1, bestState, _leader, false);
                    }
                    if (getPlayingPlayers(2, SlotState.READY, 1) >= 2)
                    {
                        using (PROTOCOL_BATTLE_LEAVEP2PSERVER_ACK packet = new PROTOCOL_BATTLE_LEAVEP2PSERVER_ACK(this))
                        {
                            SendPacketToPlayers(packet, SlotState.RENDEZVOUS, 1, slot._id);
                        }
                    }
                    hostChanged = true;
                }
                using (PROTOCOL_BATTLE_GIVEUPBATTLE_ACK packet = new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(player, quitMotive))
                {
                    SendPacketToPlayers(packet, SlotState.READY, 1, !WarnAllPlayers ? slot._id : -1);
                }
                BattleLeaveSync.SendUDPPlayerLeave(this, slot._id);
                slot.ResetSlot();
                if (votekick != null)
                {
                    votekick.TotalArray[slot._id] = false;
                }
            }
            slot._playerId = 0;
            slot._equip = null;
            slot.state = SlotState.EMPTY;
            if (RoomState == RoomState.CountDown)
            {
                if (slot._id == _leader)
                {
                    RoomState = RoomState.Ready;
                    useRoomUpdate = true;
                    countdown.Timer = null;
                    using (PROTOCOL_BATTLE_START_COUNTDOWN_ACK packet = new PROTOCOL_BATTLE_START_COUNTDOWN_ACK(CountDownEnum.StopByHost))
                    {
                        SendPacketToPlayers(packet);
                    }
                }
                else if (getPlayingPlayers(slot._team, SlotState.READY, 0) == 0)
                {
                    if (slot._id != _leader)
                    {
                        changeSlotState(_leader, SlotState.NORMAL, false);
                    }
                    StopCountDown(CountDownEnum.StopByPlayer, false);
                    useRoomUpdate = true;
                }
            }
            else if (isPreparing())
            {
                AllUtils.BattleEndPlayersCount(this, isBotMode());
                if (RoomState == RoomState.Battle)
                {
                    AllUtils.BattleEndRoundPlayersCount(this);
                }
            }
            CheckToEndWaitingBattle(hostChanged);
            requestHost.Remove(player.player_id);
            if (vote.Timer != null && votekick != null && votekick.victimIdx == player._slotId && quitMotive != 2)
            {
                vote.Timer = null;
                votekick = null;
                using (PROTOCOL_BATTLE_NOTIFY_KICKVOTE_CANCEL_ACK packet = new PROTOCOL_BATTLE_NOTIFY_KICKVOTE_CANCEL_ACK())
                {
                    SendPacketToPlayers(packet, SlotState.BATTLE, 0);
                }
            }
            Match match = player._match;
            if (match != null && player.matchSlot >= 0)
            {
                match._slots[player.matchSlot].state = SlotMatchState.Normal;
                using (PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK packet = new PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK(match))
                {
                    match.SendPacketToPlayers(packet);
                }
            }
            player._room = null;
            //Logger.LogProblems("[Room.RemovePlayer] PlayerId '" + player.player_id + "' '" + player.player_name + "'; OldSlot: " + player._slotId + "; NewSlot: -1", "ErrorC");
            player._slotId = -1;
            player._status.updateRoom(255);
            AllUtils.syncPlayerToClanMembers(player);
            AllUtils.syncPlayerToFriends(player, false);
            player.updateCacheInfo();
        }
        updateSlotsInfo();
        if (useRoomUpdate)
        {
            updateRoomInfo();
        }
        Monitor.Exit(_slots);
    }

    public int addPlayer(Account p)
    {
        lock (_slots)
        {
            for (int i = 0; i < 16; i++)
            {
                Slot slot = _slots[i];
                if (slot._playerId == 0 && (int)slot.state == 0)
                {
                    slot._playerId = p.player_id;
                    slot.state = SlotState.NORMAL;
                    p._room = this;
                    //Logger.LogProblems("[Room.AddPlayer] PlayerId '" + p.player_id + "' '" + p.player_name + "'; OldSlot: " + p._slotId + "; NewSlot: " + i, "ErrorC");
                    p._slotId = i;
                    slot._equip = p._equip;
                    p._status.updateRoom((byte)_roomId);
                    AllUtils.syncPlayerToClanMembers(p);
                    AllUtils.syncPlayerToFriends(p, false);
                    p.updateCacheInfo();
                    return i;
                }
            }
        }
        return -1;
    }

    public int addPlayer(Account p, int teamIdx)
    {
        int[] array = GetTeamArray(teamIdx);
        lock (_slots)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int SlotIdx = array[i];
                Slot slot = _slots[SlotIdx];
                if (slot._playerId == 0 && (int)slot.state == 0)
                {
                    slot._playerId = p.player_id;
                    slot.state = SlotState.NORMAL;
                    p._room = this;
                    //Logger.LogProblems("[Room.AddPlayer] PlayerId '" + p.player_id + "' '" + p.player_name + "'; OldSlot: " + p._slotId + "; NewSlot: " + i, "ErrorC");
                    p._slotId = SlotIdx;
                    slot._equip = p._equip;
                    p._status.updateRoom((byte)_roomId);
                    AllUtils.syncPlayerToClanMembers(p);
                    AllUtils.syncPlayerToFriends(p, false);
                    p.updateCacheInfo();
                    return SlotIdx;
                }
            }
        }
        return -1;
    }

    public int[] GetTeamArray(int index)
    {
        return (index == 0 ? RED_TEAM : BLUE_TEAM);
    }

    public List<Account> getAllPlayers(SlotState state, int type)
    {
        List<Account> list = new List<Account>();
        lock (_slots)
        {
            for (int i = 0; i < _slots.Length; ++i)
            {
                Slot slot = _slots[i];
                long id = slot._playerId;
                if (id > 0 && (type == 0 && slot.state == state || type == 1 && slot.state > state))
                {
                    Account player = AccountManager.getAccount(id, true);
                    if (player != null && player._slotId != -1)
                    {
                        list.Add(player);
                    }
                }
            }
        }
        return list;
    }

    public List<Account> getAllPlayers(SlotState state, int type, int exception)
    {
        List<Account> list = new List<Account>();
        lock (_slots)
        {
            for (int i = 0; i < _slots.Length; ++i)
            {
                Slot slot = _slots[i];
                long id = slot._playerId;
                if (id > 0 && i != exception && (type == 0 && slot.state == state || type == 1 && slot.state > state))
                {
                    Account player = AccountManager.getAccount(id, true);
                    if (player != null && player._slotId != -1)
                    {
                        list.Add(player);
                    }
                }
            }
        }
        return list;
    }

    public List<Account> getAllPlayers(SlotState state, int type, int exception, int exception2)
    {
        List<Account> list = new List<Account>();
        lock (_slots)
        {
            for (int i = 0; i < _slots.Length; ++i)
            {
                Slot slot = _slots[i];
                long id = slot._playerId;
                if (id > 0 && i != exception && i != exception2 && (type == 0 && slot.state == state || type == 1 && slot.state > state))
                {
                    Account player = AccountManager.getAccount(id, true);
                    if (player != null && player._slotId != -1)
                    {
                        list.Add(player);
                    }
                }
            }
        }
        return list;
    }

    public List<Account> getAllPlayers(int exception)
    {
        List<Account> list = new List<Account>();
        lock (_slots)
        {
            for (int i = 0; i < _slots.Length; ++i)
            {
                long id = _slots[i]._playerId;
                if (id > 0 && i != exception)
                {
                    Account player = AccountManager.getAccount(id, true);
                    if (player != null && player._slotId != -1)
                    {
                        list.Add(player);
                    }
                }
            }
        }
        return list;
    }

    public List<Account> getAllPlayers(long exception)
    {
        List<Account> list = new List<Account>();
        lock (_slots)
        {
            for (int i = 0; i < _slots.Length; ++i)
            {
                long id = _slots[i]._playerId;
                if (id > 0 && id != exception)
                {
                    Account player = AccountManager.getAccount(id, true);
                    if (player != null && player._slotId != -1)
                    {
                        list.Add(player);
                    }
                }
            }
        }
        return list;
    }

    public List<Account> getAllPlayers()
    {
        List<Account> list = new List<Account>();
        lock (_slots)
        {
            for (int i = 0; i < _slots.Length; ++i)
            {
                long id = _slots[i]._playerId;
                if (id > 0)
                {
                    Account player = AccountManager.getAccount(id, true);
                    if (player != null && player._slotId != -1)
                    {
                        list.Add(player);
                    }
                }
            }
        }
        return list;
    }

    public int getPlayingPlayers(int team, bool inBattle)
    {
        int players = 0;
        lock (_slots)
        {
            foreach (Slot slot in _slots)
            {
                if (slot._playerId > 0 && (slot._team == team || team == 2) && (inBattle && (int)slot.state == 13 && !slot.espectador || !inBattle && (int)slot.state >= 10))
                {
                    players++;
                }
            }
        }
        return players;
    }

    public int getPlayingPlayers(int team, SlotState state, int type)
    {
        int players = 0;
        lock (_slots)
        {
            foreach (Slot slot in _slots)
            {
                if (slot._playerId > 0 && (type == 0 && slot.state == state || type == 1 && slot.state > state) && (team == 2 || slot._team == team))
                {
                    players++;
                }
            }
        }
        return players;
    }

    public int getPlayingPlayers(int team, SlotState state, int type, int exception)
    {
        int players = 0;
        lock (_slots)
        {
            for (int i = 0; i < 16; i++)
            {
                Slot slot = _slots[i];
                if (i != exception && slot._playerId > 0 && (type == 0 && slot.state == state || type == 1 && slot.state > state) && (team == 2 || slot._team == team))
                {
                    players++;
                }
            }
        }
        return players;
    }

    public void getPlayingPlayers(bool inBattle, out int RedPlayers, out int BluePlayers)
    {
        RedPlayers = 0;
        BluePlayers = 0;
        lock (_slots)
        {
            foreach (Slot slot in _slots)
            {
                if (slot._playerId > 0 && (inBattle && (int)slot.state == 15 && !slot.espectador || !inBattle && (int)slot.state >= 11))
                {
                    if (slot._team == 0)
                    {
                        RedPlayers++;
                    }
                    else
                    {
                        BluePlayers++;
                    }
                }
            }
        }
    }

    public void getPlayingPlayers(bool inBattle, out int RedPlayers, out int BluePlayers, out int RedDeaths, out int BlueDeaths)
    {
        RedPlayers = 0;
        BluePlayers = 0;
        RedDeaths = 0;
        BlueDeaths = 0;
        lock (_slots)
        {
            foreach (Slot slot in _slots)
            {
                if (slot._deathState.HasFlag(DeadEnum.Dead))
                {
                    if (slot._team == 0)
                    {
                        RedDeaths++;
                    }
                    else
                    {
                        BlueDeaths++;
                    }
                }
                if (slot._playerId > 0 && (inBattle && (int)slot.state == 15 && !slot.espectador || !inBattle && (int)slot.state >= 11))
                {
                    if (slot._team == 0)
                    {
                        RedPlayers++;
                    }
                    else
                    {
                        BluePlayers++;
                    }
                }
            }
        }
    }

    public void CheckToEndWaitingBattle(bool host)
    {
        //Logger.warning("state: " + RoomState "; leader: " + _slots[_leader].state);
        if ((RoomState == RoomState.CountDown || RoomState == RoomState.Loading || RoomState == RoomState.Rendezvous) && (host || _slots[_leader].state == SlotState.BATTLE_READY))
        {
            AllUtils.EndBattleNoPoints(this);
        }
    }

    public void SpawnReadyPlayers()
    {
        lock (_slots)
        {
            BaseSpawnReadyPlayers(isBotMode());
        }
    }

    public void SpawnReadyPlayers(bool isBotMode)
    {
        lock (_slots)
        {
            BaseSpawnReadyPlayers(isBotMode);
        }
    }

    private void BaseSpawnReadyPlayers(bool isBotMode)
    {
        bool dinoStart = false;
        using (PROTOCOL_BATTLE_COUNT_DOWN_ACK packet5 = new PROTOCOL_BATTLE_COUNT_DOWN_ACK(0))
        {
            if (RoomState == RoomState.PreBattle && Countdown == false && isBotMode == false)
            {
                Countdown = true;
                SendPacketToPlayers(packet5);
            }
            countdownstart.Start(3250, (callbackState) =>
            {
                try
                {
                    DateTime date = DateTime.Now;
                    foreach (Slot slot in _slots)
                    {
                        if ((int)slot.state >= 14 && slot.isPlaying == 0 && slot._playerId > 0)
                        {
                            slot.isPlaying = 1;
                            slot.startTime = date;
                            slot.state = SlotState.BATTLE;
                            if (RoomState == RoomState.Battle && (RoomType == RoomType.Bomb || RoomType == RoomType.Annihilation || RoomType == RoomType.Convoy))
                            {
                                slot.espectador = true;
                            }
                        }
                    }
                    updateSlotsInfo();
                    List<int> dinos = AllUtils.getDinossaurs(this, false, -1);
                    if (RoomState == RoomState.PreBattle)
                    {
                        BattleStart = RoomType == RoomType.Bomb || RoomType == RoomType.CrossCounter || RoomType == RoomType.Ace ? date.AddMinutes(5) : date;
                        SetSpecialStage();
                    }
                    using (PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK(this, dinos, isBotMode))
                    {
                        using (PROTOCOL_BATTLE_MISSION_ROUND_START_ACK packet2 = new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(this))
                        {
                            using (PROTOCOL_BATTLE_RECORD_ACK packet3 = new PROTOCOL_BATTLE_RECORD_ACK(this))
                            {
                                byte[] data = packet.GetCompleteBytes("Room.BaseSpawnReadyPlayers-1");
                                byte[] data2 = packet2.GetCompleteBytes("Room.BaseSpawnReadyPlayers-2");
                                byte[] data3 = packet3.GetCompleteBytes("Room.BaseSpawnReadyPlayers-3");
                                foreach (Slot slot in _slots)
                                {
                                    Account player;
                                    if ((int)slot.state >= 15 && slot.isPlaying == 1 && getPlayerBySlot(slot, out player))
                                    {
                                        slot.isPlaying = 2;
                                        if (RoomState == RoomState.PreBattle)
                                        {
                                            using (PROTOCOL_BATTLE_STARTBATTLE_ACK packet4 = new PROTOCOL_BATTLE_STARTBATTLE_ACK(slot, player, dinos, isBotMode, true))
                                            {
                                                SendPacketToPlayers(packet4, SlotState.READY, 1);
                                            }
                                            player.SendCompletePacket(data);
                                            if (RoomType == RoomType.Boss || RoomType == RoomType.CrossCounter)
                                            {
                                                dinoStart = false;
                                            }
                                            else
                                            {
                                                player.SendCompletePacket(data2);
                                            }
                                        }
                                        else if (RoomState == RoomState.Battle)
                                        {
                                            using (PROTOCOL_BATTLE_STARTBATTLE_ACK packet4 = new PROTOCOL_BATTLE_STARTBATTLE_ACK(slot, player, dinos, isBotMode, false))
                                            {
                                                SendPacketToPlayers(packet4, SlotState.READY, 1);
                                            }
                                            if (RoomType == RoomType.Bomb || RoomType == RoomType.Annihilation || RoomType == RoomType.Ace || RoomType == RoomType.Convoy)
                                            {
                                                GameSync.SendUDPPlayerSync(this, slot, 0, 1);
                                            }
                                            else
                                            {
                                                player.SendCompletePacket(data);
                                            }
                                            player.SendCompletePacket(data2);
                                            player.SendCompletePacket(data3);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.warning("[Room.StartCountDown] " + ex.ToString());
                }
                lock (callbackState)
                {
                    countdownstart.Timer = null;
                }
                if (RoomState == RoomState.PreBattle)
                {
                    RoomState = RoomState.Battle;
                    updateRoomInfo();
                }
                if (dinoStart)
                {
                    StartDinoRound();
                }
            });
        }
    }
    private void StartDinoRound()
    {
        round.Start(5250, (callbackState) =>
        {
            if (RoomState == RoomState.Battle)
            {
                using (PROTOCOL_BATTLE_MISSION_ROUND_START_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(this))
                {
                    SendPacketToPlayers(packet, SlotState.BATTLE, 0);
                }
                swapRound = false;
            }
            lock (callbackState)
            {
                round.Timer = null;
            }
        });
    }
}
}*/