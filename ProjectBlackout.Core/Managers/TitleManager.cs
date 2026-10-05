using ProjectBlackout.Core.Models.Account.Title;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Data;

namespace ProjectBlackout.Core.Managers
{
    public class TitleManager
    {
        private static TitleManager acm = new TitleManager();

        public static TitleManager getInstance()
        {
            return acm;
        }

        public bool CreateTitleDB(long player_id)
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
                    cmd.CommandText = "INSERT INTO player_titles (owner_id) VALUES (@owner)";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
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

        public PlayerTitles getTitleDB(long pId)
        {
            PlayerTitles title = new PlayerTitles();
            if (pId == 0)
            {
                return title;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@owner", pId);
                    command.CommandText = "SELECT * FROM player_titles WHERE owner_id=@owner";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        title.ownerId = pId;
                        title.Equiped1 = data.GetInt32(1);
                        title.Equiped2 = data.GetInt32(2);
                        title.Equiped3 = data.GetInt32(3);
                        title.Flags = data.GetInt64(4);
                        title.Slots = data.GetInt32(5);
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error("Ocorreu um problema ao carregar os títulos!\r\n" + ex.ToString());
            }
            return title;
        }

        public bool updateEquipedTitle(long player_id, int index, int titleId)
        {
            return ComDiv.updateDB("player_titles", "titleequiped" + (index + 1), titleId, "owner_id", player_id);
        }

        public void updateTitlesFlags(long player_id, long flags)
        {
            ComDiv.updateDB("player_titles", "titleflags", flags, "owner_id", player_id);
        }

        public void updateRequi(long player_id, int medalhas, int insignias, int ordens_azuis, int broche)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.Parameters.AddWithValue("@pid", player_id);
                    command.Parameters.AddWithValue("@broche", broche);
                    command.Parameters.AddWithValue("@insignias", insignias);
                    command.Parameters.AddWithValue("@medalhas", medalhas);
                    command.Parameters.AddWithValue("@ordensazuis", ordens_azuis);
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE players SET brooch=@broche, insignia=@insignias, medal=@medalhas, blue_order=@ordensazuis WHERE player_id=@pid";
                    command.ExecuteNonQuery();
                    command.Dispose();
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