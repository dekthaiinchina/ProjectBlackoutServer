using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;
using SharpDX;
using System.Collections.Generic;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class GrenadeHit
    {
        public static List<GrenadeHitInfo> ReadInfo(ReceivePacket p, bool genLog, bool OnlyBytes = false)
        {
            return BaseReadInfo(p, OnlyBytes, genLog);
        }

        public static void ReadInfo(ReceivePacket p)
        {
            int objsCount = p.readC();
            p.Advance(32 * objsCount);
        }

        private static List<GrenadeHitInfo> BaseReadInfo(ReceivePacket p, bool OnlyBytes, bool genLog)
        {
            List<GrenadeHitInfo> hits = new List<GrenadeHitInfo>();
            int objsCount = p.readC();
            for (int i = 0; i < objsCount; i++)
            {
                GrenadeHitInfo hit = new GrenadeHitInfo
                {
                    HitInfo = p.readUD(),
                    BoomInfo = p.readUH(),
                    PlayerPos = p.readUHVector(),
                    Extensions = p.readC(),
                    WeaponId = p.readD(),
                    DeathType = p.readC(),
                    FirePos = p.readUHVector(),
                    HitPos = p.readUHVector(),
                    GrenadesCount = p.readUH()
                };
                if (!OnlyBytes)
                {
                    hit.HitEnum = (HIT_TYPE)AllUtils.getHitHelmet(hit.HitInfo);
                    if (hit.BoomInfo > 0)
                    {
                        hit.BoomPlayers = new List<int>();
                        for (int s = 0; s < 16; s++)
                        {
                            int flag = (1 << s);
                            if ((hit.BoomInfo & flag) == flag)
                            {
                                hit.BoomPlayers.Add(s);
                            }
                        }
                    }
                    hit.WeaponClass = (CLASS_TYPE)AllUtils.getIdStatics(hit.WeaponId, 2);
                }
                if (genLog)
                {
                    Logger.warning("[Player Postion] X: " + hit.FirePos.X + "; Y: " + hit.FirePos.Y + "; Z: " + hit.FirePos.Z);
                    Logger.warning("[Object Postion] X: " + hit.HitPos.X + "; Y: " + hit.HitPos.Y + "; Z: " + hit.HitPos.Z);
                }
                hits.Add(hit);
            }
            return hits;
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            List<GrenadeHitInfo> hits = ReadInfo(p, genLog, true);
            WriteInfo(s, hits);
            hits = null;
        }

        public static void WriteInfo(SendPacket s, List<GrenadeHitInfo> hits)
        {
            s.writeC((byte)hits.Count);
            for (int i = 0; i < hits.Count; i++)
            {
                GrenadeHitInfo hit = hits[i];
                s.writeD(hit.HitInfo);
                s.writeH(hit.BoomInfo);
                s.writeHVector(hit.PlayerPos);
                s.writeC(hit.Extensions);
                s.writeD(hit.WeaponId);
                s.writeC(hit.DeathType);
                s.writeHVector(hit.FirePos);
                s.writeHVector(hit.HitPos);
                s.writeH(hit.GrenadesCount);
            }
        }
    }
}