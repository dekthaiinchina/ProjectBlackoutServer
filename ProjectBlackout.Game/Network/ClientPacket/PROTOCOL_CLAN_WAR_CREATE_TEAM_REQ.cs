using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_CREATE_TEAM_REQ : ReceivePacket
    {
        private int formacao;
        private List<int> party = new List<int>();

        public PROTOCOL_CLAN_WAR_CREATE_TEAM_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            formacao = readC();
        }

        public override void run()
        {
            Account p = _client._player;
            if (p == null)
            {
                return;
            }
            Channel ch = p.getChannel();
            if (ch != null && ch._type == 4 && p._room == null)
            {
                if (p._match != null)
                {
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_CREATE_TEAM_ACK(0x80001087));
                    return;
                }
                if (p.clanId == 0)
                {
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_CREATE_TEAM_ACK(0x8000105B));
                    return;
                }
                int matchId = -1, friendId = -1;
                lock (ch._matchs)
                {
                    for (int i = 0; i < 250; i++)
                    {
                        if (ch.getMatch(i) == null)
                        {
                            matchId = i;
                            break;
                        }
                    }
                    for (int i = 0; i < ch._matchs.Count; i++)
                    {
                        Match m = ch._matchs[i];
                        if (m.clan._id == p.clanId)
                        {
                            party.Add(m.friendId);
                        }
                    }
                }
                for (int i = 0; i < 25; i++)
                {
                    if (!party.Contains(i))
                    {
                        friendId = i;
                        break;
                    }
                }
                if (matchId == -1)
                {
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_CREATE_TEAM_ACK(0x80001088));
                }
                else if (friendId == -1)
                {
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_CREATE_TEAM_ACK(0x80001089));
                }
                else
                {
                    try
                    {
                        Match match = new Match(ClanManager.getClan(p.clanId))
                        {
                            _matchId = matchId,
                            friendId = friendId,
                            formação = formacao,
                            channelId = p.channelId,
                            serverId = GameConfig.serverId
                        };
                        match.addPlayer(p);
                        ch.AddMatch(match);
                        _client.SendPacket(new PROTOCOL_CLAN_WAR_CREATE_TEAM_ACK(0, match));
                        _client.SendPacket(new PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK(match));
                    }
                    catch (Exception ex)
                    {
                        Logger.info("PROTOCOL_CLAN_WAR_CREATE_TEAM_REQ: " + ex.ToString());
                    }
                }
            }
            else
            {
                _client.SendPacket(new PROTOCOL_CLAN_WAR_CREATE_TEAM_ACK(0x80000000));
            }
        }
    }
}