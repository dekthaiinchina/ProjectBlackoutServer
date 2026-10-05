using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_MEMBER_LIST_REQ : ReceivePacket
    {
        private int page;

        public PROTOCOL_CS_MEMBER_LIST_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            page = readC();
        }

        public override void run()
        {
            try
            {
                Account pl = _client._player;
                if (pl == null)
                {
                    return;
                }
                Clan clan = ClanManager.getClan(pl.FindClanId);
                if (clan._id == 0)
                {
                    _client.SendPacket(new PROTOCOL_CS_MEMBER_LIST_ACK(-1));
                    return;
                }
                List<Account> clanPlayers = ClanManager.getClanPlayers(pl.FindClanId, -1, false);
                using (SendGPacket p = new SendGPacket())
                {
                    int count = 0;
                    for (int i = (page * 14); i < clanPlayers.Count; i++)
                    {
                        WriteData(clanPlayers[i], p);
                        if (++count == 14)
                        {
                            break;
                        }
                    }
                    _client.SendPacket(new PROTOCOL_CS_MEMBER_LIST_ACK(page, count, p.mstream.ToArray()));
                }
            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_CS_MEMBER_LIST_REQ[" + _client.player_id + "]: " + ex.ToString());
            }
        }

        private void WriteData(Account member, SendGPacket p)
        {
            p.writeQ(member.player_id);
            p.writeUnicode(member.player_name, 66);
            p.writeC((byte)member._rank);
            p.writeC((byte)member.clanAccess);
            p.writeQ(ComDiv.GetClanStatus(member._status, member._isOnline));
            p.writeD(member.clanDate);
            p.writeC((byte)member.name_color);
            p.writeD(member._statistic.ClanGames);
            p.writeD(member._statistic.ClanWins);
        }
    }
}