using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Core.Models.Account.Players
{
    public class PlayerItemTopup
    {
        public long ObjectId;
        public long PlayerId;
        public int ItemId;
        public long Count;
        public int Equip;
        public string ItemName;
    }
}
