using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_TIMERSYNC_REQ : ReceivePacket
    {
        private float Value;
        private uint TimeRemaining;
        private int Ping, Hack, Latency, Round;
        private DateTime LastTimeSync;

        public PROTOCOL_BATTLE_TIMERSYNC_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            TimeRemaining = readUD();
            Value = readT();
            Round = readC();
            Ping = readC();
            Hack = readC();
            Latency = readH();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;

                PlayerOnline();

                if (p == null)
                {
                    return;
                }
                Room room = p._room;
                if (room == null)
                {
                    return;
                }
                bool isBotMode = room.isBotMode();
                Slot slot = room.getSlot(p._slotId);
                if (slot == null || slot.state != SlotState.BATTLE)
                {
                    return;
                }
                if (Value != 1 || Hack != 0)
                {
                    if (GameConfig.AutoBan)
                    {
                        if (ComDiv.updateDB("players", "access_level", -1, "player_id", p.player_id))
                        {
                            BanManager.SaveAutoBan(p.player_id, p.login, p.player_name, "Hack detected. 1: " + Hack + " (2: " + Value + ")", DateTime.Now.ToString("dd -MM-yyyy HH:mm:ss"), p.PublicIP.ToString(), "Ban from Server");
                            using (PROTOCOL_LOBBY_CHATTING_ACK packet = new PROTOCOL_LOBBY_CHATTING_ACK("Server", 0, 1, false, "User '" + p.player_name + "' banned for possible hack"))
                            {
                                GameManager.SendPacketToAllClients(packet);
                            }
                            p.access = (int) AccessLevel.Banned;
                            p.SendPacket(new PROTOCOL_AUTH_ACCOUNT_KICK_ACK(2), false);
                            p.Close(1000, true);
                        }
                    }
                    Logger.LogHack("[Value: " + Value + " HackType: " + Hack + " (" + (HackType)Hack + ")] Player: " + p.player_name + " Id: " + p.player_id + " Login: " + p.login);
                }
                room._timeRoom = TimeRemaining;
                SyncPlayerPings(p, room, slot, isBotMode);
                if ((TimeRemaining == 0 || TimeRemaining > 0x80000000) && !room.swapRound && CompareRounds(room, Round) && room.RoomState == RoomState.Battle)
                {
                    EndRound(room, isBotMode);
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_BATTLE_TIMERSYNC_REQ: " + ex.ToString());
            }
        }

        private void PlayerOnline()
        {
            double secs = (DateTime.Now - LastTimeSync).TotalSeconds;
            if (secs < 60)
                return;
            LastTimeSync = DateTime.Now;

            foreach (Channel ch in ChannelsXml._channels)
            {
                ComDiv.updateDB("channels", "online", ch._players.Count, "channel_id", ch._id);
            }
        }

        private void SyncPlayerPings(Account p, Room room, Slot slot, bool isBotMode)
        {
            if (isBotMode)
            {
                return;
            }
            slot.latency = Latency;
            slot.ping = 5;
            if (slot.latency >= GameConfig.maxBattleLatency)
            {
                slot.failLatencyTimes++;
            }
            else
            {
                slot.failLatencyTimes = 0;
            }

            if (p.DebugPing && (DateTime.Now - p.LastPingDebug).TotalSeconds >= 5)
            {
                p.LastPingDebug = DateTime.Now;
                p.SendPacket(new PROTOCOL_LOBBY_CHATTING_ACK("Server", 0, 5, false, Latency + "ms (" + Ping + " bar)"));
            }

            if (slot.failLatencyTimes >= GameConfig.maxRepeatLatency)
            {
                Logger.error("Player: '" + p.player_name + "' (Id: " + slot._playerId + ") kicked due to high latency. (" + slot.latency + "/" + GameConfig.maxBattleLatency + "ms)");
                _client.Close(500);
                return;
            }
            else
            {
                double secs = (DateTime.Now - room.LastPingSync).TotalSeconds;
                if (secs < 7) 
                    return;

                byte[] Pings = new byte[16];
                for (int i = 0; i < 16; i++)
                    Pings[i] = (byte)room._slots[i].ping;

                using (PROTOCOL_BATTLE_SENDPING_ACK packet = new PROTOCOL_BATTLE_SENDPING_ACK(Pings))
                    room.SendPacketToPlayers(packet, SlotState.BATTLE, 0);

                room.LastPingSync = DateTime.Now;
            }
        }

        private bool CompareRounds(Room room, int externValue)
        {
            return (room.rounds == externValue);
        }

        private void EndRound(Room room, bool isBotMode)
        {
            try
            {
                room.swapRound = true;
                if (room.RoomType == RoomType.Boss || room.RoomType == RoomType.CrossCounter)
                {
                    if (room.rounds == 1)
                    {
                        room.rounds = 2;
                        foreach (Slot slot in room._slots)
                        {
                            if (slot.state == SlotState.BATTLE)
                            {
                                slot.killsOnLife = 0;
                                slot.lastKillState = 0;
                                slot.repeatLastState = false;
                            }
                        }
                        List<int> dinos = AllUtils.getDinossaurs(room, true, -2);
                        using (PROTOCOL_BATTLE_MISSION_ROUND_END_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_END_ACK(room, 2, RoundEndType.TimeOut))
                        using (PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK packet2 = new PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK(room, dinos, isBotMode))
                        {
                            room.SendPacketToPlayers(packet, packet2, SlotState.BATTLE, 0);
                        }

                        room.round.Start(5250, (callbackState) =>
                        {
                            if (room.RoomState == RoomState.Battle)
                            {
                                room.BattleStart = DateTime.Now.AddSeconds(5);
                                using (PROTOCOL_BATTLE_MISSION_ROUND_START_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(room))
                                {
                                    room.SendPacketToPlayers(packet, SlotState.BATTLE, 0);
                                }
                            }
                            room.swapRound = false;
                            lock (callbackState)
                            {
                                room.round.Timer = null;
                            }
                        });
                    }
                    else if (room.rounds == 2)
                    {
                        AllUtils.EndBattle(room, isBotMode);
                    }
                }
                else if (room.thisModeHaveRounds())
                {
                    int winner = 1;
                    if (room.RoomType != RoomType.Destroy)
                    {
                        room.blue_rounds++;
                    }
                    else
                    {
                        if (room.Bar1 > room.Bar2)
                        {
                            room.red_rounds++;
                            winner = 0;
                        }
                        else if (room.Bar1 < room.Bar2)
                        {
                            room.blue_rounds++;
                        }
                        else
                        {
                            winner = 2;
                        }
                    }
                    AllUtils.BattleEndRound(room, winner, RoundEndType.TimeOut);
                }
                else
                {
                    List<Account> players = room.getAllPlayers(SlotState.READY, 1);
                    if (players.Count == 0)
                    {
                        goto EndLabel;
                    }
                    TeamResultType winnerTeam = AllUtils.GetWinnerTeam(room);
                    room.CalculateResult(winnerTeam, isBotMode);
                    using (PROTOCOL_BATTLE_MISSION_ROUND_END_ACK packet = new PROTOCOL_BATTLE_MISSION_ROUND_END_ACK(room, winnerTeam, RoundEndType.TimeOut))
                    {
                        ushort inBattle, missionCompletes;
                        AllUtils.getBattleResult(room, out missionCompletes, out inBattle);
                        byte[] data = packet.GetCompleteBytes("PROTOCOL_BATTLE_TIMERSYNC_REQ");
                        foreach (Account pR in players)
                        {
                            if (room._slots[pR._slotId].state == SlotState.BATTLE)
                            {
                                pR.SendCompletePacket(data);
                            }
                            pR.SendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(pR, winnerTeam, inBattle, missionCompletes, isBotMode));
                        }
                    }
                EndLabel:
                    AllUtils.resetBattleInfo(room);
                }
            }
            catch (Exception ex)
            {
                if (room != null)
                {
                    Logger.error("PROTOCOL_BATTLE_TIMERSYNC_REQ: RoomId: " + room._roomId + " ChannelId: " + room._channelId + " RoomType: " + room.RoomType);
                }
                Logger.error(ex.ToString());
            }
        }
    }
}