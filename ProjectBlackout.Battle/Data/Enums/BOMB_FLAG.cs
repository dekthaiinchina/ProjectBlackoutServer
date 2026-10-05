using System;

namespace ProjectBlackout.Battle.Data.Enums
{
    [Flags]
    public enum BOMB_FLAG
    {
        START = 1,
        STOP = 2,
        DEFUSE = 4,
        UNK = 8
    }
}