using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProjectBlackout.Core.Managers.Events
{
    public class EventPlayTimeSyncer
    {
        private static List<PlayTimeModel> _events = new List<PlayTimeModel>();

        public static void GenerateList()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_events_playtime";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        PlayTimeModel ev = new PlayTimeModel
                        {
                            _startDate = (UInt32)data.GetInt64(0),
                            _endDate = (UInt32)data.GetInt64(1),
                            _title = data.GetString(2),
                            _time = data.GetInt64(3),
                            _goodReward1 = data.GetInt32(4),
                            _goodReward2 = data.GetInt32(5),
                            _goodCount1 = data.GetInt32(6),
                            _goodCount2 = data.GetInt32(7)
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

        public static PlayTimeModel getRunningEvent()
        {
            try
            {
                uint date = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
                for (int i = 0; i < _events.Count; i++)
                {
                    PlayTimeModel ev = _events[i];
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

        public static void ResetPlayerEvent(long pId, PlayerEvent pE)
        {
            if (pId == 0)
            {
                return;
            }
            ComDiv.updateDB("player_events", "player_id", pId, new string[] { "last_playtime_value", "last_playtime_finish", "last_playtime_date" }, pE.LastPlaytimeValue, pE.LastPlaytimeFinish, (long)pE.LastPlaytimeDate);
        }

    }
    public class PlayTimeModel
    {
        public int _goodReward1, _goodReward2;
        public long _goodCount1, _goodCount2;
        public uint _startDate, _endDate;
        public string _title = "";
        public long _time;

        public bool EventIsEnabled()
        {
            uint date = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
            if (_startDate <= date && date < _endDate)
            {
                return true;
            }
            return false;
        }

        public long GetRewardCount(int goodId)
        {
            return (goodId == _goodReward1 ? _goodCount1 : (goodId == _goodReward2 ? _goodCount2 : 0));
        }
    }
}