using System;
using System.Collections.Generic;

namespace ProjectBlackout.Battle.Data.Models
{
    public class ObjectModel
    {
        public int Id, Life, Animation, UltraSync, UpdateId = 1/*, Value, ValueType*/;
        public bool NeedSync, Destroyable, NoInstaSync;
        public List<AnimModel> Animations;
        public List<DeffectModel> Effects;

        public ObjectModel(bool NeedSync)
        {
            this.NeedSync = NeedSync;
            if (NeedSync)
            {
                Animations = new List<AnimModel>();
            }
            Effects = new List<DeffectModel>();
        }

        public int CheckDestroyState(int life)
        {
            for (int i = Effects.Count - 1; i > -1; i--)
            {
                DeffectModel eff = Effects[i];
                if (eff.Life >= life)
                {
                    return eff.Id;
                }
            }
            return 0;
        }

        public int GetRandomAnimation(Room Room, ObjectInfo Obj)
        {
            if (Animations != null && Animations.Count > 0)
            {
                int Idx = new Random().Next(Animations.Count);
                AnimModel Animation = Animations[Idx];
                Obj.Animation = Animation;
                Obj.UseDate = DateTime.Now;
                if (Animation.OtherObj > 0)
                {
                    ObjectInfo obj2 = Room.Objects[Animation.OtherObj];
                    GetAnim(Animation.OtherAnim, 0, 0, obj2);
                }
                return Animation.Id;
            }
            Obj.Animation = null;
            return 255;
        }

        public void GetAnim(int animId, float time, float duration, ObjectInfo obj)
        {
            if (animId == 255 || obj == null || obj.Model == null || obj.Model.Animations == null || obj.Model.Animations.Count == 0)
            {
                return;
            }
            ObjectModel objModel = obj.Model;
            for (int i = 0; i < objModel.Animations.Count; i++)
            {
                AnimModel anim = objModel.Animations[i];
                if (anim.Id == animId)
                {
                    obj.Animation = anim;
                    time -= duration;
                    obj.UseDate = DateTime.Now.AddSeconds(time * -1);
                    break;
                }
            }
        }
    }
}
