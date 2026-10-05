using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_NOTE_ACK : SendPacket
    {
        private int playersCount;

        public PROTOCOL_CS_NOTE_ACK(int count)
        {
            playersCount = count;
        }

        public override void write()
        {
            writeH(1917);
            writeD(playersCount);
        }
    }
}