using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_REPLACE_COLOR_NAME_RESULT_ACK : SendPacket
    {
        private byte color;

        public PROTOCOL_CS_REPLACE_COLOR_NAME_RESULT_ACK(byte color)
        {
            this.color = color;
        }

        public override void write()
        {
            writeH(1926);
            writeC(color);
        }
    }
}