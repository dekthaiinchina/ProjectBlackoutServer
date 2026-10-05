using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_PAGE_CHATTING_ACK : SendPacket
    {
        private string sender, message;
        private int type, bantime, name_color;
        private bool isGM;

        public PROTOCOL_CS_PAGE_CHATTING_ACK(Account p, string msg)
        {
            sender = p.player_name;
            message = msg;
            isGM = p.UseChatGM();
            name_color = p.name_color;
        }

        public PROTOCOL_CS_PAGE_CHATTING_ACK(int type, int bantime)
        {
            this.type = type;
            this.bantime = bantime;
        }

        public override void write()
        {
            writeH(1911);
            writeC((byte)type);
            if (type == 0)
            {
                writeC((byte)(sender.Length + 1));
                writeUnicode(sender, true);
                writeC(isGM);
                writeC((byte)name_color);
                writeC((byte)(message.Length + 1));
                writeUnicode(message, true);
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