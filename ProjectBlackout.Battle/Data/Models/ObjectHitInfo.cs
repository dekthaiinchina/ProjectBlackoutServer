using ProjectBlackout.Battle.Data.Enums;
using SharpDX;

namespace ProjectBlackout.Battle.Data.Models
{
    public class ObjectHitInfo
    {
        public int Type, ObjSyncId, ObjId, ObjLife, WeaponId, KillerId, AnimId1, AnimId2, DestroyState;
        public CHARA_DEATH DeathType = CHARA_DEATH.DEFAULT;
        public int HitPart/*, Value, ValueType*/;
        public byte Extensions;
        public Half3 Position;
        public float SpecialUse;

        public ObjectHitInfo(int Type)
        {
            this.Type = Type;
        }
    }
}