using PointBlank.Core.Network;

namespace PointBlank.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_SERVER_PASSWD_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_BASE_SERVER_PASSWD_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(2645);
            writeD(_erro);
        }
    }
}