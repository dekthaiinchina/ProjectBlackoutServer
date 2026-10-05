using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Core.Xml
{
    public class BasicInventoryXml
    {
        public static List<ItemsModel> basic = new List<ItemsModel>(), creationAwards = new List<ItemsModel>(), Characters = new List<ItemsModel>();

        public static void Load()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_inventory_template";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {

                        int rewardType = data.GetInt32(0);
                        ItemsModel item = new ItemsModel(data.GetInt32(1))
                        {
                            _name = data.GetString(2),
                            _count = data.GetInt64(3),
                            _equip = data.GetInt32(4),
                        };
                        if (rewardType == 0)
                        {
                            basic.Add(item);
                        }
                        else if (rewardType == 1)
                        {
                            creationAwards.Add(item);
                        }
                        else if (rewardType == 2)
                        {
                            Characters.Add(item);
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
    }
}