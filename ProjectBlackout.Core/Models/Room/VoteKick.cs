using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectBlackout.Core.Models.Room
{
    public class VoteKick
    {
        public int creatorIdx, victimIdx, motive, kikar = 1, deixar = 1, allies, enemys;
        public List<int> _votes = new List<int>();
        public bool[] TotalArray = new bool[16];

        public VoteKick(int creator, int victim)
        {
            creatorIdx = creator;
            victimIdx = victim;
            _votes.Add(creator);
            _votes.Add(victim);
        }

        public int GetInGamePlayers()
        {
            int count = 0;
            for (int i = 0; i < 16; i++)
            {
                if (TotalArray[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
}