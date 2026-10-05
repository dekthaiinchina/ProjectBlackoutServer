using ProjectBlackout.Battle.Data.Configs;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Xml;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Net;

namespace ProjectBlackout.Battle.Data.Models
{
    public class Room
    {
        public Player[] Players = new Player[16];
        public ObjectInfo[] Objects = new ObjectInfo[200];
        public uint UniqueRoomId, Seed;
        public int ObjsSyncRound, ServerRound, SourceToMap = -1, ServerId, Rule, RoomId, ChannelId, LastRound, DropCounter, Bar1 = 6000, Bar2 = 6000, Default1 = 6000, Default2 = 6000;
        public MAP_STATE_ID MapId;
        public ROOM_STATE_TYPE RoomType;
        public GameServerModel GameServer;
        public MapModel Map;
        private object Lock = new object(), Lock2 = new object();
        public bool BotMode, HasC4;
        public long LastStartTick;
        public Half3 BombPosition;
        public DateTime StartTime;

        public Room(int ServerId)
        {
            GameServer  = ServersXml.getServer(ServerId);
            if (GameServer == null)
            {
                return;
            }
            this.ServerId = ServerId;
            for (int i = 0; i < 16; ++i)
            {
                Players[i] = new Player(i);
            }
            for (int i = 0; i < 200; ++i)
            {
                Objects[i] = new ObjectInfo(i);
            }
        }

        public void SyncInfo(List<ObjectHitInfo> Objs, int Type)
        {
            lock (Lock2)
            {
                if (BotMode || !ObjectsIsValid())
                {
                    return;
                }
                DateTime Now = DateTime.Now;
                //double value = (now - LastObjsSync).TotalSeconds;
                //double value2 = (now - LastPlayersSync).TotalSeconds;
                if (/*value >= 2.5 && */(Type & 1) == 1)
                {
                    //LastObjsSync = now;
                    for (int i = 0; i < Objects.Length; i++)
                    {
                        ObjectInfo rObj = Objects[i];
                        ObjectModel mObj = rObj.Model;
                        if (mObj != null && (mObj.Destroyable && rObj.Life != mObj.Life || mObj.NeedSync))
                        {
                            float SyncingTime = AllUtils.GetDuration(rObj.UseDate);
                            AnimModel anim = rObj.Animation;
                            if (anim != null && anim.Duration > 0 && SyncingTime >= anim.Duration)
                            {
                                mObj.GetAnim(anim.NextAnim, SyncingTime, anim.Duration, rObj);
                            }
                            Objs.Add(new ObjectHitInfo(mObj.UpdateId)
                            {
                                ObjSyncId = mObj.NeedSync ? 1 : 0,
                                AnimId1 = mObj.Animation,
                                AnimId2 = rObj.Animation != null ? rObj.Animation.Id : 255,
                                DestroyState = rObj.DestroyState,
                                ObjId = mObj.Animation,
                                ObjLife = rObj.Life,
                                SpecialUse = SyncingTime,
                                /*Value = mObj.Value != 0 ? mObj.Value : 1,
                                ValueType = mObj.ValueType,
                                KillerId = 255*/
                            });
                        }
                    }
                }
                if (/*value2 >= 6.5 && */(Type & 2) == 2)
                {
                    //LastPlayersSync = now;
                    for (int i = 0; i < Players.Length; i++)
                    {
                        Player Player = Players[i];
                        if (!Player.Immortal && (Player.MaxLife != Player.Life || Player.Dead))
                        {
                            Objs.Add(new ObjectHitInfo(4)
                            {
                                ObjId = Player.Slot,
                                ObjLife = Player.Life
                            });
                        }
                    }
                }
            }
        }

        /*public bool RoundIsValid(int number)
        {
            //if (_lastRound != number && (_lastRound != number + 1 && _lastRound + 1 != number))
            //    Logger.warning("[" + _lastRound + "/" + number + "] Invalid round on - Room: " + _roomId + "; Ch: " + _channelId + "; Type: " + _roomType);
            return LastRound == number || LastRound + 1 == number;// || _lastRound == number + 1;
        }*/

        public bool ObjectsIsValid()
        {
            return ServerRound == ObjsSyncRound;
        }

        public void ResyncTick(long StartTick, uint Seed)
        {
            if (StartTick > LastStartTick)
            {
                StartTime = new DateTime(StartTick);
                if (LastStartTick > 0)
                {
                    ResetRoomInfo(Seed);
                }
                LastStartTick = StartTick;
                if (BattleConfig.isTestMode)
                {
                    Logger.warning("[New tick is defined]");
                }
            }
        }

        public void ResetRoomInfo(uint Seed)
        {
            for (int i = 0; i < 200; ++i)
            {
                Objects[i] = new ObjectInfo(i);
            }
            MapId = (MAP_STATE_ID)AllUtils.GetSeedInfo(Seed, 2);
            RoomType = (ROOM_STATE_TYPE)AllUtils.GetSeedInfo(Seed, 0);
            Rule = AllUtils.GetSeedInfo(Seed, 1);
            SourceToMap = -1;
            Map = null;
            LastRound = 0;
            DropCounter = 0;
            BotMode = false;
            HasC4 = false;
            ServerRound = 0;
            ObjsSyncRound = 0;
            //LastObjsSync = new DateTime();
            //LastPlayersSync = new DateTime();
            BombPosition = new Half3();
            if (BattleConfig.isTestMode)
            {
                Logger.warning("A room has been reseted by server.");
            }
        }

        public bool RoundResetRoomF1(int Round)
        {
            lock (Lock)
            {
                if (LastRound != Round)
                {
                    if (BattleConfig.isTestMode)
                    {
                        Logger.warning("Reseting room. [Last: " + LastRound + "; New: " + Round + "]");
                    }
                    DateTime now = DateTime.Now;
                    LastRound = Round;
                    HasC4 = false;
                    BombPosition = new Half3();
                    DropCounter = 0;
                    ObjsSyncRound = 0;
                    SourceToMap = (int)MapId;
                    if (!BotMode)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            Player player = Players[i];
                            player.Life = player.MaxLife;
                        }
                        //LastPlayersSync = now;
                        Map = MapXml.getMapId((int)MapId);
                        List<ObjectModel> objsm = Map != null ? Map.Objects : null;
                        if (objsm != null)
                        {
                            for (int i = 0; i < objsm.Count; i++)
                            {
                                ObjectModel ob = objsm[i];
                                ObjectInfo obj = Objects[ob.Id];
                                obj.Life = ob.Life;
                                if (!ob.NoInstaSync)
                                {
                                    ob.GetRandomAnimation(this, obj);
                                }
                                else
                                {
                                    obj.Animation = new AnimModel { NextAnim = 1 };
                                    obj.UseDate = now;
                                }
                                obj.Model = ob;
                                obj.DestroyState = 0;
                                MapXml.SetObjectives(ob, this);
                            }
                        }
                        //LastObjsSync = now;
                        ObjsSyncRound = Round;
                    }
                    return true;
                }
            }
            return false;
        }

        public bool RoundResetRoomS1(int Round)
        {
            lock (Lock)
            {
                if (LastRound != Round)
                {
                    if (BattleConfig.isTestMode)
                    {
                        Logger.warning("Reseting room. [Last: " + LastRound + "; New: " + Round + "]");
                    }
                    LastRound = Round;
                    HasC4 = false;
                    DropCounter = 0;
                    BombPosition = new Half3();
                    if (!BotMode)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            Player player = Players[i];
                            player.Life = player.MaxLife;
                        }
                        DateTime now = DateTime.Now;
                        //LastPlayersSync = now;
                        for (int i = 0; i < Objects.Length; i++)
                        {
                            ObjectInfo obj = Objects[i];
                            ObjectModel ob = obj.Model;
                            if (ob != null)
                            {
                                obj.Life = ob.Life;
                                if (!ob.NoInstaSync)
                                {
                                    ob.GetRandomAnimation(this, obj);
                                }
                                else
                                {
                                    obj.Animation = new AnimModel { NextAnim = 1 };
                                    obj.UseDate = now;
                                }
                                obj.DestroyState = 0;
                            }
                        }
                        //LastObjsSync = now;
                        ObjsSyncRound = Round;
                        if ((RoomType == ROOM_STATE_TYPE.Destroy || RoomType == ROOM_STATE_TYPE.Defense))
                        {
                            Bar1 = Default1;
                            Bar2 = Default2;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public Player AddPlayer(IPEndPoint Client, PacketModel Packet, string Udp)
        {
            if (BattleConfig.udpVersion != Udp)
            {
                return null;
            }
            try
            {
                Player Player = Players[Packet.Slot];
                if (!Player.CompareIp(Client))
                {
                    Player.Client = Client;
                    Player.Date = Packet.ReceiveDate;
                    Player.PlayerIdByUser = Packet.AccountId;
                    return Player;
                }
            }
            catch (Exception ex) 
            { 
                Logger.warning(ex.ToString()); 
            }
            return null;
        }

        public bool getPlayer(int Slot, out Player Player)
        {
            try
            {
                Player = Players[Slot];
            }
            catch
            {
                Player = null;
            }
            return Player != null;
        }

        public Player getPlayer(int Slot, bool Active)
        {
            Player Player;
            try
            {
                Player = Players[Slot];
            }
            catch
            {
                Player = null;
            }
            return Player != null && (!Active || Player.Client != null) ? Player : null;
        }

        public Player getPlayer(int Slot, IPEndPoint Client)
        {
            Player Player;
            try
            {
                Player = Players[Slot];
            }
            catch
            {
                Player = null;
            }
            return Player != null && Player.CompareIp(Client) ? Player : null;
        }

        public ObjectInfo getObject(int Id)
        {
            ObjectInfo Object;
            try
            {
                Object = Objects[Id];
            }
            catch
            {
                Object = null;
            }
            return Object;
        }

        public bool RemovePlayer(int Slot, IPEndPoint Ip)
        {
            try
            {
                Player Player = Players[Slot];
                if (Player.CompareIp(Ip))
                {
                    Player.ResetAllInfos();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public int getPlayersCount()
        {
            int Total = 0;
            for (int i = 0; i < 16; i++)
            {
                if (Players[i].Client != null)
                {
                    Total++;
                }
            }
            return Total;
        }
    }
}