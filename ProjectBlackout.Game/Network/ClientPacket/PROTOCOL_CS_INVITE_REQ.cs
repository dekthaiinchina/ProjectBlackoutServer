using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_INVITE_REQ : ReceivePacket
    {
        private uint erro;

        public PROTOCOL_CS_INVITE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            Account p = _client._player;
            if (p == null || p.clanId == 0)
            {
                return;
            }
            try
            {
                if (p.FindPlayer == "" || p.FindPlayer.Length == 0)
                {
                    return;
                }
                Account f = AccountManager.getAccount(p.FindPlayer, 1, 0);
                if (f != null)
                {
                    if (f.clanId == 0 && p.clanId != 0)
                    {
                        SendBoxMessage(f, p.clanId);
                    }
                    else
                    {
                        erro = 0x80000000;
                    }
                }
                else
                {
                    erro = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_CS_INVITE_ACK(erro));
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        private void SendBoxMessage(Account player, int clanId)
        {
            if (MessageManager.getMsgsCount(player.player_id) >= 100)
            {
                erro = 0x80000000;
            }
            else
            {
                Message msg = CreateMessage(clanId, player.player_id, _client.player_id);
                if (msg != null && player._isOnline)
                {
                    player.SendPacket(new PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(msg), false);
                }
            }
        }

        private Message CreateMessage(int clanId, long owner, long senderId)
        {
            Message msg = new Message(15)
            {
                sender_name = ClanManager.getClan(clanId)._name,
                clanId = clanId,
                sender_id = senderId,
                type = 5,
                state = 1,
                cB = NoteMessageClan.Invite
            };
            return MessageManager.CreateMessage(owner, msg) ? msg : null;
        }
    }
}