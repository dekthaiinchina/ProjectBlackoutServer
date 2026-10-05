using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_CHANGE_SLOT_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_ROOM_CHANGE_SLOT_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(3861);
            writeD(_erro);
        }
    }
}