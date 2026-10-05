using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_UNREADY_4VS4_ACK : SendPacket
    {
        public PROTOCOL_ROOM_UNREADY_4VS4_ACK()
        {

        }

        public override void write()
        {
            writeH(3888);
        }
    }
}