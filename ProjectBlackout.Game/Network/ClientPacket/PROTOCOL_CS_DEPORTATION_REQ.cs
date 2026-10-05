using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Sync.Server;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_DEPORTATION_REQ : ReceivePacket
    {
        private uint result;

        public PROTOCOL_CS_DEPORTATION_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            Account player = _client._player;
            if (player == null)
            {
                return;
            }
            Clan clan = ClanManager.getClan(player.clanId);
            if (clan._id == 0 || !(player.clanAccess >= 1 && player.clanAccess <= 2 || clan.owner_id == _client.player_id))
            {
                result = 2147487833;
                return;
            }
            List<Account> clanPlayers = ClanManager.getClanPlayers(clan._id, -1, true);
            int countPlayers = readC();
            for (int i = 0; i < countPlayers; i++)
            {
                Account member = AccountManager.getAccount(readQ(), 0);
                if (member != null && member.clanId == clan._id && member._match == null && ComDiv.updateDB("players", "player_id", member.player_id, new string[] 
                { 
                    "clan_id", "clanaccess", "clan_game_pt", "clan_wins_pt"
                }, 0, 0, 0, 0))
                {
                    using (PROTOCOL_CS_MEMBER_INFO_DELETE_ACK packet = new PROTOCOL_CS_MEMBER_INFO_DELETE_ACK(member.player_id))
                    {
                        ClanManager.SendPacket(packet, clanPlayers, member.player_id);
                    }
                    member.clanId = 0;
                    member.clanAccess = 0;
                    SendClanInfo.Load(member, null, 0);
                    if (MessageManager.getMsgsCount(member.player_id) < 100)
                    {
                        Message msg = CreateMessage(clan, member.player_id, _client.player_id);
                        if (msg != null && member._isOnline)
                        {
                            member.SendPacket(new PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(msg), false);
                        }
                    }
                    if (member._isOnline)
                    {
                        member.SendPacket(new PROTOCOL_CS_DEPORTATION_RESULT_ACK(), false);
                    }
                    result++;
                    clanPlayers.Remove(member);
                }
                else
                {
                    result = 2147487833;
                    break;
                }
            }
        }

        public override void run()
        {
            try
            {
                if (_client != null)
                {
                    _client.SendPacket(new PROTOCOL_CS_DEPORTATION_ACK(result));
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CS_DEPORTATION_REQ: " + ex.ToString());
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
                cB = NoteMessageClan.Deportation
            };
            return MessageManager.CreateMessage(owner, msg) ? msg : null;
        }
    }
}