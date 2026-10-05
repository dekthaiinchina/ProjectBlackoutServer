using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_JOIN_REQUEST_ACK : SendPacket
    {
        private int _clanId;
        private uint _erro;

        public PROTOCOL_CS_JOIN_REQUEST_ACK(uint erro, int clanId)
        {
            _erro = erro;
            _clanId = clanId;
        }

        public override void write()
        {
            writeH(1837);
            writeD(_erro);
            if (_erro == 0)
            {
                writeD(_clanId);
            }
        }
    }
}