using ProjectBlackout.Battle.Data.Models.SubHead;
using SharpDX;
using System;

namespace ProjectBlackout.Battle.Network.Actions.SubHead
{
    public class DropedWeapon
    {
        public static byte[] ReadInfo(ReceivePacket p)
        {
            return p.readB(15);
        }

        public static DropedWeaponInfo ReadInfo(ReceivePacket p, bool genLog)
        {
            DropedWeaponInfo info = new DropedWeaponInfo
            {
                WeaponFlag = p.readC(),
                X = p.readUH(),
                Y = p.readUH(),
                Z = p.readUH(),
                Unk1 = p.readUH(),
                Unk2 = p.readUH(),
                Unk3 = p.readUH(),
                Unk4 = p.readUH()
            };
            if (genLog)
            {
                Vector3 vec = new Half3(info.X, info.Y, info.Z);
                Logger.warning("[WeaponSync] " + BitConverter.ToString(p.getBuffer()));
                Logger.warning("[WeaponSync] Flag: " + info.WeaponFlag);
                Logger.warning("[WeaponSync] X: " + vec.X + " Y: " + vec.Y + " Z: " + vec.Z);
            }
            return info;
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p)
        {
            s.writeB(ReadInfo(p));
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            DropedWeaponInfo info = ReadInfo(p, genLog);
            s.writeC(info.WeaponFlag);
            s.writeH(info.X);
            s.writeH(info.Y);
            s.writeH(info.Z);
            s.writeH(info.Unk1);
            s.writeH(info.Unk2);
            s.writeH(info.Unk3);
            s.writeH(info.Unk4);
            info = null;
        }
    }
}