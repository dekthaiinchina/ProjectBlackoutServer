using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_SEND_WHISPER_ACK : SendPacket
    {
        private string name, msg;
        private uint erro;
        private int type, bantime;

        public PROTOCOL_AUTH_SEND_WHISPER_ACK(string name, string msg, uint erro)
        {
            this.name = name;
            this.msg = msg;
            this.erro = erro;
        }

        public PROTOCOL_AUTH_SEND_WHISPER_ACK(int type, int bantime)
        {
            this.type = type;
            this.bantime = bantime;
        }

        public override void write()
        {
            writeH(805);
            writeC((byte)type);
            if (type == 0)
            {
                writeD(erro);
                writeUnicode(name, 66);
                if (erro == 0)
                {
                    writeH((ushort)(msg.Length + 1));
                    writeUnicode(msg, true);
                }
            }
            else
            {
                writeD(bantime);
            }
            /*
             * 1 = STR_MESSAGE_BLOCK_ING
             * 2 = STR_MESSAGE_BLOCK_START
             */
        }
    }
}