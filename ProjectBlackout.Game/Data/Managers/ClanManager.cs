using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Sql;
using Npgsql;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProjectBlackout.Game.Data.Managers
{
    public static class ClanManager
    {
        public static List<Clan> _clans = new List<Clan>();

        public static void Load()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM clans";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        long owner = data.GetInt64(3);
                        if (owner == 0)
                        {
                            continue;
                        }

                        string b1, b2, b3, b4, b5;
                        Clan clan = new Clan
                        {
                            _id = data.GetInt32(0),
                            _rank = data.GetInt32(1),
                            _name = data.GetString(2),
                            owner_id = owner,
                            _logo = (uint)data.GetInt64(4),
                            _name_color = data.GetInt32(5),
                            _info = data.GetString(6),
                            _news = data.GetString(7),
                            creationDate = data.GetInt32(8),
                            autoridade = data.GetInt32(9),
                            limite_rank = data.GetInt32(10),
                            limite_idade = data.GetInt32(11),
                            limite_idade2 = data.GetInt32(12),
                            partidas = data.GetInt32(13),
                            vitorias = data.GetInt32(14),
                            derrotas = data.GetInt32(15),
                            _pontos = data.GetFloat(16),
                            maxPlayers = data.GetInt32(17),
                            _exp = data.GetInt32(18),
                            effect = data.GetInt32(24)
                    };
                        b1 = data.GetString(19);
                        b2 = data.GetString(20);
                        b3 = data.GetString(21);
                        b4 = data.GetString(22);
                        b5 = data.GetString(23);
                        clan.BestPlayers.SetPlayers(b1, b2, b3, b4, b5);
                        _clans.Add(clan);
                    }
                    command.Dispose();
                    data.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public static List<Clan> getClanListPerPage(int page)
        {
            List<Clan> clans = new List<Clan>();
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@page", (170 * page));
                    command.CommandText = "SELECT * FROM clans ORDER BY clan_id DESC OFFSET @page LIMIT 170";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        long owner = data.GetInt64(3);
                        if (owner == 0)
                        {
                            continue;
                        }

                        string b1, b2, b3, b4, b5;
                        Clan clan = new Clan
                        {
                            _id = data.GetInt32(0),
                            _rank = data.GetInt32(1),
                            _name = data.GetString(2),
                            owner_id = owner,
                            _logo = (uint)data.GetInt64(4),
                            _name_color = data.GetInt32(5),
                            _info = data.GetString(6),
                            _news = data.GetString(7),
                            creationDate = data.GetInt32(8),
                            autoridade = data.GetInt32(9),
                            limite_rank = data.GetInt32(10),
                            limite_idade = data.GetInt32(11),
                            limite_idade2 = data.GetInt32(12),
                            partidas = data.GetInt32(13),
                            vitorias = data.GetInt32(14),
                            derrotas = data.GetInt32(15),
                            _pontos = data.GetFloat(16),
                            maxPlayers = data.GetInt32(17),
                            _exp = data.GetInt32(18),
                            effect = data.GetInt32(24)
                        };
                        b1 = data.GetString(19);
                        b2 = data.GetString(20);
                        b3 = data.GetString(21);
                        b4 = data.GetString(22);
                        b5 = data.GetString(23);
                        clan.BestPlayers.SetPlayers(b1, b2, b3, b4, b5);
                        clans.Add(clan);
                    }
                    command.Dispose();
                    data.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return clans;
        }

        public static Clan getClan(int id)
        {
            if (id == 0)
            {
                return new Clan();
            }
            lock (_clans)
            {
                for (int i = 0; i < _clans.Count; i++)
                {
                    Clan c = _clans[i];
                    if (c._id == id)
                    {
                        return c;
                    }
                }
            }
            return new Clan();
        }

        public static List<Account> getClanPlayers(int clan_id, long exception, bool useCache)
        {
            List<Account> players = new List<Account>();
            if (clan_id == 0)
            {
                return players;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@clan", clan_id);
                    command.CommandText = "SELECT player_id, player_name, name_color, rank, online, clanaccess, clandate, status FROM players WHERE clan_id=@clan";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        long pId = data.GetInt64(0);
                        if (pId == exception)
                        {
                            continue;
                        }
                        Account p = new Account
                        {
                            player_id = pId,
                            player_name = data.GetString(1),
                            name_color = data.GetInt32(2),
                            clanId = clan_id,
                            _rank = data.GetInt32(3),
                            _isOnline = data.GetBoolean(4),
                            clanAccess = data.GetInt32(5),
                            clanDate = data.GetInt32(6)
                        };
                        p._status.SetData((uint)data.GetInt64(7), p.player_id);
                        if (useCache)
                        {
                            Account p2 = AccountManager.getAccount(p.player_id, true);
                            if (p2 != null)
                            {
                                p._connection = p2._connection;
                            }
                        }
                        players.Add(p);
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
            return players;
        }

        public static List<Account> getClanPlayers(int clan_id, long exception, bool useCache, bool isOnline)
        {
            List<Account> players = new List<Account>();
            if (clan_id == 0)
            {
                return players;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@clan", clan_id);
                    command.Parameters.AddWithValue("@on", isOnline);
                    command.CommandText = "SELECT player_id, player_name, name_color, rank, clanaccess, clandate, status FROM players WHERE clan_id=@clan AND online=@on";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        long pId = data.GetInt64(0);
                        if (pId == exception)
                        {
                            continue;
                        }
                        Account p = new Account
                        {
                            player_id = pId,
                            clanId = clan_id,
                            player_name = data.GetString(1),
                            name_color = data.GetInt32(2),
                            _rank = data.GetInt32(3),
                            _isOnline = isOnline,
                            clanAccess = data.GetInt32(4),
                            clanDate = data.GetInt32(5)
                        };
                        p._status.SetData((uint)data.GetInt64(6), p.player_id);
                        if (useCache)
                        {
                            Account p2 = AccountManager.getAccount(p.player_id, true);
                            if (p2 != null)
                            {
                                p._connection = p2._connection;
                            }
                        }
                        players.Add(p);

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
            return players;
        }

        public static void SendPacket(SendPacket packet, List<Account> players)
        {
            if (players.Count == 0)
            {
                return;
            }

            byte[] code = packet.GetCompleteBytes("ClanManager.SendPacket");
            for (int i = 0; i < players.Count; i++)
            {
                players[i].SendCompletePacket(code, false);
            }
        }

        public static void SendPacket(SendPacket packet, List<Account> players, long exception)
        {
            if (players.Count == 0)
            {
                return;
            }

            byte[] code = packet.GetCompleteBytes("ClanManager.SendPacket");
            for (int i = 0; i < players.Count; i++)
            {
                Account mb = players[i];
                if (mb.player_id != exception)
                {
                    mb.SendCompletePacket(code, false);
                }
            }
        }

        public static void SendPacket(SendPacket packet, int clan_id, long exception, bool useCache, bool isOnline)
        {
            List<Account> players = getClanPlayers(clan_id, exception, useCache, isOnline);
            SendPacket(packet, players);
        }

        public static bool RemoveClan(Clan clan)
        {
            lock (_clans)
            {
                return _clans.Remove(clan);
            }
        }

        public static void AddClan(Clan clan)
        {
            lock (_clans)
            {
                _clans.Add(clan);
            }
        }

        public static bool isClanNameExist(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return true;
            }
            try
            {
                int value = 0;
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@name", name);
                    command.CommandText = "SELECT COUNT(*) FROM clans WHERE clan_name=@name";
                    value = Convert.ToInt32(command.ExecuteScalar());
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return value > 0;
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
                return true;
            }
        }

        public static bool isClanLogoExist(uint logo)
        {
            try
            {
                int value = 0;
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@logo", (long)logo);
                    command.CommandText = "SELECT COUNT(*) FROM clans WHERE logo=@logo";
                    value = Convert.ToInt32(command.ExecuteScalar());
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return value > 0;
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
                return true;
            }
        }
    }
}