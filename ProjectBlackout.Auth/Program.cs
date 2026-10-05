using ProjectBlackout.Core;
using ProjectBlackout.Core.Sql;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Managers.Events;
using ProjectBlackout.Core.Managers.Server;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using System;
using System.Reflection;
using ProjectBlackout.Auth.Data.Configs;
using ProjectBlackout.Auth.Data.Sync;
using ProjectBlackout.Auth.Data.Xml;
using System.Diagnostics;
using System.Threading;

namespace ProjectBlackout.Auth
{
    public class Programm
    {
        private static void Main(string[] args)
        {
            string Date = ComDiv.GetLinkerTime(Assembly.GetExecutingAssembly(), null).ToString("dd/MM/yyyy HH:mm");
            Logger.StartedFor = "Auth";
            Logger.checkDirectorys();
            Console.Clear();
            Logger.White(@"ProjectBlackout - Auth Server");
            Logger.White(@"-> " + Date + "");
            Logger.White(@"----------------------------------------");
            AuthConfig.Load();
            if (!SqlConnection.CheckConnection())
            {
                Environment.ExitCode = 1;
                return;
            }
            ServerConfigSyncer.GenerateConfig(AuthConfig.configId);
            EventLoader.LoadAll();
            BasicInventoryXml.Load();
            ServersXml.Load();
            ChannelsXml.Load(AuthConfig.serverId);
            MissionCardXml.LoadBasicCards(2);
            MapsXml.Load();
            ShopManager.Load(1);
            ShopManager.Load(2);
            RankXml.Load();
            RankXml.LoadAwards();
            CouponEffectManager.LoadCouponFlags();
            QuickStartXml.Load();
            MissionsXml.Load();
            PermissionManager.Load();
            AuthSync.Start();

            if (Logger.erro)
            {
                Logger.error("Check your configuration.");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }

            if (AuthManager.Start())
                Auth.Update();

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}