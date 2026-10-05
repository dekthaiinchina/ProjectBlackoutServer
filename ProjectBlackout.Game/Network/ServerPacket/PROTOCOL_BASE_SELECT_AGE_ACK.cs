using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_SELECT_AGE_ACK : SendPacket
    {
        private int Error;
        private int Age;

        public PROTOCOL_BASE_SELECT_AGE_ACK(int Error, int Age)
        {
            this.Error = Error;
            this.Age = Age;
        }

        public override void write()
        {
            writeH(3096);
            writeD(Error);
            if (Error == 0)
            {
                writeC((byte)Age);
            }
        }
    }
}
