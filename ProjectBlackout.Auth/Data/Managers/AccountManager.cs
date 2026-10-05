// Decompiled with JetBrains decompiler
// Type: ProjectBlackout.Auth.Data.Managers.AccountManager
// Assembly: ProjectBlackout.Auth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2F2D71E3-3E87-4155-AA64-E654DA3CFF2D
// Assembly location: C:\Users\LucasRoot\Desktop\Servidor BG\ProjectBlackout.Auth.exe

using Npgsql;
using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Sql;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace ProjectBlackout.Auth.Data.Managers
{
    public class AccountManager
    {
        public SortedList<long, Account> _accounts = new SortedList<long, Account>();
        private static AccountManager acm = new AccountManager();

        public bool AddAccount(Account acc)
        {
            lock (_accounts)
            {
                if (!_accounts.ContainsKey(acc.player_id))
                {
                    _accounts.Add(acc.player_id, acc);
                    return true;
                }
            }
            return false;
        }

        public Account getAccountDB(object valor, object valor2, int type, int searchFlag)
        {
            if (type == 0 && (string)valor == "" || type == 1 && (long)valor == 0L || type == 2 && (string.IsNullOrEmpty((string)valor) || string.IsNullOrEmpty((string)valor2)))
                return null;
            Account acc = null;
            try
            {
                using (NpgsqlConnection npgsqlConnection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = npgsqlConnection.CreateCommand();
                    npgsqlConnection.Open();
                    command.Parameters.AddWithValue("@valor", valor);
                    switch (type)
                    {
                        case 0:
                            command.CommandText = "SELECT * FROM players WHERE token=@valor LIMIT 1";
                            break;
                        case 1:
                            command.CommandText = "SELECT * FROM players WHERE player_id=@valor LIMIT 1";
                            break;
                        case 2:
                            command.Parameters.AddWithValue("@valor2", valor2);
                            command.CommandText = "SELECT * FROM players WHERE login=@valor AND password=@valor2 LIMIT 1";
                            break;
                    }
                    NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
                    while (npgsqlDataReader.Read())
                    {
                        acc = new Account();
                        acc.login = npgsqlDataReader.GetString(0);
                        acc.password = npgsqlDataReader.GetString(1);
                        acc.SetPlayerId(npgsqlDataReader.GetInt64(2), searchFlag);
                        acc.player_name = npgsqlDataReader.GetString(3);
                        acc.name_color = npgsqlDataReader.GetInt32(4);
                        acc.clan_id = npgsqlDataReader.GetInt32(5);
                        acc._rank = npgsqlDataReader.GetInt32(6);
                        acc._gp = npgsqlDataReader.GetInt32(7);
                        acc._exp = npgsqlDataReader.GetInt32(8);
                        acc.pc_cafe = npgsqlDataReader.GetInt32(9);
                        acc._statistic.fights = npgsqlDataReader.GetInt32(10);
                        acc._statistic.fights_win = npgsqlDataReader.GetInt32(11);
                        acc._statistic.fights_lost = npgsqlDataReader.GetInt32(12);
                        acc._statistic.kills_count = npgsqlDataReader.GetInt32(13);
                        acc._statistic.deaths_count = npgsqlDataReader.GetInt32(14);
                        acc._statistic.headshots_count = npgsqlDataReader.GetInt32(15);
                        acc._statistic.escapes = npgsqlDataReader.GetInt32(16);
                        acc.access = npgsqlDataReader.GetInt32(17);
                        acc.LastRankUpDate = (uint)npgsqlDataReader.GetInt64(20);
                        acc._money = npgsqlDataReader.GetInt32(21);
                        acc._isOnline = npgsqlDataReader.GetBoolean(22);
                        acc._equip._primary = npgsqlDataReader.GetInt32(23);
                        acc._equip._secondary = npgsqlDataReader.GetInt32(24);
                        acc._equip._melee = npgsqlDataReader.GetInt32(25);
                        acc._equip._grenade = npgsqlDataReader.GetInt32(26);
                        acc._equip._special = npgsqlDataReader.GetInt32(27);
                        acc._equip._red = npgsqlDataReader.GetInt32(28);
                        acc._equip._blue = npgsqlDataReader.GetInt32(29);
                        acc._equip._helmet = npgsqlDataReader.GetInt32(30);
                        acc._equip._dino = npgsqlDataReader.GetInt32(31);
                        acc._equip._beret = npgsqlDataReader.GetInt32(32);
                        acc.brooch = npgsqlDataReader.GetInt32(33);
                        acc.insignia = npgsqlDataReader.GetInt32(34);
                        acc.medal = npgsqlDataReader.GetInt32(35);
                        acc.blue_order = npgsqlDataReader.GetInt32(36);
                        acc._mission.mission1 = npgsqlDataReader.GetInt32(37);
                        acc.clanAccess = npgsqlDataReader.GetInt32(38);
                        acc.effects = (CouponEffects)npgsqlDataReader.GetInt64(40);
                        acc._statistic.fights_draw = npgsqlDataReader.GetInt32(41);
                        acc._mission.mission2 = npgsqlDataReader.GetInt32(42);
                        acc._mission.mission3 = npgsqlDataReader.GetInt32(43);
                        acc._statistic.totalkills_count = npgsqlDataReader.GetInt32(44);
                        acc._statistic.totalfights_count = npgsqlDataReader.GetInt32(45);
                        acc._status.SetData((uint)npgsqlDataReader.GetInt64(46), acc.player_id);
                        acc.MacAddress = (PhysicalAddress)npgsqlDataReader.GetValue(50);
                        acc.ban_obj_id = npgsqlDataReader.GetInt64(51);
                        acc.token = npgsqlDataReader.GetString(52);
                        acc.hwid = npgsqlDataReader.GetString(53);
                        acc._tag = npgsqlDataReader.GetInt32(54);
                        acc.age = npgsqlDataReader.GetInt32(55);
                        acc.tourneyLevel = npgsqlDataReader.GetInt32(56);
                        acc._statistic.assist = npgsqlDataReader.GetInt32(57);
                        acc._equip.face = npgsqlDataReader.GetInt32(58);
                        acc._equip.jacket = npgsqlDataReader.GetInt32(59);
                        acc._equip.poket = npgsqlDataReader.GetInt32(60);
                        acc._equip.glove = npgsqlDataReader.GetInt32(61);
                        acc._equip.belt = npgsqlDataReader.GetInt32(62);
                        acc._equip.holster = npgsqlDataReader.GetInt32(63);
                        acc._equip.skin = npgsqlDataReader.GetInt32(64);
                        if (AddAccount(acc) && acc._isOnline)
                            acc.setOnlineStatus(false);

                    }
                    command.Dispose();
                    npgsqlDataReader.Dispose();
                    npgsqlDataReader.Close();
                    npgsqlConnection.Dispose();
                    npgsqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error("was a problem loading accounts!\r\n" + ex.ToString());
            }
            return acc;
        }

        public void getFriendlyAccounts(FriendSystem system)
        {
            if (system == null)
                return;
            if (system._friends.Count == 0)
                return;
            try
            {
                using (NpgsqlConnection npgsqlConnection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = npgsqlConnection.CreateCommand();
                    npgsqlConnection.Open();
                    List<string> stringList = new List<string>();
                    for (int index = 0; index < system._friends.Count; ++index)
                    {
                        Friend friend = system._friends[index];
                        string parameterName = "@valor" + index.ToString();
                        command.Parameters.AddWithValue(parameterName, friend.player_id);
                        stringList.Add(parameterName);
                    }
                    string str = string.Join(",", stringList.ToArray());
                    command.CommandText = "SELECT player_name, player_id, rank, online, status FROM players WHERE player_id in (" + str + ") ORDER BY player_id";
                    NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
                    while (npgsqlDataReader.Read())
                    {
                        Friend friend = system.GetFriend(npgsqlDataReader.GetInt64(1));
                        if (friend != null)
                        {
                            friend.player.player_name = npgsqlDataReader.GetString(0);
                            friend.player._rank = npgsqlDataReader.GetInt32(2);
                            friend.player._isOnline = npgsqlDataReader.GetBoolean(3);
                            friend.player._status.SetData((uint)npgsqlDataReader.GetInt64(4), friend.player_id);
                            if (friend.player._isOnline && !_accounts.ContainsKey(friend.player_id))
                            {
                                friend.player.setOnlineStatus(false);
                                friend.player._status.ResetData(friend.player_id);
                            }
                        }
                    }
                    command.Dispose();
                    npgsqlDataReader.Dispose();
                    npgsqlDataReader.Close();
                    npgsqlConnection.Dispose();
                    npgsqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error("was a problem loading (FriendlyAccounts)!\r\n" + ex.ToString());
            }
        }

        public void getFriendlyAccounts(FriendSystem system, bool isOnline)
        {
            if (system == null)
                return;
            if (system._friends.Count == 0)
                return;
            try
            {
                using (NpgsqlConnection npgsqlConnection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = npgsqlConnection.CreateCommand();
                    List<string> stringList = new List<string>();
                    for (int index = 0; index < system._friends.Count; ++index)
                    {
                        Friend friend = system._friends[index];
                        if (friend.state > 0)
                            return;
                        string parameterName = "@valor" + index.ToString();
                        command.Parameters.AddWithValue(parameterName, friend.player_id);
                        stringList.Add(parameterName);
                    }
                    string str = string.Join(",", stringList.ToArray());
                    if (str == "")
                        return;
                    npgsqlConnection.Open();
                    command.Parameters.AddWithValue("@on", isOnline);
                    command.CommandText = "SELECT player_name, player_id, rank, status FROM players WHERE player_id in (" + str + ") AND online=@on ORDER BY player_id";
                    NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
                    while (npgsqlDataReader.Read())
                    {
                        Friend friend = system.GetFriend(npgsqlDataReader.GetInt64(1));
                        if (friend != null)
                        {
                            friend.player.player_name = npgsqlDataReader.GetString(0);
                            friend.player._rank = npgsqlDataReader.GetInt32(2);
                            friend.player._isOnline = isOnline;
                            friend.player._status.SetData((uint)npgsqlDataReader.GetInt64(3), friend.player_id);
                            if (isOnline && !_accounts.ContainsKey(friend.player_id))
                            {
                                friend.player.setOnlineStatus(false);
                                friend.player._status.ResetData(friend.player_id);
                            }
                        }
                    }
                    command.Dispose();
                    npgsqlDataReader.Dispose();
                    npgsqlDataReader.Close();
                    npgsqlConnection.Dispose();
                    npgsqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error("was a problem loading (FriendAccounts2)!\r\n" + ex.ToString());
            }
        }

        public static AccountManager getInstance() => AccountManager.acm;

        public Account getAccount(long id)
        {
            if (id == 0L)
                return null;
            try
            {
                Account account = null;
                return _accounts.TryGetValue(id, out account) ? account : getAccountDB(id, null, 1, 0);
            }
            catch
            {
                return null;
            }
        }

        public Account getAccount(long id, bool noUseDB)
        {
            if (id == 0L)
                return null;
            try
            {
                Account account = null;
                return _accounts.TryGetValue(id, out account) ? account : (noUseDB ? null : getAccountDB(id, null, 1, 0));
            }
            catch
            {
                return null;
            }
        }

        public bool CreateAccount(out Account p, string login, string password)
        {
            try
            {
                using (NpgsqlConnection npgsqlConnection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = npgsqlConnection.CreateCommand();
                    npgsqlConnection.Open();
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@pass", password);
                    command.CommandText = "INSERT INTO players (login, password) VALUES (@login, @pass)";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT * FROM players WHERE login=@login";
                    NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
                    Account acc = new Account();
                    while (npgsqlDataReader.Read())
                    {
                        acc.login = login;
                        acc.password = password;
                        acc.player_id = npgsqlDataReader.GetInt64(2);
                        acc.SetPlayerId();
                        acc.player_name = npgsqlDataReader.GetString(3);
                        acc.name_color = npgsqlDataReader.GetInt32(4);
                        acc.clan_id = npgsqlDataReader.GetInt32(5);
                        acc._rank = npgsqlDataReader.GetInt32(6);
                        acc._gp = npgsqlDataReader.GetInt32(7);
                        acc._exp = npgsqlDataReader.GetInt32(8);
                        acc.pc_cafe = npgsqlDataReader.GetInt32(9);
                        acc._statistic.fights = npgsqlDataReader.GetInt32(10);
                        acc._statistic.fights_win = npgsqlDataReader.GetInt32(11);
                        acc._statistic.fights_lost = npgsqlDataReader.GetInt32(12);
                        acc._statistic.kills_count = npgsqlDataReader.GetInt32(13);
                        acc._statistic.deaths_count = npgsqlDataReader.GetInt32(14);
                        acc._statistic.headshots_count = npgsqlDataReader.GetInt32(15);
                        acc._statistic.escapes = npgsqlDataReader.GetInt32(16);
                        acc.access = npgsqlDataReader.GetInt32(17);
                        acc.LastRankUpDate = (uint)npgsqlDataReader.GetInt64(20);
                        acc._money = npgsqlDataReader.GetInt32(21);
                        acc._isOnline = npgsqlDataReader.GetBoolean(22);
                        acc._equip._primary = npgsqlDataReader.GetInt32(23);
                        acc._equip._secondary = npgsqlDataReader.GetInt32(24);
                        acc._equip._melee = npgsqlDataReader.GetInt32(25);
                        acc._equip._grenade = npgsqlDataReader.GetInt32(26);
                        acc._equip._special = npgsqlDataReader.GetInt32(27);
                        acc._equip._red = npgsqlDataReader.GetInt32(28);
                        acc._equip._blue = npgsqlDataReader.GetInt32(29);
                        acc._equip._helmet = npgsqlDataReader.GetInt32(30);
                        acc._equip._dino = npgsqlDataReader.GetInt32(31);
                        acc._equip._beret = npgsqlDataReader.GetInt32(32);
                        acc.brooch = npgsqlDataReader.GetInt32(33);
                        acc.insignia = npgsqlDataReader.GetInt32(34);
                        acc.medal = npgsqlDataReader.GetInt32(35);
                        acc.blue_order = npgsqlDataReader.GetInt32(36);
                        acc._mission.mission1 = npgsqlDataReader.GetInt32(37);
                        acc.clanAccess = npgsqlDataReader.GetInt32(38);
                        acc.effects = (CouponEffects)npgsqlDataReader.GetInt64(40);
                        acc._statistic.fights_draw = npgsqlDataReader.GetInt32(41);
                        acc._mission.mission2 = npgsqlDataReader.GetInt32(42);
                        acc._mission.mission3 = npgsqlDataReader.GetInt32(43);
                        acc._statistic.totalkills_count = npgsqlDataReader.GetInt32(44);
                        acc._statistic.totalfights_count = npgsqlDataReader.GetInt32(45);
                        acc._status.SetData((uint)npgsqlDataReader.GetInt64(46), acc.player_id);
                        acc.MacAddress = (PhysicalAddress)npgsqlDataReader.GetValue(50);
                        acc.ban_obj_id = npgsqlDataReader.GetInt64(51);
                        acc._tag = npgsqlDataReader.GetInt32(54);
                        acc.age = npgsqlDataReader.GetInt32(55);
                        acc.tourneyLevel = npgsqlDataReader.GetInt32(56);
                    }
                    p = acc;
                    AddAccount(acc);
                    command.Dispose();
                    npgsqlConnection.Dispose();
                    npgsqlConnection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.warning("[AccountManager.CreateAccount] " + ex.ToString());
                p = null;
                return false;
            }
        }

        public bool CreateAccount(out Account p, string Token)
        {
            try
            {
                using (NpgsqlConnection npgsqlConnection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = npgsqlConnection.CreateCommand();
                    npgsqlConnection.Open();
                    command.Parameters.AddWithValue("@login", "NONE USER");
                    command.Parameters.AddWithValue("@pass", "NONE PASSWORD");
                    command.Parameters.AddWithValue("@token", Token);
                    command.CommandText = "INSERT INTO players (login, password, token) VALUES (@login, @pass, @token)";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT * FROM players WHERE token=@token";
                    NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
                    Account acc = new Account();
                    while (npgsqlDataReader.Read())
                    {
                        acc.login = "NONE USER";
                        acc.password = "NONE PASSWORD";
                        acc.token = Token;
                        acc.player_id = npgsqlDataReader.GetInt64(2);
                        acc.SetPlayerId();
                        acc.player_name = npgsqlDataReader.GetString(3);
                        acc.name_color = npgsqlDataReader.GetInt32(4);
                        acc.clan_id = npgsqlDataReader.GetInt32(5);
                        acc._rank = npgsqlDataReader.GetInt32(6);
                        acc._gp = npgsqlDataReader.GetInt32(7);
                        acc._exp = npgsqlDataReader.GetInt32(8);
                        acc.pc_cafe = npgsqlDataReader.GetInt32(9);
                        acc._statistic.fights = npgsqlDataReader.GetInt32(10);
                        acc._statistic.fights_win = npgsqlDataReader.GetInt32(11);
                        acc._statistic.fights_lost = npgsqlDataReader.GetInt32(12);
                        acc._statistic.kills_count = npgsqlDataReader.GetInt32(13);
                        acc._statistic.deaths_count = npgsqlDataReader.GetInt32(14);
                        acc._statistic.headshots_count = npgsqlDataReader.GetInt32(15);
                        acc._statistic.escapes = npgsqlDataReader.GetInt32(16);
                        acc.access = npgsqlDataReader.GetInt32(17);
                        acc.LastRankUpDate = (uint)npgsqlDataReader.GetInt64(20);
                        acc._money = npgsqlDataReader.GetInt32(21);
                        acc._isOnline = npgsqlDataReader.GetBoolean(22);
                        acc._equip._primary = npgsqlDataReader.GetInt32(23);
                        acc._equip._secondary = npgsqlDataReader.GetInt32(24);
                        acc._equip._melee = npgsqlDataReader.GetInt32(25);
                        acc._equip._grenade = npgsqlDataReader.GetInt32(26);
                        acc._equip._special = npgsqlDataReader.GetInt32(27);
                        acc._equip._red = npgsqlDataReader.GetInt32(28);
                        acc._equip._blue = npgsqlDataReader.GetInt32(29);
                        acc._equip._helmet = npgsqlDataReader.GetInt32(30);
                        acc._equip._dino = npgsqlDataReader.GetInt32(31);
                        acc._equip._beret = npgsqlDataReader.GetInt32(32);
                        acc.brooch = npgsqlDataReader.GetInt32(33);
                        acc.insignia = npgsqlDataReader.GetInt32(34);
                        acc.medal = npgsqlDataReader.GetInt32(35);
                        acc.blue_order = npgsqlDataReader.GetInt32(36);
                        acc._mission.mission1 = npgsqlDataReader.GetInt32(37);
                        acc.clanAccess = npgsqlDataReader.GetInt32(38);
                        acc.effects = (CouponEffects)npgsqlDataReader.GetInt64(40);
                        acc._statistic.fights_draw = npgsqlDataReader.GetInt32(41);
                        acc._mission.mission2 = npgsqlDataReader.GetInt32(42);
                        acc._mission.mission3 = npgsqlDataReader.GetInt32(43);
                        acc._statistic.totalkills_count = npgsqlDataReader.GetInt32(44);
                        acc._statistic.totalfights_count = npgsqlDataReader.GetInt32(45);
                        acc._status.SetData((uint)npgsqlDataReader.GetInt64(46), acc.player_id);
                        acc.MacAddress = (PhysicalAddress)npgsqlDataReader.GetValue(50);
                        acc.ban_obj_id = npgsqlDataReader.GetInt64(51);
                        acc._tag = npgsqlDataReader.GetInt32(54);
                        acc.age = npgsqlDataReader.GetInt32(55);
                        acc.tourneyLevel = npgsqlDataReader.GetInt32(56);
                    }
                    p = acc;
                    AddAccount(acc);
                    command.Dispose();
                    npgsqlConnection.Dispose();
                    npgsqlConnection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.warning("[AccountManager.CreateAccount] " + ex.ToString());
                p = null;
                return false;
            }
        }
    }
}

/*using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Sql;
using Npgsql;
using ProjectBlackout.Auth.Data.Model;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using ProjectBlackout.Core.Managers;

namespace ProjectBlackout.Auth.Data.Managers
{
    public class AccountManager
    {
        public SortedList<long, Account> _accounts = new SortedList<long, Account>();
        private static AccountManager acm = new AccountManager();

        public bool AddAccount(Account acc)
        {
            lock (_accounts)
            {
                if (!_accounts.ContainsKey(acc.player_id))
                {
                    _accounts.Add(acc.player_id, acc);
                    return true;
                }
            }
            return false;
        }

        public Account getAccountDB(object valor, object valor2, int type, int searchFlag)
        {
            if (type == 0 && (string)valor == "" || type == 1 && (long)valor == 0 || type == 2 && (string.IsNullOrEmpty((string)valor) || string.IsNullOrEmpty((string)valor2)))
            {
                return null;
            }
            Account account = null;
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@valor", valor);
                    if (type == 0)
                    {
                        command.CommandText = "SELECT * FROM players WHERE token=@valor LIMIT 1";
                    }
                    else if (type == 1)
                    {
                        command.CommandText = "SELECT * FROM players WHERE player_id=@valor LIMIT 1";
                    }
                    else if (type == 2)
                    {
                        command.Parameters.AddWithValue("@valor2", valor2);
                        command.CommandText = "SELECT * FROM players WHERE login=@valor AND password=@valor2 LIMIT 1";
                    }
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        account = new Account();
                        account.login = data.GetString(0);
                        account.password = data.GetString(1);
                        account.SetPlayerId(data.GetInt64(2), searchFlag);
                        account.player_name = data.GetString(3);
                        account.name_color = data.GetInt32(4);
                        account.clan_id = data.GetInt32(5);
                        account._rank = data.GetInt32(6);
                        account._gp = data.GetInt32(7);
                        account._exp = data.GetInt32(8);
                        account.pc_cafe = data.GetInt32(9);
                        account._statistic.fights = data.GetInt32(10);
                        account._statistic.fights_win = data.GetInt32(11);
                        account._statistic.fights_lost = data.GetInt32(12);
                        account._statistic.kills_count = data.GetInt32(13);
                        account._statistic.deaths_count = data.GetInt32(14);
                        account._statistic.headshots_count = data.GetInt32(15);
                        account._statistic.escapes = data.GetInt32(16);
                        account.access = data.GetInt32(17);
                        account.LastRankUpDate = (uint)data.GetInt64(20);
                        account._money = data.GetInt32(21);
                        account._isOnline = data.GetBoolean(22);
                        account._equip._primary = data.GetInt32(23);
                        account._equip._secondary = data.GetInt32(24);
                        account._equip._melee = data.GetInt32(25);
                        account._equip._grenade = data.GetInt32(26);
                        account._equip._special = data.GetInt32(27);
                        account._equip._red = data.GetInt32(28);
                        account._equip._blue = data.GetInt32(29);
                        account._equip._helmet = data.GetInt32(30);
                        account._equip._dino = data.GetInt32(31);
                        account._equip._beret = data.GetInt32(32);
                        account.brooch = data.GetInt32(33);
                        account.insignia = data.GetInt32(34);
                        account.medal = data.GetInt32(35);
                        account.blue_order = data.GetInt32(36);
                        account._mission.mission1 = data.GetInt32(37);
                        account.clanAccess = data.GetInt32(38);
                        account.effects = (CouponEffects)data.GetInt64(40);
                        account._statistic.fights_draw = data.GetInt32(41);
                        account._mission.mission2 = data.GetInt32(42);
                        account._mission.mission3 = data.GetInt32(43);
                        account._statistic.totalkills_count = data.GetInt32(44);
                        account._statistic.totalfights_count = data.GetInt32(45);
                        account._status.SetData((uint)data.GetInt64(46), account.player_id);
                        account.MacAddress = (PhysicalAddress)data.GetValue(50);
                        account.ban_obj_id = data.GetInt64(51);
                        account.token = data.GetString(52);
                        account.hwid = data.GetString(53);
                        account.age = data.GetInt32(55);
                        account.tourneyLevel = data.GetInt32(56);
                        account._statistic.assist = data.GetInt32(57);
                        account._equip.face = data.GetInt32(58);
                        account._equip.jacket = data.GetInt32(59);
                        account._equip.poket = data.GetInt32(60);
                        account._equip.glove = data.GetInt32(61);
                        account._equip.belt = data.GetInt32(62);
                        account._equip.holster = data.GetInt32(63);
                        account._equip.skin = data.GetInt32(64);
                        account._equip.accessory = data.GetInt32(65);
                        account._statistic.mvp = data.GetInt32(66);

                        if (AddAccount(account) && account._isOnline)
                            account.setOnlineStatus(false);

                        if (PermissionManager.GetFakeRank(account.access) != -1)
                            account._rank = PermissionManager.GetFakeRank(account.access);
                    }
                    command.Dispose();
                    data.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error("was a problem loading accounts!\r\n" + ex.ToString());
            }
            return account;
        }

        public void getFriendlyAccounts(FriendSystem system)
        {
            if (system == null || system._friends.Count == 0)
            {
                return;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    string loaded = "";
                    List<string> parameters = new List<string>();
                    for (int idx = 0; idx < system._friends.Count; idx++)
                    {
                        Friend friend = system._friends[idx];
                        string param = "@valor" + idx;
                        command.Parameters.AddWithValue(param, friend.player_id);
                        parameters.Add(param);
                    }
                    loaded = string.Join(",", parameters.ToArray());
                    command.CommandText = "SELECT player_name, player_id, rank, online, status FROM players WHERE player_id in (" + loaded + ") ORDER BY player_id";
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        Friend friend = system.GetFriend(data.GetInt64(1));
                        if (friend != null)
                        {
                            friend.player.player_name = data.GetString(0);
                            friend.player._rank = data.GetInt32(2);
                            friend.player._isOnline = data.GetBoolean(3);
                            friend.player._status.SetData((uint)data.GetInt64(4), friend.player_id);
                            if (friend.player._isOnline && !_accounts.ContainsKey(friend.player_id))
                            {
                                friend.player.setOnlineStatus(false);
                                friend.player._status.ResetData(friend.player_id);
                            }
                        }
                    }
                    command.Dispose();
                    data.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error("was a problem loading (FriendlyAccounts)!\r\n" + ex.ToString());
            }
        }

        public void getFriendlyAccounts(FriendSystem system, bool isOnline)
        {
            if (system == null || system._friends.Count == 0)
            {
                return;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    string loaded = "";
                    List<string> parameters = new List<string>();
                    for (int idx = 0; idx < system._friends.Count; idx++)
                    {
                        Friend friend = system._friends[idx];
                        if (friend.state > 0)
                        {
                            return;
                        }
                        string param = "@valor" + idx;
                        command.Parameters.AddWithValue(param, friend.player_id);
                        parameters.Add(param);
                    }
                    loaded = string.Join(",", parameters.ToArray());
                    if (loaded == "")
                    {
                        return;
                    }
                    connection.Open();
                    command.Parameters.AddWithValue("@on", isOnline);
                    command.CommandText = "SELECT player_name, player_id, rank, status FROM players WHERE player_id in (" + loaded + ") AND online=@on ORDER BY player_id";
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        Friend friend = system.GetFriend(data.GetInt64(1));
                        if (friend != null)
                        {
                            friend.player.player_name = data.GetString(0);
                            friend.player._rank = data.GetInt32(2);
                            friend.player._isOnline = isOnline;
                            friend.player._status.SetData((uint)data.GetInt64(3), friend.player_id);
                            if (isOnline && !_accounts.ContainsKey(friend.player_id))
                            {
                                friend.player.setOnlineStatus(false);
                                friend.player._status.ResetData(friend.player_id);
                            }
                        }
                    }
                    command.Dispose();
                    data.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error("was a problem loading (FriendAccounts2)!\r\n" + ex.ToString());
            }
        }

        static AccountManager()
        {

        }

        public static AccountManager getInstance()
        {
            return acm;
        }

        public Account getAccount(long id)
        {
            if (id == 0)
            {
                return null;
            }
            try
            {
                Account p = null;
                return _accounts.TryGetValue(id, out p) ? p : getAccountDB(id, null, 1, 0);
            }
            catch
            {
                return null;
            }
        }

        public Account getAccount(long id, bool noUseDB)
        {
            if (id == 0)
            {
                return null;
            }
            try
            {
                Account p = null;
                return _accounts.TryGetValue(id, out p) ? p : (noUseDB ? null : getAccountDB(id, null, 1, 0));
            }
            catch
            {
                return null;
            }
        }

        public bool CreateAccount(out Account p, string login, string password)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@pass", password);
                    command.CommandText = "INSERT INTO players (login, password) VALUES (@login, @pass)";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT * FROM players WHERE login=@login";
                    NpgsqlDataReader data = command.ExecuteReader();
                    Account acc = new Account();
                    while (data.Read())
                    {
                        acc.login = login;
                        acc.password = password;
                        acc.player_id = data.GetInt64(2);
                        acc.SetPlayerId();
                        acc.player_name = data.GetString(3);
                        acc.name_color = data.GetInt32(4);
                        acc.clan_id = data.GetInt32(5);
                        acc._rank = data.GetInt32(6);
                        acc._gp = data.GetInt32(7);
                        acc._exp = data.GetInt32(8);
                        acc.pc_cafe = data.GetInt32(9);
                        acc._statistic.fights = data.GetInt32(10);
                        acc._statistic.fights_win = data.GetInt32(11);
                        acc._statistic.fights_lost = data.GetInt32(12);
                        acc._statistic.kills_count = data.GetInt32(13);
                        acc._statistic.deaths_count = data.GetInt32(14);
                        acc._statistic.headshots_count = data.GetInt32(15);
                        acc._statistic.escapes = data.GetInt32(16);
                        acc.access = data.GetInt32(17);
                        acc.LastRankUpDate = (uint)data.GetInt64(20);
                        acc._money = data.GetInt32(21);
                        acc._isOnline = data.GetBoolean(22);
                        acc._equip._primary = data.GetInt32(23);
                        acc._equip._secondary = data.GetInt32(24);
                        acc._equip._melee = data.GetInt32(25);
                        acc._equip._grenade = data.GetInt32(26);
                        acc._equip._special = data.GetInt32(27);
                        acc._equip._red = data.GetInt32(28);
                        acc._equip._blue = data.GetInt32(29);
                        acc._equip._helmet = data.GetInt32(30);
                        acc._equip._dino = data.GetInt32(31);
                        acc._equip._beret = data.GetInt32(32);
                        acc.brooch = data.GetInt32(33);
                        acc.insignia = data.GetInt32(34);
                        acc.medal = data.GetInt32(35);
                        acc.blue_order = data.GetInt32(36);
                        acc._mission.mission1 = data.GetInt32(37);
                        acc.clanAccess = data.GetInt32(38);
                        acc.effects = (CouponEffects)data.GetInt64(40);
                        acc._statistic.fights_draw = data.GetInt32(41);
                        acc._mission.mission2 = data.GetInt32(42);
                        acc._mission.mission3 = data.GetInt32(43);
                        acc._statistic.totalkills_count = data.GetInt32(44);
                        acc._statistic.totalfights_count = data.GetInt32(45);
                        acc._status.SetData((uint)data.GetInt64(46), acc.player_id);
                        acc.MacAddress = (PhysicalAddress)data.GetValue(50);
                        acc.ban_obj_id = data.GetInt64(51);
                        acc.age = data.GetInt32(55);
                        acc.tourneyLevel = data.GetInt32(56);
                        acc._statistic.mvp = data.GetInt32(66);
                    }
                    p = acc;
                    AddAccount(acc);
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.warning("[AccountManager.CreateAccount] "+ ex.ToString());
                p = null;
                return false;
            }
        }

        public bool CreateAccount(out Account p, string Token)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@login", "NONE USER");
                    command.Parameters.AddWithValue("@pass", "NONE PASSWORD");
                    command.Parameters.AddWithValue("@token", Token);
                    command.CommandText = "INSERT INTO players (login, password, token) VALUES (@login, @pass, @token)";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT * FROM players WHERE token=@token";
                    NpgsqlDataReader data = command.ExecuteReader();
                    Account acc = new Account();
                    while (data.Read())
                    {
                        acc.login = "NONE USER";
                        acc.password = "NONE PASSWORD";
                        acc.token = Token;
                        acc.player_id = data.GetInt64(2);
                        acc.SetPlayerId();
                        acc.player_name = data.GetString(3);
                        acc.name_color = data.GetInt32(4);
                        acc.clan_id = data.GetInt32(5);
                        acc._rank = data.GetInt32(6);
                        acc._gp = data.GetInt32(7);
                        acc._exp = data.GetInt32(8);
                        acc.pc_cafe = data.GetInt32(9);
                        acc._statistic.fights = data.GetInt32(10);
                        acc._statistic.fights_win = data.GetInt32(11);
                        acc._statistic.fights_lost = data.GetInt32(12);
                        acc._statistic.kills_count = data.GetInt32(13);
                        acc._statistic.deaths_count = data.GetInt32(14);
                        acc._statistic.headshots_count = data.GetInt32(15);
                        acc._statistic.escapes = data.GetInt32(16);
                        acc.access = data.GetInt32(17);
                        acc.LastRankUpDate = (uint)data.GetInt64(20);
                        acc._money = data.GetInt32(21);
                        acc._isOnline = data.GetBoolean(22);
                        acc._equip._primary = data.GetInt32(23);
                        acc._equip._secondary = data.GetInt32(24);
                        acc._equip._melee = data.GetInt32(25);
                        acc._equip._grenade = data.GetInt32(26);
                        acc._equip._special = data.GetInt32(27);
                        acc._equip._red = data.GetInt32(28);
                        acc._equip._blue = data.GetInt32(29);
                        acc._equip._helmet = data.GetInt32(30);
                        acc._equip._dino = data.GetInt32(31);
                        acc._equip._beret = data.GetInt32(32);
                        acc.brooch = data.GetInt32(33);
                        acc.insignia = data.GetInt32(34);
                        acc.medal = data.GetInt32(35);
                        acc.blue_order = data.GetInt32(36);
                        acc._mission.mission1 = data.GetInt32(37);
                        acc.clanAccess = data.GetInt32(38);
                        acc.effects = (CouponEffects)data.GetInt64(40);
                        acc._statistic.fights_draw = data.GetInt32(41);
                        acc._mission.mission2 = data.GetInt32(42);
                        acc._mission.mission3 = data.GetInt32(43);
                        acc._statistic.totalkills_count = data.GetInt32(44);
                        acc._statistic.totalfights_count = data.GetInt32(45);
                        acc._status.SetData((uint)data.GetInt64(46), acc.player_id);
                        acc.MacAddress = (PhysicalAddress)data.GetValue(50);
                        acc.ban_obj_id = data.GetInt64(51);
                        acc.age = data.GetInt32(55);
                        acc.tourneyLevel = data.GetInt32(56);
                        acc._statistic.mvp = data.GetInt32(66);
                    }
                    p = acc;
                    AddAccount(acc);
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.warning("[AccountManager.CreateAccount] " + ex.ToString());
                p = null;
                return false;
            }
        }
    }
}*/