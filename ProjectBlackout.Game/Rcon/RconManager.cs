using Fleck;
using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Rcon.Packets;
using System;

namespace ProjectBlackout.Game.Rcon
{
    public class RconManager
    {
        private static RconManager Manager;
        public static RconManager Instance() 
            => Manager != null ? Manager : (Manager = new RconManager());

        private WebSocketServer Server;
        public RconManager()
        {
            try
            {
                FleckLog.Level = LogLevel.Error;

                Server = new WebSocketServer($"ws://{GameConfig.RconIp}:{GameConfig.RconPort}");
                Server.Start(Client =>
                {
                    Client.OnMessage = Message => Receive(Message, Client);
                });

                Logger.info($"RconManager started. [ws://{GameConfig.RconIp}:{GameConfig.RconPort}]");
            }
            catch(Exception Exc)
            {
                Logger.error("RconManager start: " + Exc.ToString());
            }
        }

        private void Receive(string Message, IWebSocketConnection Client)
        {
            try
            {
                if(!GameConfig.RconValidIps.Contains(Client.ConnectionInfo.ClientIpAddress))
                {
                    if(GameConfig.RconPrintNotValidIp)
                        Logger.warning("Received message from unlisted ip: " + Client.ConnectionInfo.ClientIpAddress);
                    return;
                }

                if (Message.Contains("|") && Message.Split('|').Length >= 2)
                {
                    string[] Pattern = Message.Split('|');

                    int Opcode = int.Parse(Pattern[0]);
                    string Password = Pattern[1];

                    if(Password != GameConfig.RconPassword)
                    {
                        Logger.warning("RconManager received request with wrong password: " + Password);
                        return;
                    }

                    RconReceive Receive = null;
                    switch(Opcode)
                    {
                        case 1: Receive = new RconSendMoney(); break;
                        case 2: Receive = new RconSendPoints(); break;
                        default: Logger.warning("RconManager received request with opcode: " + Opcode); break;
                    }

                    if(Receive != null)
                    {
                        Receive.Init(Pattern);
                        Receive.Run();
                        Receive = null;
                    }
                }
                else Logger.warning("RconManager received request with wrong message: " + Message);
            }
            catch (Exception Exc)
            {
                Logger.error("RconManager receive: " + Exc.ToString());
            }
        }
    }
}
