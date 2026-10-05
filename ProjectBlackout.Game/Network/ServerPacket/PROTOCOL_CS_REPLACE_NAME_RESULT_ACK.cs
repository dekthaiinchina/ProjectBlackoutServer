using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_REPLACE_NAME_RESULT_ACK : SendPacket
    {
        private string _name;

        public PROTOCOL_CS_REPLACE_NAME_RESULT_ACK(string name)
        {
            _name = name;
        }

        public override void write()
        {
            writeH(1888);
            writeUnicode(_name, 34);
        }
    }
}