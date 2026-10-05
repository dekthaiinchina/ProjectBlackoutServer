using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_COMMISSION_MASTER_REQ : ReceivePacket
    {
        private long memberId;
        private uint erro;

        public PROTOCOL_CS_COMMISSION_MASTER_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            memberId = readQ();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null || p.clanAccess != 1)
                {
                    return;
                }
                Account member = AccountManager.getAccount(memberId, 0);
                int clanId = p.clanId;
                if (member == null || member.clanId != clanId)
                {
                    erro = 0x80000000;
                }
                else if (member._rank > 10)
                {
                    Clan clan = ClanManager.getClan(clanId);
                    if (clan._id > 0 && clan.owner_id == _client.player_id && member.clanAccess == 2 && ComDiv.updateDB("clans", "owner_id", memberId, "clan_id", clanId) &&
                        ComDiv.updateDB("players", "clanaccess", 1, "player_id", memberId) &&
                        ComDiv.updateDB("players", "clanaccess", 2, "player_id", p.player_id))
                    {
                        member.clanAccess = 1;
                        p.clanAccess = 2;
                        clan.owner_id = memberId;
                        if (MessageManager.getMsgsCount(member.player_id) < 100)
                        {
                            Message msg = CreateMessage(clan, member.player_id, p.player_id);
                            if (msg != null && member._isOnline)
                            {
                                member.SendPacket(new PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(msg), false);
                            }
                        }
                        if (member._isOnline)
                        {
                            member.SendPacket(new PROTOCOL_CS_COMMISSION_MASTER_RESULT_ACK(), false);
                        }
                    }
                    else
                    {
                        erro = 2147487744;
                    }
                }
                else
                {
                    erro = 2147487928;
                }
                _client.SendPacket(new PROTOCOL_CS_COMMISSION_MASTER_ACK(erro));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CS_COMMISSION_MASTER_REQ: " + ex.ToString());
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
                cB = NoteMessageClan.Master
            };
            return MessageManager.CreateMessage(owner, msg) ? msg : null;
        }
    }
}