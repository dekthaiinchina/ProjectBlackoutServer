using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Core.Models.Map
{
    public static class MapModel
    {
        public static List<MapRule> Rules = new List<MapRule>();
        public static List<MapMatch> Matchs = new List<MapMatch>();

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int limit)
        {
            return list.Select((item, inx) => new { item, inx }).GroupBy(x => x.inx / limit).Select(g => g.Select(x => x.item));
        }

        public static MapRule getRule(int Mode)
        {
            for (int i = 0; i < Rules.Count; i++)
            {
                MapRule Rule = Rules[i];
                if (Rule != null)
                {
                    if (Rule.Id == Mode)
                    {
                        return Rule;
                    }
                }
            }
            return null;
        }
    }
}
