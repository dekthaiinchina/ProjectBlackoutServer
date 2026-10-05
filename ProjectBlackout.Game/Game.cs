using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Threading.Tasks;

namespace ProjectBlackout.Game
{
    public static class Game
    {
        public static async void Update()
        {
            while (true)
            {
                Console.Title = "ProjectBlackout - Game [Users: " + GameManager._socketList.Count + " Online: " + ServersXml.getServer(GameConfig.serverId)._LastCount + " Used RAM: " + (GC.GetTotalMemory(true) / 1024) + " KB]";
                if (DateTime.Now.ToString("HH:mm") == "00:00")
                {
                    foreach (Account Player in AccountManager._accounts.Values)
                    {
                        if (Player != null)
                        {
                            Player.Daily = new PlayerDailyRecord();
                        }
                    }
                    foreach (GameClient Client in GameManager._socketList.Values)
                    {
                        if (Client != null && Client._player != null && Client._player._isOnline)
                        {
                            Client._player.Daily = new PlayerDailyRecord();
                        }
                    }
                    ComDiv.updateDB("player_dailyrecord", "total", 0);
                    ComDiv.updateDB("player_dailyrecord", "wins", 0);
                    ComDiv.updateDB("player_dailyrecord", "loses", 0);
                    ComDiv.updateDB("player_dailyrecord", "draws", 0);
                    ComDiv.updateDB("player_dailyrecord", "kills", 0);
                    ComDiv.updateDB("player_dailyrecord", "deaths", 0);
                    ComDiv.updateDB("player_dailyrecord", "headshots", 0);
                    ComDiv.updateDB("player_dailyrecord", "point", 0);
                    ComDiv.updateDB("player_dailyrecord", "exp", 0);
                }
                await Task.Delay(1000);
            }
        }
    }
}