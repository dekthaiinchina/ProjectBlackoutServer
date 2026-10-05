using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_SHOP_RECV_GIFT_ACK : SendPacket
    {
        private Message gift;

        public PROTOCOL_AUTH_SHOP_RECV_GIFT_ACK(Message gift)
        {
            this.gift = gift;
        }

        public override void write()
        {
            writeH(1079);
            writeD(gift.object_id);
            writeD((uint)gift.sender_id);
            writeD(gift.state);
            writeD((uint)gift.expireDate);
            writeC((byte)(gift.sender_name.Length + 1));
            writeS(gift.sender_name, gift.sender_name.Length + 1);
            writeC(6);
            writeS("EVENT", 6);
        }
    }
}