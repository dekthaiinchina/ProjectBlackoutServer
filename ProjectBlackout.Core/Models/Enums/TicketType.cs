using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Core.Models.Enums
{
    [Flags]
    public enum TicketType
    {
        NONE = 0,
        ITEM = 1,
        MONEY = 2,
    }
}
