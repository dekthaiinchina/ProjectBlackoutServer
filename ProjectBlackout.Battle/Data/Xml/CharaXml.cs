using ProjectBlackout.Battle.Data.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ProjectBlackout.Battle.Data.Xml
{
    public class CharaXml
    {
        public static List<CharaModel> _charas = new List<CharaModel>();

        public static int getLifeById(int charaId, int type)
        {
            for (int i = 0; i < _charas.Count; i++)
            {
                CharaModel chara = _charas[i];
                if (chara.Id == charaId && chara.Type == type)
                {
                    return chara.Life;
                }
            }
            return 100;
        }

        public static void Load()
        {
            string path = "Data/Battle/Charas.xml";
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
                                    if ("Chara".Equals(xmlNode2.Name))
                                    {
                                        XmlNamedNodeMap xml = xmlNode2.Attributes;
                                        CharaModel chara = new CharaModel
                                        {
                                            Id = int.Parse(xml.GetNamedItem("Id").Value),
                                            Type = int.Parse(xml.GetNamedItem("Type").Value),
                                            Life = int.Parse(xml.GetNamedItem("Life").Value)
                                        };
                                        _charas.Add(chara);
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
}