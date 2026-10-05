using ProjectBlackout.Battle.Data.Enums;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Battle.Data.Models.Event
{
    public class SuicideInfo
    {
        public uint HitInfo;
        public Half3 PlayerPos;
        public byte Extensions;
        public int WeaponId;
    }
}
