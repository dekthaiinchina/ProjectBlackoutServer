using Npgsql;
using ProjectBlackout.Battle.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Battle.Data.Items
{
    public class ItemManager
    {
        public static List<Item> Items = new List<Item>();

        public static void Load()
        {
            try
            {
                Items.Clear();

                using(NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM item_stats;";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        Items.Add(new Item()
                        {
                            Id = data.GetInt32(0),
                            Name = data.GetString(1),
                            BulletLoaded = data.GetInt32(2),
                            BulletTotal = data.GetInt32(3),
                            Damage = data.GetInt32(4),
                            FireDelay = data.GetDecimal(5),
                            HelmetPenetrate = data.GetInt32(6),
                            Range = data.GetDecimal(7)
                        });
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch(Exception e)
            {
                Logger.error(e.ToString());
            }
        }
    }
}
