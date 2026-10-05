using ProjectBlackout.Core;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Sql;
using Npgsql;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Data.Xml
{
    public static class ChannelsXml
    {
        public static List<Channel> _channels = new List<Channel>();

        public static void Load(int serverId)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@server", serverId);
                    command.CommandText = "SELECT * FROM channels WHERE server_id=@server ORDER BY channel_id ASC";
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        _channels.Add(new Channel()
                        {
                            serverId = data.GetInt32(0),
                            _id = data.GetInt32(1),
                            _type = data.GetInt32(2),
                        });
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

        public static Channel getChannel(int id)
        {
            try
            {
                return _channels[id];
            }
            catch
            {
                return null;
            }
        }

        public static List<Channel> getChannels(int ServerId)
        {
            List<Channel> Channels = new List<Channel>();
            for (int i = 0; i < _channels.Count; i++)
            {
                Channel channel = _channels[i];
                if (channel.serverId == ServerId)
                {
                    Channels.Add(channel);
                }
            }
            return Channels;
        }

        public static bool updateNotice(int serverId, int channelId, string text)
        {
            return ComDiv.updateDB("channels", "announce", text, "server_id", serverId, "channel_id", channelId);
        }

        public static bool updateNotice(string text)
        {
            return ComDiv.updateDB("channels", "announce", text);
        }
    }
}