using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.SubHead;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Battle.Network.Actions.SubHead
{
    public class GrenadeSync
    {
        public static GrenadeInfo ReadInfo(ReceivePacket p, bool genLog, bool OnlyBytes = false)
        {
            return BaseReadInfo(p, OnlyBytes, genLog);
        }

        private static GrenadeInfo BaseReadInfo(ReceivePacket p, bool OnlyBytes, bool genLog)
        {
            GrenadeInfo info = new GrenadeInfo
            {
                Extensions = p.readC(),
                WeaponId = p.readD(),
                BoomInfo = p.readUH(),
                ObjPos_X = p.readUH(),
                ObjPos_Y = p.readUH(),
                ObjPos_Z = p.readUH(),
                Unk1 = p.readUH(),
                Unk2 = p.readUH(),
                Unk3 = p.readUH(),
                GrenadesCount = p.readUH(),
                Unk4 = p.readUH(),
                Unk5 = p.readUH(),
                Unk6 = p.readUH(),
            };
            if (genLog)
            {
                Logger.warning("[GrenadeSync] " + BitConverter.ToString(p.getBuffer()));
                Logger.warning("[GrenadeSync] WeaponId: " + info.WeaponId);
            }
            return info;
        }

        public static byte[] ReadInfo(ReceivePacket p)
        {
            return p.readB(27);
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p)
        {
            s.writeB(ReadInfo(p));
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            GrenadeInfo info = ReadInfo(p, genLog, true);
            s.writeC(info.Extensions);
            s.writeD(info.WeaponId);
            s.writeH(info.BoomInfo);
            s.writeH(info.ObjPos_X);
            s.writeH(info.ObjPos_Y);
            s.writeH(info.ObjPos_Z);
            s.writeH(info.Unk1);
            s.writeH(info.Unk2);
            s.writeH(info.Unk3);
            s.writeH(info.GrenadesCount);
            s.writeH(info.Unk4);
            s.writeH(info.Unk5);
            s.writeH(info.Unk6);
            info = null;
        }
    }
}