using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Battle.Network.Packets
{
    public class PROTOCOL_EVENTS_ACTION
    {
        public static byte[] getCode(byte[] actions, DateTime date, int round, int slot)
        {
            byte[] Encrypted = AllUtils.Encrypt(actions, (13 + actions.Length) % 6 + 1);
            return BaseGetCode(Encrypted, date, round, slot);
        }

        private static byte[] BaseGetCode(byte[] actionsBuffer, DateTime date, int round, int slot)
        {
            using (SendPacket s = new SendPacket())
            {
                s.writeC(4);
                s.writeC((byte)slot);
                s.writeT(AllUtils.GetDuration(date));
                s.writeC((byte)round);
                s.writeH((ushort)(13 + actionsBuffer.Length));
                s.writeD(0);
                s.writeB(actionsBuffer);
                return s.mstream.ToArray();
            }
        }

        public static byte[] getCodeSyncData(List<ObjectHitInfo> objs)
        {
            using (SendPacket s = new SendPacket())
            {
                for (int i = 0; i < objs.Count; i++)
                {
                    ObjectHitInfo obj = objs[i];
                    if (obj.Type == 1)
                    {
                        if (obj.ObjSyncId == 0)
                        {
                            s.writeC((byte)UDP_SUB_HEAD.OBJECT_STATIC);
                            s.writeH((ushort)obj.ObjId);
                            s.writeH(10);
                            s.writeH((ushort)CHARA_DEATH.FAST_OBJECT);
                            s.writeH((ushort)obj.ObjLife);
                            s.writeC((byte)obj.KillerId);
                        }
                        else
                        {
                            s.writeC((byte)UDP_SUB_HEAD.OBJECT_STATIC);
                            s.writeH((ushort)obj.ObjId);
                            s.writeH(13);
                            s.writeH((ushort)obj.ObjLife);
                            s.writeC((byte)obj.AnimId1);
                            s.writeC((byte)obj.AnimId2);
                            s.writeT(obj.SpecialUse);
                        }
                    }
                    else if (obj.Type == 2)
                    {
                        UDP_GAME_EVENTS events = UDP_GAME_EVENTS.HpSync;
                        int Length = 11;
                        if (obj.ObjLife == 0)
                        {
                            events |= UDP_GAME_EVENTS.GetWeaponForHost;
                            Length += 12;
                        }
                        s.writeC((byte)UDP_SUB_HEAD.USER);
                        s.writeH((ushort)obj.ObjId);
                        s.writeH((ushort)Length);
                        s.writeD((uint)events);
                        s.writeH((ushort)obj.ObjLife);
                        if (events.HasFlag(UDP_GAME_EVENTS.GetWeaponForHost))
                        {
                            s.writeC((byte)obj.DeathType);
                            s.writeC((byte)obj.HitPart);
                            s.writeH(obj.Position.X.RawValue);
                            s.writeH(obj.Position.Y.RawValue);
                            s.writeH(obj.Position.Z.RawValue);
                            s.writeD(obj.WeaponId);
                        }
                    }
                    else if (obj.Type == 3)
                    {
                        if (obj.ObjSyncId == 0)
                        {
                            s.writeC((byte)UDP_SUB_HEAD.OBJECT_STATIC);
                            s.writeH((ushort)obj.ObjId);
                            s.writeH(8);
                            s.writeH(1);
                            s.writeC((obj.ObjLife == 0));
                        }
                        else
                        {
                            s.writeC((byte)UDP_SUB_HEAD.OBJECT_STATIC);
                            s.writeH((ushort)obj.ObjId);
                            s.writeH(14);
                            s.writeC((byte)obj.DestroyState);
                            s.writeH((ushort)obj.ObjLife);
                            s.writeT(obj.SpecialUse);
                            s.writeC((byte)obj.AnimId1);
                            s.writeC((byte)obj.AnimId2);
                        }
                    }
                    else if (obj.Type == 4)
                    {
                        s.writeC((byte)UDP_SUB_HEAD.STAGEINFO_CHARA);
                        s.writeH((ushort)obj.ObjId);
                        s.writeH(11);
                        s.writeD(256);
                        s.writeH((ushort)obj.ObjLife);
                    }
                    else if (obj.Type == 5)
                    {
                        s.writeC((byte)UDP_SUB_HEAD.USER); // 0
                        s.writeH((ushort)obj.ObjId);
                        s.writeH((short)UDP_SUB_HEAD.STAGEINFO_MISSION); // 14
                        s.writeD(64);
                        s.writeC(obj.Extensions);
                        s.writeD(obj.WeaponId);
                    }
                }
                return s.mstream.ToArray();
            }
        }
    }
}