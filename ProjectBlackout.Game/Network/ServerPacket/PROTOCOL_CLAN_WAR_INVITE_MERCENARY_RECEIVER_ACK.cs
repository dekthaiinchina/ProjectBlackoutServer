using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CLAN_WAR_INVITE_MERCENARY_RECEIVER_ACK : SendPacket
    {
        private int _f;
        private uint _erro;

        public PROTOCOL_CLAN_WAR_INVITE_MERCENARY_RECEIVER_ACK(uint erro, int formacao = 0)
        {
            _erro = erro;
            _f = formacao;
        }

        public override void write()
        {
            writeH(1572);
            writeD(_erro);
            if (_erro == 0)
            {
                writeC((byte)_f);
            }
        }
    }
}