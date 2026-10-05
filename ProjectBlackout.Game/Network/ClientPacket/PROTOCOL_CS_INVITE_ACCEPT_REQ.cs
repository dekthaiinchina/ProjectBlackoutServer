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
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_INVITE_ACCEPT_REQ : ReceivePacket
    {
        private int clanId, type;

        public PROTOCOL_CS_INVITE_ACCEPT_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            clanId = readD();
            readD();
            type = readC();
        }

        public override void run()
        {
            Account player = _client._player;
            if (player == null || player.player_name.Length == 0)
            {
                return;
            }
            Clan clan = ClanManager.getClan(clanId);
            List<Account> clanPlayers = ClanManager.getClanPlayers(clanId, -1, true);
            if (clan._id == 0)
            {
                _client.SendPacket(new PROTOCOL_CS_INVITE_ACCEPT_ACK(2147487835));
            }
            else if (player.clanId > 0)
            {
                _client.SendPacket(new PROTOCOL_CS_INVITE_ACCEPT_ACK(2147487832));
            }
            else if (clan.maxPlayers <= clanPlayers.Count)
            {
                _client.SendPacket(new PROTOCOL_CS_INVITE_ACCEPT_ACK(2147487830));
            }
            else if (type == 0 || type == 1)
            {
                try
                {
                    uint erro = 0;
                    Account master = AccountManager.getAccount(clan.owner_id, 0);
                    if (master != null)
                    {
                        if (MessageManager.getMsgsCount(clan.owner_id) < 100)
                        {
                            Message msg = CreateMessage(clan, player.player_name, _client.player_id);
                            if (msg != null && master._isOnline)
                            {
                                master.SendPacket(new PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(msg), false);
                            }
                        }
                        if (type == 1)
                        {
                            int date = int.Parse(DateTime.Now.AddYears(-10).ToString("yyyyMMdd"));
                            if (ComDiv.updateDB("players", "player_id", player.player_id, new string[] { "clan_id", "clanaccess", "clandate" }, clan._id, 3, date))
                            {
                                using (PROTOCOL_CS_MEMBER_INFO_INSERT_ACK packet = new PROTOCOL_CS_MEMBER_INFO_INSERT_ACK(player))
                                {
                                    ClanManager.SendPacket(packet, clanPlayers);
                                }
                                player.clanId = clan._id;
                                player.clanDate = date;
                                player.clanAccess = 3;
                                _client.SendPacket(new PROTOCOL_CS_MEMBER_INFO_ACK(clanPlayers));
                                Room room = player._room;
                                if (room != null)
                                {
                                    room.SendPacketToPlayers(new PROTOCOL_ROOM_GET_SLOTONEINFO_ACK(player, clan));
                                }
                                _client.SendPacket(new PROTOCOL_CS_ACCEPT_REQUEST_RESULT_ACK(clan, master, clanPlayers.Count + 1));
                            }
                            else
                            {
                                erro = 0x80000000;
                            }
                        }
                    }
                    else
                    {
                        erro = 0x80000000;
                    }
                    _client.SendPacket(new PROTOCOL_MESSENGER_NOTE_SEND_ACK(erro));
                }
                catch (Exception ex)
                {
                    Logger.error(ex.ToString());
                }
            }
        }

        private Message CreateMessage(Clan clan, string player, long senderId)
        {
            Message msg = new Message(15)
            {
                sender_name = clan._name,
                sender_id = senderId,
                clanId = clan._id,
                type = 4,
                text = player,
                state = 1,
                cB = type == 0 ? NoteMessageClan.JoinDenial : NoteMessageClan.JoinAccept
            };
            return MessageManager.CreateMessage(clan.owner_id, msg) ? msg : null;
        }
    }
}