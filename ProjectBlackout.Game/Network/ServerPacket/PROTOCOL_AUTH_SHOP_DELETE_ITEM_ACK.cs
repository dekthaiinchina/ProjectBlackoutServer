using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_SHOP_DELETE_ITEM_ACK : SendPacket
    {
        private long _objId;
        private uint _erro;

        public PROTOCOL_AUTH_SHOP_DELETE_ITEM_ACK(uint erro, long objId = 0)
        {
            _erro = erro;
            if (erro == 1)
            {
                _objId = objId;
            }
        }

        public override void write()
        {
            writeH(1056);
            writeD(_erro);
            if (_erro == 1)
            {
                writeD((int)_objId);
            }
        }
    }
}