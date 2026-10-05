using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CHATTING_ACK : SendPacket
    {
        private string text;
        private Account p;
        private int type, bantime;

        public PROTOCOL_CS_CHATTING_ACK(string text, Account player)
        {
            this.text = text;
            p = player;
        }

        public PROTOCOL_CS_CHATTING_ACK(int type, int bantime)
        {
            this.type = type;
            this.bantime = bantime;
        }

        public override void write()
        {
            writeH(1879);
            if (type == 0)
            {
                writeC((byte)(p.player_name.Length + 1));
                writeUnicode(p.player_name, true);
                writeC(p.UseChatGM());
                writeC((byte)p.name_color);
                writeC((byte)(text.Length + 1));
                writeUnicode(text, true);
            }
            else
            {
                writeD(bantime);
            }
            /*
             * 1=STR_MESSAGE_BLOCK_ING
             * 2=STR_MESSAGE_BLOCK_START
             */
        }
    }
}