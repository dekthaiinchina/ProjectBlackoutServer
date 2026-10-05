using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class GetWeaponForHost
    {
        public static WeaponHost ReadInfo(ActionModel ac, ReceivePacket p, bool genLog)
        {
            WeaponHost info = new WeaponHost
            {
                DeathType = p.readC(),
                HitPart = p.readC(),
                X = p.readUH(),
                Y = p.readUH(),
                Z = p.readUH(),
                WeaponId = p.readD()
            };
            if (genLog)
            {
                Logger.warning("Slot: " + ac.Slot + " Type: " + info.DeathType + " Hit: " + info.HitPart + " X: " + info.X + " Y: " + info.Y + " Z: " + info.Z + " WeaponId: " + info.WeaponId);
            }
            return info;
        }

        public static void ReadInfo(ReceivePacket p)
        {
            p.Advance(13);
        }

        public static void WriteInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
        {
            WeaponHost info = ReadInfo(ac, p, genLog);
            WriteInfo(s, info);
            info = null;
        }

        public static void WriteInfo(SendPacket s, WeaponHost info)
        {
            s.writeC(info.DeathType);
            s.writeC(info.HitPart);
            s.writeH(info.X);
            s.writeH(info.Y);
            s.writeH(info.Z);
            s.writeD(info.WeaponId);
        }
    }
}