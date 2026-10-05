using ProjectBlackout.Core;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Sync;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Data.Model
{
    public class Channel
    {
        public int _id, _type, serverId;
        public List<PlayerSession> _players = new List<PlayerSession>();
        public List<Room> _rooms = new List<Room>();
        public List<Match> _matchs = new List<Match>();
        private DateTime LastRoomsSync = DateTime.Now;

        public PlayerSession getPlayer(uint session)
        {
            lock (_players)
            {
                try
                {
                    for (int i = 0; i < _players.Count; i++)
                    {
                        PlayerSession inf = _players[i];
                        if (inf._sessionId == session)
                        {
                            return inf;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.warning(ex.ToString());
                }
                return null;
            }
        }

        public PlayerSession getPlayer(uint session, out int idx)
        {
            idx = -1;
            lock (_players)
            {
                try
                {
                    for (int i = 0; i < _players.Count; i++)
                    {
                        PlayerSession inf = _players[i];
                        if (inf._sessionId == session)
                        {
                            idx = i;
                            return inf;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.warning(ex.ToString());
                }
                return null;
            }
        }

        public bool AddPlayer(PlayerSession pS)
        {
            lock (_players)
            {
                if (!_players.Contains(pS))
                {
                    _players.Add(pS);
                    GameSync.UpdateGSCount(serverId);
                    GameSync.UpdateChannelUsers(_id, _players.Count);
                    return true;
                }
                return false;
            }
        }

        public void RemoveMatch(int matchId)
        {
            try
            {
                lock (_matchs)
                {
                    for (int i = 0; i < _matchs.Count; ++i)
                    {
                        if (matchId == _matchs[i]._matchId)
                        {
                            _matchs.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
        }

        public void AddMatch(Match match)
        {
            lock (_matchs)
            {
                if (!_matchs.Contains(match))
                {
                    _matchs.Add(match);
                }
            }
        }

        public void AddRoom(Room room)
        {
            lock (_rooms)
            {
                _rooms.Add(room);
            }
        }

        public void RemoveEmptyRooms()
        {
            try
            {
                lock (_rooms)
                {
                    if ((DateTime.Now - LastRoomsSync).TotalSeconds >= 2)
                    {
                        LastRoomsSync = DateTime.Now;
                        for (int i = 0; i < _rooms.Count; ++i)
                        {
                            Room r = _rooms[i];
                            if (r.getAllPlayers().Count < 1)
                            {
                                _rooms.RemoveAt(i--);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning("[Channel.RemoveEmptyRooms] " + ex.ToString());
            }
        }

        public Match getMatch(int id)
        {
            lock (_matchs)
            {
                try
                {
                    for (int i = 0; i < _matchs.Count; i++)
                    {
                        Match mt = _matchs[i];
                        if (mt._matchId == id)
                        {
                            return mt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.warning(ex.ToString());
                }
                return null;
            }
        }

        public Match getMatch(int id, int clan)
        {
            lock (_matchs)
            {
                try
                {
                    for (int i = 0; i < _matchs.Count; i++)
                    {
                        Match mt = _matchs[i];
                        if (mt.friendId == id && mt.clan._id == clan)
                        {
                            return mt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.warning(ex.ToString());
                }
                return null;
            }
        }

        public Room getRoom(int id)
        {
            lock (_rooms)
            {
                try
                {
                    for (int i = 0; i < _rooms.Count; i++)
                    {
                        Room room = _rooms[i];
                        if (room._roomId == id)
                        {
                            return room;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.warning(ex.ToString());
                }
                return null;
            }
        }

        public List<Account> getWaitPlayers()
        {
            List<Account> list = new List<Account>();
            lock (_players)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    Account player = AccountManager.getAccount(_players[i]._playerId, true);
                    if (player != null && player._room == null && !string.IsNullOrEmpty(player.player_name))
                    {
                        list.Add(player);
                    }
                }
            }
            return list;
        }

        public void SendPacketToWaitPlayers(SendPacket packet)
        {
            List<Account> players = getWaitPlayers();
            if (players.Count == 0)
            {
                return;
            }
            byte[] data = packet.GetCompleteBytes("Channel.SendPacketToWaitPlayers");
            for (int i = 0; i < players.Count; i++)
            {
                players[i].SendCompletePacket(data);
            }
        }

        public bool RemovePlayer(Account p)
        {
            bool result = false;
            try
            {
                p.channelId = -1;
                if (p.Session != null)
                {
                    lock (_players)
                    {
                        result = _players.Remove(p.Session);
                    }

                    GameSync.UpdateChannelUsers(_id, _players.Count);

                    if (result)
                    {
                        GameSync.UpdateGSCount(serverId);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
            return result;
        }
    }
}