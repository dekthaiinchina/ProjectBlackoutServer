using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_SHOP_JACKPOT_ACK : SendPacket
    {
        private string _w;
        private int cupomId, _random;

        public PROTOCOL_AUTH_SHOP_JACKPOT_ACK(string winner, int cupom, int rnd)
        {
            _w = winner;
            cupomId = cupom;
            _random = rnd;
        }

        public override void write()
        {
            writeH(1068);
            writeH(0);
            writeC((byte)_random);
            writeD(cupomId);
            writeC((byte)_w.Length);
            writeUnicode(_w, false);
        }
    }
}