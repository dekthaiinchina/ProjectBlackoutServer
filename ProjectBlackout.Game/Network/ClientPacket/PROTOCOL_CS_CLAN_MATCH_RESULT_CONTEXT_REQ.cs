using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_CLAN_MATCH_RESULT_CONTEXT_REQ : ReceivePacket
    {
        private int matchs;

        public PROTOCOL_CS_CLAN_MATCH_RESULT_CONTEXT_REQ(GameClient client, byte[] data)
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
                if (p != null && p.clanId > 0)
                {
                    Channel ch = p.getChannel();
                    if (ch != null && ch._type == 4)
                    {
                        lock (ch._matchs)
                        {
                            for (int i = 0; i < ch._matchs.Count; i++)
                            {
                                Match m = ch._matchs[i];
                                if (m.clan._id == p.clanId)
                                {
                                    matchs++;
                                }
                            }
                        }
                    }
                }
                _client.SendPacket(new PROTOCOL_CS_CLAN_MATCH_RESULT_CONTEXT_ACK(matchs));
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}