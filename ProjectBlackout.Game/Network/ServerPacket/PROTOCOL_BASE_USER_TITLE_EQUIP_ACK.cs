using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_USER_TITLE_EQUIP_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_BASE_USER_TITLE_EQUIP_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(587);
            writeD(_erro);
        }
    }
}