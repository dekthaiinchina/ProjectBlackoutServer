using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;
using ProjectBlackout.Battle.Data.Sync;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class MissionData
    {
        public static MissionDataInfo ReadInfo(ActionModel ac, ReceivePacket p, bool genLog, float time, bool OnlyBytes = false)
        {
            MissionDataInfo info = new MissionDataInfo
            {
                Bomb = p.readC(),
                PlantTime = p.readT()
            };
            if (!OnlyBytes)
            {
                info.BombEnum = (BOMB_FLAG)(info.Bomb & 15);
                info.BombId = (info.Bomb >> 4);
            }
            if (genLog)
            {
                Logger.warning("Slot: " + ac.Slot + " Bomb: " + info.BombEnum + " Id: " + info.BombId + " PlantTime: " + info.PlantTime + " Time: " + time);
            }
            return info;
        }

        public static void ReadInfo(ReceivePacket p)
        {
            p.Advance(5);
        }

        public static void SendC4UseSync(Room room, Player pl, MissionDataInfo info)
        {
            if (pl == null)
            {
                return;
            }
            int type = info.BombEnum.HasFlag(BOMB_FLAG.DEFUSE) ? 1 : 0;
            BattleSync.SendBombSync(room, pl, type, info.BombId);
        }

        public static void WriteInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog, float pacDate, float plantDuration)
        {
            MissionDataInfo info = ReadInfo(ac, p, genLog, pacDate);
            if (info.PlantTime > 0 && pacDate >= info.PlantTime + (plantDuration) && !info.BombEnum.HasFlag(BOMB_FLAG.STOP))
            {
                info.Bomb += 2;
            }
            WriteInfo(s, info);
            info = null;
        }

        public static void WriteInfo(SendPacket s, MissionDataInfo info)
        {
            s.writeC((byte)info.Bomb);
            s.writeT(info.PlantTime);
        }
    }
}