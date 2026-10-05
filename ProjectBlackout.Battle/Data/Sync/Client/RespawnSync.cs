using ProjectBlackout.Battle.Data.Configs;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Xml;
using ProjectBlackout.Battle.Network;
using ProjectBlackout.Battle.Network.Actions.Damage;
using ProjectBlackout.Battle.Network.Packets;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Battle.Data.Sync.Client
{
    public static class RespawnSync
    {
        public static void Load(ReceivePacket p)
        {
            uint UniqueRoomId = p.readUD();
            uint Seed = p.readUD();
            long roomTick = p.readQ();
            int syncType = p.readC();
            int round = p.readC();
            int slotId = p.readC();
            int spawnNumber = p.readC();
            byte accountId = p.readC();
            int Type = 0, Number = 0, HpBonus = 0;
            bool C4Speed = false;

            int wep1 = 0, wep2 = 0, wep3 = 0, wep4 = 0, wep5 = 0;
            if (syncType == 0 || syncType == 2)
            {
                Type = p.readC();
                Number = p.readH();
                HpBonus = p.readC();
                C4Speed = p.readC() == 1;
                wep1 = p.readD();
                wep2 = p.readD();
                wep3 = p.readD();
                wep4 = p.readD();
                wep5 = p.readD();
            }
            Room room = RoomsManager.getRoom(UniqueRoomId);
            if (room == null)
            {
                return;
            }

            room.ResyncTick(roomTick, Seed);
            Player Player = room.getPlayer(slotId, true);
            if (Player != null && Player.PlayerIdByUser != accountId)
            {
                Player.PlayerIdByUser = accountId; //
            }

            if (Player != null && Player.PlayerIdByUser == accountId)
            {
                Player.PlayerIdByServer = accountId;
                Player.RespawnByServer = spawnNumber;
                Player.Integrity = false;
                if (round > room.ServerRound)
                {
                    room.ServerRound = round;
                }
                if (syncType == 0 || syncType == 2)
                {
                    Player.RespawnByLogic++;
                    Player.Dead = false;
                    Player.PlantDuration = BattleConfig.plantDuration;
                    Player.DefuseDuration = BattleConfig.defuseDuration;
                    Player.Primary = wep1;
                    Player.Secondary = wep2;
                    Player.Knife = wep3;
                    Player.Grenade = wep4;
                    Player.Special = wep5;

                    if (C4Speed)
                    {
                        Player.PlantDuration -= AllUtils.Percentage(BattleConfig.plantDuration, 50);
                        Player.DefuseDuration -= AllUtils.Percentage(BattleConfig.defuseDuration, 25);
                    }
                    if (!room.BotMode)
                    {
                        if (room.SourceToMap == -1)
                        {
                            room.RoundResetRoomF1(round);
                        }
                        else
                        {
                            room.RoundResetRoomS1(round);
                        }
                    }
                    if (Type == 255)
                    {
                        Player.Immortal = true;
                    }
                    else
                    {
                        Player.Immortal = false;
                        int CharaHp = CharaXml.getLifeById(Number, Type);
                        CharaHp += AllUtils.Percentage(CharaHp, HpBonus);
                        Player.MaxLife = CharaHp;
                        Player.ResetLife();
                    }
                }
                if (room.BotMode || syncType == 2 || !room.ObjectsIsValid())
                {
                    return;
                }
                List<ObjectHitInfo> SyncList = new List<ObjectHitInfo>();
                for (int i = 0; i < room.Objects.Length; i++)
                {
                    ObjectInfo rObj = room.Objects[i];
                    ObjectModel mObj = rObj.Model;
                    if (mObj != null && (syncType != 2 && mObj.Destroyable && rObj.Life != mObj.Life || mObj.NeedSync))
                    {
                        SyncList.Add(new ObjectHitInfo(3)
                        {
                            ObjSyncId = mObj.NeedSync ? 1 : 0,
                            AnimId1 = mObj.Animation,
                            AnimId2 = rObj.Animation != null ? rObj.Animation.Id : 255,
                            DestroyState = rObj.DestroyState,
                            ObjId = mObj.Id,
                            ObjLife = rObj.Life,
                            SpecialUse = AllUtils.GetDuration(rObj.UseDate),
                            /*Value = mObj.Value != 0 ? mObj.Value : 1,
                            ValueType = mObj.ValueType,
                            KillerId = 255*/

                            /*ObjSyncId = mObj._needSync ? 1 : 0,
                            AnimId1 = mObj._anim1,
                            AnimId2 = rObj._anim != null ? rObj._anim._id : 255,
                            DestroyState = 255,
                            ObjId = mObj._id,
                            ObjLife = rObj._life,
                            SpecialUse = AllUtils.GetDuration(rObj._useDate),
                            Value = mObj.Value != 0 ? mObj.Value : 0,
                            ValueType = mObj.ValueType*/
                        });
                    }
                }
                for (int i = 0; i < room.Players.Length; i++)
                {
                    Player pR = room.Players[i];
                    if (pR.Slot != slotId && pR.AccountIdIsValid() && !pR.Immortal && pR.Date != new DateTime() && (pR.MaxLife != pR.Life || pR.Dead))
                    {
                        SyncList.Add(new ObjectHitInfo(4)
                        {
                            ObjId = pR.Slot,
                            ObjLife = pR.Life
                        });
                    }
                }
                if (SyncList.Count > 0)
                {
                    byte[] Packet = PROTOCOL_EVENTS_ACTION.getCode(PROTOCOL_EVENTS_ACTION.getCodeSyncData(SyncList), room.StartTime, round, 255);
                    BattleManager.Send(Packet, Player.Client);
                }
                SyncList = null;
            }
        }
    }
}