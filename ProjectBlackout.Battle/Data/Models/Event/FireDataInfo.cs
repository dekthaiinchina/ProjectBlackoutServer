using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Battle.Data.Models.Event
{
    public class FireDataInfo
    {
        public byte Effect, Part, Extensions;
        public short Index;
        public ushort X, Y, Z;
        public int WeaponId;
    }
}
