using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Battle.Data.Enums
{
    [Flags]
    public enum ROOM_STATE_TYPE
    {
        None = 0,
        DeathMatch = 4,
        Bomb = 8,
        Destroy = 12,
        Annihilation = 16,
        Defense = 20,
        FreeForAll = 24,
        Boss = 28,
        Ace = 32,
        StepUp = 36,
        Tutorial = 40,
        Domination = 44,
        CrossCounter = 48,
        Convoy = 52,
        Runaway = 56
    }
}
