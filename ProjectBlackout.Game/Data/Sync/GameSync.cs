using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers.Events;
using ProjectBlackout.Core.Managers.Server;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Models.Servers;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Sync.Client;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ProjectBlackout.Game.Data.Configs;
using System.Linq;

namespace ProjectBlackout.Game.Data.Sync
{
    public static class GameSync
    {
        private static DateTime LastSyncCount;
        public static UdpClient udp;

        public static void Start()
        {
            try
            {
                udp = new UdpClient(GameConfig.syncPort);
                uint IOC_IN = 0x80000000;
                uint IOC_VENDOR = 0x18000000;
                uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
                udp.Client.IOControl((int)SIO_UDP_CONNRESET, new byte[] { Convert.ToByte(false) }, null);
                new Thread(Read).Start();
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        public static void Read()
        {
            try
            {
                udp.BeginReceive(new AsyncCallback(AcceptCallback), null);
            }
            catch
            {

            }
        }

        private static void AcceptCallback(IAsyncResult res)
        {
            if (GameManager.ServerIsClosed)
            {
                return;
            }
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 8000);
            byte[] received = udp.EndReceive(res, ref RemoteIpEndPoint);
            Thread.Sleep(5);
            new Thread(Read).Start();
            if (received.Length >= 2)
            {
                LoadPacket(received);
            }
        }

        private static void LoadPacket(byte[] buffer)
        {
            ReceiveGPacket p = new ReceiveGPacket(buffer);
            short opcode = p.readH();
            try
            {
                if (opcode == 1)
                {
                    RoomPassPortal.Load(p);
                }
                else if (opcode == 2)
                {
                    RoomC4.Load(p);
                }
                else if (opcode == 3)
                {
                    RoomDeath.Load(p);
                }
                else if (opcode == 4)
                {
                    RoomHitMarker.Load(p);
                }
                else if (opcode == 5)
                {
                    RoomSabotageSync.Load(p);
                }
                else if (opcode == 10)
                {
                    Account player = AccountManager.getAccount(p.readQ(), true);
                    if (player != null)
                    {
                        player.SendPacket(new PROTOCOL_AUTH_ACCOUNT_KICK_ACK(1));
                        player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ERROR_ACK(0x80001000));
                        player.Close(1000);
                    }
                }
                else if (opcode == 11) //Request to sync a specific friend or clan info
                {
                    int type = p.readC();
                    int isConnect = p.readC();
                    Account player = AccountManager.getAccount(p.readQ(), 0);
                    if (player != null)
                    {
                        Account friendAcc = AccountManager.getAccount(p.readQ(), true);
                        if (friendAcc != null)
                        {
                            FriendState state = isConnect == 1 ? FriendState.Online : FriendState.Offline;
                            if (type == 0)
                            {
                                int idx = -1;
                                Friend friend = friendAcc.FriendSystem.GetFriend(player.player_id, out idx);
                                if (idx != -1 && friend != null && friend.state == 0)
                                {
                                    friendAcc.SendPacket(new PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(FriendChangeState.Update, friend, state, idx));
                                }
                            }
                            else
                            {
                                friendAcc.SendPacket(new PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK(player, state));
                            }
                        }
                    }
                }
                else if (opcode == 13)
                {
                    long playerId = p.readQ();
                    byte type = p.readC();
                    byte[] data = p.readB(p.readUH());
                    Account player = AccountManager.getAccount(playerId, true);
                    if (player != null)
                    {
                        if (type == 0)
                        {
                            player.SendPacket(data);
                        }
                        else
                        {
                            player.SendCompletePacket(data);
                        }
                    }
                }
                else if (opcode == 15)
                {
                    int serverId = p.readD();
                    int count = p.readD();
                    GameServerModel gs = ServersXml.getServer(serverId);
                    if (gs != null)
                    {
                        gs._LastCount = count;
                    }
                }
                else if (opcode == 16)
                {
                    ClanSync.Load(p);
                }
                else if (opcode == 17)
                {
                    FriendSync.Load(p);
                }
                else if (opcode == 18)
                {
                    InventorySync.Load(p);
                }
                else if (opcode == 19)
                {
                    PlayerSync.Load(p);
                }
                else if (opcode == 20)
                {
                    ServerWarning.LoadGMWarning(p);
                }
                else if (opcode == 21)
                {
                    ClanServersSync.Load(p);
                }
                else if (opcode == 22)
                {
                    ServerWarning.LoadShopRestart(p);
                }
                else if (opcode == 23)
                {
                    ServerWarning.LoadServerUpdate(p);
                }
                else if (opcode == 24)
                {
                    ServerWarning.LoadShutdown(p);
                }
                else if (opcode == 31)
                {
                    int type = p.readC();
                    EventLoader.ReloadEvent(type);
                    Logger.warning("GameSync - Reloaded event.");
                }
                else if (opcode == 32)
                {
                    int config = p.readC();
                    ServerConfigSyncer.GenerateConfig(config);
                    Logger.warning("GameSync - Reset (DB) settings.");
                }
                else
                {
                    Logger.warning("GameSync - Connection opcode not found: " + opcode);
                }
            }
            catch (Exception ex)
            {
                Logger.error("GameSync - Opcode: " + opcode + "\r\n" + ex.ToString());
                if (p != null)
                {
                    Logger.error("Buffer: " + BitConverter.ToString(p.getBuffer()));
                }
            }
        }

        public static void SendUDPPlayerSync(Room room, Slot slot, CouponEffects effects, int type)
        {
            try
            {
                using (SendGPacket pk = new SendGPacket())
                {
                    if (room != null && slot != null && room.UdpServer.Connection != null)
                    {
                        pk.writeH(1);
                        pk.writeD(room.UniqueRoomId);
                        pk.writeD(room.Seed);
                        pk.writeQ(room.StartTick);
                        pk.writeC((byte)type);
                        pk.writeC((byte)room.rounds);
                        pk.writeC((byte)slot._id);
                        pk.writeC((byte)slot.spawnsCount);
                        pk.writeC(BitConverter.GetBytes(slot._playerId)[0]);
                        if (type == 0 || type == 2)
                        {
                            WriteCharaInfo(pk, room, slot, effects);
                        }
                        SendPacket(pk.mstream.ToArray(), room.UdpServer.Connection);
                    }
                }
            }
            catch
            {

            }
        }

        private static void WriteCharaInfo(SendGPacket pk, Room room, Slot slot, CouponEffects effects)
        {
            try
            {
                int charaId = 0;
                if (room.RoomType == RoomType.Boss || room.RoomType == RoomType.CrossCounter)
                {
                    if (room.rounds == 1 && slot._team == 1 || room.rounds == 2 && slot._team == 0)
                    {
                        charaId = room.rounds == 2 ? slot._equip._red : slot._equip._blue;
                    }
                    else if (room.TRex == slot._id)
                    {
                        charaId = -1;
                    }
                    else
                    {
                        charaId = slot._equip._dino;
                    }
                }
                else
                {
                    charaId = slot._team == 0 ? slot._equip._red : slot._equip._blue;
                }
                int HPBonus = 0;
                if (effects.HasFlag(CouponEffects.HP5))
                {
                    HPBonus += 5;
                }
                if (effects.HasFlag(CouponEffects.HP10))
                {
                    HPBonus += 10;
                }
                if (charaId == -1)
                {
                    pk.writeC(255);
                    pk.writeH(65535);
                }
                else
                {
                    pk.writeC((byte)ComDiv.getIdStatics(charaId, 2));
                    pk.writeH((short)ComDiv.getIdStatics(charaId, 3));
                }
                pk.writeC((byte)HPBonus);
                pk.writeC(effects.HasFlag(CouponEffects.C4SpeedKit));
                pk.writeD(slot._equip._primary);
                pk.writeD(slot._equip._secondary);
                pk.writeD(slot._equip._melee);
                pk.writeD(slot._equip._grenade);
                pk.writeD(slot._equip._special);
            }
            catch
            {

            }
        }

        public static void SendUDPRoundSync(Room room)
        {
            try
            {
                using (SendGPacket pk = new SendGPacket())
                {
                    if (room != null)
                    {
                        pk.writeH(3);
                        pk.writeD(room.UniqueRoomId);
                        pk.writeD(room.Seed);
                        pk.writeC((byte)room.rounds);
                        SendPacket(pk.mstream.ToArray(), room.UdpServer.Connection);
                    }
                }
            }
            catch
            {

            }
        }

        public static GameServerModel GetServer(AccountStatus status)
        {
            return GetServer(status.serverId);
        }

        public static GameServerModel GetServer(int serverId)
        {
            if (serverId == 255 || serverId == GameConfig.serverId)
            {
                return null;
            }
            return ServersXml.getServer(serverId);
        }

        public static void UpdateGSCount(int serverId)
        {
            try
            {
                double pingMS = (DateTime.Now - LastSyncCount).TotalSeconds;
                if (pingMS < 5)
                {
                    return;
                }

                LastSyncCount = DateTime.Now;
                int players = 0;
                foreach (Channel ch in ChannelsXml._channels)
                {
                    players += ch._players.Count;
                    ComDiv.updateDB("channels", "online", ch._players.Count, "channel_id", ch._id);
                }
                for (int server = 0; server < ServersXml._servers.Count; server++)
                {
                    GameServerModel gs = ServersXml._servers[server];
                    if (gs._id == serverId)
                    {
                        gs._LastCount = players;
                    }
                    else
                    {
                        using (SendGPacket pk = new SendGPacket())
                        {
                            pk.writeH(15);
                            pk.writeD(serverId);
                            pk.writeD(players);
                            SendPacket(pk.mstream.ToArray(), gs.Connection);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning("[GameSync.UpdateGSCount] " + ex.ToString());
            }
        }

        public static void UpdatePartOfAuth(int Part)
        {
            try
            {
                for (int server = 0; server < ServersXml._servers.Count; server++)
                {
                    GameServerModel gs = ServersXml._servers[server];
                    if(gs._port == 39190)
                    {
                        using (SendGPacket pk = new SendGPacket())
                        {
                            pk.writeH(34);
                            pk.writeC((byte)Part);
                            SendPacket(pk.mstream.ToArray(), gs.Connection);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning("[GameSync.UpdatePartOfAuth] " + ex.ToString());
            }
        }

        public static void UpdateChannelUsers(int channelId, int count)
        {
            try
            {
                GameServerModel gs = ServersXml._servers.Where(x => x._id == 0).FirstOrDefault();

                if (gs != null)
                {
                    using (SendGPacket pk = new SendGPacket())
                    {
                        pk.writeH(33);
                        pk.writeD(channelId);
                        pk.writeD(count);
                        SendPacket(pk.mstream.ToArray(), gs.Connection);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Logger.warning("[GameSync.UpdateChannelUsers] " + ex.ToString());
            }
        }

        public static void SendBytes(long playerId, SendPacket sp, int serverId)
        {
            if (sp == null)
            {
                return;
            }
            GameServerModel gs = GetServer(serverId);
            if (gs == null)
            {
                return;
            }

            byte[] data = sp.GetBytes("GameSync.SendBytes");
            using (SendGPacket pk = new SendGPacket())
            {
                pk.writeH(13);
                pk.writeQ(playerId);
                pk.writeC(0);
                pk.writeH((ushort)data.Length);
                pk.writeB(data);
                SendPacket(pk.mstream.ToArray(), gs.Connection);
            }
        }

        public static void SendBytes(long playerId, byte[] buffer, int serverId)
        {
            if (buffer.Length == 0)
            {
                return;
            }
            GameServerModel gs = GetServer(serverId);
            if (gs == null)
            {
                return;
            }

            using (SendGPacket pk = new SendGPacket())
            {
                pk.writeH(13);
                pk.writeQ(playerId);
                pk.writeC(0);
                pk.writeH((ushort)buffer.Length);
                pk.writeB(buffer);
                SendPacket(pk.mstream.ToArray(), gs.Connection);
            }
        }

        public static void SendCompleteBytes(long playerId, byte[] buffer, int serverId)
        {
            if (buffer.Length == 0)
            {
                return;
            }
            GameServerModel gs = GetServer(serverId);
            if (gs == null)
            {
                return;
            }

            using (SendGPacket pk = new SendGPacket())
            {
                pk.writeH(13);
                pk.writeQ(playerId);
                pk.writeC(1);
                pk.writeH((ushort)buffer.Length);
                pk.writeB(buffer);
                SendPacket(pk.mstream.ToArray(), gs.Connection);
            }
        }

        public static void SendPacket(byte[] data, IPEndPoint ip)
        {
            udp.Send(data, data.Length, ip);
        }

        public static void genDeath(Room room, Slot killer, FragInfos kills, bool isSuicide)
        {
            int score;
            bool isBotMode = room.isBotMode();
            RoomDeath.RegistryFragInfos(room, killer, out score, isBotMode, isSuicide, kills);
            if (isBotMode)
            {
                killer.Score += killer.killsOnLife + room.IngameAiLevel + score;
                if (killer.Score > 65535)
                {
                    killer.Score = 65535;
                    Logger.warning("[PlayerId: " + killer._id + "] reached the maximum score of the BOT.");
                }
                kills.Score = killer.Score;
            }
            else
            {
                killer.Score += score;
                AllUtils.CompleteMission(room, killer, kills, MissionType.NA, 0);
                kills.Score = score;
            }
            using (PROTOCOL_BATTLE_DEATH_ACK packet = new PROTOCOL_BATTLE_DEATH_ACK(room, kills, killer, isBotMode))
            {
                room.SendPacketToPlayers(packet, SlotState.BATTLE, 0);
            }
            RoomDeath.EndBattleByDeath(room, killer, isBotMode, isSuicide);
        }
    }
}