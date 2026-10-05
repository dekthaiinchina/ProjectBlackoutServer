using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;
using SharpDX;
using System.Collections.Generic;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class HitData
    {
        public static List<HitDataInfo> ReadInfo(ReceivePacket Packet, bool Log, bool OnlyBytes = false)
        {
            return BaseReadInfo(Packet, OnlyBytes, Log);
        }

        public static void ReadInfo(ReceivePacket Packet)
        {
            int Count = Packet.readC();
            Packet.Advance(35 * Count);
        }

        private static List<HitDataInfo> BaseReadInfo(ReceivePacket Packet, bool OnlyBytes, bool Log)
        {
            List<HitDataInfo> Hits = new List<HitDataInfo>();
            int Count = Packet.readC();
            for (int i = 0; i < Count; i++)
            {
                HitDataInfo Hit = new HitDataInfo
                {
                    HitIndex = Packet.readUD(),
                    BoomInfo = Packet.readUH(),
                    Extensions = Packet.readC(),
                    WeaponId = Packet.readD(),
                    StartBullet = Packet.readTVector(),
                    EndBullet = Packet.readTVector()
                };
                if (!OnlyBytes)
                {
                    Hit.HitEnum = (HIT_TYPE)AllUtils.getHitHelmet(Hit.HitIndex);
                    if (Hit.BoomInfo > 0)
                    {
                        Hit.BoomPlayers = new List<int>();
                        for (int Slot = 0; Slot < 16; Slot++)
                        {
                            int Flag = (1 << Slot);
                            if ((Hit.BoomInfo & Flag) == Flag)
                            {
                                Hit.BoomPlayers.Add(Slot);
                            }
                        }
                    }
                    Hit.WeaponClass = (CLASS_TYPE)AllUtils.getIdStatics(Hit.WeaponId, 2);
                }
                if (Log)
                {
                    //Logger.warning("StartBulletAxis: " + hit._startBulletX + ";" + hit._startBulletY + ";" + hit._startBulletZ);
                    //Logger.warning("EndBulletAxis: " + hit._endBulletX + ";" + hit._endBulletY + ";" + hit._endBulletZ);
                }
                Hits.Add(Hit);
            }
            return Hits;
        }

        public static void WriteInfo(SendPacket Send, ReceivePacket Packet, bool Log)
        {
            List<HitDataInfo> Hits = ReadInfo(Packet, Log, true);
            WriteInfo(Send, Hits);
            Hits = null;
        }

        public static void WriteInfo(SendPacket Send, List<HitDataInfo> Hits)
        {
            Send.writeC((byte)Hits.Count);
            for (int i = 0; i < Hits.Count; i++)
            {
                HitDataInfo Hit = Hits[i];
                Send.writeD(Hit.HitIndex);
                Send.writeH(Hit.BoomInfo);
                Send.writeC(Hit.Extensions);
                Send.writeD(Hit.WeaponId);
                Send.writeTVector(Hit.StartBullet);
                Send.writeTVector(Hit.EndBullet);
            }
        }
    }
}