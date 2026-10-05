using Npgsql;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Gift;
using ProjectBlackout.Core.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Core.Managers
{
    public static class TicketManager
    {
        public static List<TicketModel> GetTickets()
        {
            List<TicketModel> Tickets = new List<TicketModel>();
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM tickets";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        TicketModel Ticket = new TicketModel((TicketType)data.GetInt32(0), data.GetString(1));

                        if (Ticket.Type.HasFlag(TicketType.ITEM))
                        {
                            Ticket.ItemId = data.GetInt32(2);
                            Ticket.Count = data.GetInt32(3);
                            Ticket.Equip = data.GetInt32(4);
                        }
                        if (Ticket.Type.HasFlag(TicketType.MONEY))
                        {
                            Ticket.Point = data.GetInt32(5);
                            Ticket.Cash = data.GetInt32(6);
                        }
                        Tickets.Add(Ticket);
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
            return Tickets;
        }
    }
}
