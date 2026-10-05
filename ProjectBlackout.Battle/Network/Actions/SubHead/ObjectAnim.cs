using ProjectBlackout.Battle.Data.Models.SubHead;

namespace ProjectBlackout.Battle.Network.Actions.SubHead
{
    public class ObjectAnim
    {
        public static byte[] ReadInfo(ReceivePacket p)
        {
            return p.readB(8);
        }

        public static ObjectAnimInfo ReadInfo(ReceivePacket p, bool genLog)
        {
            ObjectAnimInfo info = new ObjectAnimInfo
            {
                _life = p.readUH(),
                _anim1 = p.readC(),
                _anim2 = p.readC(),
                _syncDate = p.readT()
            };
            if (genLog)
            {
                Logger.warning("[ObjectAnim] Life: " + info._life + " Animation[1]: " + info._anim1 + " Animation[2]: " + info._anim2 + " Sync: " + info._syncDate);
            }
            return info;
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p)
        {
            s.writeB(ReadInfo(p));
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            ObjectAnimInfo info = ReadInfo(p, genLog);
            s.writeH(info._life);
            s.writeC(info._anim1);
            s.writeC(info._anim2);
            s.writeT(info._syncDate);
            info = null;
        }
    }
}