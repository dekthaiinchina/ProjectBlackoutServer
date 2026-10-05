using System.Text;

namespace ProjectBlackout.Battle.Data.Configs
{
    public static class BattleConfig
    {
        public static string dbName, dbHost, dbUser, dbPass, hosIp, serverIp, udpVersion;
        public static int dbPort;
        public static ushort hosPort, maxDrop, syncPort;
        public static bool isTestMode, sendInfoToServ, sendFailMsg, enableLog, useMaxAmmoInDrop, useHitMarker, removeHitUnlisted, damageCheckFromItems;
        public static float plantDuration, defuseDuration;
        public static Encoding EncodeText;

        public static void Load()
        {
            ConfigFile configFileDatabase = new ConfigFile("Config/Database.ini");
            dbHost = configFileDatabase.readString("Host", "localhost");
            dbName = configFileDatabase.readString("Name", "");
            dbUser = configFileDatabase.readString("User", "root");
            dbPass = configFileDatabase.readString("Pass", "");
            dbPort = configFileDatabase.readInt32("Port", 0);
            EncodeText = Encoding.GetEncoding(configFileDatabase.readInt32("EncodingPage", 0));

            ConfigFile configFile = new ConfigFile("Config/Battle.ini");
            hosIp = configFile.readString("UdpIp", "0.0.0.0");
            serverIp = configFile.readString("ServerIp", "0.0.0.0");
            hosPort = configFile.readUInt16("UdpPort", 40000);
            isTestMode = configFile.readBoolean("Test", false);
            sendInfoToServ = configFile.readBoolean("SendInfoToServer", true);
            sendFailMsg = configFile.readBoolean("SendFailMsg", true);
            enableLog = configFile.readBoolean("EnableLog", false);
            maxDrop = configFile.readUInt16("MaxDrop", 0);
            syncPort = configFile.readUInt16("SyncPort", 0);
            plantDuration = 5.5f;
            defuseDuration = 6.5f;
            useHitMarker = configFile.readBoolean("UseHitMarker", false);
            useMaxAmmoInDrop = configFile.readBoolean("UseMaxAmmoInDrop", false);
            udpVersion = configFile.readString("UdpVersion", "0.0");


            removeHitUnlisted = configFile.readBoolean("RemoveHitUnlistedItems", false);
            damageCheckFromItems = configFile.readBoolean("DamageCheckFromItems", false);
        }
    }
}