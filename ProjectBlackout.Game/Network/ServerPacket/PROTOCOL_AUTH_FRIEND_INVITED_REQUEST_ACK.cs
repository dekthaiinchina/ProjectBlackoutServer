using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_FRIEND_INVITED_REQUEST_ACK : SendPacket
    {
        private int _idx;

        public PROTOCOL_AUTH_FRIEND_INVITED_REQUEST_ACK(int idx)
        {
            _idx = idx;
        }

        public override void write()
        {
            writeH(789);
            writeC((byte)_idx);
        }
    }
}