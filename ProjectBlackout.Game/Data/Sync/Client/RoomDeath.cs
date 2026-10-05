using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Data.Model;
using System;

namespace ProjectBlackout.Game.Data.Sync.Client
{
    public static class RoomDeath
    {
        public static void Load(ReceiveGPacket p)
        {
            int roomId = p.readH();
            int channelId = p.readH();
            byte killerId = p.readC();
            byte dieObjectId = p.readC();
            int weaponId = p.readD();
            float killerX = p.readT();
            float killerY = p.readT();
            float killerZ = p.readT();
            byte killsCount = p.readC();
            int Length = (killsCount * 15);
            if (p.getBuffer().Length > (25 + Length))
            {
                Logger.warning("Invalid Death: " + BitConverter.ToString(p.getBuffer()));
            }
            Channel ch = ChannelsXml.getChannel(channelId);
            if (ch == null)
            {
                return;
            }
            Room room = ch.getRoom(roomId);
            if (room != null && room.round.Timer == null && room.RoomState == RoomState.Battle)
            {
                Slot killer = room.getSlot(killerId);
                if (killer != null && killer.state == SlotState.BATTLE)
                {
                    FragInfos info = new FragInfos
                    {
                        killerIdx = killerId,
                        killingType = 0, // 1 - Piercing | 2 - Mass
                        weapon = weaponId,
                        x = killerX,
                        y = killerY,
                        z = killerZ,
                        flag = dieObjectId
                    };
                    bool isSuicide = false;
                    for (int i = 0; i < killsCount; i++)
                    {
                        byte weaponClass = p.readC();
                        byte deathInfo = p.readC();
                        float vicX = p.readT();
                        float vicY = p.readT();
                        float vicZ = p.readT();
                        int Assist = p.readC();
                        int victimId = deathInfo & 15;
                        Slot victim = room.getSlot(victimId);
                        if (victim != null && victim.state == SlotState.BATTLE)
                        {
                            Frag frag = new Frag(deathInfo) { flag = 0, AssistSlot = Assist, victimWeaponClass = weaponClass, x = vicX, y = vicY, z = vicZ };
                            if (info.killerIdx == victimId)
                            {
                                isSuicide = true;
                            }
                            info.frags.Add(frag);
                        }
                    }
                    info.killsCount = (byte)info.frags.Count;
                    GameSync.genDeath(room, killer, info, isSuicide);
                }
            }
        }

        public static void RegistryFragInfos(Room room, Slot killer, out int score, bool isBotMode, bool isSuicide, FragInfos kills)
        {
            score = 0;
            ItemClass weaponClass = (ItemClass)ComDiv.getIdStatics(kills.weapon, 1);
            ClassType ClassType = (ClassType)ComDiv.getIdStatics(kills.weapon, 2);
            for (int i = 0; i < kills.frags.Count; i++)
            {
                Frag frag = kills.frags[i];
                CharaDeath deathType = (CharaDeath)(frag.hitspotInfo >> 4);
                if (kills.killsCount - (isSuicide ? 1 : 0) > 1)
                {
                    frag.killFlag |= deathType == CharaDeath.BOOM || deathType == CharaDeath.OBJECT_EXPLOSION || deathType == CharaDeath.POISON || deathType == CharaDeath.HOWL || deathType == CharaDeath.TRAMPLED || ClassType == ClassType.Shotgun ? KillingMessage.MassKill : KillingMessage.PiercingShot;
                }
                else
                {
                    int num2 = 0;
                    if (deathType == CharaDeath.HEADSHOT)
                    {
                        num2 = 4;
                    }
                    else if (deathType == CharaDeath.DEFAULT && weaponClass == ItemClass.KNIFE)
                    {
                        num2 = 6;
                    }
                    if (num2 > 0)
                    {
                        int num3 = killer.lastKillState >> 12;
                        if (num2 == 4)
                        {
                            if (num3 != 4)
                            {
                                killer.repeatLastState = false;
                            }
                            killer.lastKillState = num2 << 12 | (killer.killsOnLife + 1);
                            if (killer.repeatLastState)
                            {
                                frag.killFlag |= (killer.lastKillState & 16383) <= 1 ? KillingMessage.Headshot : KillingMessage.ChainHeadshot;
                            }
                            else
                            {
                                frag.killFlag |= KillingMessage.Headshot;
                                killer.repeatLastState = true;
                            }
                        }
                        else if (num2 == 6)
                        {
                            if (num3 != 6)
                            {
                                killer.repeatLastState = false;
                            }
                            killer.lastKillState = num2 << 12 | (killer.killsOnLife + 1);
                            if (killer.repeatLastState && (killer.lastKillState & 16383) > 1)
                            {
                                frag.killFlag |= KillingMessage.ChainSlugger;
                            }
                            else
                            {
                                killer.repeatLastState = true;
                            }
                        }
                    }
                    else
                    {
                        killer.lastKillState = 0;
                        killer.repeatLastState = false;
                    }
                }
                int VictimId = frag.VictimSlot;
                int AssistId = frag.AssistSlot;
                Slot VictimSlot = room._slots[VictimId];
                Slot AssistSlot = room._slots[AssistId];
                if (VictimSlot.killsOnLife > 3)
                {
                    frag.killFlag |= KillingMessage.ChainStopper;
                }
                if ((kills.weapon == 19016 || kills.weapon == 19022) && kills.killerIdx == VictimId || VictimSlot.specGM)
                {

                }
                else
                {
                    VictimSlot.allDeaths++;
                }
                if (kills.killerIdx == AssistId)
                {

                }
                else
                {
                    AssistSlot.allAssists++;
                }
                if (room.RoomType == RoomType.FreeForAll)
                {
                    killer.allKills++;
                    if (killer._deathState == DeadEnum.Alive)
                    {
                        killer.killsOnLife++;
                    }
                }
                else
                {
                    if (killer._team != VictimSlot._team)
                    {
                        score += AllUtils.getKillScore(frag.killFlag);
                        killer.allKills++;
                        if (killer._deathState == DeadEnum.Alive)
                        {
                            killer.killsOnLife++;
                        }
                        if (VictimSlot._team == 0)
                        {
                            room._redDeaths++;
                            room._blueKills++;
                        }
                        else
                        {
                            room._blueDeaths++;
                            room._redKills++;
                        }
                        if (room.RoomType == RoomType.Boss)
                        {
                            if (killer._team == 0)
                            {
                                room.red_dino += 4;
                            }
                            else
                            {
                                room.blue_dino += 4;
                            }
                        }
                    }
                }
                VictimSlot.lastKillState = 0;
                VictimSlot.killsOnLife = 0;
                VictimSlot.repeatLastState = false;
                VictimSlot.passSequence = 0;
                VictimSlot._deathState = DeadEnum.Dead;
                if (!isBotMode)
                {
                    AllUtils.CompleteMission(room, VictimSlot, MissionType.DEATH, 0);
                }
                if (deathType == CharaDeath.HEADSHOT)
                {
                    killer.headshots++;
                }
            }
        }

        public static void EndBattleByDeath(Room room, Slot killer, bool isBotMode, bool isSuicide)
        {
            if ((room.RoomType == RoomType.DeathMatch) && !isBotMode)
            {
                AllUtils.BattleEndKills(room, isBotMode);
            }
            else if (room.RoomType == RoomType.FreeForAll)
            {
                AllUtils.BattleEndKillsFreeForAll(room);
            }
            else if (!killer.specGM && (room.RoomType == RoomType.Bomb || room.RoomType == RoomType.Annihilation || room.RoomType == RoomType.Convoy))
            {
                int redDeaths, blueDeaths, allRed, allBlue, winner = 0;
                room.getPlayingPlayers(true, out allRed, out allBlue, out redDeaths, out blueDeaths);
                if (redDeaths == allRed && killer._team == 0 && isSuicide && !room.C4_actived)
                {
                    winner = 1;
                    room.blue_rounds++;
                    AllUtils.BattleEndRound(room, winner, true);
                }
                else if (blueDeaths == allBlue && killer._team == 1)
                {
                    room.red_rounds++;
                    AllUtils.BattleEndRound(room, winner, true);
                }
                else if (redDeaths == allRed && killer._team == 1)
                {
                    if (!room.C4_actived)
                    {
                        winner = 1;
                        room.blue_rounds++;
                    }
                    else if (isSuicide)
                    {
                        room.red_rounds++;
                    }
                    AllUtils.BattleEndRound(room, winner, false);
                }
                else if (blueDeaths == allBlue && killer._team == 0)
                {
                    if (!isSuicide || !room.C4_actived)
                    {
                        room.red_rounds++;
                    }
                    else
                    {
                        winner = 1;
                        room.blue_rounds++;
                    }
                    AllUtils.BattleEndRound(room, winner, true);
                }
            }
        }
    }
}