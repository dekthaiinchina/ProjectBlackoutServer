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
    public class PROTOCOL_CS_ACCEPT_REQUEST_REQ : ReceivePacket
    {
        private int result;

        public PROTOCOL_CS_ACCEPT_REQUEST_REQ(GameClient client, byte[] data)
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
            if (clan._id > 0 && (p.clanAccess >= 1 && p.clanAccess <= 2 || p.player_id == clan.owner_id))
            {
                List<Account> clanPlayers = ClanManager.getClanPlayers(clan._id, -1, true);
                if (clanPlayers.Count >= clan.maxPlayers)
                {
                    result = -1;
                    return;
                }
                int playersCount = readC();
                for (int i = 0; i < playersCount; i++)
                {
                    Account pl = AccountManager.getAccount(readQ(), 0);
                    if (pl != null && clanPlayers.Count < clan.maxPlayers && pl.clanId == 0 && PlayerManager.getRequestClanId(pl.player_id) > 0)
                    {
                        using (PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK packet = new PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK(pl))
                        {
                            ClanManager.SendPacket(packet, clanPlayers);
                        }
                        pl.clanId = p.clanId;
                        pl.clanDate = int.Parse(DateTime.Now.AddYears(-10).ToString("yyyyMMdd"));
                        pl.clanAccess = 3;
                        SendClanInfo.Load(pl, null, 3);

                        ComDiv.updateDB("players", "player_id", pl.player_id, new string[] { "clanaccess", "clan_id", "clandate" }, pl.clanAccess, pl.clanId, pl.clanDate);

                        PlayerManager.DeleteInviteDb(p.clanId, pl.player_id);
                        if (pl._isOnline)
                        {
                            pl.SendPacket(new PROTOCOL_CS_MEMBER_INFO_ACK(clanPlayers), false);
                            Room r = pl._room;
                            if (r != null)
                            {
                                r.SendPacketToPlayers(new PROTOCOL_ROOM_GET_SLOTONEINFO_ACK(pl, clan));
                            }
                            pl.SendPacket(new PROTOCOL_CS_ACCEPT_REQUEST_RESULT_ACK(clan, clanPlayers.Count + 1), false);
                        }
                        if (MessageManager.getMsgsCount(pl.player_id) < 100)
                        {
                            Message msg = CreateMessage(clan, pl.player_id, _client.player_id);
                            if (msg != null && pl._isOnline)
                            {
                                pl.SendPacket(new PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(msg), false);
                            }
                        }
                        result++;
                        clanPlayers.Add(pl);
                    }
                }
                clanPlayers = null;
            }
            else
            {
                result = -1;
            }
        }

        public override void run()
        {
            try
            {
                _client.SendPacket(new PROTOCOL_CS_ACCEPT_REQUEST_ACK((uint)result));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CS_ACCEPT_REQUEST_RESULT_REQ: " + ex.ToString());
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
                cB = NoteMessageClan.InviteAccept
            };
            return MessageManager.CreateMessage(owner, msg) ? msg : null;
        }
    }
}