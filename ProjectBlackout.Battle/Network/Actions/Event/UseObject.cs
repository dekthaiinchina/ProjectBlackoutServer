using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;
using System.Collections.Generic;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class UseObject
    {
        public static List<UseObjectInfo> ReadSyncInfo(ActionModel ac, ReceivePacket p, bool genLog)
        {
            List<UseObjectInfo> Objs = new List<UseObjectInfo>();
            int Count = p.readC();
            for (int i = 0; i < Count; i++)
            {
                UseObjectInfo Info = new UseObjectInfo
                {
                    Use = p.readC(),
                    SpaceFlags = (CHARA_MOVES)p.readC(),
                    ObjectId = p.readUH()
                };
                if (genLog)
                {
                    Logger.warning("Slot: " + ac.Slot + " UseObject: Flag: " + Info.SpaceFlags + " ObjectId: " + Info.ObjectId);
                }
                Objs.Add(Info);
            }
            return Objs;
        }

        public static void WriteInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
        {
            List<UseObjectInfo> Info = ReadSyncInfo(ac, p, genLog);
            WriteInfo(s, Info);
            Info = null;
        }

        public static void WriteInfo(SendPacket s, List<UseObjectInfo> Infos)
        {
            s.writeC((byte)Infos.Count);
            for (int i = 0; i < Infos.Count; i++)
            {
                UseObjectInfo Obj = Infos[i];
                s.writeC(Obj.Use);
                s.writeC((byte)Obj.SpaceFlags);
                s.writeH(Obj.ObjectId);
            }
        }
    }
}