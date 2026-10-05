using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_SHOP_GOODSLIST_ACK : SendPacket
    {
        private int _tudo;
        private ShopData data;

        public PROTOCOL_AUTH_SHOP_GOODSLIST_ACK(ShopData data, int tudo)
        {
            this.data = data; 
            _tudo = tudo;
        }

        public override void write()
        {
            writeH(1036);
            writeD(_tudo);
            writeD(data.ItemsCount);
            writeD(data.Offset);
            writeB(data.Buffer);
        }
    }
}