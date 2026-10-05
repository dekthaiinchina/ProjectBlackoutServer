using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_ACCEPT_REQUEST_ACK : SendPacket
    {
        private uint result;

        public PROTOCOL_CS_ACCEPT_REQUEST_ACK(uint result)
        {
            this.result = result;
        }

        public override void write()
        {
            writeH(1847);
            writeD(result);
        }
    }
}