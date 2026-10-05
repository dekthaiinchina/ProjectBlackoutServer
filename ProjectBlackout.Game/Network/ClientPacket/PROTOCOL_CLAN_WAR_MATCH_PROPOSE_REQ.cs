using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_MATCH_PROPOSE_REQ : ReceivePacket
    {
        private int id, serverInfo;
        private uint erro;

        public PROTOCOL_CLAN_WAR_MATCH_PROPOSE_REQ(GameClient client, byte[] data)
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
            try
            {
                Account p = _client._player;
                if (p != null && p._match != null && p.matchSlot == p._match._leader && p._match._state == MatchState.Ready)
                {
                    int channelId = serverInfo - ((serverInfo / 10) * 10);
                    Match mt = ChannelsXml.getChannel(channelId).getMatch(id);
                    if (mt != null)
                    {
                        Account lider = mt.getLeader();
                        if (lider != null && lider._connection != null && lider._isOnline)
                        {
                            lider.SendPacket(new PROTOCOL_CLAN_WAR_CHANGE_MAX_PER_ACK(p._match, p));
                        }
                        else
                        {
                            erro = 0x80000000;
                        }
                    }
                    else
                    {
                        erro = 0x80000000;
                    }
                }
                else
                {
                    erro = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_CLAN_WAR_MATCH_PROPOSE_ACK(erro));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CLAN_WAR_MATCH_PROPOSE_REQ: " + ex.ToString());
            }
        }
    }
}