using ProjectBlackout.Core.Models.Map;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ProjectBlackout.Core.Xml
{
    public class MapsXml
    {
        public static void Load()
        {
            MatchParse();
            RuleParse();
        }

        private static void MatchParse()
        {
            string Path = "Data/Maps/Matchs.xml";
            if (File.Exists(Path))
            {
                XmlDocument XmlDocument = new XmlDocument();
                using (FileStream FileStream = new FileStream(Path, FileMode.Open))
                {
                    if (FileStream.Length == 0)
                    {
                        Logger.error("File is empty: " + Path);
                    }
                    else
                    {
                        try
                        {
                            XmlDocument.Load(FileStream);
                            for (XmlNode NodeList = XmlDocument.FirstChild; NodeList != null; NodeList = NodeList.NextSibling)
                            {
                                if ("List".Equals(NodeList.Name))
                                {
                                    for (XmlNode Node = NodeList.FirstChild; Node != null; Node = Node.NextSibling)
                                    {
                                        if ("Map".Equals(Node.Name))
                                        {
                                            XmlNamedNodeMap Xml = Node.Attributes;
                                            MapMatch Match = new MapMatch();
                                            Match.Mode = int.Parse(Xml.GetNamedItem("Mode").Value);
                                            Match.Id = int.Parse(Xml.GetNamedItem("Id").Value);
                                            Match.Limit = int.Parse(Xml.GetNamedItem("Limit").Value);
                                            Match.Tag = int.Parse(Xml.GetNamedItem("Tag").Value);
                                            MapModel.Matchs.Add(Match);
                                        }
                                    }
                                }
                            }
                        }
                        catch (XmlException ex)
                        {
                            Logger.error(ex.ToString());
                        }
                    }
                    FileStream.Dispose();
                    FileStream.Close();
                }
            }
            else
            {
                Logger.error("File not found: " + Path);
            }
        }

        private static void RuleParse()
        {
            string Path = "Data/Maps/Rules.xml";
            if (File.Exists(Path))
            {
                XmlDocument XmlDocument = new XmlDocument();
                using (FileStream FileStream = new FileStream(Path, FileMode.Open))
                {
                    if (FileStream.Length == 0)
                    {
                        Logger.error("File is empty: " + Path);
                    }
                    else
                    {
                        try
                        {
                            XmlDocument.Load(FileStream);
                            for (XmlNode NodeList = XmlDocument.FirstChild; NodeList != null; NodeList = NodeList.NextSibling)
                            {
                                if ("List".Equals(NodeList.Name))
                                {
                                    for (XmlNode Node = NodeList.FirstChild; Node != null; Node = Node.NextSibling)
                                    {
                                        if ("Map".Equals(Node.Name))
                                        {
                                            XmlNamedNodeMap Xml = Node.Attributes;
                                            MapRule Rule = new MapRule();
                                            Rule.Id = int.Parse(Xml.GetNamedItem("Id").Value);
                                            Rule.Rule = int.Parse(Xml.GetNamedItem("Rule").Value);
                                            Rule.StageOptions = int.Parse(Xml.GetNamedItem("StageOptions").Value);
                                            Rule.Conditions = int.Parse(Xml.GetNamedItem("Conditions").Value);
                                            Rule.Name = Xml.GetNamedItem("Name").Value;
                                            MapModel.Rules.Add(Rule);
                                        }
                                    }
                                }
                            }
                        }
                        catch (XmlException ex)
                        {
                            Logger.error(ex.ToString());
                        }
                    }
                    FileStream.Dispose();
                    FileStream.Close();
                }
            }
            else
            {
                Logger.error("File not found: " + Path);
            }
        }
    }
}