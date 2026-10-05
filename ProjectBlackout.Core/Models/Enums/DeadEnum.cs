using System;

namespace ProjectBlackout.Core.Models.Enums
{
    [Flags]
    public enum DeadEnum
    {
        Alive = 1,
        Dead = 2,
        UseChat = 4
    }
}