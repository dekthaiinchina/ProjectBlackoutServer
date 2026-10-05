using ProjectBlackout.Battle.Data.Models.SubHead;

namespace ProjectBlackout.Battle.Network.Actions.SubHead
{
    public class ObjectStatic
    {
        public static byte[] ReadInfo(ReceivePacket p)
        {
            return p.readB(10);
        }

        public static ObjectStaticInfo ReadInfo(ReceivePacket p, bool genLog)
        {
            ObjectStaticInfo info = new ObjectStaticInfo
            {
                Type = p.readUH(),
                Life = p.readUH(),
                DestroyedBySlot = p.readUH(),
                Unk = p.readD()
            };
            if (genLog)
            {
                Logger.warning("[ObjectStatic] Life: " + info.Life + " Destroyed: " + info.DestroyedBySlot);
            }
            return info;
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p)
        {
            s.writeB(ReadInfo(p));
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            ObjectStaticInfo info = ReadInfo(p, genLog);
            s.writeH(info.Type);
            s.writeH(info.Life);
            s.writeH(info.DestroyedBySlot);
            s.writeD(info.Unk);
            info = null;
        }
    }
}