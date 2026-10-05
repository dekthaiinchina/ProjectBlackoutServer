using ProjectBlackout.Battle.Data.Configs;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Sync.Client;
using ProjectBlackout.Battle.Network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ProjectBlackout.Battle.Data.Sync
{
    public class BattleSync
    {
        private static UdpClient udp;

        public static void Start()
        {
            try
            {
                udp = new UdpClient(BattleConfig.syncPort);
                uint IOC_IN = 0x80000000;
                uint IOC_VENDOR = 0x18000000;
                uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
                udp.Client.IOControl((int)SIO_UDP_CONNRESET, new byte[] { Convert.ToByte(false) }, null);
                new Thread(Read).Start();
                //Logger.debug("Server sync port: " + Config.syncPort);
            }
            catch (Exception e)
            {
                Logger.warning(e.ToString());
            }
        }

        public static void Read()
        {
            try
            {
                udp.BeginReceive(new AsyncCallback(AsyncCallback), null);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private static void AsyncCallback(IAsyncResult res)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 8000);
            byte[] received = udp.EndReceive(res, ref RemoteIpEndPoint);
            new Thread(Read).Start();
            if (received.Length >= 2)
            {
                LoadPacket(received);
            }
        }

        private static void LoadPacket(byte[] buffer)
        {
            ReceivePacket p = new ReceivePacket(buffer);
            short opcode = p.readH();
            if (opcode == 1)
            {
                RespawnSync.Load(p);
            }
            else if (opcode == 2)
            {
                RemovePlayerSync.Load(p);
            }
            else if (opcode == 3)
            {
                uint UniqueRoomId = p.readUD();
                uint Seed = p.readUD();
                int round = p.readC();
                Room room = RoomsManager.getRoom(UniqueRoomId, Seed);
                if (room != null)
                {
                    room.ServerRound = round;
                }
            }
        }

        public static void SendPortalPass(Room room, Player pl, int portalIdx)
        {
            if (room.RoomType != ROOM_STATE_TYPE.Boss)
            {
                return;
            }
            pl.Life = pl.MaxLife;
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            using (SendPacket p = new SendPacket())
            {
                p.writeH(1);
                p.writeH((short)room.RoomId);
                p.writeH((short)room.ChannelId);
                p.writeC((byte)pl.Slot);
                p.writeC((byte)portalIdx);
                SendData(room, s, p.mstream.ToArray());
            }
        }

        public static void SendDeathSync(Room room, Player killer, int objId, int weaponId, List<DeathServerData> deaths)
        {
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            using (SendPacket p = new SendPacket())
            {
                p.writeH(3);
                p.writeH((short)room.RoomId);
                p.writeH((short)room.ChannelId);
                p.writeC((byte)killer.Slot);
                p.writeC((byte)objId);
                p.writeD(weaponId);
                p.writeTVector(killer.Position);
                p.writeC((byte)deaths.Count);
                for (int i = 0; i < deaths.Count; i++)
                {
                    DeathServerData ob = deaths[i];
                    p.writeC((byte)AllUtils.getIdStatics(weaponId, 2));
                    p.writeC((byte)(((int)ob.DeathType * 16) + ob.Player.Slot));
                    p.writeTVector(ob.Player.Position);
                    p.writeC((byte)ob.Assist);
                }
                SendData(room, s, p.mstream.ToArray());
            }
        }

        public static void SendBombSync(Room room, Player pl, int type, int bombArea)
        {
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            using (SendPacket p = new SendPacket())
            {
                p.writeH(2);
                p.writeH((short)room.RoomId);
                p.writeH((short)room.ChannelId);
                p.writeC((byte)type);
                p.writeC((byte)pl.Slot);
                if (type == 0)
                {
                    p.writeC((byte)bombArea);
                    p.writeTVector(pl.Position);
                    room.BombPosition = pl.Position;
                }
                SendData(room, s, p.mstream.ToArray());
            }
        }

        public static void SendHitMarkerSync(Room room, Player pl, int deathType, int hitEnum, int damage)
        {
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            using (SendPacket p = new SendPacket())
            {
                p.writeH(4);
                p.writeH((short)room.RoomId);
                p.writeH((short)room.ChannelId);
                p.writeC((byte)pl.Slot);
                p.writeC((byte)deathType);
                p.writeC((byte)hitEnum);
                p.writeH((short)damage);
                SendData(room, s, p.mstream.ToArray());
            }
        }

        public static void SendSabotageSync(Room room, Player pl, int damage, int ultraSYNC)
        {
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            using (SendPacket p = new SendPacket())
            {
                p.writeH(5);
                p.writeH((short)room.RoomId);
                p.writeH((short)room.ChannelId);
                p.writeC((byte)pl.Slot);
                p.writeH((ushort)room.Bar1);
                p.writeH((ushort)room.Bar2);
                p.writeC((byte)ultraSYNC);
                p.writeH((ushort)damage);
                SendData(room, s, p.mstream.ToArray());
            }
        }

        private static void SendData(Room room, Socket socket, byte[] data)
        {
            if (BattleConfig.sendInfoToServ)
            {
                socket.SendTo(data, room.GameServer.Connection);
            }
        }
    }
}