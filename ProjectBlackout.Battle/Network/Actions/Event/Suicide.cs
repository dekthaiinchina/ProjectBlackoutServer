using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;
using SharpDX;
using System.Collections.Generic;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class Suicide
    {
        public static List<SuicideInfo> ReadInfo(ReceivePacket p, bool genLog, bool OnlyBytes = false)
        {
            return BaseReadInfo(p, OnlyBytes, genLog);
        }

        private static List<SuicideInfo> BaseReadInfo(ReceivePacket p, bool OnlyBytes, bool genLog)
        {
            List<SuicideInfo> hits = new List<SuicideInfo>();
            int count = p.readC();
            for (int i = 0; i < count; i++)
            {
                SuicideInfo hit = new SuicideInfo
                {
                    HitInfo = p.readUD(),
                    Extensions = p.readC(),
                    WeaponId = p.readD(),
                    PlayerPos = p.readUHVector()
                };
                if (!OnlyBytes)
                {

                }
                if (genLog)
                {
                    Logger.warning("[" + i + "] Suicide: Hit: " + hit.HitInfo + " WeaponId: " + hit.WeaponId + " X: " + hit.PlayerPos.X + " Y: " + hit.PlayerPos.Y + " Z: " + hit.PlayerPos.Z);
                }
                hits.Add(hit);
            }
            return hits;
        }

        public static void ReadInfo(ReceivePacket p)
        {
            int count = p.readC();
            p.Advance(15 * count);
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            List<SuicideInfo> hits = ReadInfo(p, genLog, true);
            WriteInfo(s, hits);
            hits = null;
        }

        public static void WriteInfo(SendPacket s, List<SuicideInfo> hits)
        {
            s.writeC((byte)hits.Count);
            for (int i = 0; i < hits.Count; i++)
            {
                SuicideInfo hit = hits[i];
                s.writeD(hit.HitInfo);
                s.writeC(hit.Extensions);
                s.writeD(hit.WeaponId);
                s.writeHVector(hit.PlayerPos);
            }
        }
    }
}