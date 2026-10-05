using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using ProjectBlackout.Core.Models.Shop;
using System.ComponentModel;
using System.Data.Common;

namespace ProjectBlackout.Core.Managers
{
    public static class PlayerManager
    {
        public static void updatePlayerBonus(long pId, int bonuses, int freepass)
        {
            if (pId == 0)
            {
                return;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", pId);
                    command.Parameters.AddWithValue("@bonuses", bonuses);
                    command.Parameters.AddWithValue("@freepass", freepass);
                    command.CommandText = "UPDATE player_bonus SET bonuses=@bonuses, freepass=@freepass WHERE player_id=@id";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public static void updateCupomEffects(long id, CouponEffects effects)
        {
            if (id == 0)
            {
                return;
            }
            ComDiv.updateDB("players", "effects", (long)effects, "player_id", id);
        }

        public static PlayerBonus getPlayerBonusDB(long id)
        {
            PlayerBonus c = new PlayerBonus();
            if (id == 0)
            {
                return c;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandText = "SELECT * FROM player_bonus WHERE player_id=@id";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        c.ownerId = id;
                        c.bonuses = data.GetInt32(1);
                        c.sightColor = data.GetInt32(2);
                        c.freepass = data.GetInt32(3);
                        c.fakeRank = data.GetInt32(4);
                        c.fakeNick = data.GetString(5);
                        c.muzzle = data.GetInt32(6);
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
            return c;
        }

        public static PlayerDailyRecord getPlayerDailyRecord(long PlayerId)
        {
            PlayerDailyRecord Daily = null;
            if (PlayerId == 0)
            {
                return null;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@PlayerId", PlayerId);
                    command.CommandText = "SELECT * FROM player_dailyrecord WHERE player_id=@PlayerId";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        Daily = new PlayerDailyRecord();
                        Daily.PlayerId = PlayerId;
                        Daily.Total = data.GetInt32(1);
                        Daily.Wins = data.GetInt32(2);
                        Daily.Loses = data.GetInt32(3);
                        Daily.Draws = data.GetInt32(4);
                        Daily.Kills = data.GetInt32(5);
                        Daily.Deaths = data.GetInt32(6);
                        Daily.Headshots = data.GetInt32(7);
                        Daily.Point = data.GetInt32(8);
                        Daily.Exp = data.GetInt32(9);
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
                return null;
            }
            return Daily;
        }

        public static bool DeletePlayerTopup(long ObjectId, long PlayerId)
        {
            if (ObjectId == 0 || PlayerId == 0)
            {
                return false;
            }
            return ComDiv.deleteDB("player_topups", "object_id", ObjectId, "player_id", PlayerId);
        }

        public static void CreatePlayerDailyRecord(long id)
        {
            if (id == 0)
            {
                return;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandText = "INSERT INTO player_dailyrecord(player_id)VALUES(@id)";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public static void CreatePlayerBonusDB(long id)
        {
            if (id == 0)
            {
                return;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandText = "INSERT INTO player_bonus(player_id)VALUES(@id)";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public static bool DeleteItem(long objId, long ownerId)
        {
            if (objId == 0 || ownerId == 0)
            {
                return false;
            }
            return ComDiv.deleteDB("player_items", "object_id", objId, "owner_id", ownerId);
        }

        public static int CheckEquipedItems(PlayerEquipedItems items, List<ItemsModel> inventory, bool BattleRules = false)
        {
            int type = 0;
            bool w1 = false, w2 = false, w3 = false, w4 = false, w5 = false, c1 = false, c2 = false, c3 = false, c4 = false, c5 = false;
            if (items._primary == 0)
            {
                w1 = true;
            }
            if (BattleRules)
            {
                if (!w1)
                {
                    if (items._primary == 105025 || //SSG-69 (IN MODE)
                        items._primary == 106007)   //870MCS (IN MODE)
                    {
                        w1 = true;
                    }
                }
                if (!w3)
                {
                    if (items._melee == 323001) //Barefist (IN MODE)
                    {
                        w3 = true;
                    }
                }
            }
            if (items._beret == 0)
            {
                c4 = true;
            }
            lock (inventory)
            {
                foreach (ItemsModel item in inventory)
                {
                    if (item._count > 0)
                    {
                        if (item._id == items._primary) w1 = true;
                        else if (item._id == items._secondary) w2 = true;
                        else if (item._id == items._melee) w3 = true;
                        else if (item._id == items._grenade) w4 = true;
                        else if (item._id == items._special) w5 = true;
                        else if (item._id == items._red) c1 = true;
                        else if (item._id == items._blue) c2 = true;
                        else if (item._id == items._helmet) c3 = true;
                        else if (item._id == items._beret) c4 = true;
                        else if (item._id == items._dino) c5 = true;
                        if (w1 && w2 && w3 && w4 && w5 &&
                            c1 && c2 && c3 && c4 && c5)
                            break;
                    }
                }
            }
            if (!w1 || !w2 || !w3 || !w4 || !w5)
                type += 2;
            if (!c1 || !c2 || !c3 || !c4 || !c5)
                type++;
            if (!w1) items._primary = 103004;
            if (!w2) items._secondary = 202003;
            if (!w3) items._melee = 301001;
            if (!w4) items._grenade = 407001;
            if (!w5) items._special = 508001;
            if (!c1) items._red = 601001;
            if (!c2) items._blue = 602002;
            if (!c3) items._helmet = 1000800000;
            if (!c4) items._beret = 0;
            if (!c5) items._dino = 1500511;
            return type;
        }

        public static void updateWeapons(PlayerEquipedItems source, PlayerEquipedItems items, DBQuery query)
        {
            if (items._primary != source._primary) query.AddQuery("weapon_primary", source._primary);
            if (items._secondary != source._secondary) query.AddQuery("weapon_secondary", source._secondary);
            if (items._melee != source._melee) query.AddQuery("weapon_melee", source._melee);
            if (items._grenade != source._grenade) query.AddQuery("weapon_thrown_normal", source._grenade);
            if (items._special != source._special) query.AddQuery("weapon_thrown_special", source._special);
        }

        public static void updateChars(PlayerEquipedItems source, PlayerEquipedItems items, DBQuery query)
        {
            if (items._red != source._red) query.AddQuery("char_red", source._red);
            if (items._blue != source._blue) query.AddQuery("char_blue", source._blue);
            if (items._helmet != source._helmet) query.AddQuery("char_helmet", source._helmet);
            if (items._beret != source._beret) query.AddQuery("char_beret", source._beret);
            if (items._dino != source._dino) query.AddQuery("char_dino", source._dino);
            if (items.face != source.face) query.AddQuery("face", source.face);
            if (items.jacket != source.jacket) query.AddQuery("jacket", source.jacket);
            if (items.poket != source.poket) query.AddQuery("poket", source.poket);
            if (items.glove != source.glove) query.AddQuery("glove", source.glove);
            if (items.belt != source.belt) query.AddQuery("belt", source.belt);
            if (items.holster != source.holster) query.AddQuery("holster", source.holster);
            if (items.skin != source.skin) query.AddQuery("skin", source.skin);
        }

        public static void updateCharSlots(PlayerEquipedItems source, PlayerEquipedItems items, DBQuery query)
        {
            if (items._red != source._red) query.AddQuery("char_red", source._red);
            if (items._blue != source._blue) query.AddQuery("char_blue", source._blue);
            if (items._dino != source._dino) query.AddQuery("char_dino", source._dino);
        }

        public static void updateWeapons(PlayerEquipedItems items, DBQuery query)
        {
            query.AddQuery("weapon_primary", items._primary);
            query.AddQuery("weapon_secondary", items._secondary);
            query.AddQuery("weapon_melee", items._melee);
            query.AddQuery("weapon_thrown_normal", items._grenade);
            query.AddQuery("weapon_thrown_special", items._special);
        }

        public static void updateChars(PlayerEquipedItems items, DBQuery query)
        {
            query.AddQuery("char_red", items._red);
            query.AddQuery("char_blue", items._blue);
            query.AddQuery("char_helmet", items._helmet);
            query.AddQuery("char_beret", items._beret);
            query.AddQuery("char_dino", items._dino);
            query.AddQuery("face", items.face);
            query.AddQuery("jacket", items.jacket);
            query.AddQuery("poket", items.poket);
            query.AddQuery("glove", items.glove);
            query.AddQuery("belt", items.belt);
            query.AddQuery("holster", items.holster);
            query.AddQuery("skin", items.skin);
        }

        public static bool updateFights(int partidas, int partidas_ganhas, int partidas_perdidas, int partidas_empatadas, int todas, long id)
        {
            if (id == 0)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@owner", id);
                    command.Parameters.AddWithValue("@partidas", partidas);
                    command.Parameters.AddWithValue("@ganhas", partidas_ganhas);
                    command.Parameters.AddWithValue("@perdidas", partidas_perdidas);
                    command.Parameters.AddWithValue("@empates", partidas_empatadas);
                    command.Parameters.AddWithValue("@todaspartidas", todas);
                    command.CommandText = "UPDATE players SET fights=@partidas, fights_win=@ganhas, fights_lost=@perdidas, fights_draw=@empates, totalfights_count=@todaspartidas WHERE player_id=@owner";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static bool updateAccountCashing(long player_id, int gold, int cash)
        {
            if (player_id == 0 || gold == -1)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@owner", player_id);
                    string cmd = "";
                    if (gold > -1)
                    {
                        command.Parameters.AddWithValue("@gold", gold);
                        cmd += "gp=@gold";
                    }
                    if (cash > -1)
                    {
                        command.Parameters.AddWithValue("@cash", cash);
                        cmd += (cmd != "" ? ", " : "") + "money=@cash";
                    }
                    command.CommandText = "UPDATE players SET " + cmd + " WHERE player_id=@owner";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static bool updateAccountCash(long player_id, int cash)
        {
            if (player_id == 0 || cash == -1)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@owner", player_id);
                    command.Parameters.AddWithValue("@cash", cash);
                    command.CommandText = "UPDATE players SET money=@cash WHERE player_id=@owner";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static bool updateAccountTag(long player_id, int tag) //int tag
        {
            if (player_id == 0L || tag == -1)
                return false;
            try
            {
                using (NpgsqlConnection npgsqlConnection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = npgsqlConnection.CreateCommand();
                    ((DbConnection)npgsqlConnection).Open();
                    ((DbCommand)command).CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@owner", (object)player_id);
                    command.Parameters.AddWithValue("@tag", (object)tag);
                    ((DbCommand)command).CommandText = "UPDATE players SET tag=@tag WHERE player_id=@owner";
                    ((DbCommand)command).ExecuteNonQuery();
                    ((Component)command).Dispose();
                    ((Component)npgsqlConnection).Dispose();
                    ((DbConnection)npgsqlConnection).Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static bool updateAccountAccess(long player_id, int Vip)
        {
            if (player_id == 0 || Vip == -1)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@owner", player_id);
                    command.Parameters.AddWithValue("@access_level", Vip);
                    command.CommandText = "UPDATE players SET access_level=@access_level WHERE player_id=@owner";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static bool updateAccountVip(long player_id, int Vip)
        {
            if (player_id == 0 || Vip == -1)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@owner", player_id);
                    command.Parameters.AddWithValue("@pc_cafe", Vip);
                    command.CommandText = "UPDATE players SET pc_cafe=@pc_cafe WHERE player_id=@owner";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static bool updateAccountGold(long player_id, int gold)
        {
            if (player_id == 0 || gold == -1)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@owner", player_id);
                    command.Parameters.AddWithValue("@gold", gold);
                    command.CommandText = "UPDATE players SET gp=@gold WHERE player_id=@owner";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static bool updateKD(long player_id, int kills, int death, int hs, int total)
        {
            if (player_id == 0)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@owner", player_id);
                    command.Parameters.AddWithValue("@deaths", death);
                    command.Parameters.AddWithValue("@kills", kills);
                    command.Parameters.AddWithValue("@hs", hs);
                    command.Parameters.AddWithValue("@total", total);
                    command.CommandText = "UPDATE players SET kills_count=@kills, deaths_count=@deaths, headshots_count=@hs, totalkills_count=@total WHERE player_id=@owner";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool updateMissionId(long player_id, int value, int index)
        {
            return ComDiv.updateDB("players", "mission_id" + (index + 1), value, "player_id", player_id);
        }

        public static bool isPlayerNameExist(string name)
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
                    command.CommandText = "SELECT COUNT(*) FROM players WHERE player_name=@name";
                    value = Convert.ToInt32(command.ExecuteScalar());
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return value > 0;
            }
            catch
            {
                return true;
            }
        }

        public static bool DeleteFriend(long friendId, long pId)
        {
            return ComDiv.deleteDB("player_friends", "friend_id", friendId, "owner_id", pId);
        }

        public static void UpdateFriendState(long ownerId, Friend friend)
        {
            ComDiv.updateDB("player_friends", "state", friend.state, "owner_id", ownerId, "friend_id", friend.player_id);
        }

        public static void UpdateFriendBlock(long ownerId, Friend friend)
        {
            ComDiv.updateDB("player_friends", "removed", friend.removed, "owner_id", ownerId, "friend_id", friend.player_id);
        }

        public static List<Friend> getFriendList(long ownerId)
        {
            List<Friend> friends = new List<Friend>();
            if (ownerId == 0)
            {
                return friends;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@owner", ownerId);
                    command.CommandText = "SELECT * FROM player_friends WHERE owner_id=@owner ORDER BY friend_id";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        friends.Add(new Friend(data.GetInt64(1))
                        {
                            state = data.GetInt32(2),
                            removed = data.GetBoolean(3)
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
            return friends;
        }

        public static bool CreateItem(ItemsModel item, long playerId)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@owner", playerId);
                    command.Parameters.AddWithValue("@itmId", item._id);
                    command.Parameters.AddWithValue("@ItmNm", item._name);
                    command.Parameters.AddWithValue("@count", item._count);
                    command.Parameters.AddWithValue("@equip", item._equip);
                    command.Parameters.AddWithValue("@category", item._category);
                    command.CommandText = "INSERT INTO player_items(owner_id,item_id,item_name,count,equip,category)VALUES(@owner,@itmId,@ItmNm,@count,@equip,@category) RETURNING object_id";
                    object data = command.ExecuteScalar();
                    item._objId = (long)data;
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
                return false;
            }
        }

        public static bool CreateClan(out int clanId, string name, long ownerId, string clan_info, int date)
        {
            try
            {
                clanId = -1;
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@owner", ownerId);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@info", clan_info);
                    command.Parameters.AddWithValue("@best", "0-0");
                    command.CommandText = "INSERT INTO clans(clan_name,owner_id,create_date,clan_info,best_exp,best_participation,best_wins,best_kills,best_headshot)VALUES(@name,@owner,@date,@info,@best,@best,@best,@best,@best) RETURNING clan_id";
                    object data = command.ExecuteScalar();
                    clanId = (int)data;
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                clanId = -1;
                return false;
            }
        }

        public static bool updateClanInfo(int clan_id, int autoridade, int limite_rank, int limite_idade, int limite_idade2)
        {
            if (clan_id == 0)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@clan", clan_id);
                    command.Parameters.AddWithValue("@autoridade", autoridade);
                    command.Parameters.AddWithValue("@limite_rank", limite_rank);
                    command.Parameters.AddWithValue("@limite_idade", limite_idade);
                    command.Parameters.AddWithValue("@limite_idade2", limite_idade2);
                    command.CommandText = "UPDATE clans SET autoridade=@autoridade, limite_rank=@limite_rank, limite_idade=@limite_idade, limite_idade2=@limite_idade2 WHERE clan_id=@clan";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static bool updateClanLogo(int clan_id, uint logo)
        {
            if (clan_id == 0)
            {
                return false;
            }
            return ComDiv.updateDB("clans", "logo", (long)logo, "clan_id", clan_id);
        }

        public static bool updateClanPoints(int clan_id, float pontos)
        {
            if (clan_id == 0)
            {
                return false;
            }
            return ComDiv.updateDB("clans", "pontos", pontos, "clan_id", clan_id);
        }

        public static bool updateClanExp(int clan_id, int exp)
        {
            if (clan_id == 0)
            {
                return false;
            }
            return ComDiv.updateDB("clans", "clan_exp", exp, "clan_id", clan_id);
        }

        public static bool updateClanRank(int clan_id, int rank)
        {
            if (clan_id == 0)
            {
                return false;
            }
            return ComDiv.updateDB("clans", "clan_rank", rank, "clan_id", clan_id);
        }

        public static bool updateClanBattles(int clan_id, int partidas, int vitorias, int derrotas)
        {
            if (clan_id == 0)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@clan", clan_id);
                    command.Parameters.AddWithValue("@partidas", partidas);
                    command.Parameters.AddWithValue("@vitorias", vitorias);
                    command.Parameters.AddWithValue("@derrotas", derrotas);
                    command.CommandText = "UPDATE clans SET partidas=@partidas, vitorias=@vitorias, derrotas=@derrotas WHERE clan_id=@clan";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static int getClanPlayers(int clanId)
        {
            int players = 0;
            if (clanId == 0)
            {
                return players;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@clan", clanId);
                    command.CommandText = "SELECT COUNT(*) FROM players WHERE clan_id=@clan";
                    players = Convert.ToInt32(command.ExecuteScalar());
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
            return players;
        }

        public static List<ItemsModel> getInventoryItems(long player_id)
        {
            List<ItemsModel> items = new List<ItemsModel>();
            if (player_id == 0)
            {
                return items;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@owner", player_id);
                    command.CommandText = "SELECT * FROM player_items WHERE owner_id=@owner ORDER BY object_id ASC;";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        items.Add(new ItemsModel(data.GetInt32(2), data.GetInt32(5), data.GetString(3), data.GetInt32(6), data.GetInt64(4), data.GetInt64(0)));
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
            return items;
        }

        public static bool CheckWeaponPermanent(int ItemId)
        {
            foreach (ItemRepair Item in ShopManager.ItemRepairs)
            {
                if (ItemId == Item.ItemId)
                {
                    return false;
                }
            }
            return true;
        }

        public static void tryCreateItem(ItemsModel modelo, PlayerInventory inventory, long pId)
        {
            try
            {
                ItemsModel iv = inventory.getItem(modelo._id);
                if (iv == null)
                {
                    if (CreateItem(modelo, pId))
                    {
                        inventory.AddItem(modelo);
                    }
                }
                else
                {
                    modelo._objId = iv._objId;
                    if (iv._equip == 1)
                    {
                        if (CheckWeaponPermanent(modelo._id))
                        {
                            modelo._count += iv._count;
                            ComDiv.updateDB("player_items", "count", modelo._count, "owner_id", pId, "item_id", modelo._id);
                        }
                        else
                        {
                            modelo._count = 100;
                            ComDiv.updateDB("player_items", "count", modelo._count, "owner_id", pId, "item_id", modelo._id);
                        }
                    }
                    else if (iv._equip == 2)
                    {
                        DateTime data = DateTime.ParseExact(iv._count.ToString(), "yyMMddHHmm", CultureInfo.InvariantCulture);
                        if (modelo._category != 3)
                        {
                            modelo._equip = 2;
                            modelo._count = Convert.ToInt64(data.AddSeconds(modelo._count).ToString("yyMMddHHmm"));
                        }
                        else
                        {
                            TimeSpan Time = (DateTime.ParseExact(modelo._count.ToString(), "yyMMddHHmm", CultureInfo.InvariantCulture) - DateTime.Now);
                            modelo._equip = 2;
                            modelo._count = Convert.ToInt64(data.AddDays(Time.TotalDays).ToString("yyMMddHHmm"));
                        }
                        ComDiv.updateDB("player_items", "count", modelo._count, "owner_id", pId, "item_id", modelo._id);
                    }
                    iv._equip = modelo._equip;
                    iv._count = modelo._count;
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public static PlayerConfig getConfigDB(long playerId)
        {
            PlayerConfig config = null;
            if (playerId == 0)
            {
                return null;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@owner", playerId);
                    command.CommandText = "SELECT * FROM player_configs WHERE owner_id=@owner";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        config = new PlayerConfig
                        {
                            config = data.GetInt32(1),
                            blood = data.GetInt32(2),
                            sight = data.GetInt32(3),
                            hand = data.GetInt32(4),
                            audio1 = data.GetInt32(5),
                            audio2 = data.GetInt32(6),
                            audio_enable = data.GetInt32(7),
                            sensibilidade = data.GetInt32(8),
                            fov = data.GetInt32(9),
                            mouse_invertido = data.GetInt32(10),
                            msgConvite = data.GetInt32(11),
                            chatSussurro = data.GetInt32(12),
                            macro = data.GetInt32(13),
                            macro_1 = data.GetString(14),
                            macro_2 = data.GetString(15),
                            macro_3 = data.GetString(16),
                            macro_4 = data.GetString(17),
                            macro_5 = data.GetString(18)
                        };
                        data.GetBytes(19, 0, config.keys, 0, 235);
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
                return config;
            }
            catch (Exception ex)
            {
                Logger.error("Ocorreu um problema ao carregar as configurações!\r\n" + ex.ToString());
                return null;
            }
        }

        public static bool CreateConfigDB(long player_id)
        {
            if (player_id == 0)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand cmd = connection.CreateCommand();
                    connection.Open();
                    cmd.Parameters.AddWithValue("@owner", player_id);
                    cmd.CommandText = "INSERT INTO player_configs (owner_id) VALUES (@owner)";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Dispose();
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static void updateConfigs(DBQuery query, PlayerConfig config)
        {
            query.AddQuery("mira", config.sight);
            query.AddQuery("audio1", config.audio1);
            query.AddQuery("audio2", config.audio2);
            query.AddQuery("sensibilidade", config.sensibilidade);
            query.AddQuery("sangue", config.blood);
            query.AddQuery("visao", config.fov);
            query.AddQuery("mao", config.hand);
            query.AddQuery("audio_enable", config.audio_enable);
            query.AddQuery("config", config.config);
            query.AddQuery("mouse_invertido", config.mouse_invertido);
            query.AddQuery("msgconvite", config.msgConvite);
            query.AddQuery("chatsussurro", config.chatSussurro);
            query.AddQuery("macro", config.macro);
        }

        public static void updateMacros(DBQuery query, PlayerConfig config, int value)
        {
            if ((value & 1) == 1)
            {
                query.AddQuery("macro_1", config.macro_1);
            }
            if ((value & 2) == 2)
            {
                query.AddQuery("macro_2", config.macro_2);
            }
            if ((value & 4) == 4)
            {
                query.AddQuery("macro_3", config.macro_3);
            }
            if ((value & 8) == 8)
            {
                query.AddQuery("macro_4", config.macro_4);
            }
            if ((value & 16) == 16)
            {
                query.AddQuery("macro_5", config.macro_5);
            }
        }

        public static PlayerEvent getPlayerEventDB(long pId)
        {
            PlayerEvent events = null;
            if (pId == 0)
            {
                return null;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@id", pId);
                    command.CommandText = "SELECT * FROM player_events WHERE player_id=@id";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        events = new PlayerEvent
                        {
                            LastVisitEventId = data.GetInt32(1),
                            LastVisitSequence1 = data.GetInt32(2),
                            LastVisitSequence2 = data.GetInt32(3),
                            NextVisitDate = data.GetInt32(4),
                            LastXmasRewardDate = (uint)data.GetInt64(5),
                            LastPlaytimeDate = (uint)data.GetInt64(6),
                            LastPlaytimeValue = data.GetInt64(7),
                            LastPlaytimeFinish = data.GetInt32(8),
                            LastLoginDate = (uint)data.GetInt64(9),
                            LastQuestDate = (uint)data.GetInt64(10),
                            LastQuestFinish = data.GetInt32(11)
                        };
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
                return events;
            }
            catch (Exception ex)
            {
                Logger.error("Ocorreu um problema ao carregar os eventos!\r\n" + ex.ToString());
                return null;
            }
        }

        public static void addEventDB(long pId)
        {
            if (pId == 0)
            {
                return;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand cmd = connection.CreateCommand();
                    connection.Open();
                    cmd.Parameters.AddWithValue("@id", pId);
                    cmd.CommandText = "INSERT INTO player_events (player_id) VALUES (@id)";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public static List<ClanInvite> getClanRequestList(int clan_id)
        {
            List<ClanInvite> invites = new List<ClanInvite>();
            if (clan_id == 0)
            {
                return invites;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@clan", clan_id);
                    command.CommandText = "SELECT * FROM clan_invites WHERE clan_id=@clan";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        invites.Add(new ClanInvite
                        {
                            clan_id = clan_id,
                            player_id = data.GetInt64(1),
                            inviteDate = data.GetInt32(2),
                            text = data.GetString(3)
                        });
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
            return invites;
        }

        public static int getRequestCount(int clanId)
        {
            int count = 0;
            if (clanId == 0)
            {
                return count;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@clan", clanId);
                    command.CommandText = "SELECT COUNT(*) FROM clan_invites WHERE clan_id=@clan";
                    count = Convert.ToInt32(command.ExecuteScalar());
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return count;
        }

        public static int getRequestClanId(long player_id)
        {
            int resultado = 0;
            if (player_id == 0)
            {
                return resultado;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@owner", player_id);
                    command.CommandText = "SELECT clan_id FROM clan_invites WHERE player_id=@owner";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    if (data.Read())
                    {
                        resultado = data.GetInt32(0);
                    }
                    command.Dispose();
                    data.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
            return resultado;
        }

        public static string getRequestText(int clan_id, long player_id)
        {
            if (clan_id == 0 || player_id == 0)
            {
                return null;
            }
            try
            {
                string resultado = null;
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@clan", clan_id);
                    command.Parameters.AddWithValue("@player", player_id);
                    command.CommandText = "SELECT text FROM clan_invites WHERE clan_id=@clan AND player_id=@player";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    if (data.Read())
                    {
                        resultado = data.GetString(0);
                    }
                    command.Dispose();
                    data.Close();
                    connection.Close();
                }
                return resultado;
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteInviteDb(int clanId, long pId)
        {
            if (pId == 0 || clanId == 0)
            {
                return false;
            }
            return ComDiv.deleteDB("clan_invites", "clan_id", clanId, "player_id", pId);
        }

        public static bool DeleteInviteDb(long pId)
        {
            if (pId == 0)
            {
                return false;
            }
            return ComDiv.deleteDB("clan_invites", "player_id", pId);
        }

        public static bool CreateInviteInDb(ClanInvite invite)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@clan", invite.clan_id);
                    command.Parameters.AddWithValue("@player", invite.player_id);
                    command.Parameters.AddWithValue("@date", invite.inviteDate);
                    command.Parameters.AddWithValue("@text", invite.text);
                    command.CommandText = "INSERT INTO clan_invites(clan_id, player_id, dateInvite, text)VALUES(@clan,@player,@date,@text)";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void updateBestPlayers(Clan clan)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@id", clan._id);
                    command.Parameters.AddWithValue("@bp1", clan.BestPlayers.Exp.GetSplit());
                    command.Parameters.AddWithValue("@bp2", clan.BestPlayers.Participation.GetSplit());
                    command.Parameters.AddWithValue("@bp3", clan.BestPlayers.Wins.GetSplit());
                    command.Parameters.AddWithValue("@bp4", clan.BestPlayers.Kills.GetSplit());
                    command.Parameters.AddWithValue("@bp5", clan.BestPlayers.Headshot.GetSplit());
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE clans SET best_exp=@bp1, best_participation=@bp2, best_wins=@bp3, best_kills=@bp4, best_headshot=@bp5 WHERE clan_id=@id";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public static int getClanIdByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return 0;
            }
            int clanId = 0;
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@name", name);
                    command.CommandText = "SELECT clan_id FROM clans WHERE clan_name=@name";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        clanId = data.GetInt32(0);
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
            return clanId;
        }
    }
}