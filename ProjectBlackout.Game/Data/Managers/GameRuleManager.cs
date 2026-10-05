using Npgsql;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Sql;
using ProjectBlackout.Game.Data.Configs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Data.Managers
{
    public class GameRuleManager
    {
        public static List<GameRule> GameRules = new List<GameRule>();

        public static List<GameRule> getGameRules(int RuleId)
        {
            try
            {
                using (NpgsqlConnection Connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand Command = Connection.CreateCommand();
                    Connection.Open();
                    Command.Parameters.AddWithValue("@RuleId", RuleId);
                    Command.CommandText = "SELECT * FROM gamerules WHERE id=@RuleId";
                    Command.CommandType = CommandType.Text;
                    NpgsqlDataReader Data = Command.ExecuteReader();
                    while (Data.Read())
                    {
                        GameRules.Add(new GameRule
                        {
                            WeaponId = Data.GetInt32(1),
                        });
                    }
                    Command.Dispose();
                    Data.Close();
                    Connection.Dispose();
                    Connection.Close();
                }
            }
            catch
            {

            }
            return GameRules;
        }

        public static void Reload()
        {
            GameRules.Clear();
            getGameRules(GameConfig.ruleId);
        }
    }
}