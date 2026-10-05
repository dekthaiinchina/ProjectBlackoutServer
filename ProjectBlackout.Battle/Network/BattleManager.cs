using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Configs;
using System;
using System.Net;
using System.Net.Sockets;

namespace ProjectBlackout.Battle.Network
{
    public class BattleManager
    {
        private static UdpClient UdpClient;

        public static void Connect()
        {
            try
            {
                UdpClient = new UdpClient();
                uint IOC_IN = 0x80000000;
                uint IOC_VENDOR = 0x18000000;
                uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
                UdpClient.Client.IOControl((int)SIO_UDP_CONNRESET, new byte[] { Convert.ToByte(false) }, null);
                IPEndPoint LocalEP = new IPEndPoint(IPAddress.Parse(BattleConfig.hosIp), BattleConfig.hosPort);
                var UdpState = new UdpState(LocalEP, UdpClient);
                UdpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                UdpClient.Client.Bind(LocalEP);
                UdpClient.BeginReceive(AcceptCallback, UdpState);

                Logger.info("BattleManager started. [" + BattleConfig.hosIp + ":" + BattleConfig.hosPort + "]");
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString() + "\r\nAn error occurred while listing the Udp connections!!");
            }
        }

        private static void Read(UdpState state)
        {
            try
            {
                UdpClient.BeginReceive(new AsyncCallback(AcceptCallback), state);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            if (!ar.IsCompleted)
            {
                Logger.warning("Result is not completed.");
            }
            ar.AsyncWaitHandle.WaitOne(5000);
            DateTime now = DateTime.Now;
            IPEndPoint RecEP = new IPEndPoint(IPAddress.Any, 0);
            UdpClient Client = ((UdpState)ar.AsyncState).UdpClient;
            IPEndPoint LocalEP = ((UdpState)ar.AsyncState).EndPoint;
            try
            {
                byte[] Buffer = Client.EndReceive(ar, ref RecEP);
                if (Buffer.Length >= 22)
                {
                    new BattleHandler(UdpClient, Buffer, RecEP, now);
                }
                else
                {
                    Logger.warning("No Length (22) Buffer: " + BitConverter.ToString(Buffer));
                }
            }
            catch (Exception ex)
            {
                Logger.warning("Exception: " + RecEP.Address + ":" + RecEP.Port);
                Logger.warning(ex.ToString());
            }
            UdpState State = new UdpState(LocalEP, Client);
            Read(State);
        }

        public static void Send(byte[] data, IPEndPoint ip)
        {
            UdpClient.Send(data, data.Length, ip);
        }

        private class UdpState : object
        {
            public UdpState(IPEndPoint EndPoint, UdpClient UdpClient)
            {
                this.EndPoint = EndPoint;
                this.UdpClient = UdpClient;
            }

            public IPEndPoint EndPoint;
            public UdpClient UdpClient;
        }
    }
}