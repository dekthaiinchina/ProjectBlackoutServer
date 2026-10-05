using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_INVITE_ACCEPT_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_CS_INVITE_ACCEPT_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(1915);
            writeD(_erro);
        }
    }
}