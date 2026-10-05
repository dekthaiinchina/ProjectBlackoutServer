using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CLOSE_CLAN_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_CS_CLOSE_CLAN_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(1833);
            writeD(_erro);
        }
    }
}