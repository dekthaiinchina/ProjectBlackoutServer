using ProjectBlackout.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace ProjectBlackout.Game.Data.Xml
{
    public static class BattleServerXml
    {
        public static List<BattleServer> Servers = new List<BattleServer>();

        public static void Load()
        {
            string path = "Data/Battle/ServerList.xml";
            if (File.Exists(path))
            {
                parse(path);
            }
            else
            {
                Logger.error("File not found: " + path);
            }
        }

        public static BattleServer GetRandomServer()
        {
            if (Servers.Count == 0)
            {
                return null;
            }
            Random rnd = new Random();
            int idx = rnd.Next(Servers.Count);
            try
            {
                return Servers[idx];
            }
            catch
            {
                return null;
            }
        }

        private static void parse(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    if (fileStream.Length > 0)
                    {
                        xmlDocument.Load(fileStream);
                        for (XmlNode xmlNode1 = xmlDocument.FirstChild; xmlNode1 != null; xmlNode1 = xmlNode1.NextSibling)
                        {
                            if ("List".Equals(xmlNode1.Name))
                            {
                                XmlNamedNodeMap xml2 = xmlNode1.Attributes;
                                for (XmlNode xmlNode2 = xmlNode1.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
                                {
                                    if ("Server".Equals(xmlNode2.Name))
                                    {
                                        XmlNamedNodeMap xml = xmlNode2.Attributes;
                                        BattleServer server = new BattleServer(xml.GetNamedItem("Ip").Value, int.Parse(xml.GetNamedItem("Sync").Value))
                                        {
                                            Port = int.Parse(xml.GetNamedItem("Port").Value),
                                        };
                                        Servers.Add(server);
                                    }
                                }
                            }
                        }
                    }
                    fileStream.Dispose();
                    fileStream.Close();
                }
            }
            catch (XmlException ex)
            {
                Logger.error("File error: " + path + "\r\n" + ex.ToString());
            }
        }
    }

    public class BattleServer
    {
        public string IP;
        public int Port, SyncPort;
        public IPEndPoint Connection;

        public BattleServer(string ip, int syncPort)
        {
            IP = ip;
            SyncPort = syncPort;
            Connection = new IPEndPoint(IPAddress.Parse(ip), syncPort);
        }
    }
}