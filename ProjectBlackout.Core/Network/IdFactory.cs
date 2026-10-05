using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Core.Network
{
    public class IdFactory
    {
        private static IdFactory Instance;
        private BitSet IdList = new BitSet();
        private BitSet SeedList = new BitSet();
        private int NextMinId = 0;
        private int NextMinSeed = 1;

        public int NextId()
        {
            int Id = 0;
            if (NextMinId == int.MinValue)
            {

            }
            else
            {
                Id = IdList.NextClearBit(NextMinId);
            }
            IdList.Set(Id);
            NextMinId = Id + 1;
            return Id;
        }

        public ushort NextSeed()
        {
            ushort Id = 0;
            if (NextMinSeed == ushort.MinValue)
            {

            }
            else
            {
                Id = (ushort)SeedList.NextClearBit(NextMinSeed);
            }
            SeedList.Set(Id);
            NextMinSeed = Id + 1;
            return Id;
        }

        public static IdFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new IdFactory();
            }
            return Instance;
        }
    }
}
