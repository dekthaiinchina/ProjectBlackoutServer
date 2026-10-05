using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_MESSENGER_NOTE_SEND_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_MESSENGER_NOTE_SEND_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(930);
            writeD(_erro);
        }
    }
}