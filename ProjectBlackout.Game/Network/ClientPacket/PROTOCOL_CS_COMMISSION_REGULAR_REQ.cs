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

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_COMMISSION_REGULAR_REQ : ReceivePacket
    {
        private uint result;

        public PROTOCOL_CS_COMMISSION_REGULAR_REQ(GameClient client, byte[] data)
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
            int playersCount = readC();
            for (int i = 0; i < playersCount; i++)
            {
                Account member = AccountManager.getAccount(readQ(), 0);
                if (member != null && member.clanId == clan._id && member.clanAccess == 2 && ComDiv.updateDB("players", "clanaccess", 3, "player_id", member.player_id))
                {
                    member.clanAccess = 3;
                    SendClanInfo.Load(member, null, 3);
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
                        member.SendPacket(new PROTOCOL_CS_COMMISSION_REGULAR_RESULT_ACK(), false);
                    }
                    result++;
                }
            }
        }

        public override void run()
        {
            try
            {
                if (_client != null)
                {
                    _client.SendPacket(new PROTOCOL_CS_COMMISSION_REGULAR_ACK(result));
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CS_COMMISSION_REGULAR_REQ: " + ex.ToString());
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
                cB = NoteMessageClan.Regular
            };
            return MessageManager.CreateMessage(owner, msg) ? msg : null;
        }
    }
}