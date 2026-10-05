using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Account.Title;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ProjectBlackout.Core.Xml
{
    public class TitleAwardsXml
    {
        public static List<TitleA> awards = new List<TitleA>();

        public static void Load()
        {
            string path = "Data/Titles/TitleAwards.xml";
            if (File.Exists(path))
            {
                parse(path);
            }
            else
            {
                Logger.error("File not found: " + path);
            }
        }

        public static List<ItemsModel> getAwards(int titleId)
        {
            List<ItemsModel> items = new List<ItemsModel>();
            lock (awards)
            {
                for (int i = 0; i < awards.Count; i++)
                {
                    TitleA title = awards[i];
                    if (title._id == titleId)
                    {
                        items.Add(title._item);
                    }
                }
            }
            return items;
        }

        public static bool Contains(int titleId, int itemId)
        {
            if (itemId == 0)
            {
                return false;
            }
            for (int i = 0; i < awards.Count; i++)
            {
                TitleA title = awards[i];
                if (title._id == titleId && title._item._id == itemId)
                {
                    return true;
                }
            }
            return false;
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
                                        int itemId = int.Parse(xml.GetNamedItem("ItemId").Value);
                                        awards.Add(new TitleA { _id = int.Parse(xml.GetNamedItem("Id").Value), _item = new ItemsModel(itemId, "Title Reward", int.Parse(xml.GetNamedItem("Equip").Value), long.Parse(xml.GetNamedItem("Count").Value)) });
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