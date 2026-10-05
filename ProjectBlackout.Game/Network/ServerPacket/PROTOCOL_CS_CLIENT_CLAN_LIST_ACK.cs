using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CLIENT_CLAN_LIST_ACK : SendPacket
    {
        private uint _page;
        private int _count;
        private byte[] _array;

        public PROTOCOL_CS_CLIENT_CLAN_LIST_ACK(uint page, int count, byte[] array)
        {
            _page = page;
            _count = count;
            _array = array;
        }

        public override void write()
        {
            writeH(1798);
            writeD(_page);
            writeC((byte)_count);
            writeB(_array);
        }
    }
}