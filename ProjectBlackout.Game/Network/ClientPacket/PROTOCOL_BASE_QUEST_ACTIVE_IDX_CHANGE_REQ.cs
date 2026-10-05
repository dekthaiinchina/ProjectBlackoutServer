using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_REQ : ReceivePacket
    {
        private int cardIdx, actualMission, cardFlags;

        public PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            actualMission = readC();
            cardIdx = readC();
            cardFlags = readUH();
        }

        public override void run()
        {
            try
            {
                if (_client == null)
                {
                    return;
                }
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                PlayerMissions missions = p._mission;
                DBQuery query = new DBQuery();
                if (missions.getCard(actualMission) != cardIdx)
                {
                    if (actualMission == 0)
                    {
                        missions.card1 = cardIdx;
                    }
                    else if (actualMission == 1)
                    {
                        missions.card2 = cardIdx;
                    }
                    else if (actualMission == 2)
                    {
                        missions.card3 = cardIdx;
                    }
                    else if (actualMission == 3)
                    {
                        missions.card4 = cardIdx;
                    }
                    query.AddQuery("card" + (actualMission + 1), cardIdx);
                }
                missions.selectedCard = cardFlags == 65535;
                if (missions.actualMission != actualMission)
                {
                    query.AddQuery("actual_mission", actualMission);
                    missions.actualMission = actualMission;
                }
                ComDiv.updateDB("player_missions", "owner_id", _client.player_id, query.GetTables(), query.GetValues());
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_REQ: " + ex.ToString());
            }
        }
    }
}