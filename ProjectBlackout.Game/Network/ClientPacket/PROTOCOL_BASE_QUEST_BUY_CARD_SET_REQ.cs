using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Xml;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_QUEST_BUY_CARD_SET_REQ : ReceivePacket
    {
        private int missionId;
        private uint erro;

        public PROTOCOL_BASE_QUEST_BUY_CARD_SET_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            missionId = readC();
        }

        public override void run()
        {
            Account player = _client._player;
            if (player == null)
            {
                return;
            }
            PlayerMissions missions = player._mission;
            int price = MissionsXml.GetMissionPrice(missionId);
            if (player == null || price == -1 || 0 > player._gp - price || missions.mission1 == missionId || missions.mission2 == missionId || missions.mission3 == missionId)
            {
                erro = price == -1 ? 0x8000104C : 0x8000104D;
            }
            else
            {
                if (missions.mission1 == 0)
                {
                    if (PlayerManager.updateMissionId(player.player_id, missionId, 0))
                    {
                        missions.mission1 = missionId;
                        missions.list1 = new byte[40];
                        missions.actualMission = 0;
                        missions.card1 = 0;
                    }
                    else
                    {
                        erro = 0x8000104C;
                    }
                }
                else if (missions.mission2 == 0)
                {
                    if (PlayerManager.updateMissionId(player.player_id, missionId, 1))
                    {
                        missions.mission2 = missionId;
                        missions.list2 = new byte[40];
                        missions.actualMission = 1;
                        missions.card2 = 0;
                    }
                    else
                    {
                        erro = 0x8000104C;
                    }
                }
                else if (missions.mission3 == 0)
                {
                    if (PlayerManager.updateMissionId(player.player_id, missionId, 2))
                    {
                        missions.mission3 = missionId;
                        missions.list3 = new byte[40];
                        missions.actualMission = 2;
                        missions.card3 = 0;
                    }
                    else
                    {
                        erro = 0x8000104C;
                    }
                }
                else
                {
                    erro = 0x8000104E;
                }
                if (erro == 0)
                {
                    if (price == 0 || PlayerManager.updateAccountGold(player.player_id, player._gp - price))
                    {
                        player._gp -= price;
                    }
                    else
                    {
                        erro = 0x8000104C;
                    }
                }
            }
            _client.SendPacket(new PROTOCOL_BASE_QUEST_BUY_CARD_SET_ACK(erro, player));
            /*
             * 0x8000104C STR_TBL_GUI_BASE_FAIL_BUY_CARD_BY_NO_CARD_INFO
             * 0x8000104D STR_TBL_GUI_BASE_NO_POINT_TO_GET_ITEM
             * 0x8000104E STR_TBL_GUI_BASE_LIMIT_CARD_COUNT
             * 0x800010D5 STR_TBL_GUI_BASE_DID_NOT_TUTORIAL_MISSION_CARD
             */
        }
    }
}