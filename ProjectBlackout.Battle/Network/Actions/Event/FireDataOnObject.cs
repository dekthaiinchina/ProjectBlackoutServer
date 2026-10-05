using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;
using System;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class FireDataOnObject
    {
        public static FireDataObjectInfo ReadInfo(ReceivePacket p, bool genLog)
        {
            FireDataObjectInfo info = new FireDataObjectInfo
            {
                ShotId = p.readUH(),
            };
            return info;
        }

        public static void ReadInfo(ReceivePacket p)
        {
            p.Advance(2);
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            FireDataObjectInfo info = ReadInfo(p, genLog);
            s.writeH(info.ShotId);
            info = null;
        }
    }
}