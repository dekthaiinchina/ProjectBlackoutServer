using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_DEPORTATION_RESULT_ACK : SendPacket
    {
        public PROTOCOL_CS_DEPORTATION_RESULT_ACK()
        {

        }

        public override void write()
        {
            writeH(1856);
        }
    }
}