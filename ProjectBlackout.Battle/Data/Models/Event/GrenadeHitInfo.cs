using ProjectBlackout.Battle.Data.Enums;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Battle.Data.Models.Event
{
    public class GrenadeHitInfo
    {
        public byte DeathType, Extensions;
        public ushort BoomInfo, GrenadesCount;
        public uint HitInfo;
        public int WeaponId;
        public List<int> BoomPlayers;
        public Half3 FirePos, HitPos, PlayerPos;
        public HIT_TYPE HitEnum;
        public CLASS_TYPE WeaponClass;
    }
}
