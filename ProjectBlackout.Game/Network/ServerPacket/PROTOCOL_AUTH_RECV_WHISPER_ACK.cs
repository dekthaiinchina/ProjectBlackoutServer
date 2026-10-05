using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_RECV_WHISPER_ACK : SendPacket
    {
        private string _sender, _msg;
        private bool chatGM;

        public PROTOCOL_AUTH_RECV_WHISPER_ACK(string sender, string msg, bool chatGM)
        {
            _sender = sender;
            _msg = msg;
            this.chatGM = chatGM;
        }

        public override void write()
        {
            writeH(806);
            writeUnicode(_sender, 66);
            writeC(chatGM);
            writeC(0); // ?
            writeH((ushort)(_msg.Length + 1));
            writeUnicode(_msg, true);
        }
    }
}