using ProjectBlackout.Battle.Data.Configs;
using ProjectBlackout.Battle.Data.Items;
using ProjectBlackout.Battle.Data.Sync;
using ProjectBlackout.Battle.Data.Xml;
using ProjectBlackout.Battle.Network;
using ProjectBlackout.Battle;
using ProjectBlackout.Core.Network;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjectBlackout.Battle
{
    class Program
    {
        public static void Main(string[] args)
        {
            string Date = ComDiv.GetLinkerTime(Assembly.GetExecutingAssembly(), null).ToString("dd/MM/yyyy HH:mm");
            BattleConfig.Load();
            Logger.checkDirectory();
            Console.Clear();
            Logger.White(@"ProjectBlackout - Battle Server");
			Logger.White(@"-> " + Date + "");
			Logger.White(@"----------------------------------------");
			MapXml.Load();
            CharaXml.Load();
            MeleeExceptionsXml.Load();
            ServersXml.Load();
            ItemManager.Load();
            BattleSync.Start();
            BattleManager.Connect();

            Update();

            Process.GetCurrentProcess().WaitForExit();
        }

        protected static async void Update()
        {
            while (true)
            {
                Console.Title = "ProjectBlackout - Battle Server [Used RAM: " + (GC.GetTotalMemory(true) / 1024) + " KB]";

                await Task.Delay(5000);
            }
        }
    }
}