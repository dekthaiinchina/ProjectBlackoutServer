using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class Animation
    {
        public static AnimationInfo ReadInfo(ActionModel ac, ReceivePacket p, bool genLog)
        {
            AnimationInfo info = new AnimationInfo
            {
                Animation = p.readUH()
            };
            if (genLog)
            {
                Logger.warning("Slot: " + ac.Slot + " is moving the crosshair position: posV (" + info.Animation + ")");
            }
            return info;
        }

        public static void WriteInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
        {
            AnimationInfo info = ReadInfo(ac, p, genLog);
            s.writeH(info.Animation);
            info = null;
        }
    }
}