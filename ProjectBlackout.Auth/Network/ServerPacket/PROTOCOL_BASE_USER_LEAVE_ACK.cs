using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_USER_LEAVE_ACK : SendPacket
    {
        private int erro;

        public PROTOCOL_BASE_USER_LEAVE_ACK(int erro)
        {
            this.erro = erro;
        }

        public override void write()
        {
            writeH(537);
            writeH(0);
            writeD(erro);
        }
    }
}