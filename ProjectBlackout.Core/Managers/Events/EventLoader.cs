
namespace ProjectBlackout.Core.Managers.Events
{
    public static class EventLoader
    {
        public static void LoadAll()
        {
            EventVisitSyncer.GenerateList();
            EventLoginSyncer.GenerateList();
            EventMapSyncer.GenerateList();
            EventPlayTimeSyncer.GenerateList();
            EventQuestSyncer.GenerateList();
            EventRankUpSyncer.GenerateList();
            EventXmasSyncer.GenerateList();
        }

        public static void ReloadEvent(int index)
        {
            if (index == 0)
            {
                EventVisitSyncer.ReGenList();
            }
            else if (index == 1)
            {
                EventLoginSyncer.ReGenList();
            }
            else if (index == 2)
            {
                EventMapSyncer.ReGenList();
            }
            else if (index == 3)
            {
                EventPlayTimeSyncer.ReGenList();
            }
            else if (index == 4)
            {
                EventQuestSyncer.ReGenList();
            }
            else if (index == 5)
            {
                EventRankUpSyncer.ReGenList();
            }
            else if (index == 6)
            {
                EventXmasSyncer.ReGenList();
            }
        }

        public static void ReloadAll()
        {
            EventVisitSyncer.ReGenList();
            EventLoginSyncer.ReGenList();
            EventMapSyncer.ReGenList();
            EventPlayTimeSyncer.ReGenList();
            EventQuestSyncer.ReGenList();
            EventRankUpSyncer.ReGenList();
            EventXmasSyncer.ReGenList();
        }
    }
}