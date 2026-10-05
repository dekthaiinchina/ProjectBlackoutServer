using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_MATCH_TEAM_INFO_REQ : ReceivePacket
    {
        private int id, serverInfo;

        public PROTOCOL_CLAN_WAR_MATCH_TEAM_INFO_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            id = readH();
            serverInfo = readH();
        }

        public override void run()
        {
            Account player = _client._player;
            if (player == null || player._match == null)
            {
                return;
            }
            try
            {
                int channelId = serverInfo - ((serverInfo / 10) * 10);
                Channel ch = ChannelsXml.getChannel(channelId);
                if (ch != null)
                {
                    Match match = ch.getMatch(id);
                    if (match != null)
                    {
                        _client.SendPacket(new PROTOCOL_CLAN_WAR_MATCH_TEAM_INFO_ACK(0, match.clan));
                    }
                    else
                    {
                        _client.SendPacket(new PROTOCOL_CLAN_WAR_MATCH_TEAM_INFO_ACK(0x80000000));
                    }
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_MATCH_TEAM_INFO_ACK(0x80000000));
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}