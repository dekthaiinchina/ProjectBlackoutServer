using Npgsql;
using ProjectBlackout.Core.Models.Account.Mission;
using ProjectBlackout.Core.Sql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Core.Xml
{
    public class MissionAwardsXml
    {
        private static List<MissionAwards> _awards = new List<MissionAwards>();

        public static void Load()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_cards_awards WHERE id > 0;";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        _awards.Add(new MissionAwards(data.GetInt32(0), data.GetInt32(1), data.GetInt32(2), data.GetInt32(3)));
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                Logger.error(ex.ToString());
            }

        }

        public static MissionAwards getAward(int mission)
        {
            lock (_awards)
            {
                for (int i = 0; i < _awards.Count; i++)
                {
                    MissionAwards mis = _awards[i];
                    if (mis._id == mission)
                    {
                        return mis;
                    }
                }
                return null;
            }
        }
    }
}