using PointBlank.Core.Network;

namespace PointBlank.Game.Network.ServerPacket
{
    public class PROTOCOL_SERVER_MESSAGE_ITEM_RECEIVE_ACK : SendPacket
    {
        private uint _er;

        public PROTOCOL_SERVER_MESSAGE_ITEM_RECEIVE_ACK(uint er)
        {
            _er = er;
        }

        public override void write()
        {
            writeH(2692);
            writeD(_er);
        }
    }
}