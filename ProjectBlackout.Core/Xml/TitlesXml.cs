using ProjectBlackout.Core.Models.Account.Title;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ProjectBlackout.Core.Xml
{
    public class TitlesXml
    {
        private static List<TitleQ> titles = new List<TitleQ>();

        public static TitleQ getTitle(int titleId, bool ReturnNull = true)
        {
            if (titleId == 0)
            {
                if (!ReturnNull)
                {
                    return new TitleQ();
                }
                else
                {
                    return null;
                }
            }
            for (int i = 0; i < titles.Count; i++)
            {
                TitleQ title = titles[i];
                if (title._id == titleId)
                {
                    return title;
                }
            }
            return null;
        }

        public static void get2Titles(int titleId1, int titleId2, out TitleQ title1, out TitleQ title2, bool ReturnNull = true)
        {
            if (!ReturnNull)
            {
                title1 = new TitleQ();
                title2 = new TitleQ();
            }
            else
            {
                title1 = null;
                title2 = null;
            }
            if (titleId1 == 0 && titleId2 == 0)
            {
                return;
            }
            for (int i = 0; i < titles.Count; i++)
            {
                TitleQ title = titles[i];
                if (title._id == titleId1)
                {
                    title1 = title;
                }
                else if (title._id == titleId2)
                {
                    title2 = title;
                }
            }
        }

        public static void get3Titles(int titleId1, int titleId2, int titleId3, out TitleQ title1, out TitleQ title2, out TitleQ title3, bool ReturnNull)
        {
            if (!ReturnNull)
            {
                title1 = new TitleQ();
                title2 = new TitleQ();
                title3 = new TitleQ();
            }
            else
            {
                title1 = null;
                title2 = null;
                title3 = null;
            }
            if (titleId1 == 0 && titleId2 == 0 && titleId3 == 0)
            {
                return;
            }
            for (int i = 0; i < titles.Count; i++)
            {
                TitleQ title = titles[i];
                if (title._id == titleId1) title1 = title;
                else if (title._id == titleId2) title2 = title;
                else if (title._id == titleId3) title3 = title;
            }
        }

        public static void Load()
        {
            string path = "Data/Titles/TitleInfo.xml";
            if (File.Exists(path))
            {
                parse(path);
            }
            else
            {
                Logger.error("File not found: " + path);
            }
        }

        private static void parse(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                if (fileStream.Length > 0)
                {
                    try
                    {
                        xmlDocument.Load(fileStream);
                        for (XmlNode xmlNode1 = xmlDocument.FirstChild; xmlNode1 != null; xmlNode1 = xmlNode1.NextSibling)
                        {
                            if ("List".Equals(xmlNode1.Name))
                            {
                                for (XmlNode xmlNode2 = xmlNode1.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
                                {
                                    if ("Title".Equals(xmlNode2.Name))
                                    {
                                        XmlNamedNodeMap xml = xmlNode2.Attributes;
                                        int titleId = int.Parse(xml.GetNamedItem("Id").Value);
                                        titles.Add(new TitleQ(titleId) { _classId = int.Parse(xml.GetNamedItem("List").Value), _medals = int.Parse(xml.GetNamedItem("Medals").Value), _brooch = int.Parse(xml.GetNamedItem("Brooch").Value), _blueOrder = int.Parse(xml.GetNamedItem("BlueOrder").Value), _insignia = int.Parse(xml.GetNamedItem("Insignia").Value), _rank = int.Parse(xml.GetNamedItem("Rank").Value), _slot = int.Parse(xml.GetNamedItem("Slot").Value), _req1 = int.Parse(xml.GetNamedItem("ReqT1").Value), _req2 = int.Parse(xml.GetNamedItem("ReqT2").Value) });
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
                fileStream.Dispose();
                fileStream.Close();
            }
        }
    }
}