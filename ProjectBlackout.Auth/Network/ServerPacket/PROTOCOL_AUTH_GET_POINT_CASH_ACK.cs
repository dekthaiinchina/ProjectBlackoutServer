using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_AUTH_GET_POINT_CASH_ACK : SendPacket
    {
        private int _erro, _gold, _cash, _tag;

        public PROTOCOL_AUTH_GET_POINT_CASH_ACK(int erro, int gold = 0, int cash = 0, int tag = 0)
        {
            this._erro = erro;
            this._gold = gold;
            this._cash = cash;
            this._tag = tag;
        }

        public override void write()
        {
            writeH(1058);
            writeD(_erro);
            if (_erro >= 0)
            {
                writeD(_gold);
                writeD(_cash);
                writeD(_tag);
            }
            writeD(0);
        }
    }
}