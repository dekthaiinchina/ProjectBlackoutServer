using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_MEGAPHONE_ACK : SendPacket
    {
        private string _text, _sender;

        public PROTOCOL_BASE_MEGAPHONE_ACK(string name, string text)
        {
            _text = text;
            _sender = name;
        }

        public override void write()
        {
            writeH(658);
            writeH(0);//?
            writeH((short)(_text.Length + 1));
            writeUnicode(_text, true);

            writeC((byte)(_sender.Length + 1));
            writeUnicode(_sender, true);
        }
    }
}