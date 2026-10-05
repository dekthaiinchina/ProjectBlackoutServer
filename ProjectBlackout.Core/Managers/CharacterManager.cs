using Npgsql;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Core.Managers
{
    public class CharacterManager
    {
        public static List<Character> getCharacters(long PlayerId)
        {
            if (PlayerId == 0)
            {
                return null;
            }
            List<Character> List = new List<Character>();
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@PlayerId", PlayerId);
                    command.CommandText = "SELECT * FROM player_characters WHERE player_id=@PlayerId ORDER BY slot ASC;";
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        Character Character = new Character();
                        Character.ObjId = data.GetInt64(0);
                        Character.Id = data.GetInt32(2);
                        Character.Slot = data.GetInt32(3);
                        Character.Name = data.GetString(4);
                        Character.CreateDate = data.GetInt32(5);
                        Character.PlayTime = data.GetInt32(6);
                        List.Add(Character);
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
                Logger.error("was a problem Loading (Character)!\r\n" + ex.ToString());
            }
            return List;
        }

        public static bool Create(Character Model, long PlayerId)
        {
            if (PlayerId == 0)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@player_id", PlayerId);
                    command.Parameters.AddWithValue("@id", Model.Id);
                    command.Parameters.AddWithValue("@slot", Model.Slot);
                    command.Parameters.AddWithValue("@name", Model.Name);
                    command.Parameters.AddWithValue("@createdate", Model.CreateDate);
                    command.Parameters.AddWithValue("@playtime", Model.PlayTime);
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO player_characters(player_id, id, slot, name, createdate, playtime)VALUES(@player_id, @id, @slot, @name, @createdate, @playtime) RETURNING object_id";
                    object Data = command.ExecuteScalar();
                    Model.ObjId = (long)Data;
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.error("was a problem Create (Characater)!\r\n" + ex.ToString());
                return false;
            }
        }

        public static bool Delete(long ObjectId, long PlayerId)
        {
            if (ObjectId == 0 || PlayerId == 0)
            {
                return false;
            }
            return ComDiv.deleteDB("player_characters", "object_id", ObjectId, "player_id", PlayerId);
        }

        public static void Update(int Slot, long ObjectId)
        {
            if (ObjectId == 0)
            {
                return;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@ObjectId", ObjectId);
                    command.Parameters.AddWithValue("@Slot", Slot);
                    command.CommandText = "UPDATE player_characters SET slot=@Slot WHERE object_id=@ObjectId";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error("was a problem Update (Characater)!\r\n" + ex.ToString());
            }
        }

        public static int getSlots(long PlayerId)
        {
            int Result = 0;
            if (PlayerId == 0)
            {
                return Result;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@PlayerId", PlayerId);
                    command.CommandText = "SELECT slot FROM player_characters WHERE player_id=@PlayerId ORDER BY slot ASC;";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        Result = data.GetInt32(0);
                    }
                    command.Dispose();
                    data.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error("was a problem Slots (Characater)!\r\n" + ex.ToString());
            }
            return Result;
        }
    }
}
