using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Core.Managers.Events
{
    public class EventLoginSyncer
    {
        private static List<EventLoginModel> _events = new List<EventLoginModel>();

        public static void GenerateList()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_events_login";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        EventLoginModel ev = new EventLoginModel
                        {
                            startDate = (UInt32)data.GetInt64(0),
                            endDate = (UInt32)data.GetInt64(1),
                            _rewardId = data.GetInt32(2),
                            _count = data.GetInt64(3)
                        };
                        ev._category = ComDiv.GetItemCategory(ev._rewardId);
                        if (ev._rewardId < 100000)
                        {
                            Logger.error("Event with incorrect reward! [Id: " + ev._rewardId + "]");
                        }
                        else
                        {
                            _events.Add(ev);
                        }
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

        public static EventLoginModel getRunningEvent()
        {
            try
            {
                uint date = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
                for (int i = 0; i < _events.Count; i++)
                {                    
                    EventLoginModel ev = _events[i];
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
    }

    public class EventLoginModel
    {
        public int _rewardId, _category;
        public long _count;
        public uint startDate, endDate;
    }
}