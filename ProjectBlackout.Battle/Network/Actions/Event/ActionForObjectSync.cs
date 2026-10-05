using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event.Event;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class ActionForObjectSync
    {
        public static ActionObjectInfo ReadSyncInfo(ActionModel ac, ReceivePacket p, bool genLog)
        {
            ActionObjectInfo info = new ActionObjectInfo
            {
                Unk1 = p.readC(),
                Unk2 = p.readC()
            };
            if (genLog)
            {
                Logger.warning("Slot: " + ac.Slot + " ActionForObjectSync: Unk (" + info.Unk1 + ";" + info.Unk2 + ")");
            }
            return info;
        }

        public static void WriteInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
        {
            ActionObjectInfo info = ReadSyncInfo(ac, p, genLog);
            s.writeC(info.Unk1);
            s.writeC(info.Unk2);
            info = null;
        }
    }
}
