using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_USER_ENTER_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_BASE_USER_ENTER_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(539);
            writeH(0);
            writeD(0);
        }
    }
}