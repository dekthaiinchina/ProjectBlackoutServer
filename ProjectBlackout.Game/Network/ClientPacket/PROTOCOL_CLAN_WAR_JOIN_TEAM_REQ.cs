using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_JOIN_TEAM_REQ : ReceivePacket
    {
        private int matchId, serverInfo, type;
        private uint erro;

        public PROTOCOL_CLAN_WAR_JOIN_TEAM_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            matchId = readH();
            serverInfo = readH();
            type = readC(); //0 normal | 1 - amigos do clã
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (type >= 2 || p == null || p._match != null || p._room != null)
                {
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_JOIN_TEAM_ACK(0x80000000));
                    return;
                }
                int channelId = serverInfo - ((serverInfo / 10) * 10);
                Channel ch = ChannelsXml.getChannel(type == 0 ? channelId : p.channelId);
                if (ch != null)
                {
                    if (p.clanId == 0)
                    {
                        _client.SendPacket(new PROTOCOL_CLAN_WAR_JOIN_TEAM_ACK(0x8000105B));
                    }
                    else
                    {
                        Match mt = type == 1 ? ch.getMatch(matchId, p.clanId) : ch.getMatch(matchId);
                        if (mt != null)
                        {
                            JoinPlayer(p, mt);
                        }
                        else
                        {
                            _client.SendPacket(new PROTOCOL_CLAN_WAR_JOIN_TEAM_ACK(0x80000000));
                        }
                    }
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_JOIN_TEAM_ACK(0x80000000));
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }

        private void JoinPlayer(Account p, Match mt)
        {
            if (!mt.addPlayer(p))
            {
                erro = 0x80000000;
            }
            _client.SendPacket(new PROTOCOL_CLAN_WAR_JOIN_TEAM_ACK(erro, mt));
            if (erro == 0)
            {
                using (PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK packet = new PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK(mt))
                {
                    mt.SendPacketToPlayers(packet);
                }
            }
        }
    }
}