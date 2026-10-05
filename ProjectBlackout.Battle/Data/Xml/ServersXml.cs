using Npgsql;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Battle.Data.Xml
{
    public class ServersXml
    {
        private static List<GameServerModel> _servers = new List<GameServerModel>();

        public static GameServerModel getServer(int id)
        {
            lock (_servers)
            {
                for (int i = 0; i < _servers.Count; i++)
                {
                    GameServerModel server = _servers[i];
                    if (server._id == id)
                    {
                        return server;
                    }
                }
                return null;
            }
        }

        public static void Load()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM gameservers ORDER BY id ASC";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        GameServerModel server = new GameServerModel(data.GetString(3), (ushort)data.GetInt32(5))
                        {
                            _id = data.GetInt32(0),
                            _state = data.GetInt32(1),
                            _type = data.GetInt32(2),
                            _port = (ushort)data.GetInt32(4),
                            _maxPlayers = data.GetInt32(6)
                        };
                        _servers.Add(server);
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