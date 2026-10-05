using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CLAN_WAR_TEAM_CHATTING_ACK : SendPacket
    {
        private int type, bantime;
        private string message, sender;

        public PROTOCOL_CLAN_WAR_TEAM_CHATTING_ACK(string sender, string text)
        {
            this.sender = sender;
            message = text;
        }

        public PROTOCOL_CLAN_WAR_TEAM_CHATTING_ACK(int type, int bantime)
        {
            this.type = type;
            this.bantime = bantime;
        }

        public override void write()
        {
            writeH(1577);
            writeC((byte)type);
            if (type == 0)
            {
                writeC((byte)(sender.Length + 1));
                writeS(sender, sender.Length + 1);
                writeC((byte)message.Length);
                writeS(message, message.Length);
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