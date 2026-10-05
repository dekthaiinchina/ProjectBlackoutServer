using Microsoft.Win32.SafeHandles;
using ProjectBlackout.Auth.Data.Configs;
using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Auth.Data.Sync;
using ProjectBlackout.Auth.Data.Sync.Server;
using ProjectBlackout.Auth.Network;
using ProjectBlackout.Auth.Network.ClientPacket;
using ProjectBlackout.Auth.Network.ServerPacket;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ProjectBlackout.Auth
{
    public class AuthClient : IDisposable
    {
        public Socket _client;
        public Account _player;
        public DateTime ConnectDate;
        public uint SessionId;
        public ushort SessionSeed;
        public int SetKey, firstPacketId;
        //private byte[] lastCompleteBuffer;
        private bool disposed = false, closed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            catch
            {

            }
        }

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (disposed)
                {
                    return;
                }
                _player = null;
                if (_client != null)
                {
                    _client.Dispose();
                    _client = null;
                }
                if (disposing)
                {
                    handle.Dispose();
                }
                disposed = true;
            }
            catch
            {

            }
        }


        public AuthClient(Socket client)
        {
            _client = client;
        }

        public void Start()
        {
            ConnectDate = DateTime.Now;
            SetKey = 319394958;
            new Thread(new ThreadStart(() =>
            {
                SendPacket(new PROTOCOL_BASE_CONNECT_ACK(this));
            })).Start();
            new Thread(new ThreadStart(BeginResult)).Start();
        }

        private void ConnectionCheck()
        {
            Thread.Sleep(10000);
            if (_client == null)
            {
                Logger.warning("Connection destroyed due to socket null.");
                AuthManager.RemoveSocket(this);
                Dispose();
            }
        }

        public string GetIPAddress()
        {
            try
            {
                if (_client != null && _client.RemoteEndPoint != null)
                {
                    return ((IPEndPoint)_client.RemoteEndPoint).Address.ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        public IPAddress GetAddress()
        {
            try
            {
                if (_client != null && _client.RemoteEndPoint != null)
                {
                    return ((IPEndPoint)_client.RemoteEndPoint).Address;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public void SendCompletePacket(byte[] data)
        {
            try
            {
                if (data.Length < 4)
                {
                    return;
                }
                //if (AuthConfig.debugMode)
                //{
                //    ushort opcode = BitConverter.ToUInt16(data, 2);
                //    string debugData = "";
                //    foreach (string str2 in BitConverter.ToString(data).Split('-', ',', '.', ':', '\t'))
                //    {
                //        debugData += " " + str2;
                //    }
                //    Logger.debug("Opcode: [" + opcode + "]");
                //}
                //_client.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), _client);
            }
            catch
            {
                Close(0, true);
            }
        }

        public void SendPacket(byte[] data)
        {
            try
            {
                if (data.Length < 2)
                {
                    return;
                }
                //ushort size = Convert.ToUInt16(data.Length - 2);
                //List<byte> list = new List<byte>(data.Length + 2);
                //list.AddRange(BitConverter.GetBytes(size));
                //list.AddRange(data);
                //byte[] result = list.ToArray();
                //if (AuthConfig.debugMode)
                //{
                //    ushort opcode = BitConverter.ToUInt16(data, 0);
                //    string debugData = "";
                //    foreach (string str2 in BitConverter.ToString(result).Split('-', ',', '.', ':', '\t'))
                //    {
                //        debugData += " " + str2;
                //    }
                //    Logger.debug("Opcode: [" + opcode + "]");
                //}
                //if (result.Length > 0)
                //{
                //    _client.BeginSend(result, 0, result.Length, SocketFlags.None, new AsyncCallback(SendCallback), _client);
                //}
                //list.Clear();
            }
            catch
            {
                Close(0, true);
            }
        }

        public void SendPacket(SendPacket bp)
        {
            try
            {
                using (bp)
                {
                    bp.write();
                    byte[] oldPacketData = bp.mstream.ToArray();
                    if (oldPacketData.Length < 2)
                    {
                        Console.WriteLine("Error");
                        return;
                    }
                    ushort opcode = BitConverter.ToUInt16(oldPacketData, 0);
                    int lengthBasic = oldPacketData.Length + 2;
                    byte[] PacketSize = BitConverter.GetBytes((ushort)lengthBasic); // converte o short em um array de bytes
                    byte[] newPacketData = new byte[oldPacketData.Length + PacketSize.Length];
                    Array.Copy(PacketSize, 0, newPacketData, 0, PacketSize.Length); // copia os bytes do short para o início do novo array
                    Array.Copy(oldPacketData, 0, newPacketData, PacketSize.Length, oldPacketData.Length); // copia os bytes do array original para o novo array após o short


                    byte[] bytesLogics = new byte[5]; // Novos bytes a serem adicionados

                    int tamanhoAntigo = oldPacketData.Length; // Armazena o tamanho antigo do array
                    Array.Resize(ref newPacketData, newPacketData.Length + bytesLogics.Length); // Redimensiona o array para adicionar os novos bytes

                    for (int i = 1; i <= bytesLogics.Length; i++)
                    {
                        newPacketData[tamanhoAntigo + i] = bytesLogics[i - 1]; // Adiciona os novos bytes ao array
                    }

                    Logger.Cyan($"[S]: {bp.GetType().Name}\t\tData Length: {newPacketData.Length}");

                    {
                        _client.BeginSend(newPacketData, 0, newPacketData.Length, SocketFlags.None, new AsyncCallback(SendCallback), _client);
                    }
                    bp.mstream.Close();
                    newPacketData = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                if (handler != null && handler.Connected)
                {
                    handler.EndSend(ar);
                }
            }
            catch
            {
                Close(0, true);
            }
        }

        private class StateSocket
        {
            public const int bufferSize = 8912; //8096
            public byte[] Buffer = new byte[bufferSize];
            public Socket client;
        }
        private void BeginResult()
        {
            try
            {
                StateSocket obj = new StateSocket();
                obj.client = _client;
                _client.BeginReceive(obj.Buffer, 0, StateSocket.bufferSize, SocketFlags.None, new AsyncCallback(OnReceiveCallback), obj);
            }
            catch
            {
            }
        }

        public void Close(int time, bool destroyConnection)
        {
            if (closed)
            {
                return;
            }
            try
            {
                closed = true;
                AuthManager.RemoveSocket(this);
                Account player = _player;
                if (destroyConnection)
                {
                    if (player != null)
                    {
                        player.setOnlineStatus(false);
                        if (player._status.serverId == 0)
                        {
                            SendRefresh.RefreshAccount(player, false);
                        }
                        player._status.ResetData(player.player_id);
                        player.SimpleClear();
                        player.updateCacheInfo();
                        _player = null;
                    }
                    _client.Close(time);
                    Thread.Sleep(time);
                    Dispose();
                }
                else if (player != null)
                {
                    player.SimpleClear();
                    player.updateCacheInfo();
                    _player = null;
                }
                AuthSync.UpdateGSCount(0);
            }
            catch (Exception ex)
            {
                Logger.warning("AuthClient.Close " + ex.ToString());
            }
        }

        /*
        * + 3 encrypted 
        * + 5 not encrypted
        *
        * result = ((214013 * this[13526] + 2531011) >> 16) & 0x7FFF;
        *  bufferLength = (length & 0x8000) != 0 ? (length & 0x7FFF) + 3 : (length & 0x7FFF) + 5;
        */

        //private void OnReceiveCallback(IAsyncResult ar)
        //{

        //    StateSocket asyncState = (StateSocket)ar.AsyncState;
        //    try
        //    {
        //        int byteSize = asyncState.client.EndReceive(ar);
        //        if (byteSize > 0)
        //        {
        //            int PacketLengthTotal = BitConverter.ToUInt16(asyncState.Buffer, 0) & 0x7FFF;
        //            bool EncryptedPackage = byteSize - PacketLengthTotal == 3;

        //            if (EncryptedPackage)
        //            {
        //                byte[] babyBuffer = new byte[byteSize];
        //                Array.Copy(asyncState.Buffer, 0, babyBuffer, 0, byteSize);

        //                //Pacote recebido da client encriptado.
        //                byte[] packetDataEncryted = new byte[PacketLengthTotal];
        //                Array.Copy(asyncState.Buffer, 2, packetDataEncryted, 0, packetDataEncryted.Length);

        //                //Pacote recebido da client e decriptado.
        //                int shift = (int)SessionId % 7 + 1;
        //                CBitRotDecryptor(packetDataEncryted, 0, 2048, shift);
        //                RunPacket(packetDataEncryted);

        //                //   CheckOut(babyBuffer, PacketLengthTotal);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    new Thread(new ThreadStart(BeginResult)).Start();
        //}

        private void OnReceiveCallback(IAsyncResult ar)
        {

            StateSocket asyncState = (StateSocket)ar.AsyncState;
            try
            {
                int byteSize = asyncState.client.EndReceive(ar);
                if (byteSize > 0)
                {
                    int PacketLengthTotal = BitConverter.ToUInt16(asyncState.Buffer, 0) & 0x7FFF;
                    bool EncryptedPackage = byteSize - PacketLengthTotal == 3;

                    byte[] babyBuffer = new byte[byteSize];
                    Array.Copy(asyncState.Buffer, 0, babyBuffer, 0, byteSize);

                    byte[] packetDataEncryted = new byte[PacketLengthTotal];
                    Array.Copy(asyncState.Buffer, 2, packetDataEncryted, 0, packetDataEncryted.Length);

                    int shift = (int)SessionId % 7 + 1;
                    CBitRotDecryptor(packetDataEncryted, 0, 2048, shift);

                    RunPacket(packetDataEncryted);
                    // CheckOut(babyBuffer, PacketLengthTotal);

                    if (EncryptedPackage)
                    {
                        Logger.warning("byteSize is a normal. : " + byteSize + ", PacketLengthTotal: " + PacketLengthTotal + ", difference: " + (byteSize - PacketLengthTotal));

                    }
                    else
                    {
                        Logger.warning("byteSize is a false : " + byteSize + ", PacketLengthTotal: " + PacketLengthTotal + ", difference: " + (byteSize - PacketLengthTotal));

                    }
                }
                new Thread(new ThreadStart(BeginResult)).Start();
            }
            catch (ObjectDisposedException)
            {
                Close(0, true);
            }
            catch (SocketException)
            {
                Close(0, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("OnReceiveCallback catch! : " + ex.ToString());
                Close(0, true);
            }
        }

        public void CheckOut(byte[] buffer, int FirstLength)
        {
            int tamanho = buffer.Length;
            try
            {
                byte[] newPacketENC = new byte[tamanho - FirstLength - 3];

                Array.Copy(buffer, FirstLength + 3, newPacketENC, 0, newPacketENC.Length);
                if (newPacketENC.Length == 0)
                {
                    return;
                }

                int lengthPK = BitConverter.ToUInt16(buffer, 0) & 0x7FFF;

                byte[] newPacketENC2 = new byte[lengthPK + 2];
                Array.Copy(buffer, 2, newPacketENC2, 0, newPacketENC2.Length);


                byte[] newPacketGO = new byte[lengthPK + 2];

                int shift = (int)SessionId % 7 + 1;
                CBitRotDecryptor(newPacketENC2, 0, 2048, shift);

                Array.Copy(newPacketENC2, 0, newPacketGO, 0, newPacketGO.Length);

                RunPacket(newPacketGO);
                CheckOut(buffer, lengthPK);
            }
            catch
            {
            }
        }
        public static void CBitRotDecryptor(IList<byte> rawData, int start, int blockSize, int shift)
        {
            int to = start + blockSize;

            if (rawData.Count < to)
            {
                to = rawData.Count;
            }

            byte last = rawData[to - 1];

            for (int j = to - 1; j >= start; j--)
            {
                int index;
                if (j <= start)
                {
                    index = last;
                }
                else
                {
                    index = (rawData[j - 1] & 255);
                }
                rawData[j] = (byte)((index << (8 - shift)) | ((rawData[j] & 255) >> shift));
            }
        }
        public static void CBitRotEncryptor(IList<byte> rawData, int start, int blockSize, int shift)
        {
            int total = start + blockSize;

            if (rawData.Count < total)
            {
                total = rawData.Count;
            }

            byte last = rawData[start];

            for (int j = start; j < total; j++)
            {
                int current;
                if (j >= total - 1)
                {
                    current = last;
                }
                else
                {
                    current = (rawData[j + 1] & 255);
                }
                rawData[j] = (byte)((current >> (8 - shift)) | ((rawData[j] & 255) << shift));
            }
        }

        public static byte[] BitRotateDecript(byte[] data, int shift)
        {
            byte[] newBuffer = new byte[data.Length];
            Array.Copy(data, 0, newBuffer, 0, newBuffer.Length);

            for (int i = newBuffer.Length - 1; i >= 0; --i)
            {
                int lastElement;
                if (i == 0)
                {
                    lastElement = newBuffer[newBuffer.Length - 1];
                }
                else
                {
                    lastElement = (newBuffer[i - 1] & 255);
                }
                newBuffer[i] = (byte)((lastElement << (8 - shift)) | ((newBuffer[i] & 255) >> shift));
                //Console.WriteLine("newBuffer >> ");
                //Console.WriteLine(HexDump(newBuffer));
            }
            return newBuffer;
        }

        private void FirstPacketCheck(ushort packetId)
        {
            if (firstPacketId != 0)
                return;
            firstPacketId = packetId;
            if (packetId == 257)
                return;
            Logger.warning("Connection destroyed due to unknown first packet. [" + packetId + "]");
            Close(0, true);
        }
        private void RunPacket(byte[] buff)
        {
            ushort opcode = BitConverter.ToUInt16(buff, 0);
            FirstPacketCheck(opcode);
            if (closed)
            {
                return;
            }
            ReceivePacket packet = null;
            switch (opcode)
            {
                case 257:
                    packet = new PROTOCOL_BASE_LOGIN_REQ(this, buff); break;
                case 515:
                    packet = new PROTOCOL_BASE_LOGOUT_REQ(this, buff); break;
                case 520:
                    packet = new PROTOCOL_BASE_GAMEGUARD_REQ(this, buff); break;
                case 522:
                    packet = new PROTOCOL_BASE_GET_SYSTEM_INFO_REQ(this, buff); break;
                case 524:
                    packet = new PROTOCOL_BASE_GET_USER_INFO_REQ(this, buff); break;
                case 526:
                    packet = new PROTOCOL_BASE_GET_INVEN_INFO_REQ(this, buff); break;
                case 528:
                    packet = new PROTOCOL_BASE_GET_OPTION_REQ(this, buff); break;
                case 530:
                    packet = new PROTOCOL_BASE_OPTION_SAVE_REQ(this, buff); break;
                case 536:
                    packet = new PROTOCOL_BASE_USER_LEAVE_REQ(this, buff); break;
                case 540:
                    packet = new PROTOCOL_BASE_GET_CHANNELLIST_REQ(this, buff); break;
                case 622:
                    packet = new PROTOCOL_BASE_DAILY_RECORD_REQ(this, buff); break;
                case 667: //Original 666
                    packet = new PROTOCOL_BASE_GET_MAP_INFO_REQ(this, buff); break;
                case 1057:
                    packet = new PROTOCOL_AUTH_GET_POINT_CASH_REQ(this, buff); break;
                //NEW
                case 607:
                    packet = new PROTOCOL_BASE_GAME_SERVER_STATE_REQ(this, buff); break;
                case 697:
                    packet = new PROTOCOL_BASE_SERVER_LIST_REFRESH_REQ(this, buff); break;
                case 7699:
                    packet = new PROTOCOL_7699_REQ(this, buff); break;

                //Deprecated
                case 5377:
                    packet = new PROTOCOL_LOBBY_QUICKJOIN_ROOM_REQ(this, buff); break;

                case 517:
                    if (packet != null)
                    {
                        ThreadPool.QueueUserWorkItem(delegate
                        {
                            RunPacket(buff);
                        });
                    }
                    break;
                default:
                    {
                        Logger.error("Opcode not found: " + opcode);
                        Console.WriteLine(HexDump(buff));
                        break;
                    }
            }
            if (packet != null)
            {
                Logger.Cyan($"[C]: {packet.GetType().Name}\t\tData Length: {buff.Length}");
                new Thread(packet.run).Start();
            }
        }
        public static string HexDump(byte[] bytes, int bytesPerLine = 16)
        {
            if (bytes == null) return "<null>";
            int bytesLength = bytes.Length;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                  8                   // 8 characters for the address
                + 3;                  // 3 spaces

            int firstCharColumn = firstHexColumn
                + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                + 2;                  // 2 spaces 

            int lineLength = firstCharColumn
                + bytesPerLine           // - characters to show the ascii value
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            return result.ToString();
        }
    }
}
