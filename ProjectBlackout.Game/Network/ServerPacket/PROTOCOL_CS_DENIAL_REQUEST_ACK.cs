using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_DENIAL_REQUEST_ACK : SendPacket
    {
        private int result;

        public PROTOCOL_CS_DENIAL_REQUEST_ACK(int result)
        {
            this.result = result;
        }

        public override void write()
        {
            writeH(1850);
            writeD(result);
        }
    }
}