using ProjectBlackout.Battle.Data.Models.SubHead;

namespace ProjectBlackout.Battle.Network.Actions.SubHead
{
    public class StageObjAnim
    {
        public static byte[] ReadInfo(ReceivePacket p)
        {
            return p.readB(9);
        }

        public static StageAnimInfo ReadInfo(ReceivePacket p, bool genLog)
        {
            StageAnimInfo info = new StageAnimInfo
            {
                _unk = p.readC(),
                _life = p.readUH(),
                _syncDate = p.readT(),
                _anim1 = p.readC(),
                _anim2 = p.readC()
            };
            if (genLog)
            {
                Logger.warning("[StageObjAnim] Unk: " + info._unk + " Life: " + info._life + " Sync: " + info._syncDate + " Animation[1]: " + info._anim1 + " Animation[2]: " + info._anim2);
            }
            return info;
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p)
        {
            s.writeB(ReadInfo(p));
        }

        public static void WriteInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            StageAnimInfo info = ReadInfo(p, genLog);
            s.writeC(info._unk);
            s.writeH(info._life);
            s.writeT(info._syncDate);
            s.writeC(info._anim1);
            s.writeC(info._anim2);
            info = null;
        }
    }
}