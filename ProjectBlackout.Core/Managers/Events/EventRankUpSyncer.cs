using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Core.Managers.Events
{
    public class EventRankUpSyncer
    {
        private static List<EventUpModel> _events = new List<EventUpModel>();

        public static void GenerateList()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_events_rankup";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        EventUpModel ev = new EventUpModel
                        {
                            _startDate = (UInt32)data.GetInt64(0),
                            _endDate = (UInt32)data.GetInt64(1),
                            _percentXp = data.GetInt32(2),
                            _percentGp = data.GetInt32(3)
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

        public static EventUpModel getRunningEvent()
        {
            try
            {
                uint date = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
                for (int i = 0; i < _events.Count; i++)
                {
                    EventUpModel ev = _events[i];
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
    }

    public class EventUpModel
    {
        public int _percentXp, _percentGp;
        public uint _startDate, _endDate;
    }
}