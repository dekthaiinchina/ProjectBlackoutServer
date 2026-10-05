using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Sync;
using ProjectBlackout.Battle.Data.Xml;
using ProjectBlackout.Battle.Network.Actions.Damage;
using ProjectBlackout.Battle.Network.Actions.SubHead;
using ProjectBlackout.Battle.Network.Actions.Event;
using ProjectBlackout.Battle.Network.Packets;
using SharpDX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using ProjectBlackout.Battle.Data.Configs;
using ProjectBlackout.Battle.Data.Models.Event;
using ProjectBlackout.Battle.Data.Items;
using System.Linq;
using System.Text;

namespace ProjectBlackout.Battle.Network
{
    public class BattleHandler
    {
        private UdpClient Client;
        private IPEndPoint RemoteEP;

        public BattleHandler(UdpClient Client, byte[] Buff, IPEndPoint RemoteEP, DateTime Date)
        {
            this.Client = Client;
            this.RemoteEP = RemoteEP;
            BeginReceive(Buff, Date);
        }

        public void BeginReceive(byte[] Buffer, DateTime Date)
        {
            PacketModel Packet = new PacketModel();
            Packet.Data = Buffer;
            Packet.ReceiveDate = Date;
            ReceivePacket Receive = new ReceivePacket(Packet.Data);
            Packet.Opcode = Receive.readC();
            Packet.Slot = Receive.readC();
            Packet.Time = Receive.readT();
            Packet.Round = Receive.readC();
            Packet.Length = Receive.readUH();
            Packet.Respawn = Receive.readC();
            Packet.RoundNumber = Receive.readC();
            Packet.AccountId = Receive.readC();
            Packet.Unk = Receive.readC();
            if (Packet.Length > Packet.Data.Length)
            {
                Logger.LogProblems(RemoteEP.ToString(), "Ip/Battle");
                Logger.warning("Packet with invalid size canceled. [Length: " + Packet.Length + " DataLength: " + Packet.Data.Length + "]");
                return;
            }
            getDecryptedData(Packet);
            if (BattleConfig.isTestMode && Packet.Unk > 0)
            {
                Logger.warning("Unk: " + Packet.Unk);
            }
            ReadPacket(Packet);
        }

        public void getDecryptedData(PacketModel packet)
        {
            try
            {
                byte[] withEnd, noEnd;
                if (packet.Data.Length >= packet.Length)
                {
                    byte[] result = new byte[packet.Length - 13];
                    Array.Copy(packet.Data, 13, result, 0, result.Length);
                    withEnd = AllUtils.Decrypt(result, packet.Length % 6 + 1);
                    noEnd = new byte[withEnd.Length - 9];
                    Array.Copy(withEnd, noEnd, noEnd.Length);
                    packet.withEndData = withEnd;
                    packet.noEndData = noEnd;
                }
                else
                {
                    throw new Exception("Invalid packet size.");
                }
            }
            catch
            {

            }
        }

        public void ReadPacket(PacketModel Packet)
        {
            byte[] withEndData = Packet.withEndData;
            byte[] noEndData = Packet.noEndData;
            ReceivePacket Receive = new ReceivePacket(withEndData);
            int BasicBufferLength = noEndData.Length, DedicationSlot = 0;
            uint UniqueRoomId = 0, Seed = 0;
            Room Room = null;
            try
            {
                switch (Packet.Opcode)
                {
                    case 131:
                    case 132:
                        Receive.Advance(BasicBufferLength);
                        UniqueRoomId = Receive.readUD();
                        DedicationSlot = Receive.readC();
                        Seed = Receive.readUD();
                        Room = RoomsManager.getRoom(UniqueRoomId);
                        if (Room != null)
                        {
                            Player Player = Room.getPlayer(Packet.Slot, RemoteEP);
                            if (Player != null && Player.AccountIdIsValid(Packet.AccountId))
                            {
                                Room.BotMode = true;
                                Player Player2 = DedicationSlot != 255 ? Room.getPlayer(DedicationSlot, false) : null;
                                byte[] Code;
                                if (Player2 != null)
                                {
                                    Code = PROTOCOL_BOTS_ACTION.getCode(noEndData, Player2.Date, Packet.Round, DedicationSlot);
                                }
                                else
                                {
                                    Code = PROTOCOL_BOTS_ACTION.getCode(noEndData, Player.Date, Packet.Round, Packet.Slot);
                                }
                                for (int i = 0; i < 16; i++)
                                {
                                    Player PlayerR = Room.Players[i];
                                    if (PlayerR.Client != null && PlayerR.AccountIdIsValid() && i != Packet.Slot)
                                    {
                                        Send(Code, PlayerR.Client);
                                    }
                                }
                            }
                        }
                        break;

                    case 97:
                        UniqueRoomId = Receive.readUD();
                        DedicationSlot = Receive.readC();
                        Seed = Receive.readUD();
                        Room = RoomsManager.getRoom(UniqueRoomId);
                        byte[] Data = Packet.Data;
                        if (Room != null)
                        {
                            Player Player = Room.getPlayer(Packet.Slot, RemoteEP);
                            if (Player != null)
                            {
                                Player.LastPing = Packet.ReceiveDate;
                                Send(Data, RemoteEP);
                            }
                        }
                        break;

                    case 4:
                    case 3:
                        Receive.Advance(BasicBufferLength);
                        UniqueRoomId = Receive.readUD();
                        DedicationSlot = Receive.readC();
                        Seed = Receive.readUD();
                        Room = RoomsManager.getRoom(UniqueRoomId);
                        if (Room != null)
                        {
                            Player Player = Room.getPlayer(Packet.Slot, RemoteEP);
                            if (Player != null && Player.AccountIdIsValid(Packet.AccountId))
                            {
                                Player.RespawnByUser = Packet.Respawn;
                                if (Packet.Opcode == 4)
                                {
                                    Room.BotMode = true;
                                }
                                if (Room.StartTime == new DateTime())
                                {
                                    return;
                                }
                                byte[] Actions = WriteActionBytes(noEndData, Room, AllUtils.GetDuration(Player.Date), Packet);
                                bool UseDate = Packet.Opcode == 4 && DedicationSlot == 255;
                                int Value = 0;
                                if (UseDate)
                                {
                                    Value = Packet.Slot;
                                }
                                else if (Packet.Opcode == 3)
                                {
                                    Value = Room.BotMode ? Packet.Slot : 255;
                                }
                                else
                                {
                                    Logger.warning("DedicationSlotId: " + DedicationSlot + " Slot: " + Packet.Slot + "  Opcode: " + Packet.Opcode);
                                }
                                byte[] Code = PROTOCOL_EVENTS_ACTION.getCode(Actions, UseDate ? Player.Date : Room.StartTime, Packet.Round, Value);
                                bool V3 = Packet.Opcode == 3 && !Room.BotMode && DedicationSlot != 255;
                                for (int i = 0; i < 16; i++)
                                {
                                    bool V1 = i != Packet.Slot;
                                    Player PlayerInRoom = Room.Players[i];
                                    if (PlayerInRoom.Client != null && PlayerInRoom.AccountIdIsValid() && (DedicationSlot == 255 && V1 || Packet.Opcode == 3 && Room.BotMode && V1 || V3))
                                    {
                                        Send(Code, PlayerInRoom.Client);
                                    }
                                }
                            }
                        }
                        break;

                    case 65:
                        string Version = Receive.readH() + "." + Receive.readH();
                        Console.WriteLine("UDP In Ver: " + Version);
                        UniqueRoomId = Receive.readUD();
                        Seed = Receive.readUD();
                        DedicationSlot = Receive.readC();
                        Room = RoomsManager.CreateOrGetRoom(UniqueRoomId, Seed);
                        if (Room != null)
                        {
                            Player Player = Room.AddPlayer(RemoteEP, Packet, Version);
                            if (Player != null)
                            {
                                if (!Player.Integrity)
                                {
                                    Player.ResetBattleInfos();
                                }
                                byte[] Code = PROTOCOL_CONNECT.getCode();
                                Send(Code, Player.Client);
                                if (BattleConfig.isTestMode)
                                {
                                    Logger.warning("Player Connected. [" + Player.Client.Address + ":" + Player.Client.Port + "]");
                                }
                            }
                        }
                        break;

                    case 67:
                        string outVersion = Receive.readH() + "." + Receive.readH();
                        UniqueRoomId = Receive.readUD();
                        Seed = Receive.readUD();
                        DedicationSlot = Receive.readC();
                        Room = RoomsManager.getRoom(UniqueRoomId);
                        if (Room != null)
                        {
                            if (Room.RemovePlayer(Packet.Slot, RemoteEP))
                            {
                                if (BattleConfig.isTestMode)
                                {
                                    Logger.warning("Player Disconnected. [" + RemoteEP.Address + ":" + RemoteEP.Port + "]");
                                }
                            }
                            if (Room.getPlayersCount() == 0)
                            {
                                RoomsManager.RemoveRoom(Room.UniqueRoomId);
                            }
                        }
                        break;

                    default:
                        Logger.warning("Invalid Packet: " + Packet.Opcode);
                        Logger.warning("Decrypt Data:");
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
                Logger.warning("Decrypt Data:");
            }
        }

        private void RemoveHit(IList List, int Idx)
        {
            List.RemoveAt(Idx);
        }

        public List<ObjectHitInfo> getNewActions(ActionModel Action, Room Room, float Time, out byte[] EventsData)
        {
            EventsData = new byte[0];
            if (Room == null)
            {
                return null;
            }
            if (Action.Data.Length == 0)
            {
                return new List<ObjectHitInfo>();
            }
            byte[] Data = Action.Data;
            List<ObjectHitInfo> Objs = new List<ObjectHitInfo>();
            ReceivePacket Receive = new ReceivePacket(Data);
            using (SendPacket Send = new SendPacket())
            {
                int Event = 0;
                Player Player = Room.getPlayer(Action.Slot, true);
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.ActionState))
                {
                    Event++;
                    ActionStateInfo Info = ActionState.ReadInfo(Receive, Action, false);
                    if (!Room.BotMode)
                    {
                        if (Player != null)
                        {
                            int weaponId = 0;
                            byte extensions = 0;
                            if (Info.Action.HasFlag(ACTION_STATE.WEAPONSYNC))
                            {
                                if (Info.Flag.HasFlag(WEAPON_SYNC_TYPE.PRIMARY))
                                {
                                    weaponId = Player.Primary;
                                }
                                if (Info.Flag.HasFlag(WEAPON_SYNC_TYPE.SECONDARY))
                                {
                                    weaponId = Player.Secondary;
                                }
                                if (Info.Flag.HasFlag(WEAPON_SYNC_TYPE.MELEE))
                                {
                                    weaponId = Player.Knife;
                                }
                                if (Info.Flag.HasFlag(WEAPON_SYNC_TYPE.GRENADE))
                                {
                                    weaponId = Player.Grenade;
                                }
                                if (Info.Flag.HasFlag(WEAPON_SYNC_TYPE.SPECIAL))
                                {
                                    weaponId = Player.Special;
                                }
                                if (Info.Flag.HasFlag(WEAPON_SYNC_TYPE.MISSION))
                                {
                                    if (Room.RoomType == ROOM_STATE_TYPE.Bomb)
                                    {
                                        weaponId = 5009001;
                                    }
                                }
                                if (Info.Flag.HasFlag(WEAPON_SYNC_TYPE.DUAL))
                                {
                                    extensions = 16;
                                    weaponId = Player.Primary;
                                }
                            }
                            Objs.Add(new ObjectHitInfo(5)
                            {
                                ObjId = Player.Slot,
                                WeaponId = weaponId,
                                Extensions = extensions
                            });
                        }
                    }
                    ActionState.WriteInfo(Send, Info);
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.Animation))
                {
                    Event += 2;
                    Animation.WriteInfo(Send, Action, Receive, false);
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.PosRotation))
                {
                    Event += 4;
                    PosRotationInfo Info = PosRotation.ReadInfo(Receive, false);
                    PosRotation.WriteInfo(Send, Info);
                    if (Player != null)
                    {
                        Player.Position = new Half3(Info.RotationX, Info.RotationY, Info.RotationZ);
                    }

                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.UseObject))
                {
                    Event += 8;
                    List<UseObjectInfo> Infos = UseObject.ReadSyncInfo(Action, Receive, false);
                    for (int i = 0; i < Infos.Count; i++)
                    {
                        UseObjectInfo Info = Infos[i];
                        if (!Room.BotMode && Info.ObjectId != 65535 && (Info.SpaceFlags.HasFlag(CHARA_MOVES.HELI_STOPPED) || Info.SpaceFlags.HasFlag(CHARA_MOVES.HELI_IN_MOVE)))
                        {
                            bool SecurityBlock = false;
                            ObjectInfo Obj = Room.getObject(Info.ObjectId);
                            if (Obj != null)
                            {
                                if (Info.SpaceFlags.HasFlag(CHARA_MOVES.HELI_STOPPED))
                                {
                                    AnimModel anim = Obj.Animation;
                                    if (anim != null && anim.Id == 0)
                                    {
                                        Obj.Model.GetAnim(anim.NextAnim, 0, 0, Obj);
                                    }
                                }
                                else if (Info.SpaceFlags.HasFlag(CHARA_MOVES.HELI_IN_MOVE))
                                {
                                    DateTime date = Obj.UseDate;
                                    if (date.ToString("yyMMddHHmm") == "0101010000")
                                    {
                                        SecurityBlock = true;
                                    }
                                }
                                if (!SecurityBlock)
                                {
                                    Objs.Add(new ObjectHitInfo(3)
                                    {
                                        ObjSyncId = 1,
                                        ObjId = Obj.Id,
                                        ObjLife = Obj.Life,
                                        AnimId1 = 255,
                                        AnimId2 = Obj.Animation != null ? Obj.Animation.Id : 255,
                                        SpecialUse = AllUtils.GetDuration(Obj.UseDate),
                                    });
                                }
                            }
                        }
                        else
                        {
                            RemoveHit(Infos, i--);
                        }
                    }
                    UseObject.WriteInfo(Send, Infos);
                    Infos = null;
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.ActionForObjectSync))
                {
                    Event += 0x10;
                    ActionForObjectSync.WriteInfo(Send, Action, Receive, false);
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.RadioChat))
                {
                    Event += 0x20;
                    RadioChat.WriteInfo(Send, Action, Receive, false);
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.WeaponSync))
                {
                    Event += 0x40;
                    WeaponSyncInfo Info = WeaponSync.ReadInfo(Action, Receive, false);
                    WeaponSync.WriteInfo(Send, Info);
                    if (Player != null)
                    {
                        Player.Extensions = Info.Extensions;
                        Player.WeaponId = Info.WeaponId;
                        Player.WeaponClass = (CLASS_TYPE)AllUtils.getIdStatics(Info.WeaponId, 2);
                        Room.SyncInfo(Objs, 2);
                    }
                }
                /*if (Action.Flag.HasFlag(UDP_GAME_EVENTS.WeaponRecoil))
                {
                    Event += 0x80;
                    WeaponRecoil.WriteInfo(Send, Action, Receive, false);
                }*/
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.HpSync))
                {
                    Event += 0x100;
                    HpSync.writeInfo(Send, Receive, false);
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.Suicide))
                {
                    Event += 0x200;
                    List<SuicideInfo> Hits = Suicide.ReadInfo(Receive, false);
                    int BasicInfo = 0;
                    if (Player != null)
                    {
                        List<DeathServerData> Deaths = new List<DeathServerData>();
                        int ObjIdx = -1;
                        for (int i = 0; i < Hits.Count; i++)
                        {
                            SuicideInfo Hit = Hits[i];
                            if (Player != null && !Player.Dead && Player.Life > 0)
                            {
                                int Damage = (int)(Hit.HitInfo >> 20);
                                CHARA_DEATH DeathType = (CHARA_DEATH)(Hit.HitInfo & 15);
                                int KillerId = (int)((Hit.HitInfo >> 11) & 511);
                                int HitPart = (int)((Hit.HitInfo >> 4) & 63);
                                int Type = (int)((Hit.HitInfo >> 10) & 1); // 0 = User | 1 = Object
                                if (Type == 1) 
                                    ObjIdx = KillerId;
                                BasicInfo = Hit.WeaponId;

                                Player.Life -= Damage;
                                AssistModel Assist = new AssistModel();
                                Assist.RoomId = Room.RoomId;
                                Assist.Killer = Player.Slot;
                                Assist.Victim = Player.Slot;
                                Assist.Damage = Damage;
                                if (Player.Life <= 0)
                                {
                                    Assist.IsKiller = true;
                                    Assist.VictimDead = true;
                                }
                                else
                                {
                                    Assist.IsKiller = false;
                                    Assist.VictimDead = false;
                                }

                                // TODO: Add assist
                                //if (Assist.Killer != Assist.Victim)
                                   // DamageManager.Assists.Add(Assist);

                                if (Player.Life <= 0)
                                {
                                    DamageManager.SetDeath(Deaths, Player, Player, DeathType);
                                }
                                else
                                {
                                    DamageManager.SetHitEffect(Objs, Player, DeathType, HitPart);
                                }
                                Objs.Add(new ObjectHitInfo(2)
                                {
                                    ObjId = Player.Slot,
                                    ObjLife = Player.Life,
                                    DeathType = DeathType,
                                    HitPart = HitPart,
                                    WeaponId = BasicInfo,
                                    Position = Hit.PlayerPos,
                                });
                            }
                            else
                            {
                                RemoveHit(Hits, i--);
                            }
                        }
                        if (Deaths.Count > 0)
                        {
                            BattleSync.SendDeathSync(Room, Player, ObjIdx, BasicInfo, Deaths);
                        }
                        Deaths = null;
                    }
                    else
                    {
                        Hits = new List<SuicideInfo>();
                    }
                    Suicide.WriteInfo(Send, Hits);
                    Hits = null;
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.MissionData))
                {
                    Event += 0x400;
                    MissionDataInfo Info = MissionData.ReadInfo(Action, Receive, false, Time);
                    if (Room.Map != null && Player != null && !Player.Dead && Info.PlantTime > 0 && !Info.BombEnum.HasFlag(BOMB_FLAG.STOP))
                    {
                        BombPosition Bomb = Room.Map.GetBomb(Info.BombId);
                        if (Bomb != null)
                        {
                            bool isDefuse = Info.BombEnum.HasFlag(BOMB_FLAG.DEFUSE);
                            Vector3 BombVec3d;
                            if (isDefuse)
                            {
                                BombVec3d = Room.BombPosition;
                            }
                            else if (Info.BombEnum.HasFlag(BOMB_FLAG.START))
                            {
                                BombVec3d = Bomb.Position;
                            }
                            else
                            {
                                BombVec3d = new Half3(0, 0, 0);
                            }
                            double PlayerDistance = Vector3.Distance(Player.Position, BombVec3d);
                            if ((Bomb.EveryWhere || PlayerDistance <= 2.0) && (Player.Team == 1 && isDefuse || Player.Team == 0 && !isDefuse))
                            {
                                if (Player.C4Time != Info.PlantTime)
                                {
                                    Player.C4First = DateTime.Now;
                                    Player.C4Time = Info.PlantTime;
                                }
                                double Seconds = (DateTime.Now - Player.C4First).TotalSeconds;

                                float Objective = isDefuse ? Player.DefuseDuration : Player.PlantDuration;

                                if (((Time >= Info.PlantTime + (Objective)) || Seconds >= Objective) && (!Room.HasC4 && Info.BombEnum.HasFlag(BOMB_FLAG.START) || Room.HasC4 && isDefuse))
                                {
                                    Room.HasC4 = Room.HasC4 ? false : true;
                                    Info.Bomb |= 2;
                                    MissionData.SendC4UseSync(Room, Player, Info);
                                }
                            }
                        }
                    }
                    MissionData.WriteInfo(Send, Info);
                    Info = null;
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.DropWeapon))
                {
                    Event += 0x20000;
                    DropWeaponInfo dropWeaponInfo = DropWeapon.ReadInfo(Receive, false);
                    if (Room != null && !Room.BotMode)
                    {
                        Room.DropCounter++;
                        if (Room.DropCounter > BattleConfig.maxDrop)
                        {
                            Room.DropCounter = 0;
                        }
                        if (Player != null)
                        {
                            int idStatics = AllUtils.getIdStatics(dropWeaponInfo.WeaponId, 1);
                            if (idStatics == 1)
                            {
                                Player.Primary = 0;
                            }
                            if (idStatics == 2)
                            {
                                Player.Secondary = 0;
                            }
                        }
                    }
                    DropWeapon.WriteInfo(Send, dropWeaponInfo, (Room != null) ? Room.DropCounter : 0);
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.GetWeaponForClient))
                {
                    Event += 0x40000;
                    WeaponClient weaponClient = GetWeaponForClient.ReadInfo(Action, Receive, false);
                    if (!Room.BotMode)
                    {
                        if (Player != null)
                        {
                            int idStatics2 = AllUtils.getIdStatics(weaponClient.WeaponId, 1);
                            if (idStatics2 == 1)
                            {
                                Player.Primary = weaponClient.WeaponId;
                            }
                            if (idStatics2 == 2)
                            {
                                Player.Secondary = weaponClient.WeaponId;
                            }
                        }
                    }
                    GetWeaponForClient.WriteInfo(Send, weaponClient);
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.FireData))
                {
                    // TODO: Code fire data check
                    Event += 0x80000;
                    FireData.WriteInfo(Send, Action, Receive, false);
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.CharaFireNHitData))
                {
                    Event += 0x100000;
                    CharaFireNHitData.WriteInfo(Send, Receive, false);
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.HitData))
                {
                    Event += 0x200000;
                    List<HitDataInfo> Hits = HitData.ReadInfo(Receive, false);
                    List<DeathServerData> Deaths = new List<DeathServerData>();
                    int BasicInfo = 0;
                    if (Player != null)
                    {
                        for (int i = 0; i < Hits.Count; i++)
                        {
                            HitDataInfo Hit = Hits[i];
                            if (Hit.HitEnum == HIT_TYPE.HelmetProtection || Hit.HitEnum == HIT_TYPE.HeadshotProtection)
                            {
                                continue;
                            }
                            double HitDistance = Vector3.Distance(Hit.StartBullet, Hit.EndBullet);
                            if (Hit.WeaponClass == CLASS_TYPE.Knife && (MeleeExceptionsXml.Contains(AllUtils.getIdStatics(Hit.WeaponId, 3)) || HitDistance < 3) || Hit.WeaponClass != CLASS_TYPE.Knife)
                            {
                                int Damage = AllUtils.getHitDamageNormal(Hit.HitIndex), 
                                    ObjId = AllUtils.getHitWho(Hit.HitIndex), 
                                    HitPart = AllUtils.getHitPart(Hit.HitIndex);

                                // Check damage
                                Item Item = ItemManager.Items.Where(x => x.Id == Hit.WeaponId).FirstOrDefault();
                                if (Item != null && BattleConfig.damageCheckFromItems)
                                {
                                    if(Damage > Item.Damage)
                                        Damage = Item.Damage;
                                }
                                else if(BattleConfig.removeHitUnlisted) Damage = 0;

                                // Let's go on
                                CHARA_DEATH DeathType = CHARA_DEATH.DEFAULT;
                                BasicInfo = Hit.WeaponId;
                                OBJECT_TYPE HitType = AllUtils.getHitType(Hit.HitIndex);
                                if (HitType == OBJECT_TYPE.Object)
                                {
                                    ObjectInfo Obj = Room.getObject(ObjId);
                                    ObjectModel ObjM = Obj == null ? null : Obj.Model;
                                    if (ObjM != null && ObjM.Destroyable)
                                    {
                                        if (Obj.Life > 0)
                                        {
                                            Obj.Life -= Damage;
                                            if (Obj.Life <= 0)
                                            {
                                                Obj.Life = 0;
                                                DamageManager.BoomDeath(Room, Player, BasicInfo, Deaths, Objs, Hit.BoomPlayers);
                                            }
                                            Obj.DestroyState = ObjM.CheckDestroyState(Obj.Life);
                                            DamageManager.SabotageDestroy(Room, Player, ObjM, Obj, Damage);
                                            Objs.Add(new ObjectHitInfo(ObjM.UpdateId)
                                            {
                                                ObjId = Obj.Id,
                                                ObjLife = Obj.Life,
                                                KillerId = Action.Slot,
                                                ObjSyncId = ObjM.NeedSync ? 1 : 0,
                                                SpecialUse = AllUtils.GetDuration(Obj.UseDate),
                                                AnimId1 = ObjM.Animation,
                                                AnimId2 = Obj.Animation != null ? Obj.Animation.Id : 255,
                                                DestroyState = Obj.DestroyState,
                                            });
                                        }
                                    }
                                    else if (BattleConfig.sendFailMsg && ObjM == null)
                                    {
                                        Logger.warning("Fire Obj: " + ObjId + " Map: " + Room.MapId + " Invalid Object.");
                                        Player.LogPlayerPos(Hit.EndBullet);
                                    }
                                }
                                else if (HitType == OBJECT_TYPE.User)
                                {
                                    Player User;
                                    if (Room.getPlayer(ObjId, out User) && Player.RespawnLogicIsValid() && !Player.Dead && !User.Dead && !User.Immortal)
                                    {
                                        if (HitPart == 24)
                                        {
                                            DeathType = CHARA_DEATH.HEADSHOT;
                                        }
                                        if (Room.RoomType == ROOM_STATE_TYPE.DeathMatch && Room.Rule == 32 && DeathType != CHARA_DEATH.HEADSHOT)
                                        {
                                            Damage = 1;
                                        }
                                        else if (Room.RoomType == ROOM_STATE_TYPE.Boss && DeathType == CHARA_DEATH.HEADSHOT)
                                        {
                                            if (Room.LastRound == 1 && User.Team == 0 || Room.LastRound == 2 && User.Team == 1)
                                            {
                                                Damage = (Damage / 10);
                                            }
                                        }
                                        else if (Room.RoomType == ROOM_STATE_TYPE.DeathMatch && Room.Rule == 80)
                                        {
                                            Damage = 200;
                                        }
                                        if (BattleConfig.useHitMarker)
                                        {
                                            BattleSync.SendHitMarkerSync(Room, Player, (int)DeathType, (int)Hit.HitEnum, Damage);
                                        }

                                        AssistModel Assist = new AssistModel();
                                        User.Life -= Damage;
                                        Assist.RoomId = Room.RoomId;
                                        Assist.Killer = Player.Slot;
                                        Assist.Victim = User.Slot;
                                        Assist.Damage = Damage;
                                        if (User.Life <= 0)
                                        {
                                            Assist.IsKiller = true;
                                            Assist.VictimDead = true;
                                        }
                                        else
                                        {
                                            Assist.IsKiller = false;
                                            Assist.VictimDead = false;
                                        }
                                        // TODO: Add assist
                                        //if (Assist.Killer != Assist.Victim)
                                            //DamageManager.Assists.Add(Assist);
                                        DamageManager.SimpleDeath(Deaths, Objs, Player, User, Damage, BasicInfo, HitPart, DeathType);
                                    }
                                    else
                                    {
                                        RemoveHit(Hits, i--);
                                    }
                                }
                                else if (HitType == OBJECT_TYPE.UserObject)
                                {
                                    int ownerSlot = (ObjId >> 4);
                                    int grenadeMapId = (ObjId & 15);
                                }
                                else
                                {
                                    Logger.warning("HitType: (" + HitType + "/" + (int)HitType + ") Slot: " + Action.Slot);
                                    Logger.warning("BoomPlayers: " + Hit.BoomInfo + " " + Hit.BoomPlayers.Count);
                                }
                            }
                            else
                            {
                                RemoveHit(Hits, i--);
                            }
                        }
                        if (Deaths.Count > 0)
                        {
                            BattleSync.SendDeathSync(Room, Player, 255, BasicInfo, Deaths);
                        }
                    }
                    else
                    {
                        Hits = new List<HitDataInfo>();
                    }
                    HitData.WriteInfo(Send, Hits);
                    Deaths = null;
                    Hits = null;
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.GrenadeHit))
                {
                    Event += 0x400000;
                    List<GrenadeHitInfo> Hits = GrenadeHit.ReadInfo(Receive, false);
                    List<DeathServerData> Deaths = new List<DeathServerData>();
                    int BasicInfo = 0;
                    if (Player != null)
                    {
                        int idx = -1;
                        for (int i = 0; i < Hits.Count; i++)
                        {
                            GrenadeHitInfo Hit = Hits[i];
                            int Damage = AllUtils.getHitDamageNormal(Hit.HitInfo), ObjId = AllUtils.getHitWho(Hit.HitInfo), HitPart = AllUtils.getHitPart(Hit.HitInfo);
                            BasicInfo = Hit.WeaponId;
                            OBJECT_TYPE HitType = AllUtils.getHitType(Hit.HitInfo);
                            if (HitType == OBJECT_TYPE.Object)
                            {
                                ObjectInfo Obj = Room.getObject(ObjId);
                                ObjectModel ObjM = Obj == null ? null : Obj.Model;
                                if (ObjM != null && ObjM.Destroyable && Obj.Life > 0)
                                {
                                    Obj.Life -= Damage;
                                    if (Obj.Life <= 0)
                                    {
                                        Obj.Life = 0;
                                        DamageManager.BoomDeath(Room, Player, BasicInfo, Deaths, Objs, Hit.BoomPlayers);
                                    }
                                    Obj.DestroyState = ObjM.CheckDestroyState(Obj.Life);
                                    DamageManager.SabotageDestroy(Room, Player, ObjM, Obj, Damage);
                                    if (Damage > 0)
                                    {
                                        Objs.Add(new ObjectHitInfo(ObjM.UpdateId)
                                        {
                                            ObjId = Obj.Id,
                                            ObjLife = Obj.Life,
                                            KillerId = Action.Slot,
                                            ObjSyncId = ObjM.NeedSync ? 1 : 0,
                                            AnimId1 = ObjM.Animation,
                                            AnimId2 = Obj.Animation != null ? Obj.Animation.Id : 255,
                                            DestroyState = Obj.DestroyState,
                                            SpecialUse = AllUtils.GetDuration(Obj.UseDate),
                                        });
                                    }
                                }
                                else if (BattleConfig.sendFailMsg && ObjM == null)
                                {
                                    Logger.warning("Boom Obj: " + ObjId + " Map: " + Room.MapId + " Invalid Object.");
                                    Player.LogPlayerPos(Hit.HitPos);
                                }
                            }
                            else if (HitType == OBJECT_TYPE.User)
                            {
                                idx++;
                                Player User;
                                if (Damage > 0 && Room.getPlayer(ObjId, out User) && Player.RespawnLogicIsValid() && !User.Dead && !User.Immortal)
                                {
                                    if (Hit.DeathType == 10)
                                    {
                                        User.Life += Damage;
                                        User.CheckLifeValue();
                                    }
                                    else if (Hit.DeathType == 2 && CLASS_TYPE.Dino != Hit.WeaponClass && (idx % 2 == 0))
                                    {
                                        int valor = Damage;
                                        Damage = (int)Math.Ceiling(Damage / 2.7); // + 14;
                                        User.Life -= Damage;

                                        AssistModel Assist = new AssistModel();
                                        Assist.RoomId = Room.RoomId;
                                        Assist.Killer = Player.Slot;
                                        Assist.Victim = User.Slot;
                                        Assist.Damage = Damage;
                                        if (User.Life <= 0)
                                        {
                                            Assist.IsKiller = true;
                                            Assist.VictimDead = true;
                                        }
                                        else
                                        {
                                            Assist.IsKiller = false;
                                            Assist.VictimDead = false;
                                        }
                                        // TODO: Add assist
                                        //if (Assist.Killer != Assist.Victim) DamageManager.Assists.Add(Assist);

                                        if (User.Life <= 0)
                                        {
                                            DamageManager.SetDeath(Deaths, User, Player, (CHARA_DEATH)Hit.DeathType);
                                        }
                                        else
                                        {
                                            DamageManager.SetHitEffect(Objs, User, Player, (CHARA_DEATH)Hit.DeathType, HitPart);
                                        }
                                    }
                                    else
                                    {
                                        User.Life -= Damage;

                                        AssistModel Assist = new AssistModel();
                                        Assist.RoomId = Room.RoomId;
                                        Assist.Killer = Player.Slot;
                                        Assist.Victim = User.Slot;
                                        Assist.Damage = Damage;
                                        if (User.Life <= 0)
                                        {
                                            Assist.IsKiller = true;
                                            Assist.VictimDead = true;
                                        }
                                        else
                                        {
                                            Assist.IsKiller = false;
                                            Assist.VictimDead = false;
                                        }
                                        // TODO: Add assist
                                        //if (Assist.Killer != Assist.Victim) DamageManager.Assists.Add(Assist);
                                        if (User.Life <= 0)
                                        {
                                            DamageManager.SetDeath(Deaths, User, Player, (CHARA_DEATH)Hit.DeathType);
                                        }
                                        else
                                        {
                                            DamageManager.SetHitEffect(Objs, User, Player, (CHARA_DEATH)Hit.DeathType, HitPart);
                                        }
                                    }
                                    if (Damage > 0)
                                    {
                                        if (BattleConfig.useHitMarker)
                                        {
                                            BattleSync.SendHitMarkerSync(Room, Player, Hit.DeathType, (int)Hit.HitEnum, Damage);
                                        }
                                        Objs.Add(new ObjectHitInfo(2)
                                        {
                                            ObjId = User.Slot,
                                            ObjLife = User.Life,
                                            DeathType = (CHARA_DEATH)Hit.DeathType,
                                            WeaponId = BasicInfo,
                                            HitPart = HitPart,
                                        });
                                    }
                                }
                                else
                                {
                                    RemoveHit(Hits, i--);
                                }
                            }
                            else if (HitType == OBJECT_TYPE.UserObject)
                            {
                                int ownerSlot = (ObjId >> 4);
                                int grenadeMapId = (ObjId & 15);
                            }
                            else
                            {
                                Logger.warning("Grenade Boom, HitType: (" + HitType + "/" + (int)HitType + ")");
                            }
                        }
                        if (Deaths.Count > 0)
                        {
                            BattleSync.SendDeathSync(Room, Player, 255, BasicInfo, Deaths);
                        }
                    }
                    else
                    {
                        Hits = new List<GrenadeHitInfo>();
                    }
                    GrenadeHit.WriteInfo(Send, Hits);
                    Deaths = null;
                    Hits = null;
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.GetWeaponForHost))
                {
                    Event += 0x1000000;
                    GetWeaponForHost.WriteInfo(Send, Action, Receive, false);
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.FireDataOnObject))
                {
                    Event += 0x2000000;
                    FireDataOnObject.WriteInfo(Send, Receive, false);
                }
                if (Action.Flag.HasFlag(UDP_GAME_EVENTS.FireNHitDataOnObject))
                {
                    Event += 0x4000000;
                    FireNHitDataObjectInfo Info = FireNHitDataOnObject.ReadInfo(Action, Receive, false);
                    FireNHitDataOnObject.WriteInfo(Send, Info);
                    if (Player != null && !Player.Dead)
                    {
                        FireNHitDataOnObject.SendPassSync(Room, Player, Info);
                    }
                    Info = null;
                }
                EventsData = Send.mstream.ToArray();
                if (Event != (uint)Action.Flag)
                {
                    Logger.warning("[" + (uint)Action.Flag + " | " + ((uint)Action.Flag - Event));
                }
                return Objs;
            }
        }

        public void CheckDataFlags(ActionModel Action, PacketModel Packet)
        {
            UDP_GAME_EVENTS Flags = Action.Flag;
            if (!Flags.HasFlag(UDP_GAME_EVENTS.WeaponSync) || Packet.Opcode == 4)
            {
                return;
            }
            if ((Flags & (UDP_GAME_EVENTS.GetWeaponForClient | UDP_GAME_EVENTS.DropWeapon)) > 0)
            {
                Action.Flag -= UDP_GAME_EVENTS.WeaponSync;
            }
        }

        public byte[] WriteActionBytes(byte[] Data, Room Room, float time, PacketModel Packet)
        {
            ReceivePacket Receive = new ReceivePacket(Data);
            List<ObjectHitInfo> Objs = new List<ObjectHitInfo>();
            using (SendPacket Send = new SendPacket())
            {
                for (int i = 0; i < 16; i++)
                {
                    ActionModel Action = new ActionModel();
                    try
                    {
                        bool Exception;
                        Action.SubHead = (UDP_SUB_HEAD)Receive.readC(out Exception);
                        if (Exception)
                        {
                            break;
                        }
                        Action.Slot = Receive.readUH();
                        Action.Length = Receive.readUH();
                        if (Action.Length == 65535)
                        {
                            break;
                        }
                        Send.writeC((byte)Action.SubHead);
                        Send.writeH(Action.Slot);
                        Send.writeH(Action.Length);
                        if (Action.SubHead == UDP_SUB_HEAD.GRENADE)
                        {
                            GrenadeSync.WriteInfo(Send, Receive, false);
                        }
                        else if (Action.SubHead == UDP_SUB_HEAD.DROPEDWEAPON)
                        {
                            DropedWeapon.WriteInfo(Send, Receive, false);
                        }
                        else if (Action.SubHead == UDP_SUB_HEAD.OBJECT_STATIC)
                        {
                            ObjectStatic.WriteInfo(Send, Receive, false);
                        }
                        else if (Action.SubHead == UDP_SUB_HEAD.OBJECT_ANIM)
                        {
                            ObjectAnim.WriteInfo(Send, Receive, false);
                        }
                        else if (Action.SubHead == UDP_SUB_HEAD.STAGEINFO_OBJ_STATIC)
                        {
                            StageInfoObjStatic.WriteInfo(Send, Receive, false);
                        }
                        else if (Action.SubHead == UDP_SUB_HEAD.STAGEINFO_OBJ_ANIM)
                        {
                            StageObjAnim.WriteInfo(Send, Receive, false);
                        }
                        else if (Action.SubHead == UDP_SUB_HEAD.CONTROLED_OBJECT)
                        {
                            ControledObj.WriteInfo(Send, Receive, false);
                        }
                        else if (Action.SubHead == UDP_SUB_HEAD.USER || Action.SubHead == UDP_SUB_HEAD.STAGEINFO_CHARA)
                        {
                            Action.Flag = (UDP_GAME_EVENTS)Receive.readUD();
                            Action.Data = Receive.readB(Action.Length - 9);
                            CheckDataFlags(Action, Packet);
                            byte[] Result;
                            Objs.AddRange(getNewActions(Action, Room, time, out Result));
                            Send.GoBack(2);
                            Send.writeH((ushort)(Result.Length + 9));
                            Send.writeD((uint)Action.Flag);
                            Send.writeB(Result);
                            if (Action.Data.Length == 0 && (Action.Length - 9 != 0))
                            {
                                break;
                            }
                        }
                        else
                        {
                            Logger.warning("[SubHead: '" + Action.SubHead + "' or '" + (int)Action.SubHead + "']");
                            //throw new Exception("Unknown action type");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.warning("WriteActionBytes \r\n" + ex.ToString());
                        Logger.warning("WriteActionBytes Data: ");
                        Objs = new List<ObjectHitInfo>();
                        break;
                    }
                }
                if (Objs.Count > 0)
                {
                    Send.writeB(PROTOCOL_EVENTS_ACTION.getCodeSyncData(Objs));
                }
                Objs = null;
                return Send.mstream.ToArray();
            }
        }

        private void Send(byte[] data, IPEndPoint ip)
        {
            Client.Send(data, data.Length, ip);
        }
        public static string HexDump(byte[] bytes, int bytesPerLine = 16)
        {
            if (bytes == null) return "<null>";
            int bytesLength = bytes.Length;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                  8                   // 8 characters for the address
                + 3;                  // 3 spaces

            int firstCharColumn = firstHexColumn
                + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                + 2;                  // 2 spaces 

            int lineLength = firstCharColumn
                + bytesPerLine           // - characters to show the ascii value
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            return result.ToString();
        }
    }
}