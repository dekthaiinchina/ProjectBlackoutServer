using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_REPLACE_NOTICE_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_CS_REPLACE_NOTICE_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(1883);
            writeD(_erro);
        }
    }
}