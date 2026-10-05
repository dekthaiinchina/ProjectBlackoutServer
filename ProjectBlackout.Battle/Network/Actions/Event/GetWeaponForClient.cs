using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Configs;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;


namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class GetWeaponForClient
    {
        public static WeaponClient ReadInfo(ActionModel ac, ReceivePacket p, bool genLog)
        {
            WeaponClient info = new WeaponClient
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
                Logger.warning("Slot: " + ac.Slot + " WeaponId: " + info.WeaponId);
            }
            return info;
        }

        public static void ReadInfo(ReceivePacket p)
        {
            p.Advance(8);
        }

        public static void WriteInfo(SendPacket s, WeaponClient info)
        {
            s.writeC(info.WeaponFlag);
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