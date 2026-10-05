using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_GET_NICKNAME_ACK : SendPacket
    {
        private int slotIdx, color;
        private string name;

        public PROTOCOL_ROOM_GET_NICKNAME_ACK(int slot, string name, int color)
        {
            slotIdx = slot;
            this.name = name;
            this.color = color;
        }

        public override void write()
        {
            writeH(3855);
            writeD(slotIdx);
            if (slotIdx >= 0)
            {
                writeUnicode(name, 33);
                writeC((byte)color);
            }
        }
    }
}