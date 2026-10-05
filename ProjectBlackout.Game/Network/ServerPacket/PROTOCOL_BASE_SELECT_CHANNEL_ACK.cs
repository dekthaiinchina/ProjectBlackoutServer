using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_SELECT_CHANNEL_ACK : SendPacket
    {
        private int _channelId;
        private uint _error;

        public PROTOCOL_BASE_SELECT_CHANNEL_ACK(int id, uint error)
        {
            _channelId = id;
            _error = error;
        }

        public PROTOCOL_BASE_SELECT_CHANNEL_ACK(uint erro)
        {
            _error = erro;
        }

        public override void write()
        {
            writeH(543);
            if (_error == 0)
            {
                writeD(_error);
                writeD(0);
                writeH((ushort)_channelId);
            }
            else if (_error != 0)
            {
                writeH(0);
                writeD(_error);
            }
        }
    }
}