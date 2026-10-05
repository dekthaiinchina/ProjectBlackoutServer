using System;

namespace Battle.network.actions.others
{
    public class code10_StageObjMove
    {
        public static byte[] ReadInfo(ReceivePacket p)
        {
            return p.readB(7);
        }
        public static Struct ReadInfo(ReceivePacket p, bool genLog)
        {
            Struct info = new Struct
            {
                state = p.readC(),
                _unk = p.readB(6)
            };
            if (genLog)
                Logger.warning("[code10_StageObjMove] " + BitConverter.ToString(info._unk));
            return info;
        }
        public static void writeInfo(SendPacket s, ReceivePacket p)
        {
            s.writeB(ReadInfo(p));
        }
        public static void writeInfo(SendPacket s, ReceivePacket p, bool genLog)
        {
            Struct info = ReadInfo(p, genLog);
            s.writeC((byte)info.state);
            s.writeB(info._unk);
            info = null;
        }
        public class Struct
        {
            public byte[] _unk;
            public int state;
        }
    }
}