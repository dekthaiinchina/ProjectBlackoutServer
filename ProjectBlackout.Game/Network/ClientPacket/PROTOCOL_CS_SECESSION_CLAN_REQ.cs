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
    public class PROTOCOL_CS_SECESSION_CLAN_REQ : ReceivePacket
    {
        private uint erro;

        public PROTOCOL_CS_SECESSION_CLAN_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            try
            {
                if (_client == null)
                {
                    return;
                }
                Account p = _client._player;
                try
                {
                    if (p != null && p.clanId > 0)
                    {
                        Clan clan = ClanManager.getClan(p.clanId);
                        if (clan._id > 0 && clan.owner_id != p.player_id)
                        {
                            if (ComDiv.updateDB("players", "player_id", p.player_id, new string[]
                            {
                                "clan_id", "clanaccess", "clan_game_pt", "clan_wins_pt"
                            }, 0, 0, 0, 0))
                            {
                                using (PROTOCOL_CS_MEMBER_INFO_DELETE_ACK packet = new PROTOCOL_CS_MEMBER_INFO_DELETE_ACK(p.player_id))
                                {
                                    ClanManager.SendPacket(packet, p.clanId, p.player_id, true, true);
                                }
                                long ownerId = clan.owner_id;
                                if (MessageManager.getMsgsCount(ownerId) < 100)
                                {
                                    Message msg = CreateMessage(clan, p);
                                    if (msg != null)
                                    {
                                        Account pM = AccountManager.getAccount(ownerId, 0);
                                        if (pM != null && pM._isOnline)
                                        {
                                            pM.SendPacket(new PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(msg), false);
                                        }
                                    }
                                }
                                p.clanId = 0;
                                p.clanAccess = 0;
                            }
                            else
                            {
                                erro = 0x8000106B;
                            }
                        }
                        else
                        {
                            erro = 2147487838;
                        }
                    }
                    else
                    {
                        erro = 2147487835;
                    }
                }
                catch
                {
                    erro = 0x8000106B;
                }
                _client.SendPacket(new PROTOCOL_CS_SECESSION_CLAN_ACK(erro));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CS_SECESSION_CLAN_REQ: " + ex.ToString());
            }
        }

        private Message CreateMessage(Clan clan, Account sender)
        {
            Message msg = new Message(15)
            {
                sender_name = clan._name,
                sender_id = sender.player_id,
                clanId = clan._id,
                type = 4,
                text = sender.player_name,
                state = 1,
                cB = NoteMessageClan.Secession
            };
            return MessageManager.CreateMessage(clan.owner_id, msg) ? msg : null;
        }
    }
}