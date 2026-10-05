using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK : SendPacket
    {
        private Message msg;

        public PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(Message msg)
        {
            this.msg = msg;
        }

        public override void write()
        {
            writeH(939);
            writeD(msg.object_id);
            writeQ(msg.sender_id);
            writeC((byte)msg.type);
            writeC((byte)msg.state);
            writeC((byte)msg.DaysRemaining);
            writeD(msg.clanId);
            writeC((byte)(msg.sender_name.Length + 1));
            writeC((byte)(msg.type == 5 || msg.type == 4 && (int)msg.cB != 0 ? 0 : (msg.text.Length + 1)));
            writeUnicode(msg.sender_name, true);
            if (msg.type == 5 || msg.type == 4)
            {
                if ((int)msg.cB >= 4 && (int)msg.cB <= 6)
                {
                    writeH((short)(msg.text.Length + 1));
                    writeH((short)msg.cB);
                    writeUnicode(msg.text, false);
                }
                else if ((int)msg.cB == 0)
                {
                    writeUnicode(msg.text, true);
                }
                else
                {
                    writeH(3);
                    writeD((int)msg.cB);
                    if (msg.cB != NoteMessageClan.Master || msg.cB != NoteMessageClan.Staff || msg.cB != NoteMessageClan.Regular)
                    {
                        writeH(0);
                    }
                }
            }
            else
            {
                writeUnicode(msg.text, true);
            }
        }
    }
}