using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_GAMEGUARD_ACK : SendPacket
    {
        public PROTOCOL_BASE_GAMEGUARD_ACK()
        {

        }

        public override void write()
        {
            writeH(519);
        }
    }
}