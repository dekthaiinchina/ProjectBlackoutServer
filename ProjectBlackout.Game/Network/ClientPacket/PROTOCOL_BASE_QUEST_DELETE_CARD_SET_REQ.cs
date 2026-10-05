using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_QUEST_DELETE_CARD_SET_REQ : ReceivePacket
    {
        private uint erro;
        private int missionIdx;

        public PROTOCOL_BASE_QUEST_DELETE_CARD_SET_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            missionIdx = readC();
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
                PlayerMissions missions = p._mission;
                bool failed = false;
                if (missionIdx >= 3 || missionIdx == 0 && missions.mission1 == 0 || missionIdx == 1 && missions.mission2 == 0 || missionIdx == 2 && missions.mission3 == 0)
                {
                    failed = true;
                }
                if (!failed && PlayerManager.updateMissionId(p.player_id, 0, missionIdx) &&
                    ComDiv.updateDB("player_missions", "owner_id", p.player_id, new string[]
                    {
                        "card" + (missionIdx + 1),
                        "mission" + (missionIdx + 1)
                    }, 0, new byte[0]))
                {
                    if (missionIdx == 0)
                    {
                        missions.mission1 = 0;
                        missions.card1 = 0;
                        missions.list1 = new byte[40];
                    }
                    else if (missionIdx == 1)
                    {
                        missions.mission2 = 0;
                        missions.card2 = 0;
                        missions.list2 = new byte[40];
                    }
                    else if (missionIdx == 2)
                    {
                        missions.mission3 = 0;
                        missions.card3 = 0;
                        missions.list3 = new byte[40];
                    }
                }
                else
                {
                    erro = 0x80001050;
                }
                _client.SendPacket(new PROTOCOL_BASE_QUEST_DELETE_CARD_SET_ACK(erro, p));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_BASE_QUEST_DELETE_CARD_SET_REQ: " + ex.ToString());
            }
        }
    }
}