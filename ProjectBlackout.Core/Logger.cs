using System;
using System.IO;
using System.Text;

namespace ProjectBlackout.Core
{
    public static class Logger
    {
        private static string Date = DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");
        public static string StartedFor = "None";
        private static object Sync = new object();
        public static bool erro;
        public static void title(string text, ConsoleColor color) => Logger.write(text, color);

        public static void LogLogin(string text)
        {
            try
            {
                save("[Date: " + DateTime.Now.ToString("dd/MM/yy HH:mm") + "] Login: " + text, "Login");
            }
            catch
            {

            }
        }

        public static void LogProblems(string text, string problemInfo)
        {
            try
            {
                save("[Data: " + DateTime.Now.ToString("yy/MM/dd HH:mm:ss") + "]" + text, problemInfo);
            }
            catch
            {

            }
        }

        public static void LogCMD(string text)
        {
            try
            {
                save(text, "Command");
            }
            catch
            {

            }
        }

        public static void LogCMDPlayer(string text)
        {
            try
            {
                save(text, "Player");
            }
            catch
            {

            }
        }

        public static void LogConsole(string text, string Result)
        {
            try
            {
                save("[" + DateTime.Now.ToString("yy/MM/dd HH:mm:ss") + "] Command: " + text + " Result: " + Result, "Console");
            }
            catch
            {

            }
        }

        public static void LogHack(string text)
        {
            try
            {
                save("[" + DateTime.Now.ToString("yy/MM/dd HH:mm:ss") + "]: " + text, "Hack");
            }
            catch
            {

            }
        }

        /*public static void LogRoom(string text, uint startDate, uint uniqueRoomId)
        {
            try
            {
                save(text, startDate, uniqueRoomId);
            }
            catch
            {

            }
        }*/

        public static void Xyan(string text)
        {
            write(DateTime.Now.ToString("HH:mm:ss ") + text, ConsoleColor.Cyan);
        }

        public static void title(string text)
        {
            write(text, ConsoleColor.Green);
        }

        public static void White(string text)
        {
            write(text, ConsoleColor.White);
        }

        public static void DarkRed(string text)
        {
            write(text, ConsoleColor.DarkRed);
        }

        public static void RedNew(string text)
        {
            write(DateTime.Now.ToString("HH:mm:ss ") + "[Login] " + text, ConsoleColor.Red);
        }

        public static void Red(string text)
        {
            write(text, ConsoleColor.Red);
        }

        public static void YellowNew(string text)
        {
            write(DateTime.Now.ToString("HH:mm:ss ") + "[Login] " + text, ConsoleColor.Yellow);
        }

        public static void GreenNew(string text)
        {
            write(DateTime.Now.ToString("HH:mm:ss ") + "[Login] " + text, ConsoleColor.Green);
        }

        public static void Yellow(string text)
        {
            write(text, ConsoleColor.Yellow);
        }

        public static void Green(string text)
        {
            write(text, ConsoleColor.Green);
        }

        public static void Cyan(string text)
        {
            write(text, ConsoleColor.Cyan);
        }

        public static void Blue(string text)
        {
            write(text, ConsoleColor.Blue);
        }

        public static void Pink(string text)
        {
            write(text, ConsoleColor.Magenta);
        }

        public static void info(string text)
        {
            write(DateTime.Now.ToString("HH:mm:ss ") + "[Info] " + text, ConsoleColor.Gray);
        }

        public static void warning(string text)
        {
            write(DateTime.Now.ToString("HH:mm:ss ") + "[Warning] " + text, ConsoleColor.Yellow);
        }

        public static void console(string text)
        {
            write(DateTime.Now.ToString("HH:mm:ss ") + "[Console] " + text, ConsoleColor.Cyan);
        }

        public static void error(string text)
        {
            write(DateTime.Now.ToString("HH:mm:ss ") + "[Error] " + text, ConsoleColor.Red);
        }

        public static void debug(string text)
        {
            write(DateTime.Now.ToString("HH:mm:ss ") + "[Debug] " + text, ConsoleColor.Green);
        }

        public static void IP_S(string text)
        {
            write(DateTime.Now.ToString("HH:mm:ss ") + "[IP] " + text, ConsoleColor.Green);
        }

        public static void IP_X(string text)
        {
            write(DateTime.Now.ToString("HH:mm:ss ") + "[IP] " + text, ConsoleColor.Cyan);
        }

        public static void send(string text)
        {
            write(text, ConsoleColor.Gray);
        }

        public static void Print(string text, ConsoleColor color)
        {
            Write(DateTime.Now.ToString("HH:mm:ss ") + "[Time] " + text, color);
        }
        public static void PrintLine(string text, ConsoleColor color)
        {
            WriteLine(DateTime.Now.ToString("HH:mm:ss ") + "[Time] " + text, color);
        }

        private static void Write(string text, ConsoleColor color)
        {
            try
            {
                lock (Sync)
                {
                    System.Console.ForegroundColor = color;
                    System.Console.Write(text);
                    System.Console.ResetColor();
                    save(text, StartedFor);
                }
            }
            catch
            {

            }
        }
        private static void WriteLine(string text, ConsoleColor color)
        {
            try
            {
                lock (Sync)
                {
                    System.Console.ForegroundColor = color;
                    System.Console.WriteLine(text);
                    System.Console.ResetColor();
                    save(text, StartedFor);
                }
            }
            catch
            {

            }
        }

        public static void unkhown_packet(string text)
        {
            write(text, ConsoleColor.Green);
        }

        private static void write(string text, ConsoleColor color)
        {
            try
            {
                lock (Sync)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine(text);
                    save(text, StartedFor);
                }
            }
            catch
            {

            }
        }

        public static void checkDirectorys()
        {
            try
            {
                if (StartedFor == "Auth")
                {
                    if (!Directory.Exists("Logs/Auth"))
                    {
                        Directory.CreateDirectory("Logs/Auth");
                    }
                    if (!Directory.Exists("Logs/Login"))
                    {
                        Directory.CreateDirectory("Logs/Login");
                    }
                }
                else
                {
                    if (!Directory.Exists("Logs/Command"))
                    {
                        Directory.CreateDirectory("Logs/Command");
                    }
                    if (!Directory.Exists("Logs/Console"))
                    {
                        Directory.CreateDirectory("Logs/Console");
                    }
                    if (!Directory.Exists("Logs/Player"))
                    {
                        Directory.CreateDirectory("Logs/Player");
                    }
                    if (!Directory.Exists("Logs/Game"))
                    {
                        Directory.CreateDirectory("Logs/Game");
                    }
                    if (!Directory.Exists("Logs/ErrorC"))
                    {
                        Directory.CreateDirectory("Logs/ErrorC");
                    }
                    if (!Directory.Exists("Logs/Hack"))
                    {
                        Directory.CreateDirectory("Logs/Hack");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /*public static void save(string text, uint dateTime, ulong roomId)
        {
            using (FileStream fileStream = new FileStream("Logs/Rooms/" + dateTime + "-" + roomId + ".log", FileMode.Append))
            using (StreamWriter stream = new StreamWriter(fileStream))
            {
                try
                {
                    if (stream != null)
                    {
                        //string msg = Encoding.GetEncoding("ISO-8859-11").GetString(ConfigGB.EncodeText.GetBytes(text));
                        stream.WriteLine(text);
                    }
                }
                catch
                {

                }
                stream.Flush();
                stream.Close();
                fileStream.Flush();
                fileStream.Close();
            }
        }
        */

        public static void save(string text, string type)
        {
            using (FileStream fileStream = new FileStream("Logs/" + type + "/" + Date + ".log", FileMode.Append))
            using (StreamWriter stream = new StreamWriter(fileStream))
            {
                try
                {
                    if (stream != null)
                    {
                        //string msg = Encoding.GetEncoding("ISO-8859-11").GetString(ConfigGB.EncodeText.GetBytes(text));
                        stream.WriteLine(text);
                    }
                }
                catch
                {

                }
                stream.Flush();
                stream.Close();
                fileStream.Flush();
                fileStream.Close();
            }
        }
    }
}