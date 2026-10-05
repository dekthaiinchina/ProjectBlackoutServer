using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_DENIAL_REQUEST_REQ : ReceivePacket
    {
        private int result;

        public PROTOCOL_CS_DENIAL_REQUEST_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            Account p = _client._player;
            if (p == null)
            {
                return;
            }
            Clan clan = ClanManager.getClan(p.clanId);
            if (clan._id > 0 && (p.clanAccess >= 1 && p.clanAccess <= 2 || clan.owner_id == p.player_id))
            {
                int count = readC();
                for (int i = 0; i < count; i++)
                {
                    long pId = readQ();
                    if (PlayerManager.DeleteInviteDb(clan._id, pId))
                    {
                        if (MessageManager.getMsgsCount(pId) < 100)
                        {
                            Message msg = CreateMessage(clan, pId, p.player_id);
                            if (msg != null)
                            {
                                Account pK = AccountManager.getAccount(pId, 0);
                                if (pK != null && pK._isOnline)
                                {
                                    pK.SendPacket(new PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(msg), false);
                                }
                            }
                        }
                        result++;
                    }
                }
            }
        }

        public override void run()
        {
            try
            {
                _client.SendPacket(new PROTOCOL_CS_DENIAL_REQUEST_ACK(result));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CS_DENIAL_REQUEST_REQ: " + ex.ToString());
            }
        }

        private Message CreateMessage(Clan clan, long owner, long senderId)
        {
            Message msg = new Message(15)
            {
                sender_name = clan._name,
                sender_id = senderId,
                clanId = clan._id,
                type = 4,
                state = 1,
                cB = NoteMessageClan.InviteDenial
            };
            return MessageManager.CreateMessage(owner, msg) ? msg : null;
        }
    }
}