using ProjectBlackout.Core.Models.Account.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ProjectBlackout.Core.Models.Randombox;

namespace ProjectBlackout.Core.Xml
{
    public class RandomBoxXml
    {
        private static SortedList<int, RandomBoxModel> boxes = new SortedList<int, RandomBoxModel>();

        public static void LoadBoxes()
        {
            DirectoryInfo folder = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Data\Coupons");
            if (!folder.Exists)
            {
                return;
            }
            foreach (FileInfo file in folder.GetFiles())
            {
                try
                {
                    LoadBox(int.Parse(file.Name.Substring(0, file.Name.Length - 4)));
                }
                catch
                {

                }
            }
        }

        private static void LoadBox(int id)
        {
            string path = "Data/Coupons/" + id + ".xml";
            if (File.Exists(path))
            {
                parse(path, id);
            }
            else
            {
                Logger.error("File not found: " + path);
            }
        }

        private static void parse(string path, int cupomId)
        {
            XmlDocument xmlDocument = new XmlDocument();
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                if (fileStream.Length == 0)
                {
                    Logger.error("File is empty: " + path);
                }
                else
                {
                    try
                    {
                        xmlDocument.Load(fileStream);
                        for (XmlNode xmlNode1 = xmlDocument.FirstChild; xmlNode1 != null; xmlNode1 = xmlNode1.NextSibling)
                        {
                            if ("List".Equals(xmlNode1.Name))
                            {
                                XmlNamedNodeMap xml2 = xmlNode1.Attributes;
                                RandomBoxModel box = new RandomBoxModel
                                {
                                    itemsCount = int.Parse(xml2.GetNamedItem("Count").Value)
                                };
                                for (XmlNode xmlNode2 = xmlNode1.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
                                {
                                    if ("Item".Equals(xmlNode2.Name))
                                    {
                                        XmlNamedNodeMap xml = xmlNode2.Attributes;
                                        ItemsModel item = null;
                                        int itemId = int.Parse(xml.GetNamedItem("Id").Value);
                                        long count = long.Parse(xml.GetNamedItem("Count").Value);
                                        if (itemId > 0)
                                        {
                                            item = new ItemsModel(itemId)
                                            {
                                                _name = "Randombox",
                                                _equip = int.Parse(xml.GetNamedItem("Equip").Value),
                                                _count = count
                                            };
                                        }
                                        box.items.Add(new RandomBoxItem
                                        {
                                            index = int.Parse(xml.GetNamedItem("Index").Value),
                                            percent = int.Parse(xml.GetNamedItem("Percent").Value),
                                            special = bool.Parse(xml.GetNamedItem("Special").Value),
                                            count = count,
                                            item = item
                                        });
                                    }
                                }
                                box.SetTopPercent();
                                boxes.Add(cupomId, box);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.error("[Box: " + cupomId + "] " + ex.ToString());
                    }
                }
                fileStream.Dispose();
                fileStream.Close();
            }
        }

        public static bool ContainsBox(int id)
        {
            return boxes.ContainsKey(id);
        }

        public static RandomBoxModel getBox(int id)
        {
            try
            {
                return boxes[id];
            }
            catch 
            { 
                return null; 
            }
        }
    }
}