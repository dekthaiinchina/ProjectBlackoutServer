using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_ACCOUNT_KICK_ACK : SendPacket
    {
        private int _type;

        public PROTOCOL_AUTH_ACCOUNT_KICK_ACK(int type)
        {
            _type = type;
        }

        public override void write()
        {
            writeH(998);
            writeC((byte)_type);
        }
    }
}