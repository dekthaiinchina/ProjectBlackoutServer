using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Sql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Core.Managers.Events
{
    public class EventVisitSyncer
    {
        private static List<EventVisitModel> _events = new List<EventVisitModel>();

        public static void GenerateList()
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM server_events_visit";
                    command.CommandType = CommandType.Text;
                    NpgsqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        EventVisitModel ev = new EventVisitModel
                        {
                            id = data.GetInt32(0),
                            startDate = (UInt32)data.GetInt64(1),
                            endDate = (UInt32)data.GetInt64(2),
                            title = data.GetString(3),
                            checks = data.GetInt32(4)
                        };

                        string goods1 = data.GetString(5);
                        string counts1 = data.GetString(6);

                        
                        string goods2 = data.GetString(7);
                        string counts2 = data.GetString(8);

                        string[] goodsarray1 = goods1.Split(',');
                        string[] goodsarray2 = goods2.Split(',');

                        for (int i = 0; i < goodsarray1.Length; i++)
                        {
                            VisitBox box = new VisitBox();
                            box.reward1.good_id = int.Parse(goodsarray1[i]);
                            ev.box.Add(box);
                        }

                        for (int i = 0; i < goodsarray2.Length; i++)
                        {
                            ev.box[i].reward2.good_id = int.Parse(goodsarray2[i]);
                        }

                        string[] countarray1 = counts1.Split(',');
                        string[] countarray2 = counts2.Split(',');
                        for (int i = 0; i < countarray1.Length; i++)
                        {
                            VisitItem item = ev.box[i].reward1;
                            item.SetCount(countarray1[i]);
                        }
                        for (int i = 0; i < countarray2.Length; i++)
                        {
                            VisitItem item = ev.box[i].reward2;
                            item.SetCount(countarray2[i]);
                        }

                        ev.SetBoxCounts(goodsarray1.Length);

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

        public static EventVisitModel getEvent(int eventId)
        {
            try
            {
                for (int i = 0; i < _events.Count; i++)
                {
                    EventVisitModel ev = _events[i];
                    if (ev.id == eventId)
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

        public static EventVisitModel getRunningEvent()
        {
            try
            {
                uint date = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
                for (int i = 0; i < _events.Count; i++)
                {
                    EventVisitModel ev = _events[i];
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

        public static void ResetPlayerEvent(long pId, int eventId)
        {
            if (pId == 0)
            {
                return;
            }
            ComDiv.updateDB("player_events", "player_id", pId, new string[] { "last_visit_event_id", "last_visit_sequence1", "last_visit_sequence2", "next_visit_date" }, eventId, 0, 0, 0);
        }
    }

    public class EventVisitModel
    {
        public int id, checks = 7;
        public uint startDate, endDate;
        public string title = "";
        public List<VisitBox> box = new List<VisitBox>();

        public bool EventIsEnabled()
        {
            uint date = uint.Parse(DateTime.Now.ToString("yyMMddHHmm"));
            if (startDate <= date && date < endDate)
            {
                return true;
            }
            return false;
        }

        public VisitItem getReward(int idx, int rewardIdx)
        {
            try
            {
                return rewardIdx == 0 ? box[idx].reward1 : box[idx].reward2;
            }
            catch
            {
                return null;
            }
        }

        public void SetBoxCounts(int count)
        {
            for (int i = 0; i < count; i++)
            {
                box[i].SetCount();
            }
        }
    }
}