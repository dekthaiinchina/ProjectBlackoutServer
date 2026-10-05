using System;

namespace ProjectBlackout.Battle.Data.Enums
{
    [Flags]
    public enum UDP_GAME_EVENTS : uint
    {
        ActionState = 1,
        Animation = 2,
        PosRotation = 4,
        UseObject = 8,
        ActionForObjectSync = 0x10,
        RadioChat = 0x20,
        WeaponSync = 0x40,
        WeaponRecoil = 0x80, //
        HpSync = 0x100,
        Suicide = 0x200,
        MissionData = 0x400,
        DropWeapon = 0x20000,
        GetWeaponForClient = 0x40000,
        FireData = 0x80000,
        CharaFireNHitData = 0x100000,
        HitData = 0x200000,
        FireNHitData = 0x300000,
        GrenadeHit = 0x400000,
        GetWeaponForHost = 0x1000000,
        FireDataOnObject = 0x2000000,
        FireNHitDataOnObject = 0x4000000,
    }
}