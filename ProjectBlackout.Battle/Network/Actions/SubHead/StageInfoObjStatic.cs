using ProjectBlackout.Battle.Data.Models.SubHead;

namespace ProjectBlackout.Battle.Network.Actions.SubHead
{
    public class StageInfoObjStatic
    {
        public static StageStaticInfo ReadSyncInfo(ReceivePacket p, bool genLog)
        {
            StageStaticInfo info = new StageStaticInfo
            {
                _isDestroyed = p.readC() // 0 = Normal| 1 = Quebrado
            };
            if (genLog)
            {
                Logger.warning("[StageInfoObjStatic] Destroyed: " + info._isDestroyed);
            }
            return info;
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            StageStaticInfo info = ReadSyncInfo(p, genLog);
            s.writeC(info._isDestroyed);
            info = null;
        }
    }
}