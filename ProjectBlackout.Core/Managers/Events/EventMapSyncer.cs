using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Core.Managers.Events
{
    public class EventMapSyncer
    {
        private static List<EventMapModel> _events = new List<EventMapModel>();

        public static void GenerateList()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_events_mapbonus";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        EventMapModel ev = new EventMapModel
                        {
                            _startDate = (UInt32)data.GetInt64(0),
                            _endDate = (UInt32)data.GetInt64(1),
                            _mapId = data.GetInt32(2),
                            _stageType = data.GetInt32(3),
                            _percentXp = data.GetInt32(4),
                            _percentGp = data.GetInt32(5),
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

        public static EventMapModel getRunningEvent()
        {
            try
            {
                uint date = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
                for (int i = 0; i < _events.Count; i++)
                {
                    EventMapModel ev = _events[i];
                    if (ev._startDate <= date && date < ev._endDate)
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

        public static bool EventIsValid(EventMapModel ev, int map, int stageType)
        {
            return ev != null && (ev._mapId == map || ev._stageType == stageType);
        }
    }

    public class EventMapModel
    {
        public int _mapId, _percentXp, _percentGp, _stageType;
        public uint _startDate, _endDate;
    }
}