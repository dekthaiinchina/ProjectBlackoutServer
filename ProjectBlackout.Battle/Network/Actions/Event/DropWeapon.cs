using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Configs;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;
using System;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class DropWeapon
    {
        public static DropWeaponInfo ReadInfo(ReceivePacket p, bool genLog)
        {
            DropWeaponInfo info = new DropWeaponInfo
            {
                WeaponFlag = p.readC(),
                WeaponId = p.readD(),
                Extensions = p.readC(),
                AmmoPrin = p.readUH(),
                AmmoDual = p.readUH(),
                AmmoTotal = p.readUH(),
                Unk1 = p.readUH(),
                Unk2 = p.readD()
            };
            if (genLog)
            {
                Logger.warning("[ActionBuffer]: " + BitConverter.ToString(p.getBuffer()));
                Logger.warning("[DropWeapon] WeaponId: " + info.WeaponId);
            }
            return info;
        }

        public static void ReadInfo(ReceivePacket p)
        {
            p.Advance(8);
        }

        public static void WriteInfo(SendPacket s, DropWeaponInfo info, int count)
        {
            s.writeC((byte)(info.WeaponFlag + count));
            s.writeD(info.WeaponId);
            s.writeC(info.Extensions);
            if (BattleConfig.useMaxAmmoInDrop)
            {
                s.writeH(65535);
                s.writeH(info.AmmoDual);
                s.writeH(10000);
            }
            else
            {
                s.writeH(info.AmmoPrin);
                s.writeH(info.AmmoDual);
                s.writeH(info.AmmoTotal);
            }
            s.writeH(info.Unk1);
            s.writeD(info.Unk2);
            info = null;
        }
    }
}