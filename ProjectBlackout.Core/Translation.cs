using System.Collections.Generic;
using System.IO;

namespace ProjectBlackout.Core
{
    public static class Translation
    {
        private static SortedList<string, string> strings = new SortedList<string,string>();

        public static void Load()
        {
            string[] lines = File.ReadAllLines("Config/Strings.ini");
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int idx = line.IndexOf("=");
                if (idx >= 0)
                {
                    string title = line.Substring(0, idx);
                    string text = line.Substring(idx + 1);
                    strings.Add(title, text);
                }
            }
        }

        public static string GetLabel(string title)
        {
            try
            {
                string value;
                if (strings.TryGetValue(title, out value))
                {
                    return value.Replace("\\n", ((char)0x0A).ToString());
                }
                return title;
            }
            catch
            {
                return title;
            }
        }

        public static string GetLabel(string title, params object[] args)
        {
            string text = GetLabel(title);
            return string.Format(text, args);
        }
    }
}