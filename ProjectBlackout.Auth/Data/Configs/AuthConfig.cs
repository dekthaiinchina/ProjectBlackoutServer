using ProjectBlackout.Core;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectBlackout.Core.Models.Enums;

namespace ProjectBlackout.Auth.Data.Configs
{
    public static class AuthConfig
    {
        public static string authIp;
        public static bool isTestMode, Outpost, AUTO_ACCOUNTS, debugMode, ClearToken;
        public static int syncPort, configId, maxNickSize, minNickSize, minTokenSize, authPort, serverId, maxChannelPlayers, STR_LOBBY_BACKGROUNG;
        public static ulong LauncherKey;
        public static List<ClientLocale> GameLocales;

        public static void Load()
        {
            ConfigFile configFileDatabase = new ConfigFile("Config/Database.ini");
            Config.dbHost = configFileDatabase.readString("Host", "localhost");
            Config.dbName = configFileDatabase.readString("Name", "");
            Config.dbUser = configFileDatabase.readString("User", "root");
            Config.dbPass = configFileDatabase.readString("Pass", "");
            Config.dbPort = configFileDatabase.readInt32("Port", 0);
            Config.EncodeText = Encoding.GetEncoding(configFileDatabase.readInt32("EncodingPage", 0));

            ConfigFile configFile = new ConfigFile("Config/Auth.ini");
            configId = configFile.readInt32("ConfigId", 0);
            serverId = configFile.readInt32("ServerId", -1);
            authIp = configFile.readString("AuthIp", "127.0.0.1");
            authPort = configFile.readInt32("AuthPort", 39190);
            syncPort = configFile.readInt32("SyncPort", 0);
            AUTO_ACCOUNTS = configFile.readBoolean("AutoAccounts", false);
            debugMode = configFile.readBoolean("Debug", true);
            isTestMode = configFile.readBoolean("Test", true);
            maxChannelPlayers = configFile.readInt32("MaxChannelPlayers", 100);
            Outpost = configFile.readBoolean("Outpost", false);
            LauncherKey = configFile.readUInt64("LauncherKey", 0);
            minNickSize = configFile.readInt32("MinNickSize", 0);
            maxNickSize = configFile.readInt32("MaxNickSize", 0);
            minTokenSize = configFile.readInt32("MinTokenSize", 0);
            ClearToken = configFile.readBoolean("ClearToken", true);
            AuthConfig.STR_LOBBY_BACKGROUNG = configFile.readInt32("LobbyBackground", 0);
            GameLocales = new List<ClientLocale>();
            string strLocales = configFile.readString("GameLocales", "None");
            foreach (string splitedLocale in strLocales.Split(','))
            {
                ClientLocale clientLocale;
                Enum.TryParse(splitedLocale, out clientLocale);
                GameLocales.Add(clientLocale);
            }
        }
    }
}