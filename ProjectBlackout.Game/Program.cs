using ProjectBlackout.Core;
using ProjectBlackout.Core.Sql;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Managers.Events;
using ProjectBlackout.Core.Managers.Server;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Sync;
using System;
using System.Diagnostics;
using System.Reflection;
using ProjectBlackout.Core.Filters;
using ProjectBlackout.Game.Data.Configs;
using System.Text;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Chat;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Game.Rcon;
using System.Threading;
using ProjectBlackout.Game.Data.Command;

namespace ProjectBlackout.Game
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            string Date = ComDiv.GetLinkerTime(Assembly.GetExecutingAssembly(), null).ToString("dd/MM/yyyy HH:mm");
            Logger.StartedFor = "Game";
            Logger.checkDirectorys();
            Console.Clear();
            Logger.White(@"ProjectBlackout - Game Server");
			Logger.White(@"-> " + Date + "");
			Logger.White(@"----------------------------------------");
			GameConfig.Load();
            if (!SqlConnection.CheckConnection())
            {
                Environment.ExitCode = 1;
                return;
            }
            BasicInventoryXml.Load();
            ServerConfigSyncer.GenerateConfig(GameConfig.configId);
            ServersXml.Load();
            ChannelsXml.Load(GameConfig.serverId);
            EventLoader.LoadAll();
            TitlesXml.Load();
            TitleAwardsXml.Load();
            ClanManager.Load();
            NickFilter.Load();
            MissionCardXml.LoadBasicCards(1);
            RankXml.Load();
            BattleServerXml.Load();
            RankXml.LoadAwards();
            ClanRankXml.Load();
            MissionAwardsXml.Load();
            MissionsXml.Load();
            Translation.Load();
            ShopManager.Load(1);
            MapsXml.Load();
            RandomBoxXml.LoadBoxes();
            CouponEffectManager.LoadCouponFlags();
            GameSync.Start();
            PermissionManager.Load();
            CommandManager.Load();

            if(Logger.erro)
            {
                Logger.error("Check your configuration.");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }

            if (GameManager.Start())
                Game.Update();

            if (GameConfig.RconEnable)
                RconManager.Instance();

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}