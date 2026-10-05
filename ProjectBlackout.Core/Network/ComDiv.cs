using Npgsql;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Sql;
using ProjectBlackout.Core.Xml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace ProjectBlackout.Core.Network
{
    public static class ComDiv
    {
        public static int GetItemCategory(int id)
        {
            int value = getIdStatics(id, 1);
            int type = value % 10000;
            if (value >= 1 && value <= 5)
            {
                return 1;
            }
            else if (value >= 6 && value <= 8)
            {
                return 2;
            }
            else if (value == 15)
            {
                return 2;
            }
            else if (value >= 26 && value <= 27)
            {
                return 2;
            }
            else if (type >= 7 && type <= 14)
            {
                return 2;
            }
            else if (value >= 16 && value <= 20)
            {
                return 3;
            }
            else if (value >= 28 && value <= 34)
            {
                return 3;
            }
            else
            {
                Logger.warning("Invalid Category [" + value + "]: " + id);
            }
            return 0;
        }

        public static int getIdStatics(int id, int type)
        {
            if (type == 1)
            {
                return id / 100000; // Item Class
            }
            else if (type == 2)
            {
                return (id % 100000) / 1000; // Class Type
            }
            else if (type == 3)
            {
                return id % 1000; // Number
            }
            else if (type == 4)
            {
                return id % 10000000 / 100000;
            }
            return 0;
        }

        public static int CreateItemId(int ItemClass, int ClassType, int Number)
        {
            return (ItemClass * 100000) + (ClassType * 1000) + Number;
        }

        public static ClassType getIdClassType(int id)
        {
            return (ClassType)((id % 100000) / 1000);
        }

        public static string arrayToString(byte[] buffer, int length)
        {
            string str = "";
            try
            {
                str = Encoding.Unicode.GetString(buffer, 0, length);
                int idx = str.IndexOf(char.MinValue);
                if (idx != -1)
                {
                    str = str.Substring(0, idx);
                }
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
            return str;
        }

        private static int ToByte(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return (c - '0');
            }
            if (c >= 'A' && c <= 'F')
            {
                return (c - 'A' + 10);
            }
            if (c >= 'a' && c <= 'f')
            {
                return (c - 'a' + 10);
            }
            return 0;
        }

        public static byte[] HexStringToByteArray(string hexString)
        {
            string enc = hexString.Replace(":", "").Replace("-", "").Replace(" ", "");
            int length = enc.Length;
            byte[] buffer = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                buffer[i / 2] = (byte)((ToByte(enc.ElementAt(i)) << 4) | ToByte(enc.ElementAt(i + 1)));
            }
            return buffer;
        }

        public static bool updateDB(string TABELA, string COLUNA, object VALOR)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@valor", VALOR);
                    command.CommandText = "UPDATE " + TABELA + " SET " + COLUNA + "=@valor";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error("[AllUtils.updateDB1] " + ex.ToString());
                return false;
            }
        }

        public static bool updateDB(string TABELA, string req1, object valorReq1, string[] COLUNAS, params object[] VALORES)
        {
            if (COLUNAS.Length > 0 && VALORES.Length > 0 && COLUNAS.Length != VALORES.Length)
            {
                Logger.error("[Update Database] Wrong values: " + String.Join(",", COLUNAS) + "/" + String.Join(",", VALORES));
                return false;
            }
            else if (COLUNAS.Length == 0 || VALORES.Length == 0)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    string loaded = "";
                    List<string> parameters = new List<string>();
                    for (int i = 0; i < VALORES.Length; i++)
                    {
                        object obj = VALORES[i];
                        string column = COLUNAS[i];
                        string param = "@valor" + i;
                        command.Parameters.AddWithValue(param, obj);
                        parameters.Add(column + "=" + param);
                    }
                    loaded = string.Join(",", parameters.ToArray());
                    command.Parameters.AddWithValue("@req1", valorReq1);
                    command.CommandText = "UPDATE " + TABELA + " SET " + loaded + " WHERE " + req1 + "=@req1";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error("[AllUtils.updateDB2] " + ex.ToString());
                return false;
            }
        }

        public static bool updateDB(string TABELA, string COLUNA, object VALOR, string req1, object valorReq1)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@valor", VALOR);
                    command.Parameters.AddWithValue("@req1", valorReq1);
                    command.CommandText = "UPDATE " + TABELA + " SET " + COLUNA + "=@valor WHERE " + req1 + "=@req1";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error("[AllUtils.updateDB3] " + ex.ToString());
                return false;
            }
        }

        public static bool updateDB(string TABELA, string req1, object valorReq1, string req2, object valorReq2, string[] COLUNAS, params object[] VALORES)
        {
            if (COLUNAS.Length > 0 && VALORES.Length > 0 && COLUNAS.Length != VALORES.Length)
            {
                Logger.error("[Update Database] Wrong values: " + String.Join(",", COLUNAS) + "/" + String.Join(",", VALORES));
                return false;
            }
            else if (COLUNAS.Length == 0 || VALORES.Length == 0)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    string loaded = "";
                    List<string> parameters = new List<string>();
                    for (int i = 0; i < VALORES.Length; i++)
                    {
                        object obj = VALORES[i];
                        string column = COLUNAS[i];
                        string param = "@valor" + i;
                        command.Parameters.AddWithValue(param, obj);
                        parameters.Add(column + "=" + param);
                    }
                    loaded = string.Join(",", parameters.ToArray());
                    if (req1 != null)
                    {
                        command.Parameters.AddWithValue("@req1", valorReq1);
                    }
                    if (req2 != null)
                    {
                        command.Parameters.AddWithValue("@req2", valorReq2);
                    }
                    if (req1 != null && req2 == null)
                    {
                        command.CommandText = "UPDATE " + TABELA + " SET " + loaded + " WHERE " + req1 + "=@req1";
                    }
                    else if (req2 != null && req1 == null)
                    {
                        command.CommandText = "UPDATE " + TABELA + " SET " + loaded + " WHERE " + req2 + "=@req2";
                    }
                    else if (req2 != null && req1 != null)
                    {
                        command.CommandText = "UPDATE " + TABELA + " SET " + loaded + " WHERE " + req1 + "=@req1 AND " + req2 + "=@req2";
                    }
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error("[AllUtils.updateDB4] " + ex.ToString());
                return false;
            }
        }

        public static bool updateDB(string TABELA, string req1, int[] valorReq1, string req2, object valorReq2, string[] COLUNAS, params object[] VALORES)
        {
            if (COLUNAS.Length > 0 && VALORES.Length > 0 && COLUNAS.Length != VALORES.Length)
            {
                Logger.error("[updateDB5] Wrong values: " + String.Join(",", COLUNAS) + "/" + String.Join(",", VALORES));
                return false;
            }
            else if (COLUNAS.Length == 0 || VALORES.Length == 0)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    string loaded = "";
                    List<string> parameters = new List<string>();
                    for (int i = 0; i < VALORES.Length; i++)
                    {
                        object obj = VALORES[i];
                        string column = COLUNAS[i];
                        string param = "@valor" + i;
                        command.Parameters.AddWithValue(param, obj);
                        parameters.Add(column + "=" + param);
                    }
                    loaded = string.Join(",", parameters.ToArray());

                    if (req1 != null)
                    {
                        command.Parameters.AddWithValue("@req1", valorReq1);
                    }
                    if (req2 != null)
                    {
                        command.Parameters.AddWithValue("@req2", valorReq2);
                    }
                    if (req1 != null && req2 == null)
                    {
                        command.CommandText = "UPDATE " + TABELA + " SET " + loaded + " WHERE " + req1 + " = ANY (@req1)";
                    }
                    else if (req2 != null && req1 == null)
                    {
                        command.CommandText = "UPDATE " + TABELA + " SET " + loaded + " WHERE " + req2 + "=@req2";
                    }
                    else if (req2 != null && req1 != null)
                    {
                        command.CommandText = "UPDATE " + TABELA + " SET " + loaded + " WHERE " + req1 + " = ANY (@req1) AND " + req2 + "=@req2";
                    }
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error("[AllUtils.updateDB5] " + ex.ToString());
                return false;
            }
        }

        public static bool updateDB(string TABELA, string COLUNA, object VALOR, string req1, object valorReq1, string req2, object valorReq2)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@valor", VALOR);
                    if (req1 != null)
                    {
                        command.Parameters.AddWithValue("@req1", valorReq1);
                    }
                    if (req2 != null)
                    {
                        command.Parameters.AddWithValue("@req2", valorReq2);
                    }
                    if (req1 != null && req2 == null)
                    {
                        command.CommandText = "UPDATE " + TABELA + " SET " + COLUNA + "=@valor WHERE " + req1 + "=@req1";
                    }
                    else if (req2 != null && req1 == null)
                    {
                        command.CommandText = "UPDATE " + TABELA + " SET " + COLUNA + "=@valor WHERE " + req2 + "=@req2";
                    }
                    else if (req2 != null && req1 != null)
                    {
                        command.CommandText = "UPDATE " + TABELA + " SET " + COLUNA + "=@valor WHERE " + req1 + "=@req1 AND " + req2 + "=@req2";
                    }
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error("[AllUtils.updateDB6] " + ex.ToString());
                return false;
            }
        }

        public static bool deleteDB(string TABELA, string req1, object valorReq1)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@req1", valorReq1);
                    command.CommandText = "DELETE FROM " + TABELA + " WHERE " + req1 + "=@req1";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static bool deleteDB(string TABELA, string req1, object valorReq1, string req2, object valorReq2)
        {
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    if (req1 != null)
                    {
                        command.Parameters.AddWithValue("@req1", valorReq1);
                    }
                    if (req2 != null)
                    {
                        command.Parameters.AddWithValue("@req2", valorReq2);
                    }
                    if (req1 != null && req2 == null)
                    {
                        command.CommandText = "DELETE FROM " + TABELA + " WHERE " + req1 + "=@req1";
                    }
                    else if (req2 != null && req1 == null)
                    {
                        command.CommandText = "DELETE FROM " + TABELA + " WHERE " + req2 + "=@req2";
                    }
                    else if (req2 != null && req1 != null)
                    {
                        command.CommandText = "DELETE FROM " + TABELA + " WHERE " + req1 + "=@req1 AND " + req2 + "=@req2";
                    }
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }

        public static bool deleteDB(string TABELA, string req1, object[] valorReq1, string req2, object valorReq2)
        {
            if (valorReq1.Length == 0)
            {
                return false;
            }
            try
            {
                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandType = CommandType.Text;

                    string loaded = "";
                    List<string> parameters = new List<string>();
                    for (int i = 0; i < valorReq1.Length; i++)
                    {
                        object obj = valorReq1[i];
                        string param = "@valor" + i;
                        command.Parameters.AddWithValue(param, obj);
                        parameters.Add(param);
                    }
                    loaded = string.Join(",", parameters.ToArray());
                    command.Parameters.AddWithValue("@req2", valorReq2);
                    command.CommandText = "DELETE FROM " + TABELA + " WHERE " + req1 + " in (" + loaded + ") AND " + req2 + "=@req2";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                return false;
            }
        }
        public static byte[] Decrypt(byte[] data, int shift)
        {
            byte[] newBuffer = new byte[data.Length];
            Array.Copy(data, 0, newBuffer, 0, newBuffer.Length);
            byte LastElement = newBuffer[newBuffer.Length - 1];
            for (int i = newBuffer.Length - 1; i > 0; i--)
            {
                newBuffer[i] = (byte)((newBuffer[i - 1] & 255) << 8 - shift | (newBuffer[i] & 255) >> shift);
            }
            newBuffer[0] = (byte)(LastElement << 8 - shift | (newBuffer[0] & 255) >> shift);
            return newBuffer;
        }
        public static DateTime GetLinkerTime(Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                stream.Read(buffer, 0, 2048);
            }

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return TimeZoneInfo.ConvertTimeFromUtc(epoch.AddSeconds(secondsSince1970), target ?? TimeZoneInfo.Local);
        }

        public static ushort getCardFlags(int missionId, int cardIdx, byte[] arrayList)
        {
            if (missionId == 0)
            {
                return 0;
            }
            int result = 0;
            List<Card> list = MissionCardXml.getCards(missionId, cardIdx);
            for (int i = 0; i < list.Count; i++)
            {
                Card card = list[i];
                if (arrayList[card._arrayIdx] >= card._missionLimit)
                {
                    result |= card._flag;
                }
            }
            return (ushort)result;
        }

        public static byte[] getCardFlags(int missionId, byte[] arrayList)
        {
            if (missionId == 0)
            {
                return new byte[20];
            }
            List<Card> list = MissionCardXml.getCards(missionId);
            if (list.Count == 0)
            {
                return new byte[20];
            }
            using (SendGPacket p = new SendGPacket(20))
            {
                int result = 0;
                for (int i = 0; i < 10; i++)
                {
                    List<Card> list2 = MissionCardXml.getCards(list, i);
                    for (int i2 = 0; i2 < list2.Count; i2++)
                    {
                        Card card = list2[i2];
                        if (arrayList[card._arrayIdx] >= card._missionLimit)
                        {
                            result |= card._flag;
                        }
                    }
                    p.writeH((ushort)result);
                    result = 0;
                }
                return p.mstream.ToArray();
            }
        }

        public static uint GetPlayerStatus(AccountStatus status, bool isOnline)
        {
            FriendState state;
            int serverId, channelId, roomId;

            GetPlayerLocation(status, isOnline, out state, out roomId, out channelId, out serverId);
            return GetPlayerStatus(roomId, channelId, serverId, (int)state);
        }

        public static uint GetPlayerStatus(int roomId, int channelId, int serverId, int stateId)
        {
            int p1 = ((stateId & 0xFF) << 28),
                 p2 = ((serverId & 0xFF) << 20),
                 p3 = ((channelId & 0xFF) << 12),
                 p4 = (roomId & 0xFFF);
            return (uint)(p1 | p2 | p3 | p4);
        }

        public static ulong GetPlayerStatus(int clanFId, int roomId, int channelId, int serverId, int stateId)
        {
            long p1 = ((clanFId & 0xFFFFFFFF) << 32),
                p2 = ((stateId & 0xFF) << 28),
                p3 = ((serverId & 0xFF) << 20),
                p4 = ((channelId & 0xFF) << 12),
                p5 = (roomId & 0xFFF);
            return (ulong)(p1 | p2 | p3 | p4 | p5);
        }

        public static ulong GetClanStatus(AccountStatus status, bool isOnline)
        {
            FriendState state;
            int serverId, channelId, roomId, clanFId;
            GetPlayerLocation(status, isOnline, out state, out roomId, out channelId, out serverId, out clanFId);
            return GetPlayerStatus(clanFId, roomId, channelId, serverId, (int)state);
        }

        public static ulong GetClanStatus(FriendState state)
        {
            return GetPlayerStatus(0, 0, 0, 0, (int)state);
        }

        public static uint GetFriendStatus(Friend f)
        {
            PlayerInfo info = f.player;
            if (info == null)
            {
                return 0;
            }
            FriendState state = 0;
            int serverId = 0, channelId = 0, roomId = 0;
            if (f.removed)
            {
                state = FriendState.Offline;
            }
            else if (f.state > 0)
            {
                state = (FriendState)f.state;
            }
            else
            {
                GetPlayerLocation(info._status, info._isOnline, out state, out roomId, out channelId, out serverId);
            }
            return GetPlayerStatus(roomId, channelId, serverId, (int)state);
        }

        public static uint GetFriendStatus(Friend f, FriendState stateN)
        {
            PlayerInfo info = f.player;
            if (info == null)
            {
                return 0;
            }
            FriendState state = stateN;
            int serverId = 0, channelId = 0, roomId = 0;
            if (f.removed)
            {
                state = FriendState.Offline;
            }
            else if (f.state > 0)
            {
                state = (FriendState)f.state;
            }
            else if (stateN == 0)
            {
                GetPlayerLocation(info._status, info._isOnline, out state, out roomId, out channelId, out serverId);
            }
            return GetPlayerStatus(roomId, channelId, serverId, (int)state);
        }

        public static void GetPlayerLocation(AccountStatus status, bool isOnline, out FriendState state, out int roomId, out int channelId, out int serverId)
        {
            roomId = 0;
            channelId = 0;
            serverId = 0;
            if (isOnline)
            {
                if (status.roomId != 255)
                {
                    roomId = status.roomId;
                    channelId = status.channelId;
                    state = FriendState.Room;
                }
                else if (status.roomId == 255 && status.channelId != 255)
                {
                    channelId = status.channelId;
                    state = FriendState.Lobby;
                }
                else if (status.roomId == 255 && status.channelId == 255)
                {
                    state = FriendState.Online;
                }
                else
                {
                    state = FriendState.Offline;
                }
                if (status.serverId != 255)
                {
                    serverId = status.serverId;
                }
            }
            else
            {
                state = FriendState.Offline;
            }
        }

        public static void GetPlayerLocation(AccountStatus status, bool isOnline, out FriendState state, out int roomId, out int channelId, out int serverId, out int clanFId)
        {
            roomId = 0;
            channelId = 0;
            serverId = 0;
            clanFId = 0;
            if (isOnline)
            {
                if (status.roomId != 255)
                {
                    roomId = status.roomId;
                    channelId = status.channelId;
                    state = FriendState.Room;
                }
                else if ((status.clanFId != 255 || status.roomId == 255) && status.channelId != 255)
                {
                    channelId = status.channelId;
                    state = FriendState.Lobby;
                }
                else if (status.roomId == 255 && status.channelId == 255)
                {
                    state = FriendState.Online;
                }
                else
                {
                    state = FriendState.Offline;
                }
                if (status.serverId != 255)
                {
                    serverId = status.serverId;
                }
                if (status.clanFId != 255)
                {
                    clanFId = status.clanFId + 1;
                }
            }
            else
            {
                state = FriendState.Offline;
            }
        }

        public static string gen5(string text)
        {
            using (var hmacMD5 = new HMACMD5(Encoding.UTF8.GetBytes("/x!a@r-$r%an¨.&e&+f*f(f(a)")))
            {
                byte[] data = hmacMD5.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}