using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_MESSENGER_NOTE_SEND_REQ : ReceivePacket
    {
        private int nameLength, textLength;
        private string name, text;
        private uint erro;

        public PROTOCOL_MESSENGER_NOTE_SEND_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            nameLength = readC();
            textLength = readC();
            name = readUnicode(nameLength * 2);
            text = readUnicode(textLength * 2);
        }

        public override void run()
        {
            try
            {
                if (text.Length > 120)
                {
                    return;
                }
                //0x80001080 STR_TBL_NETWORK_DONT_SEND_MYSELF_MESSAGE
                //0x80001081 STR_TBL_NETWORK_FULL_SEND_MESSAGE_PER_DAY
                Account p = _client._player;
                if (p == null || p.player_name.Length == 0 || p.player_name == name)
                {
                    return;
                }
                Account rec = AccountManager.getAccount(name, 1, 0);
                if (rec != null)
                {
                    if (MessageManager.getMsgsCount(rec.player_id) >= 100)
                    {
                        erro = 0x8000107F;
                    }
                    else
                    {
                        Message msg = CreateMessage(p.player_name, rec.player_id, _client.player_id);
                        if (msg != null)
                        {
                            rec.SendPacket(new PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(msg), false);
                        }
                    }
                }
                else
                {
                    erro = 0x8000107E;
                }
                _client.SendPacket(new PROTOCOL_MESSENGER_NOTE_SEND_ACK(erro));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_MESSENGER_NOTE_SEND_REQ: " + ex.ToString());
            }
        }

        private Message CreateMessage(string senderName, long owner, long senderId)
        {
            Message msg = new Message(15)
            {
                sender_name = senderName,
                sender_id = senderId,
                text = text,
                state = 1
            };
            if (!MessageManager.CreateMessage(owner, msg))
            {
                erro = 0x80000000;
                return null;
            }
            return msg;
        }
    }
}