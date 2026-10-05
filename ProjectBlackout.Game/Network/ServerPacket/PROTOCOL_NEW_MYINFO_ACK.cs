using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_NEW_MYINFO_ACK : SendPacket
    {
        private long _pId;

        public PROTOCOL_NEW_MYINFO_ACK(long pId)
        {
            _pId = pId;
        }

        public override void write()
        {
            writeH(1999);
            writeD(0);
            writeQ(_pId);
            writeB(new byte[132]);
        }
    }
}