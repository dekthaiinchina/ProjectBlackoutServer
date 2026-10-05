using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_REQUEST_MAIN_ACK : SendPacket
    {
        private uint _slot;

        public PROTOCOL_ROOM_REQUEST_MAIN_ACK(uint slot)
        {
            _slot = slot;
        }

        public PROTOCOL_ROOM_REQUEST_MAIN_ACK(int slot)
        {
            _slot = (uint)slot;
        }

        public override void write()
        {
            writeH(3876);
            writeD(_slot);
        }
    }
}