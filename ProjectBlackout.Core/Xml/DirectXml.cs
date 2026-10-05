using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace PointBlank.Core.Xml
{
    public class DirectXml
    {
        public static List<string> md5s = new List<string>();

        public static void Start()
        {
            string path = "Data/DirectX.xml";
            if (File.Exists(path))
            {
                Load(path);
            }
            else
            {
                Logger.error("File not found: " + path);
            }
        }

        public static bool IsValid(string md5)
        {
            if (string.IsNullOrEmpty(md5))
            {
                return true;
            }
            for (int i = 0; i < md5s.Count; i++)
            {
                if (md5s[i] == md5)
                {
                    return true;
                }
            }
            return false;
        }

        private static void Load(string path)
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
                                    if ("D3D9".Equals(xmlNode2.Name))
                                    {
                                        XmlNamedNodeMap xml = xmlNode2.Attributes;
                                        md5s.Add(xml.GetNamedItem("MD5").Value);
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