using Microsoft.VisualBasic.Devices;
using ProjectBlackout.Auth.Data.Managers;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth
{
    public class Auth
    {
        public static async void Update()
        {
            while (true)
            {
                Console.Title = "ProjectBlackout - Auth [Users: " + AuthManager._socketList.Count + " Online: " + ServersXml.getServer(0)._LastCount + " Used RAM: " + (GC.GetTotalMemory(true) / 1024) + " KB]";
                await Task.Delay(1000);
            }
        }
    }
}