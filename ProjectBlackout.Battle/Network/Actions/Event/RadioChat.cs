using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class RadioChat
    {
        public static RadioChatInfo ReadSyncInfo(ActionModel ac, ReceivePacket p, bool genLog)
        {
            RadioChatInfo info = new RadioChatInfo
            {
                RadioId = p.readC(),
                AreaId = p.readC()
            };
            if (genLog)
            {
                Logger.warning("Slot: " + ac.Slot + " Radio: " + info.RadioId + " Area: " + info.AreaId);
            }
            return info;
        }

        public static void WriteInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
        {
            RadioChatInfo info = ReadSyncInfo(ac, p, genLog);
            s.writeC(info.RadioId);
            s.writeC(info.AreaId);
            info = null;
        }
    }
}