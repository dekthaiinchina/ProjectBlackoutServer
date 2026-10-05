using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_LOBBY_ENTER_ACK : SendPacket
    {
        public PROTOCOL_LOBBY_ENTER_ACK()
        {

        }

        public override void write()
        {
            writeH(3074);
            writeH(0);
            writeD(0);
            writeC(1);
            writeQ(0);
        }
    }
}