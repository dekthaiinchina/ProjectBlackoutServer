using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectBlackout.Core.Filters
{
    public static class NickFilter
    {
        public static List<string> _filter = new List<string>();

        public static void Load()
        {
            if (File.Exists("Data/Filters/Nicks.txt"))
            {
                string line;
                try
                {
                    using (StreamReader file = new StreamReader("Data/Filters/Nicks.txt"))
                    {
                        while ((line = file.ReadLine()) != null)
                        {
                            _filter.Add(line);
                        }
                        file.Close();
                    }
                }
                catch (Exception ex)
                {
                    Logger.error("Filter: " + ex.ToString());
                }
            }
            else
            {
                Logger.warning("Filter file does not exist.");
            }
        }
    }
}