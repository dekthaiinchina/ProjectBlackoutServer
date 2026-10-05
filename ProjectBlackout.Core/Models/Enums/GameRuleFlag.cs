using System;

namespace ProjectBlackout.Core.Models.Enums
{
    [Flags]
    public enum GameRuleFlag
    {
        None = 0,
        No_Baret = 1,
        No_Shotguns = 2,
        No_Masks = 4,
        Racing = 8,
        RPG7 = 16,
    }
}