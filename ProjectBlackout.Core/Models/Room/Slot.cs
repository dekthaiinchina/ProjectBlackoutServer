using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Core.Models.Room
{
    public class Slot
    {
        public SlotState state;
        public ResultIcon bonusFlags;
        public PlayerEquipedItems _equip;
        public long _playerId;
        public DeadEnum _deathState = DeadEnum.Alive;
        public bool firstRespawn = true, repeatLastState, check, espectador, specGM, withHost;
        public int _id, Flag, _team, aiLevel, latency, failLatencyTimes, ping = 5, passSequence, isPlaying, earnedXP, spawnsCount, headshots, lastKillState, killsOnLife, exp, money, gp, Score, allKills, allDeaths, allAssists, objects, BonusItemExp, BonusItemPoint, BonusEventExp, BonusEventPoint, BonusCafePoint, BonusCafeExp, unkItem, Costume = 0;
        public DateTime NextVoteDate, startTime, preStartDate, preLoadDate;
        public ushort damageBar1, damageBar2;
        public List<int> armas_usadas = new List<int>();
        public bool MissionsCompleted;
        public PlayerMissions Missions;
        public TimerState timing = new TimerState();

        public void StopTiming()
        {
            if (timing != null)
            {
                timing.Timer = null;
            }
        }

        public Slot(int slotIdx)
        {
            SetSlotId(slotIdx);
        }

        public void SetSlotId(int slotIdx)
        {
            _id = slotIdx;
            _team = (slotIdx % 2);
            Flag = (1 << slotIdx);
        }

        public void ResetSlot()
        {
            repeatLastState = false;
            _deathState = DeadEnum.Alive;
            StopTiming();
            check = false;
            espectador = false;
            specGM = false;
            withHost = false;
            firstRespawn = true;
            failLatencyTimes = 0;
            latency = 0;
            ping = 0;
            passSequence = 0;
            allDeaths = 0;
            allKills = 0;
            allAssists = 0;
            bonusFlags = 0;
            killsOnLife = 0;
            lastKillState = 0;
            Score = 0;
            gp = 0;
            exp = 0;
            headshots = 0;
            objects = 0;
            BonusItemExp = 0;
            BonusItemPoint = 0;
            BonusCafeExp = 0;
            BonusCafePoint = 0;
            BonusEventExp = 0;
            BonusEventPoint = 0;
            spawnsCount = 0;
            damageBar1 = 0;
            damageBar2 = 0;
            earnedXP = 0;
            isPlaying = 0;
            money = 0;
            NextVoteDate = new DateTime();
            aiLevel = 0;
            armas_usadas.Clear();
            MissionsCompleted = false;
            Missions = null;
        }

        public void SetMissionsClone(PlayerMissions missions)
        {
            Missions = missions.DeepCopy();
            MissionsCompleted = false;
        }

        public double inBattleTime(DateTime date)
        {
            if (startTime == new DateTime())// || startTime > date)
            {
                return 0;
            }
            return (date - startTime).TotalSeconds;
        }
    }
}