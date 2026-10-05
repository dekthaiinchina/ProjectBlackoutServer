using PointBlank.Battle.Data;
using PointBlank.Battle.Data.Enums;
using SharpDX;
using System.Collections.Generic;

namespace PointBlank.Battle.Network.Actions.Event
{
    public class InvalidHitData
    {
        public static List<HitData> ReadInfo(ReceivePacket p, bool genLog, bool OnlyBytes = false)
        {
            return BaseReadInfo(p, OnlyBytes, genLog);
        }

        public static void ReadInfo(ReceivePacket p)
        {
            int objsCount = p.readC();
            p.Advance(14 * objsCount);
        }

        private static List<HitData> BaseReadInfo(ReceivePacket p, bool OnlyBytes, bool genLog)
        {
            List<HitData> hits = new List<HitData>();
            int objsCount = p.readC();
            for (int ob = 0; ob < objsCount; ob++)
            {
                HitData hit = new HitData
                {
                    _hitInfo = p.readUH(),
                    FirePos = p.readUHVector(),
                    HitPos = p.readUHVector()
                };
                if (!OnlyBytes)
                {
                    hit.HitEnum = (HIT_TYPE)AllUtils.getHitHelmet(hit._hitInfo);
                }
                if (genLog)
                {
                    //Logger.warning("StartBulletAxis: " + hit._startBulletX + ";" + hit._startBulletY + ";" + hit._startBulletZ);
                    //Logger.warning("EndBulletAxis: " + hit._endBulletX + ";" + hit._endBulletY + ";" + hit._endBulletZ);
                }
                hits.Add(hit);
            }
            return hits;
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            List<HitData> hits = ReadInfo(p, genLog, true);
            WriteInfo(s, hits);
            hits = null;
        }

        public static void WriteInfo(SendPacket s, List<HitData> hits)
        {
            s.writeC((byte)hits.Count);
            for (int i = 0; i < hits.Count; i++)
            {
                HitData hit = hits[i];
                s.writeH(hit._hitInfo);
                s.writeHVector(hit.FirePos);
                s.writeHVector(hit.HitPos);
            }
        }

        public class HitData
        {
            public ushort _hitInfo;
            public Half3 FirePos, HitPos;
            public HIT_TYPE HitEnum;
        }
    }
}