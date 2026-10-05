using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers.Server;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Auth.Data.Configs;
using ProjectBlackout.Auth.Data.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ProjectBlackout.Auth
{
    public class AuthManager
    {
        public static ServerConfig Config;
        public static Socket mainSocket;
        public static bool ServerIsClosed;
        public static ConcurrentDictionary<uint, AuthClient> _socketList = new ConcurrentDictionary<uint, AuthClient>();
        public static List<AuthClient> _loginQueue = new List<AuthClient>();

        public static bool Start()
        {
            try
            {
                Config = ServerConfigSyncer.GenerateConfig(AuthConfig.configId);
                mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint Local = new IPEndPoint(IPAddress.Parse(AuthConfig.authIp), AuthConfig.authPort);
                mainSocket.Bind(Local);
                mainSocket.Listen((int)SocketOptionName.MaxConnections);
                mainSocket.BeginAccept(new AsyncCallback(AcceptCallback), mainSocket);

                Logger.info("AuthManager started. [" + AuthConfig.authIp + ":" + AuthConfig.authPort + "]");

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
                    AuthClient client = new AuthClient(handler);
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

        public static void AddSocket(AuthClient sck)
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
            sck.Close(500, true);
        }

        public static int EnterQueue(AuthClient sck)
        {
            if (sck == null)
            {
                return -1;
            }
            lock (_loginQueue)
            {
                if (_loginQueue.Contains(sck))
                {
                    return -1;
                }
                _loginQueue.Add(sck);
                return _loginQueue.IndexOf(sck);
            }
        }

        public static bool RemoveSocket(AuthClient sck)
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
            if (_socketList.Count > 0)
            {
                byte[] code = packet.GetCompleteBytes("GameManager.SendPacketToAllClients");
                foreach (AuthClient client in _socketList.Values)
                {
                    Account player = client._player;
                    if (player != null && player._isOnline)
                    {
                        player.SendCompletePacket(code);
                        count++;
                    }
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
            foreach (AuthClient client in _socketList.Values)
            {
                Account player = client._player;
                if (player != null && player.player_id == accountId)
                {
                    return player;
                }
            }
            return null;
        }
    }
}