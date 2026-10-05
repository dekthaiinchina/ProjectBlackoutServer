using ProjectBlackout.Battle.Data.Enums;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Battle.Data.Models.Event
{
    public class HitDataInfo
    {
        public byte Extensions;
        public ushort BoomInfo;
        public uint HitIndex;
        public int WeaponId;
        public Half3 StartBullet, EndBullet;
        public List<int> BoomPlayers;
        public HIT_TYPE HitEnum;
        public CLASS_TYPE WeaponClass;
    }
}
