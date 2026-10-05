using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers.Server;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ProjectBlackout.Game
{
    public static class GameManager
    {
        public static ServerConfig Config;
        public static Socket mainSocket;
        public static bool ServerIsClosed;
        public static ConcurrentDictionary<uint, GameClient> _socketList = new ConcurrentDictionary<uint, GameClient>();

        public static bool Start()
        {
            try
            {
                Config = ServerConfigSyncer.GenerateConfig(GameConfig.configId);
                mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint Local = new IPEndPoint(IPAddress.Parse(GameConfig.gameIp), GameConfig.gamePort);
                mainSocket.Bind(Local);
                mainSocket.Listen((int)SocketOptionName.MaxConnections);
                mainSocket.BeginAccept(new AsyncCallback(AcceptCallback), mainSocket);


                Logger.info($"GameManager started. [{GameConfig.gameIp}:{GameConfig.gamePort}]");

                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        private static void AcceptCallback(IAsyncResult result)
        {
            if (ServerIsClosed)
            {
                return;
            }
            Socket clientSocket = (Socket)result.AsyncState;
            try
            {
                Socket handler = clientSocket.EndAccept(result);
                if (handler != null)
                {
                    GameClient client = new GameClient(handler);
                    AddSocket(client);
                    if (client == null)
                    {
                        Console.WriteLine("Destroyed after failed to add to list.");
                    }
                    Thread.Sleep(5);
                }
            }
            catch
            {
                Logger.warning("Failed a Client Connection");
            }
            mainSocket.BeginAccept(new AsyncCallback(AcceptCallback), mainSocket);
        }

        public static void AddSocket(GameClient sck)
        {
            if (sck == null)
            {
                return;
            }
            uint idx = 0;
            while (true)
            {
                if (idx >= 100000)
                {
                    break;
                }
                uint valor = ++idx;
                if (!_socketList.ContainsKey(valor) && _socketList.TryAdd(valor, sck))
                {
                    sck.SessionId = valor;
                    sck.Start();
                    return;
                }
            }
            sck.Close(500);
        }

        public static bool RemoveSocket(GameClient sck)
        {
            if (sck == null || sck.SessionId == 0)
            {
                return false;
            }
            if (_socketList.ContainsKey(sck.SessionId) && _socketList.TryGetValue(sck.SessionId, out sck))
            {
                return _socketList.TryRemove(sck.SessionId, out sck);
            }
            //Logger.warning("Session #" + session + " disconnected. (" + work + ")");
            return false;
        }

        public static int SendPacketToAllClients(SendPacket packet)
        {
            int count = 0;
            if (_socketList.Count == 0)
            {
                return count;
            }
            byte[] code = packet.GetCompleteBytes("GameManager.SendPacketToAllClients");
            foreach (GameClient client in _socketList.Values)
            {
                Account player = client._player;
                if (player != null && player._isOnline)
                {
                    player.SendCompletePacket(code);
                    count++;
                }
            }
            return count;
        }

        public static Account SearchActiveClient(long accountId)
        {
            if (_socketList.Count == 0)
            {
                return null;
            }
            foreach (GameClient client in _socketList.Values)
            {
                Account player = client._player;
                if (player != null && player.player_id == accountId)
                {
                    return player;
                }
            }
            return null;
        }

        public static Account SearchActiveClient(uint sessionId)
        {
            if (_socketList.Count == 0)
            {
                return null;
            }
            foreach (GameClient client in _socketList.Values)
            {
                if (client._player != null && client.SessionId == sessionId)
                {
                    return client._player;
                }
            }
            return null;
        }

        public static int KickActiveClient(double Hours)
        {
            int count = 0;
            DateTime now = DateTime.Now;
            foreach (GameClient client in _socketList.Values)
            {
                Account pl = client._player;
                if (pl != null && pl._room == null && pl.channelId > -1 && !pl.IsGM() && (now - pl.LastLobbyEnter).TotalHours >= Hours)
                {
                    count++;
                    pl.Close(5000);
                }
            }
            return count;
        }

        public static int KickCountActiveClient(double Hours)
        {
            int count = 0;
            DateTime now = DateTime.Now;
            foreach (GameClient client in _socketList.Values)
            {
                Account pl = client._player;
                if (pl != null && pl._room == null && pl.channelId > -1 && !pl.IsGM() && (now - pl.LastLobbyEnter).TotalHours >= Hours)
                {
                    count++;
                }
            }
            return count;
        }
    }
}