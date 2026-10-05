using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;
using ProjectBlackout.Battle.Data.Sync;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class FireNHitDataOnObject
    {
        public static FireNHitDataObjectInfo ReadInfo(ActionModel ac, ReceivePacket p, bool genLog)
        {
            FireNHitDataObjectInfo info = new FireNHitDataObjectInfo
            {
                Portal = p.readUH()
            };
            if (genLog)
            {
                Logger.warning("Slot: " + ac.Slot + " passed on the portal [" + info.Portal + "]");
            }
            return info;
        }

        public static void ReadInfo(ReceivePacket p)
        {
            p.Advance(2);
        }

        public static void SendPassSync(Room room, Player p, FireNHitDataObjectInfo info)
        {
            BattleSync.SendPortalPass(room, p, info.Portal);
        }

        public static void WriteInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
        {
            FireNHitDataObjectInfo info = ReadInfo(ac, p, genLog);
            WriteInfo(s, info);
            info = null;
        }

        public static void WriteInfo(SendPacket s, FireNHitDataObjectInfo info)
        {
            s.writeH(info.Portal);
        }
    }
}