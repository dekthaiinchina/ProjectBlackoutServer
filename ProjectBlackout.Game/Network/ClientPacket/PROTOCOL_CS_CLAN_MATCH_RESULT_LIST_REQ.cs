using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_CLAN_MATCH_RESULT_LIST_REQ : ReceivePacket
    {
        private List<Match> partyList = new List<Match>();
        private int page;

        public PROTOCOL_CS_CLAN_MATCH_RESULT_LIST_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            page = readC();
            //Logger.warning("[Party_List] Page: " + page);
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                if (p.clanId > 0)
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
                                    partyList.Add(m);
                                }
                            }
                        }
                    }
                }
                _client.SendPacket(new PROTOCOL_CS_CLAN_MATCH_RESULT_LIST_ACK(p.clanId == 0 ? 91 : 0, partyList));
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}