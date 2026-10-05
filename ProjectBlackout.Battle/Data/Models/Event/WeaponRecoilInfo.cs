using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Battle.Data.Models.Event
{
    public class WeaponRecoilInfo
    {
        public float RecoilHorzAngle, RecoilHorzMax, RecoilVertAngle, RecoilVertMax, Deviation;
        public int WeaponId;
        public byte Extensions, Unk, RecoilHorzCount;
    }
}
