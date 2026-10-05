using System;

namespace ProjectBlackout.Core.Models.Enums
{
    [Flags]
    public enum RoomWeaponsFlag
    {
        Barefist = 128,
        Shotgun = 64,
        Sniper = 32,
        RPG7 = 16,
        Primary = 8,
        Secondary = 4,
        Melee = 2,
        Grenade = 1,
        None = 0
    }
}