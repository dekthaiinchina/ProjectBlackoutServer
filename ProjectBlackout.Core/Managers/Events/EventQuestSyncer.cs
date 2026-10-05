using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Core.Managers.Events
{
    public class EventQuestSyncer
    {
        private static List<QuestModel> _events = new List<QuestModel>();

        public static void GenerateList()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_events_quest";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        QuestModel ev = new QuestModel
                        {
                            startDate = (UInt32)data.GetInt64(0),
                            endDate = (UInt32)data.GetInt64(1)
                        };
                        _events.Add(ev);
                    }
                    command.Dispose();
                    data.Close();
                    connection.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public static void ReGenList()
        {
            _events.Clear();
            GenerateList();
        }

        public static QuestModel getRunningEvent()
        {
            try
            {
                uint date = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
                for (int i = 0; i < _events.Count; i++)
                {
                    QuestModel ev = _events[i];
                    if (ev.startDate <= date && date < ev.endDate)
                    {
                        return ev;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return null;
        }

        public static void ResetPlayerEvent(long pId, PlayerEvent pE)
        {
            if (pId == 0)
            {
                return;
            }
            ComDiv.updateDB("player_events", "player_id", pId, new string[] { "last_quest_date", "last_quest_finish" }, (long)pE.LastQuestDate, pE.LastQuestFinish);
        }
    }

    public class QuestModel
    {
        public uint startDate, endDate;
    }
}