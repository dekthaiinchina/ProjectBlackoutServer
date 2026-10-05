using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_MATCH_TEAM_COUNT_REQ : ReceivePacket
    {
        public PROTOCOL_CLAN_WAR_MATCH_TEAM_COUNT_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

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
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_MATCH_TEAM_COUNT_ACK(ch._matchs.Count));
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}