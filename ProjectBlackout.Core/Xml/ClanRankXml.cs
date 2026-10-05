using Npgsql;
using ProjectBlackout.Core.Models.Account.Rank;
using ProjectBlackout.Core.Sql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Core.Xml
{
    public class ClanRankXml
    {
        private static List<RankModel> _ranks = new List<RankModel>();
        public static void Load()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_clan_ranks;";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        _ranks.Add(new RankModel(data.GetInt32(0), data.GetInt32(1), 0, data.GetInt32(2)));
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception exc)
            {
                Logger.error(exc.ToString());
            }
        }

        public static RankModel getRank(int rankId)
        {
            lock (_ranks)
            {
                for (int i = 0; i < _ranks.Count; i++)
                {
                    RankModel rank = _ranks[i];
                    if (rank._id == rankId)
                    {
                        return rank;
                    }
                }
                return null;
            }
        }
    }
}