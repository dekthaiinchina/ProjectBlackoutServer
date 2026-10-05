using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_USER_TITLE_CHANGE_ACK : SendPacket
    {
        private int _slots;
        private uint _erro;

        public PROTOCOL_BASE_USER_TITLE_CHANGE_ACK(uint erro, int slots)
        {
            _erro = erro;
            _slots = slots;
        }

        public override void write()
        {
            writeH(585);
            writeD(_erro);
            writeD(_slots);
        }
    }
}