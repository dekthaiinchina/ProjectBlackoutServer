using ProjectBlackout.Core;
using ProjectBlackout.Core.Network;
using Microsoft.Win32.SafeHandles;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network;
using ProjectBlackout.Game.Network.ClientPacket;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using ProjectBlackout.Game.Data.Configs;
using System.Reflection.Emit;
using System.Text;

namespace ProjectBlackout.Game
{
    public class GameClient : IDisposable
    {
        public long player_id;
        public Socket _client;
        public Account _player;
        public DateTime ConnectDate;
        public uint SessionId;
        public ushort SessionSeed;
        public int SetKey, firstPacketId;
        public byte[] lastCompleteBuffer;
        public bool disposed = false, closed = false;
        public SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

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
                player_id = 0;
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

        public GameClient(Socket client)
        {
            _client = client;
            _client.NoDelay = true; // NEWA05
        }

        public void Start()
        {
            ConnectDate = DateTime.Now;
            SetKey = 319394958;
            new Thread(new ThreadStart(() =>
            {
                Console.WriteLine("PROTOCOL_BASE_CONNECT_ACK");
                SendPacket(new PROTOCOL_BASE_CONNECT_ACK(this));

            })).Start();
            new Thread(new ThreadStart(BeginResult)).Start();
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
                if (GameConfig.debugMode)
                {
                    ushort opcode = BitConverter.ToUInt16(data, 2);
                    string debugData = "";
                    foreach (string str2 in BitConverter.ToString(data).Split('-', ',', '.', ':', '\t'))
                    {
                        debugData += " " + str2;
                    }
                    Logger.debug(string.Concat(new object[]
                    {
                            "[GameClient.SendCompletePacket] Address: ",
                            _client.RemoteEndPoint,
                            ", Opcode: [",
                            opcode,
                            "]"
                    }));
                }
                Console.WriteLine("do SendCompletePacket[]");
                _client.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), _client);
            }
            catch
            {
                Close(0);
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
                ushort size = Convert.ToUInt16(data.Length - 2);
                List<byte> list = new List<byte>(data.Length + 2);
                list.AddRange(BitConverter.GetBytes(size));
                list.AddRange(data);
                byte[] result = list.ToArray();
                if (GameConfig.debugMode)
                {
                    ushort opcode = BitConverter.ToUInt16(data, 0);
                    string debugData = "";
                    foreach (string str2 in BitConverter.ToString(result).Split('-', ',', '.', ':', '\t'))
                    {
                        debugData += " " + str2;
                    }
                    Logger.debug(string.Concat(new object[]
                    {
                            "[GameClient.SendPacket(byte[])] Address: ",
                            _client.RemoteEndPoint,
                            ", Opcode: [",
                            opcode,
                            "]"
                    }));
                }
                Console.WriteLine("do byte[]");
                if (result.Length > 0)
                {
                    _client.BeginSend(result, 0, result.Length, SocketFlags.None, new AsyncCallback(SendCallback), _client);
                }
                list.Clear();
            }
            catch
            {
                Close(0);
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

                    //Console.WriteLine("oldPacketData >>>>>>>>>>>>>>>>>> " + HexDump(oldPacketData));
                    //Console.WriteLine("newPacketData >>>>>>>>>>>>>>>>>> " + HexDump(newPacketData));



                    Logger.Cyan($"[S]: {bp.GetType().Name}\t\tData Length: {newPacketData.Length}");

                    if (newPacketData.Length > 0)
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
                Close(0);
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

        /*
        * + 3 encrypted 
        * + 5 not encrypted
        *
        * result = ((214013 * this[13526] + 2531011) >> 16) & 0x7FFF;
        *  bufferLength = (length & 0x8000) != 0 ? (length & 0x7FFF) + 3 : (length & 0x7FFF) + 5;
        */

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

                    if (EncryptedPackage)
                    {
                        byte[] babyBuffer = new byte[byteSize];
                        Array.Copy(asyncState.Buffer, 0, babyBuffer, 0, byteSize);

                        //Pacote recebido da client encriptado.
                        byte[] packetDataEncryted = new byte[PacketLengthTotal];
                        Array.Copy(asyncState.Buffer, 2, packetDataEncryted, 0, packetDataEncryted.Length);

                        //Pacote recebido da client e decriptado.
                        int shift = (int)SessionId % 7 + 1;
                        CBitRotDecryptor(packetDataEncryted, 0, 2048, shift);
                        RunPacket(packetDataEncryted);

                        //CheckOut(babyBuffer, PacketLengthTotal);
                    }
                }
            }
            catch
            {

            }
            new Thread(new ThreadStart(BeginResult)).Start();
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
                    index = rawData[j - 1];
                }
                rawData[j] = (byte)((index << (8 - shift)) | (rawData[j] >> shift));
            }
        }

        public void Close(int time, bool kicked = false)
        {
            try
            {
                if (!closed)
                {
                    try
                    {
                        closed = true;
                        GameManager.RemoveSocket(this);
                        Account p = _player;
                        if (player_id > 0 && p != null)
                        {
                            Channel ch = p.getChannel();
                            Room room = p._room;
                            Match match = p._match;
                            p.setOnlineStatus(false);
                            if (room != null)
                            {
                                room.RemovePlayer(p, false, kicked ? 1 : 0);
                            }
                            if (match != null)
                            {
                                match.RemovePlayer(p);
                            }
                            if (ch != null)
                            {
                                ch.RemovePlayer(p);
                            }
                            p._status.ResetData(player_id);

                            AllUtils.syncPlayerToFriends(p, false);
                            AllUtils.syncPlayerToClanMembers(p);

                            p.SimpleClear();
                            p.updateCacheInfo();
                            _player = null;
                        }
                        player_id = 0;
                        Console.WriteLine("Deconectado");
                    }
                    catch (Exception ex)
                    {
                        Logger.warning("PlayerId: " + player_id + "\n" + ex.ToString());
                    }
                }
                if (_client != null)
                {
                    _client.Close(time);
                }
                Dispose();
            }
            catch (Exception ex)
            {
                Logger.error("Close: " + ex.ToString());
            }
        }

        private void FirstPacketCheck(ushort packetId)
        {
            if (firstPacketId == 0)
            {
                firstPacketId = packetId;
                if (packetId != 538 && packetId != 517)
                {
                    Close(0, false);
                    Logger.warning("Connection destroyed due to unknown first packet. [" + packetId + "]");
                }
            }
        }

        private void RunPacket(byte[] buff)
        {
            ushort Opcode = BitConverter.ToUInt16(buff, 0);
            FirstPacketCheck(Opcode);
            if (closed)
            {
                return;
            }
            ReceivePacket packet = null;
            switch (Opcode)
            {
                case 515:
                    packet = new PROTOCOL_BASE_LOGOUT_REQ(this, buff); break;
                case 517:
                    packet = new PROTOCOL_BASE_PACKET_EMPTY_REQ(this, buff); break;
                case 520:
                //   packet = new PROTOCOL_BASE_GAMEGUARD_REQ(this, buff); break;
                case 530:
                    packet = new PROTOCOL_BASE_OPTION_SAVE_REQ(this, buff); break;
                case 534:
                    packet = new PROTOCOL_BASE_CREATE_NICK_REQ(this, buff); break;
                case 536:
                    packet = new PROTOCOL_BASE_USER_LEAVE_REQ(this, buff); break;
                case 538:
                    packet = new PROTOCOL_BASE_USER_ENTER_REQ(this, buff); break;
                case 540:
                    packet = new PROTOCOL_BASE_GET_CHANNELLIST_REQ(this, buff); break;
                case 542:
                    packet = new PROTOCOL_BASE_SELECT_CHANNEL_REQ(this, buff); break;
                case 544:
                    packet = new PROTOCOL_BASE_ATTENDANCE_REQ(this, buff); break;
                case 546:
                    packet = new PROTOCOL_BASE_ATTENDANCE_CLEAR_ITEM_REQ(this, buff); break;
                case 558:
                    packet = new PROTOCOL_BASE_GET_RECORD_INFO_DB_REQ(this, buff); break;
                case 568:
                    packet = new PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_REQ(this, buff); break;
                case 572:
                    packet = new PROTOCOL_BASE_QUEST_BUY_CARD_SET_REQ(this, buff); break;
                case 574:
                    packet = new PROTOCOL_BASE_QUEST_DELETE_CARD_SET_REQ(this, buff); break;
                case 584:
                    packet = new PROTOCOL_BASE_USER_TITLE_CHANGE_REQ(this, buff); break;
                case 586:
                    packet = new PROTOCOL_BASE_USER_TITLE_EQUIP_REQ(this, buff); break;
                case 588:
                    packet = new PROTOCOL_BASE_USER_TITLE_RELEASE_REQ(this, buff); break;
                case 592:
                    packet = new PROTOCOL_BASE_CHATTING_REQ(this, buff); break;
                case 600:
                    packet = new PROTOCOL_BASE_MISSION_SUCCESS_REQ(this, buff); break;
                case 633:
                    packet = new PROTOCOL_BASE_GET_USER_BASIC_INFO_REQ(this, buff); break;
                case 622:
                    packet = new PROTOCOL_BASE_DAILY_RECORD_REQ(this, buff); break;
                case 672:
                    packet = new PROTOCOL_BASE_PACKET_EMPTY_REQ(this, buff); break;
                case 685:
                    packet = new PROTOCOL_BASE_PACKET_EMPTY_REQ(this, buff); break;
                case 706:
                    packet = new PROTOCOL_BASE_PACKET_EMPTY_REQ(this, buff); break;
                case 718:
                    packet = new PROTOCOL_BASE_PACKET_EMPTY_REQ(this, buff); break;
                case 716:
                    packet = new PROTOCOL_BASE_PACKET_EMPTY_REQ(this, buff); break;
                case 787:
                    packet = new PROTOCOL_AUTH_FRIEND_INVITED_REQUEST_REQ(this, buff); break;
                case 792:
                    packet = new PROTOCOL_AUTH_FRIEND_ACCEPT_REQ(this, buff); break;
                case 794:
                    packet = new PROTOCOL_AUTH_FRIEND_INVITED_REQ(this, buff); break;
                case 796:
                    packet = new PROTOCOL_AUTH_FRIEND_DELETE_REQ(this, buff); break;
                case 802:
                    packet = new PROTOCOL_AUTH_RECV_WHISPER_REQ(this, buff); break;
                case 804:
                    packet = new PROTOCOL_AUTH_SEND_WHISPER_REQ(this, buff); break;
                case 809:
                    packet = new PROTOCOL_AUTH_FIND_USER_REQ(this, buff); break;
                case 929:
                    packet = new PROTOCOL_MESSENGER_NOTE_SEND_REQ(this, buff); break;
                case 931:
                    packet = new PROTOCOL_MESSENGER_NOTE_RECEIVE_REQ(this, buff); break;
                case 934:
                    packet = new PROTOCOL_MESSENGER_NOTE_CHECK_READED_REQ(this, buff); break;
                case 936:
                    packet = new PROTOCOL_MESSENGER_NOTE_DELETE_REQ(this, buff); break;
                case 1025:
                    packet = new PROTOCOL_SHOP_ENTER_REQ(this, buff); break;
                case 1027:
                    packet = new PROTOCOL_SHOP_LEAVE_REQ(this, buff); break;
                //case 1030:
                //   packet = new PROTOCOL_BASE_PACKET_EMPTY_REQ(this, buff); break;
                // case 1029:
                //   packet = new PROTOCOL_SHOP_GET_SAILLIST_REQ(this, buff); break;
                case 1041:
                    packet = new PROTOCOL_AUTH_SHOP_GET_GIFTLIST_REQ(this, buff); break;
                case 1043:
                    packet = new PROTOCOL_AUTH_SHOP_GOODS_BUY_REQ(this, buff); break;
                case 1047:
                    packet = new PROTOCOL_AUTH_SHOP_ITEM_AUTH_REQ(this, buff); break;
                case 1049:
                    packet = new PROTOCOL_INVENTORY_USE_ITEM_REQ(this, buff); break;
                case 1053:
                    packet = new PROTOCOL_AUTH_SHOP_AUTH_GIFT_REQ(this, buff); break;
                case 1055:
                    packet = new PROTOCOL_AUTH_SHOP_DELETE_ITEM_REQ(this, buff); break;
                case 1057:
                    packet = new PROTOCOL_AUTH_GET_POINT_CASH_REQ(this, buff); break;
                case 1061:
                    packet = new PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_REQ(this, buff); break;
                case 1075:
                    packet = new PROTOCOL_BASE_PACKET_EMPTY_REQ(this, buff); break;
                case 1076:
                    packet = new PROTOCOL_SHOP_REPAIR_REQ(this, buff); break;
                case 1084:
                    packet = new PROTOCOL_AUTH_SHOP_USE_GIFTCOUPON_REQ(this, buff); break;
                case 1087:
                    packet = new PROTOCOL_AUTH_SHOP_ITEM_CHANGE_DATA_REQ(this, buff); break;
                case 1793:
                    packet = new PROTOCOL_CS_CLIENT_ENTER_REQ(this, buff); break;
                case 1795:
                    packet = new PROTOCOL_CS_CLIENT_LEAVE_REQ(this, buff); break;
                case 1797:
                    packet = new PROTOCOL_CS_CLIENT_CLAN_LIST_REQ(this, buff); break;
                case 1799:
                    packet = new PROTOCOL_CS_CLIENT_CLAN_CONTEXT_REQ(this, buff); break;
                case 1824:
                    packet = new PROTOCOL_CS_DETAIL_INFO_REQ(this, buff); break;
                case 1826:
                    packet = new PROTOCOL_CS_MEMBER_CONTEXT_REQ(this, buff); break;
                case 1828:
                    packet = new PROTOCOL_CS_MEMBER_LIST_REQ(this, buff); break;
                case 1830:
                    packet = new PROTOCOL_CS_CREATE_CLAN_REQ(this, buff); break;
                case 1832:
                    packet = new PROTOCOL_CS_CLOSE_CLAN_REQ(this, buff); break;
                case 1834:
                    packet = new PROTOCOL_CS_CHECK_JOIN_AUTHORITY_ERQ(this, buff); break;
                case 1836:
                    packet = new PROTOCOL_CS_JOIN_REQUEST_REQ(this, buff); break;
                case 1838:
                    packet = new PROTOCOL_CS_CANCEL_REQUEST_REQ(this, buff); break;
                case 1840:
                    packet = new PROTOCOL_CS_REQUEST_CONTEXT_REQ(this, buff); break;
                case 1842:
                    packet = new PROTOCOL_CS_REQUEST_LIST_REQ(this, buff); break;
                case 1844:
                    packet = new PROTOCOL_CS_REQUEST_INFO_REQ(this, buff); break;
                case 1846:
                    packet = new PROTOCOL_CS_ACCEPT_REQUEST_REQ(this, buff); break;
                case 1849:
                    packet = new PROTOCOL_CS_DENIAL_REQUEST_REQ(this, buff); break;
                case 1852:
                    packet = new PROTOCOL_CS_SECESSION_CLAN_REQ(this, buff); break;
                case 1854:
                    packet = new PROTOCOL_CS_DEPORTATION_REQ(this, buff); break;
                case 1857:
                    packet = new PROTOCOL_CS_COMMISSION_MASTER_REQ(this, buff); break;
                case 1860:
                    packet = new PROTOCOL_CS_COMMISSION_STAFF_REQ(this, buff); break;
                case 1863:
                    packet = new PROTOCOL_CS_COMMISSION_REGULAR_REQ(this, buff); break;
                case 1878:
                    packet = new PROTOCOL_CS_CHATTING_REQ(this, buff); break;
                case 1880:
                    packet = new PROTOCOL_CS_CHECK_MARK_REQ(this, buff); break;
                case 1882:
                    packet = new PROTOCOL_CS_REPLACE_NOTICE_REQ(this, buff); break;
                case 1884:
                    packet = new PROTOCOL_CS_REPLACE_INTRO_REQ(this, buff); break;
                case 1892:
                    packet = new PROTOCOL_CS_REPLACE_MANAGEMENT_REQ(this, buff); break;
                case 1901:
                    packet = new PROTOCOL_CS_ROOM_INVITED_REQ(this, buff); break;
                case 1910:
                    packet = new PROTOCOL_CS_PAGE_CHATTING_REQ(this, buff); break;
                case 1912:
                    packet = new PROTOCOL_CS_INVITE_REQ(this, buff); break;
                case 1914:
                    packet = new PROTOCOL_CS_INVITE_ACCEPT_REQ(this, buff); break;
                case 1916:
                    packet = new PROTOCOL_CS_NOTE_REQ(this, buff); break;
                case 1936:
                    packet = new PROTOCOL_CS_CREATE_CLAN_CONDITION_REQ(this, buff); break;
                case 1938:
                    packet = new PROTOCOL_CS_CHECK_DUPLICATE_REQ(this, buff); break;
                case 1946:
                    packet = new PROTOCOL_CS_CLAN_LIST_DETAIL_INFO_REQ(this, buff); break;
                case 1954:
                    packet = new PROTOCOL_CS_CLAN_MATCH_RESULT_CONTEXT_REQ(this, buff); break;
                case 1956:
                    packet = new PROTOCOL_CS_CLAN_MATCH_RESULT_LIST_REQ(this, buff); break;
                case 3073:
                    packet = new PROTOCOL_LOBBY_ENTER_REQ(this, buff); break;
                case 3075:
                    packet = new PROTOCOL_LOBBY_LEAVE_REQ(this, buff); break;
                /*case 3077:
                    packet = new PROTOCOL_BASE_PACKET_EMPTY_REQ(this, buff); break;*/
                case 3077:
                    packet = new PROTOCOL_LOBBY_GET_ROOMLIST_REQ(this, buff); break;
                case 3083:
                    packet = new PROTOCOL_LOBBY_GET_ROOMINFOADD_REQ(this, buff); break;
                case 3093:
                    packet = new PROTOCOL_LOBBY_NEW_VIEW_USER_ITEM_REQ(this, buff); break;
                case 3095:
                    packet = new PROTOCOL_BASE_SELECT_AGE_REQ(this, buff); break;
                case 3329:
                    packet = new PROTOCOL_INVENTORY_ENTER_REQ(this, buff); break;
                case 3331:
                    packet = new PROTOCOL_INVENTORY_LEAVE_REQ(this, buff); break;
                case 3841:
                    packet = new PROTOCOL_ROOM_CREATE_REQ(this, buff); break;
                case 3843:
                    packet = new PROTOCOL_ROOM_JOIN_REQ(this, buff); break;
                case 3858:
                    packet = new PROTOCOL_ROOM_CHANGE_PASSWD_REQ(this, buff); break;
                case 3860:
                    packet = new PROTOCOL_ROOM_CHANGE_SLOT_REQ(this, buff); break;
                case 3865:
                    packet = new PROTOCOL_ROOM_PERSONAL_TEAM_CHANGE_REQ(this, buff); break;
                case 3869:
                    packet = new PROTOCOL_ROOM_INVITE_LOBBY_USER_LIST_REQ(this, buff); break;
                case 3875:
                    packet = new PROTOCOL_ROOM_REQUEST_MAIN_REQ(this, buff); break;
                case 3877:
                    packet = new PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_REQ(this, buff); break;
                case 3879:
                    packet = new PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_WHO_REQ(this, buff); break;
                case 3881:
                    packet = new PROTOCOL_ROOM_CHECK_MAIN_REQ(this, buff); break;
                case 3883:
                    packet = new PROTOCOL_ROOM_TOTAL_TEAM_CHANGE_REQ(this, buff); break;
                case 3893:
                    packet = new PROTOCOL_ROOM_CHANGE_ROOMINFO_REQ(this, buff); break;
                case 3911:
                    packet = new PROTOCOL_ROOM_LOADING_START_REQ(this, buff); break;
                case 3925:
                    packet = new PROTOCOL_ROOM_INFO_ENTER_REQ(this, buff); break;
                case 3927:
                    packet = new PROTOCOL_ROOM_INFO_LEAVE_REQ(this, buff); break;
                case 3929:
                    packet = new PROTOCOL_ROOM_GET_LOBBY_USER_LIST_REQ(this, buff); break;
                case 3931:
                    packet = new PROTOCOL_ROOM_CHANGE_COSTUME_REQ(this, buff); break;
                case 3933:
                    packet = new PROTOCOL_ROOM_SELECT_SLOT_CHANGE_REQ(this, buff); break;
                case 4097:
                    packet = new PROTOCOL_BATTLE_HOLE_CHECK_REQ(this, buff); break;
                case 4099:
                    packet = new PROTOCOL_BATTLE_READYBATTLE_REQ(this, buff); break;
                case 4105:
                    packet = new PROTOCOL_BATTLE_PRESTARTBATTLE_REQ(this, buff); break;
                case 4107:
                    packet = new PROTOCOL_BATTLE_STARTBATTLE_REQ(this, buff); break;
                case 4109:
                    packet = new PROTOCOL_BATTLE_GIVEUPBATTLE_REQ(this, buff); break;
                case 4111:
                    packet = new PROTOCOL_BATTLE_DEATH_REQ(this, buff); break;
                case 4113:
                    packet = new PROTOCOL_BATTLE_RESPAWN_REQ(this, buff); break;
                case 4119:
                    packet = new PROTOCOL_BATTLE_TIMEOUTCLIENT_REQ(this, buff); break;
                case 4121:
                    packet = new PROTOCOL_BASE_PACKET_EMPTY_REQ(this, buff); break;
                case 4122:
                    packet = new PROTOCOL_BATTLE_SENDPING_REQ(this, buff); break;
                case 4132:
                    packet = new PROTOCOL_BATTLE_MISSION_BOMB_INSTALL_REQ(this, buff); break;
                case 4134:
                    packet = new PROTOCOL_BATTLE_MISSION_BOMB_UNINSTALL_REQ(this, buff); break;
                case 4142:
                    packet = new PROTOCOL_BATTLE_MISSION_GENERATOR_INFO_REQ(this, buff); break;
                case 4144:
                    packet = new PROTOCOL_BATTLE_TIMERSYNC_REQ(this, buff); break;
                case 4148:
                    packet = new PROTOCOL_BATTLE_CHANGE_DIFFICULTY_LEVEL_REQ(this, buff); break;
                case 4150:
                    packet = new PROTOCOL_BATTLE_RESPAWN_FOR_AI_REQ(this, buff); break;
                case 4156:
                    packet = new PROTOCOL_BATTLE_MISSION_DEFENCE_INFO_REQ(this, buff); break;
                case 4158:
                    packet = new PROTOCOL_BATTLE_MISSION_TOUCHDOWN_COUNT_REQ(this, buff); break;
                case 4164:
                    packet = new PROTOCOL_BATTLE_MISSION_TUTORIAL_ROUND_END_REQ(this, buff); break;
                case 4238:
                    packet = new PROTOCOL_BATTLE_NEW_JOIN_ROOM_SCORE_REQ(this, buff); break;
                case 4252:
                    packet = new PROTOCOL_BATTLE_USER_SOPETYPE_REQ(this, buff); break;
                case 5377:
                    packet = new PROTOCOL_LOBBY_QUICKJOIN_ROOM_REQ(this, buff); break;
                case 6145:
                    packet = new PROTOCOL_CHAR_CREATE_CHARA_REQ(this, buff); break;
                case 6149:
                    packet = new PROTOCOL_CHAR_CHANGE_EQUIP_REQ(this, buff); break;
                case 6151:
                    packet = new PROTOCOL_CHAR_DELETE_CHARA_REQ(this, buff); break;
                case 6963:
                    packet = new PROTOCOL_CLAN_WAR_RESULT_REQ(this, buff); break;
                case 6914:
                    packet = new PROTOCOL_CLAN_WAR_MATCH_TEAM_COUNT_REQ(this, buff); break;
                case 1544:
                    packet = new PROTOCOL_CLAN_WAR_MATCH_TEAM_LIST_REQ(this, buff); break;
                case 1546:
                    packet = new PROTOCOL_CLAN_WAR_CREATE_TEAM_REQ(this, buff); break;
                case 1548:
                    packet = new PROTOCOL_CLAN_WAR_JOIN_TEAM_REQ(this, buff); break;
                case 1550:
                    packet = new PROTOCOL_CLAN_WAR_LEAVE_TEAM_REQ(this, buff); break;
                case 1553:
                    packet = new PROTOCOL_CLAN_WAR_MATCH_PROPOSE_REQ(this, buff); break;
                case 1558:
                    packet = new PROTOCOL_CLAN_WAR_INVITE_ACCEPT_REQ(this, buff); break;
                case 1565:
                    packet = new PROTOCOL_CLAN_WAR_CREATE_ROOM_REQ(this, buff); break;
                case 1567:
                    packet = new PROTOCOL_CLAN_WAR_JOIN_ROOM_REQ(this, buff); break;
                case 1569:
                    packet = new PROTOCOL_CLAN_WAR_MATCH_TEAM_INFO_REQ(this, buff); break;
                case 1571:
                    packet = new PROTOCOL_CLAN_WAR_INVITE_MERCENARY_RECEIVER_REQ(this, buff); break;
                case 1576:
                    packet = new PROTOCOL_CLAN_WAR_TEAM_CHATTING_REQ(this, buff); break;
                case 3396:
                    packet = new PROTOCOL_BATTLE_START_KICKVOTE_REQ(this, buff); break;
                case 3400:
                    packet = new PROTOCOL_BATTLE_NOTIFY_CURRENT_KICKVOTE_REQ(this, buff); break;
                case 3910:
                    packet = new PROTOCOL_BASE_PLAYTIME_REWARD_REQ(this, buff); break;
                case 3934:
                    packet = new PROTOCOL_BASE_PACKET_EMPTY_REQ(this, buff); break; // PROTOCOL_ROOM_GET_ACEMODE_PLAYERINFO_REQ
                case 3936:
                //  packet = new PROTOCOL_ROOM_MODE_ACE_CHANGE_SLOT_REQ(this, buff); break;
                default:
                    {
                        Logger.error("Opcode not found: " + Opcode);
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