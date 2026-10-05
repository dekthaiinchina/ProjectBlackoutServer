using ProjectBlackout.Core.Models.Servers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectBlackout.Core.Xml
{
    public class QuickStartXml
    {
        public static List<QuickStart> QucikStarts = new List<QuickStart>(3);

        public static void Load()
        {
            string Path = "Data//QuickStart.xml";
            if (File.Exists(Path))
            {
                Parse(Path);
            }
            else
            {
                Logger.error("File not found: " + Path);
            }
        }

        public static void Parse(string Path)
        {
            XmlDocument XmlDocument = new XmlDocument();
            FileStream FileStream = new FileStream(Path, FileMode.Open);
            if (FileStream.Length == 0)
            {
                Logger.error("File is Empty: " + Path);
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
                                if ("QuickStart".Equals(Node.Name))
                                {
                                    XmlNamedNodeMap Xml = Node.Attributes;
                                    QuickStart QuickStart = new QuickStart();
                                    QuickStart.MapId = int.Parse(Xml.GetNamedItem("MapId").Value);
                                    QuickStart.Rule = int.Parse(Xml.GetNamedItem("Rule").Value);
                                    QuickStart.StageOptions = int.Parse(Xml.GetNamedItem("StageOptions").Value);
                                    QuickStart.Type = int.Parse(Xml.GetNamedItem("Type").Value);
                                    QucikStarts.Add(QuickStart);
                                }
                            }
                        }
                    }
                }
                catch (XmlException ex)
                {
                    Logger.warning(ex.ToString());
                }
            }
            FileStream.Dispose();
            FileStream.Close();
        }
    }
}
