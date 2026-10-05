using ProjectBlackout.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Core.Models.Gift
{
    public class TicketModel
    {
        public string Ticket;
        public int ItemId, Count, Equip, Point, Cash;
        public TicketType Type;

        public TicketModel(TicketType Type, string Ticket)
        {
            this.Type = Type;
            this.Ticket = Ticket;
        }
    }
}
