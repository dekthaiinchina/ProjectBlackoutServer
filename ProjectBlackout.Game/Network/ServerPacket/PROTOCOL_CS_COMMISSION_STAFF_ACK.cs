using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_COMMISSION_STAFF_ACK : SendPacket
    {
        private uint result;

        public PROTOCOL_CS_COMMISSION_STAFF_ACK(uint result)
        {
            this.result = result;
        }

        public override void write()
        {
            writeH(1861);
            writeD(result);
        }
    }
}