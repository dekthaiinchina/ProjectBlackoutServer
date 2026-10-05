using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_CHATTING_ACK : SendPacket
    {
        private string sender, msg;
        private uint sessionId;
        private int nameColor;
        private bool GMColor;

        public PROTOCOL_BASE_CHATTING_ACK(Account player, string message, bool GMCmd = false)
        {
            if (!GMCmd)
            {
                nameColor = player.name_color;
                GMColor = player.UseChatGM();
            }
            else
            {
                GMColor = true;
            }
            sender = player.player_name;
            sessionId = player.getSessionId();
            msg = message;
        }

        public PROTOCOL_BASE_CHATTING_ACK(string snd, uint session, int name_color, bool chatGm, string message)
        {
            sender = snd;
            sessionId = session;
            nameColor = name_color;
            GMColor = chatGm;
            msg = message;
        }

        public override void write()
        {
            writeH(2628);//2385
            writeD(sessionId);
            writeC((byte)(sender.Length + 1));
            writeUnicode(sender, true);
            writeC((byte)nameColor);
            writeC(GMColor);
            writeH((ushort)(msg.Length + 1));
            writeUnicode(msg, true);
        }
    }
}