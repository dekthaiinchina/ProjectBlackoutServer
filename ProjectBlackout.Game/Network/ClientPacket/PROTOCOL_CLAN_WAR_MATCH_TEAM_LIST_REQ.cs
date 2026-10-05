using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_MATCH_TEAM_LIST_REQ : ReceivePacket
    {
        private int page;

        public PROTOCOL_CLAN_WAR_MATCH_TEAM_LIST_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            page = readH();
            //Logger.warning("[Match_Team_List] Page: " + page);
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null || p._match == null)
                {
                    return;
                }
                Channel ch = p.getChannel();
                if (ch != null && ch._type == 4)
                {
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_MATCH_TEAM_LIST_ACK(page, ch._matchs, p._match._matchId));
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}