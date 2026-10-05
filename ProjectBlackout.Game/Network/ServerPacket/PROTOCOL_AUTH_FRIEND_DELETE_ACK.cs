using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_FRIEND_DELETE_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_AUTH_FRIEND_DELETE_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(797);
            writeD(_erro);
        }
    }
}