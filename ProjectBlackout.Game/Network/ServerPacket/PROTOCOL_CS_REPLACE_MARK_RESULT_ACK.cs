using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_REPLACE_MARK_RESULT_ACK : SendPacket
    {
        private uint _logo;

        public PROTOCOL_CS_REPLACE_MARK_RESULT_ACK(uint logo)
        {
            _logo = logo;
        }

        public override void write()
        {
            writeH(1891);
            writeD(_logo);
        }
    }
}