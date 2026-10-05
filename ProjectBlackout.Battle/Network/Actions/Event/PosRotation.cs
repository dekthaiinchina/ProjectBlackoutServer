using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class PosRotation
    {
        public static PosRotationInfo ReadInfo(ReceivePacket p, bool genLog)
        {
            PosRotationInfo info = new PosRotationInfo
            {
                RotationX = p.readUH(),
                RotationY = p.readUH(),
                RotationZ = p.readUH(),
                CameraX = p.readUH(),
                CameraY = p.readUH(),
                Area = p.readUH()
            };
            if (genLog)
            {
               //Logger.warning("Slot " + aM._slot + " is now in: rX,rY,rZ,cX,cY,A (" + info._rotationX + ";" + info._rotationY + ";" + info._rotationZ + ";" + info._cameraX + ";" + info._cameraY + ";" + info._area + ")");
            }
            return info;
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            PosRotationInfo info = ReadInfo(p, genLog);
            WriteInfo(s, info);
            info = null;
        }

        public static void WriteInfo(SendPacket s, PosRotationInfo info)
        {
            s.writeH(info.RotationX);
            s.writeH(info.RotationY);
            s.writeH(info.RotationZ);
            s.writeH(info.CameraX);
            s.writeH(info.CameraY);
            s.writeH(info.Area);
        }
    }
}