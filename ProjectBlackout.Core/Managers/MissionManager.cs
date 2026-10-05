using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Data;

namespace ProjectBlackout.Core.Managers
{
    public class MissionManager
    {
        private static MissionManager acm = new MissionManager();

        public static MissionManager getInstance()
        {
            return acm;
        }

        public void addMissionDB(long player_id)
        {
            if (player_id == 0)
            {
                return;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand cmd = connection.CreateCommand();
                    connection.Open();
                    cmd.Parameters.AddWithValue("@owner", player_id);
                    cmd.CommandText = "INSERT INTO player_missions (owner_id) VALUES (@owner)";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public PlayerMissions getMission(long pId, int mission1, int mission2, int mission3, int mission4)
        {
            if (pId == 0)
            {
                return null;
            }
            PlayerMissions mission = null;
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@owner", pId);
                    command.CommandText = "SELECT * FROM player_missions WHERE owner_id=@owner";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        mission = new PlayerMissions
                        {
                            actualMission = data.GetInt32(1),
                            card1 = data.GetInt32(2),
                            card2 = data.GetInt32(3),
                            card3 = data.GetInt32(4),
                            card4 = data.GetInt32(5),
                            mission1 = mission1,
                            mission2 = mission2,
                            mission3 = mission3,
                            mission4 = mission4,
                        };

                        data.GetBytes(6, 0, mission.list1, 0, 40);
                        data.GetBytes(7, 0, mission.list2, 0, 40);
                        data.GetBytes(8, 0, mission.list3, 0, 40);
                        data.GetBytes(9, 0, mission.list4, 0, 40);
                        mission.UpdateSelectedCard();
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
                return mission;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return null;
            }
        }

        public void updateCurrentMissionList(long player_id, PlayerMissions mission)
        {
            byte[] list = mission.getCurrentMissionList();
            ComDiv.updateDB("player_missions", "mission" + (mission.actualMission + 1), list, "owner_id", player_id);
        }
    }
}