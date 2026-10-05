using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_MESSENGER_NOTE_RECEIVE_REQ : ReceivePacket
    {
        private long receiverId;
        private string text;
        private uint erro;

        public PROTOCOL_MESSENGER_NOTE_RECEIVE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            receiverId = readQ();
            text = readUnicode(readC() * 2);
        }

        public override void run()
        {
            try
            {
                if (text.Length > 120)
                {
                    return;
                }
                Account p = _client._player;
                if (p == null || _client.player_id == receiverId)
                {
                    return;
                }
                Account rec = AccountManager.getAccount(receiverId, 0);
                if (rec != null)
                {
                    if (MessageManager.getMsgsCount(rec.player_id) >= 100)
                    {
                        erro = 2147487871;
                    }
                    else
                    {
                        Message msgF = CreateMessage(p.player_name, rec.player_id, _client.player_id);
                        if (msgF != null)
                        {
                            rec.SendPacket(new PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(msgF), false);
                        }
                    }
                }
                else
                {
                    erro = 2147487870;
                }
                _client.SendPacket(new PROTOCOL_MESSENGER_NOTE_SEND_ACK(erro));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_MESSENGER_NOTE_RECEIVE_REQ: " + ex.ToString());
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