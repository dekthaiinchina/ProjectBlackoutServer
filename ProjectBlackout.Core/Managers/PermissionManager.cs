using Npgsql;
using ProjectBlackout.Core.Sql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Core.Managers
{
    public class PermissionManager
    {
        private static Dictionary<int, string> Permissions = new Dictionary<int, string>();
        private static Dictionary<int, List<string>> LevelsPermissions = new Dictionary<int, List<string>>();
        private static Dictionary<int, int> LevelsRanks = new Dictionary<int, int>();

        public static void Load()
        {
            Permissions.Clear();
            LevelsPermissions.Clear();
            LevelsRanks.Clear();

            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM permissions";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        int Id = data.GetInt32(0);
                        string Permission = data.GetString(1);

                        if (!Permissions.ContainsKey(Id))
                            Permissions.Add(Id, Permission);
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }

                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM permissions_levels";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        int Id = data.GetInt32(0);
                        string Name = data.GetString(1);
                        int FakeRank = data.GetInt32(3);

                        LevelsRanks.Add(Id, FakeRank);

                        LevelsPermissions.Add(Id, new List<string>());
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }

                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM permissions_rights";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        int LevelId = data.GetInt32(0);
                        int PermissionId = data.GetInt32(1);

                        if(Permissions.ContainsKey(PermissionId))
                        {
                            LevelsPermissions[LevelId].Add(Permissions[PermissionId]);
                        }
                            
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

        public static int GetFakeRank(int Level)
        {
            if (LevelsRanks.ContainsKey(Level))
                return LevelsRanks[Level];

            return -1;
        }
        public static bool HavePermission(string Permission, int Level)
        {
            if (LevelsPermissions.ContainsKey(Level))
                if (LevelsPermissions[Level].Contains(Permission))
                    return true;

            return false;
        }
    }
}
