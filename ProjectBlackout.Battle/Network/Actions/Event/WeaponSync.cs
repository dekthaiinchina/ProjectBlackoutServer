using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class WeaponSync
    {
        public static WeaponSyncInfo ReadInfo(ActionModel ac, ReceivePacket p, bool genLog, bool OnlyBytes = false)
        {
            return BaseReadInfo(ac, p, OnlyBytes, genLog);
        }

        private static WeaponSyncInfo BaseReadInfo(ActionModel ac, ReceivePacket p, bool OnlyBytes, bool genLog)
        {
            WeaponSyncInfo info = new WeaponSyncInfo
            {
                Extensions = p.readC(),
                WeaponId = p.readD()
            };
            if (!OnlyBytes)
            {
                /*info.WeaponSlot = AllUtils.getIdStatics(info.WeaponInfo, 2);
                info.WeaponClass = AllUtils.getIdStatics(info.WeaponInfo, 3);
                info.WeaponId = AllUtils.getIdStatics(info.WeaponInfo, 4);*/
            }
            if (genLog)
            {
                //Logger.warning("Slot " + aM._slot + " weapon sync: wInfo,ID,wSlot,charaModel (" + info._weaponInfo + ";" + (info._weaponInfo >> 6) + ";" + info._weaponSlot + ";" + info._charaModelId + ")");
            }
            return info;
        }

        public static void WriteInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
        {
            WeaponSyncInfo info = ReadInfo(ac, p, genLog, true);
            WriteInfo(s, info);
            info = null;
        }

        public static void WriteInfo(SendPacket s, WeaponSyncInfo info)
        {
            s.writeC(info.Extensions);
            s.writeD(info.WeaponId);
        }
    }
}