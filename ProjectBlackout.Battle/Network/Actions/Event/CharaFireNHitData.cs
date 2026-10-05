using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class CharaFireNHitData
    {
        public static void ReadInfo(ReceivePacket p)
        {
            int Count = p.readC();
            p.Advance(17 * Count);
        }

        public static List<CharaFireNHitDataInfo> ReadInfo(ReceivePacket p, bool genLog)
        {
            List<CharaFireNHitDataInfo> Hits = new List<CharaFireNHitDataInfo>();
            int Count = p.readC();
            for (int i = 0; i < Count; i++)
            {
                CharaFireNHitDataInfo Hit = new CharaFireNHitDataInfo
                {
                    HitInfo = p.readUD(),
                    Extensions = p.readC(),
                    WeaponId = p.readD(),
                    Unk = p.readUH(),
                    X = p.readUH(),
                    Y = p.readUH(),
                    Z = p.readUH()
                };
                if (genLog)
                {
                    Logger.warning("X: " + Hit.X + " Y: " + Hit.Y + " Z: " + Hit.Z);
                    Logger.warning("[" + i + "] Hit: " + BitConverter.ToString(p.getBuffer()));
                }
                Hits.Add(Hit);
            }
            return Hits;
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            List<CharaFireNHitDataInfo> Hits = ReadInfo(p, genLog);
            s.writeC((byte)Hits.Count);
            for (int i = 0; i < Hits.Count; i++)
            {
                CharaFireNHitDataInfo Hit = Hits[i];
                s.writeD(Hit.HitInfo);
                s.writeC(Hit.Extensions);
                s.writeD(Hit.WeaponId);
                s.writeH(Hit.Unk);
                s.writeH(Hit.X);
                s.writeH(Hit.Y);
                s.writeH(Hit.Z);
            }
            Hits = null;
        }
    }
}