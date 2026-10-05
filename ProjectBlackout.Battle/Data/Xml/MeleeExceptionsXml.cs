using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ProjectBlackout.Battle.Data.Xml
{
    public class MeleeExceptionsXml
    {
        public static List<MeleeExcep> _items = new List<MeleeExcep>();

        public static bool Contains(int number)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                MeleeExcep exc = _items[i];
                if (exc.Number == number)
                {
                    return true;
                }
            }
            return false;
        }

        public static void Load()
        {
            string path = "Data/Battle/Exceptions.xml";
            if (File.Exists(path))
            {
                parse(path);
            }
            else
            {
                Logger.warning("File not found: " + path);
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
                                    if ("Weapon".Equals(xmlNode2.Name))
                                    {
                                        XmlNamedNodeMap xml = xmlNode2.Attributes;
                                        MeleeExcep item = new MeleeExcep
                                        {
                                            Number = int.Parse(xml.GetNamedItem("Number").Value)
                                        };
                                        _items.Add(item);
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
                fileStream.Dispose();
                fileStream.Close();
            }
        }
    }

    public class MeleeExcep
    {
        public int Number;
    }
}