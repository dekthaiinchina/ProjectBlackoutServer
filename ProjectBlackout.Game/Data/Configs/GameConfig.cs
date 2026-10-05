using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using System.Collections.Generic;
using System.Text;

namespace ProjectBlackout.Game.Data.Configs
{
    public static class GameConfig
    {
        public static string passw, gameIp, RconIp, RconPassword;
        public static bool RconPrintNotValidIp, RconEnable, isTestMode, debugMode, winCashPerBattle, showCashReceiveWarn, AutoBan;
        public static UdpState udpType;
        public static float maxClanPoints;
        public static int RconPort, serverId, configId, ruleId, maxBattleLatency, maxRepeatLatency, syncPort, maxActiveClans, minRankVote, maxNickSize, minNickSize, maxBattleXP, maxBattleGP, maxBattleMY, maxChannelPlayers, gamePort, minCreateGold, minCreateRank;
        public static List<string> RconValidIps;

        public static void Load()
        {
            ConfigFile configFileDatabase = new ConfigFile("Config/Database.ini");
            Config.dbHost = configFileDatabase.readString("Host", "localhost");
            Config.dbName = configFileDatabase.readString("Name", "");
            Config.dbUser = configFileDatabase.readString("User", "root");
            Config.dbPass = configFileDatabase.readString("Pass", "");
            Config.dbPort = configFileDatabase.readInt32("Port", 0);
            Config.EncodeText = Encoding.GetEncoding(configFileDatabase.readInt32("EncodingPage", 0));


            ConfigFile configFile = new ConfigFile("Config/Game.ini");
            serverId = configFile.readInt32("ServerId", -1);
            configId = configFile.readInt32("ConfigId", 0);
            gameIp = configFile.readString("GameIp","127.0.0.1");
            gamePort = configFile.readInt32("GamePort", 39190);
            syncPort = configFile.readInt32("SyncPort", 0);
            debugMode = configFile.readBoolean("Debug", true);
            isTestMode = configFile.readBoolean("Test", true);
            AutoBan = configFile.readBoolean("AutoBan", false);
            winCashPerBattle = configFile.readBoolean("WinCashPerBattle", true);
            showCashReceiveWarn = configFile.readBoolean("ShowCashReceiveWarn", true);
            minCreateRank = configFile.readInt32("MinCreateRank", 15);
            minCreateGold = configFile.readInt32("MinCreatePoint", 7500);
            maxClanPoints = configFile.readFloat("MaxClanPoints", 0);
            passw = configFile.readString("Password", "");
            maxChannelPlayers = configFile.readInt32("MaxChannelPlayers", 100);
            maxBattleXP = configFile.readInt32("MaxBattleXP", 1000);
            maxBattleGP = configFile.readInt32("MaxBattlePoint", 1000);
            maxBattleMY = configFile.readInt32("MaxBattleMY", 1000);
            udpType = (UdpState)configFile.readByte("UdpType", 1);
            minNickSize = configFile.readInt32("MinNickSize", 0);
            maxNickSize = configFile.readInt32("MaxNickSize", 0);
            minRankVote = configFile.readInt32("MinRankVote", 0);
            maxActiveClans = configFile.readInt32("MaxActiveClans", 0);
            maxBattleLatency = configFile.readInt32("MaxBattleLatency", 0);
            maxRepeatLatency = configFile.readInt32("MaxRepeatLatency", 0);
            ruleId = configFile.readInt32("RuleId", 0);

            RconEnable = configFile.readBoolean("RconEnable", false);
            RconIp = configFile.readString("RconIp", "127.0.0.1");
            RconPassword = configFile.readString("RconPassword", "");
            RconPort = configFile.readInt32("RconPort", 39189);
            RconPrintNotValidIp = configFile.readBoolean("RconPrintNotValidIp", false);

            RconValidIps = new List<string>();
            string Ips = configFile.readString("RconValidIps", "127.0.0.1");
            if (Ips.Contains(";"))
            {
                RconValidIps.AddRange(Ips.Split(';'));
            }
            else RconValidIps.Add(Ips);

        }
    }
}