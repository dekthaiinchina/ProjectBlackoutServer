using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_MEMBER_INFO_DELETE_ACK : SendPacket
    {
        private long _pId;

        public PROTOCOL_CS_MEMBER_INFO_DELETE_ACK(long pId)
        {
            _pId = pId;
        }

        public override void write()
        {
            writeH(1873);
            writeQ(_pId);
        }
    }
}