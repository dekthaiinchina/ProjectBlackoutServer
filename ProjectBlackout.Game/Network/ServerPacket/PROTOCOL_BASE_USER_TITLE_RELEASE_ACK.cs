using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_USER_TITLE_RELEASE_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_BASE_USER_TITLE_RELEASE_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(589);
            writeD(_erro);
        }
    }
}