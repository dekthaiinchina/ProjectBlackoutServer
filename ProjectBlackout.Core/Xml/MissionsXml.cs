using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Core.Xml
{
    public class MissionsXml
    {
        public static uint _missionPage1, _missionPage2;
        private static List<MissionModel> Missions = new List<MissionModel>();

        public static void Load()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_cards ORDER BY mission_id ASC";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        bool enable = data.GetBoolean(2);
                        MissionModel mission = new MissionModel
                        {
                            id = data.GetInt32(0),
                            price = data.GetInt32(1)
                        };
                        uint flag = (uint)(1 << mission.id);
                        int listId = (int)(Math.Ceiling(mission.id / 32.0));
                        if (enable)
                        {
                            if (listId == 1)
                            {
                                _missionPage1 += flag;
                            }
                            else if (listId == 2)
                            {
                                _missionPage2 += flag;
                            }
                        }
                        Missions.Add(mission);
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public static int GetMissionPrice(int id)
        {
            for (int i = 0; i < Missions.Count; i++)
            {
                MissionModel mission = Missions[i];
                if (mission.id == id)
                {
                    return mission.price;
                }
            }
            return -1;
        }
    }

    public class MissionModel
    {
        public int id, price;
    }
}