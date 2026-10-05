using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_REPLACE_PERSONMAX_ACK : SendPacket
    {
        private int _max;

        public PROTOCOL_CS_REPLACE_PERSONMAX_ACK(int max)
        {
            _max = max;
        }

        public override void write()
        {
            writeH(1897);
            writeD(0); // ?
            writeC((byte)_max);
        }
    }
}