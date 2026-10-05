using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_SERVER_MESSAGE_KICK_PLAYER_ACK : SendPacket
    {
        public PROTOCOL_SERVER_MESSAGE_KICK_PLAYER_ACK()
        {

        }

        public override void write()
        {
            writeH(2563);
            writeC(0);
        }
    }
}