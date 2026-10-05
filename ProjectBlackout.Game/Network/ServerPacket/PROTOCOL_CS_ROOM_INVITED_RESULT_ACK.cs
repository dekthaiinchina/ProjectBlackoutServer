using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_ROOM_INVITED_RESULT_ACK : SendPacket
    {
        private long _pId;

        public PROTOCOL_CS_ROOM_INVITED_RESULT_ACK(long pId)
        {
            _pId = pId;
        }

        public override void write()
        {
            writeH(1903);
            writeQ(_pId);
        }
    }
}