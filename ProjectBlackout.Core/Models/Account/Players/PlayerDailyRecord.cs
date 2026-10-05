using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Core.Models.Account.Players
{
    public class PlayerDailyRecord
    {
        public long PlayerId;
        public int Total, Wins, Loses, Draws, Kills, Deaths, Headshots, Exp, Point;
    }
}
