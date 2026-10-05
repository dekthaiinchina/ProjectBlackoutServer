using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using System.Collections.Generic;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_MESSENGER_NOTE_LIST_ACK : SendPacket
    {
        private int pageIdx;
        private List<Message> msgs;

        public PROTOCOL_MESSENGER_NOTE_LIST_ACK(int pageIdx, List<Message> msgs)
        {
            this.pageIdx = pageIdx;
            this.msgs = new List<Message>();
            int count = 0;
            for (int i = pageIdx * 25; i < msgs.Count; i++)
            {
                this.msgs.Add(msgs[i]);
                if (++count == 25)
                {
                    break;
                }
            }
        }

        public override void write()
        {
            writeH(933);
            writeC((byte)pageIdx);
            writeC((byte)msgs.Count);
            for (int i = 0; i < msgs.Count; i++)
            {
                Message msg = msgs[i];
                writeD(msg.object_id);
                writeQ(msg.sender_id);
                writeC((byte)msg.type);
                writeC((byte)msg.state);
                writeC((byte)msg.DaysRemaining);
                writeD(msg.clanId);
            }
            for (int i = 0; i < msgs.Count; i++)
            {
                Message msg = msgs[i];
                writeC((byte)(msg.sender_name.Length + 1));
                writeC((byte)(msg.type == 5 || msg.type == 4 && msg.cB != 0 ? 0 : (msg.text.Length + 1)));
                writeUnicode(msg.sender_name, true);
                if (msg.type == 5 || msg.type == 4)
                {
                    if ((int)msg.cB >= 4 && (int)msg.cB <= 6)
                    {
                        writeH((short)(msg.text.Length + 1));
                        writeH((short)msg.cB);
                        writeUnicode(msg.text, false);
                    }
                    else if (msg.cB == 0)
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
}