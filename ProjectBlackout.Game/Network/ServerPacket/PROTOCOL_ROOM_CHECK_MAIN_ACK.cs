using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_CHECK_MAIN_ACK : SendPacket
    {
        private uint _slot;

        public PROTOCOL_ROOM_CHECK_MAIN_ACK(uint slot)
        {
            _slot = slot;
        }

        public override void write()
        {
            writeH(3882);
            writeD(_slot);
        }
    }
}