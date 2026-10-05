using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class WeaponRecoil
    {
        public static WeaponRecoilInfo ReadInfo(ActionModel ac, ReceivePacket p, bool genLog)
        {
            WeaponRecoilInfo info = new WeaponRecoilInfo
            {
                RecoilHorzAngle = p.readT(),
                RecoilHorzMax = p.readT(),
                RecoilVertAngle = p.readT(),
                RecoilVertMax = p.readT(),
                Deviation = p.readT(),
                Extensions = p.readC(),
                WeaponId = p.readD(),
                Unk = p.readC(),
                RecoilHorzCount = p.readC()
            };
            if (genLog)
            {
                Logger.warning("Slot: " + ac.Slot + " WeaponId: " + info.WeaponId);
            }
            return info;
        }

        public static void ReadInfo(ReceivePacket p)
        {
            p.Advance(27);
        }

        public static void WriteInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
        {
            WeaponRecoilInfo info = ReadInfo(ac, p, genLog);
            s.writeT(info.RecoilHorzAngle);
            s.writeT(info.RecoilHorzMax);
            s.writeT(info.RecoilVertAngle);
            s.writeT(info.RecoilVertMax);
            s.writeT(info.Deviation);
            s.writeC(info.Extensions);
            s.writeD(info.WeaponId);
            s.writeC(info.Unk);
            s.writeC(info.RecoilHorzCount);
            info = null;
        }
    }
}