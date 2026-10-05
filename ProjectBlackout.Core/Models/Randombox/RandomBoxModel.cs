using System.Collections.Generic;

namespace ProjectBlackout.Core.Models.Randombox
{
    public class RandomBoxModel
    {
        public int itemsCount, minPercent, maxPercent;
        public List<RandomBoxItem> items = new List<RandomBoxItem>();

        public List<RandomBoxItem> getRewardList(List<RandomBoxItem> sortedList, int rnd)
        {
            List<RandomBoxItem> result = new List<RandomBoxItem>();
            if (sortedList.Count > 0)
            {
                int sortedIndex = sortedList[rnd].index;
                for (int i = 0; i < sortedList.Count; i++)
                {
                    RandomBoxItem item = sortedList[i];
                    if (item.index == sortedIndex)
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public List<RandomBoxItem> getSortedList(int percent)
        {
            if (percent < minPercent)
            {
                percent = minPercent;
            }
            List<RandomBoxItem> result = new List<RandomBoxItem>();
            for (int i = 0; i < items.Count; i++)
            {
                RandomBoxItem item = items[i];
                if (percent <= item.percent)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public void SetTopPercent()
        {
            int minRecord = 100, maxRecord = 0;
            for (int i = 0; i < items.Count; i++)
            {
                RandomBoxItem item = items[i];
                if (item.percent < minRecord)
                {
                    minRecord = item.percent;
                }
                if (item.percent > maxRecord)
                {
                    maxRecord = item.percent;
                }
            }
            minPercent = minRecord;
            maxPercent = maxRecord;
        }
    }
}