using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Account.Rank;
using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;

namespace ProjectBlackout.Core.Xml
{
    public class RankXml
    {
        private static List<RankModel> _ranks = new List<RankModel>();
        private static SortedList<int, List<ItemsModel>> _awards = new SortedList<int, List<ItemsModel>>();
        public static void Load()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_ranks;";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        _ranks.Add(new RankModel(data.GetInt32(0), data.GetInt32(1), data.GetInt32(2), data.GetInt32(3)));
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch(Exception exc)
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

        private static void parse(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                if (fileStream.Length == 0)
                {
                    Logger.error("File is empty: " + path);
                }
                else
                {
                    try
                    {
                        xmlDocument.Load(fileStream);
                        for (XmlNode xmlNode1 = xmlDocument.FirstChild; xmlNode1 != null; xmlNode1 = xmlNode1.NextSibling)
                        {
                            if ("List".Equals(xmlNode1.Name))
                            {
                                for (XmlNode xmlNode2 = xmlNode1.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
                                {
                                    if ("Rank".Equals(xmlNode2.Name))
                                    {
                                        XmlNamedNodeMap xml = xmlNode2.Attributes;
                                        _ranks.Add(new RankModel(int.Parse(xml.GetNamedItem("Id").Value),
                                            int.Parse(xml.GetNamedItem("NextLevel").Value),
                                            int.Parse(xml.GetNamedItem("PointUp").Value),
                                            int.Parse(xml.GetNamedItem("AllExp").Value)));

                                        using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                                        {
                                            NpgsqlCommand command = connection.CreateCommand();
                                            connection.Open();
                                            command.CommandText = "INSERT INTO server_ranks VALUES (@Id, @NextLevel, @PointUp, @AllExp);";
                                            command.Parameters.AddWithValue("Id", int.Parse(xml.GetNamedItem("Id").Value));
                                            command.Parameters.AddWithValue("NextLevel", int.Parse(xml.GetNamedItem("NextLevel").Value));
                                            command.Parameters.AddWithValue("PointUp", int.Parse(xml.GetNamedItem("PointUp").Value));
                                            command.Parameters.AddWithValue("AllExp", int.Parse(xml.GetNamedItem("AllExp").Value));
                                            command.CommandType = CommandType.Text;
                                            command.ExecuteNonQuery();
                                            command.Dispose();
                                            connection.Dispose();
                                            connection.Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (XmlException ex)
                    {
                        Logger.warning(ex.ToString());
                    }
                }
                fileStream.Dispose();
                fileStream.Close();
            }
        }

        public static List<ItemsModel> getAwards(int rank)
        {
            lock (_awards)
            {
                List<ItemsModel> model;
                if (_awards.TryGetValue(rank, out model))
                {
                    return model;
                }
            }
            return new List<ItemsModel>();
        }

        public static void LoadAwards()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_rank_awards ORDER BY rank_id ASC";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        int rankId = data.GetInt32(0);
                        ItemsModel item = new ItemsModel(data.GetInt32(1))
                        {
                            _name = data.GetString(2),
                            _count = data.GetInt64(3),
                            _equip = data.GetInt32(4),
                        };
                        AddItemToList(rankId, item);
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

        private static void AddItemToList(int rank, ItemsModel item)
        {
            if (_awards.ContainsKey(rank))
            {
                _awards[rank].Add(item);
            }
            else
            {
                List<ItemsModel> items = new List<ItemsModel>();
                items.Add(item);
                _awards.Add(rank, items);
            }
        }
    }
}