using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Utils;
using System.Collections.Generic;
using System.Threading;
using ProjectBlackout.Core.Models.Enums;

namespace ProjectBlackout.Game.Data.Model
{
    public class Match
    {
        public Clan clan;
        public int formação, serverId, channelId, _matchId = -1, _leader, friendId;
        public SlotMatch[] _slots = new SlotMatch[8];
        public MatchState _state = MatchState.Ready;

        public Match(Clan clan)
        {
            this.clan = clan;
            for (int index = 0; index < 8; ++index)
            {
                _slots[index] = new SlotMatch(index);
            }
        }

        public bool getSlot(int slotId, out SlotMatch slot)
        {
            lock (_slots)
            {
                slot = null;
                if (slotId >= 0 && slotId < 16)
                {
                    slot = _slots[slotId];
                }
                return slot != null;
            }
        }

        public SlotMatch getSlot(int slotId)
        {
            lock (_slots)
            {
                if (slotId >= 0 && slotId < 16)
                {
                    return _slots[slotId];
                }
                return null;
            }
        }

        public void setNewLeader(int leader, int oldLeader)
        {
            Monitor.Enter(_slots);
            if (leader == -1)
            {
                for (int i = 0; i < formação; ++i)
                {
                    if (i != oldLeader && _slots[i]._playerId > 0)
                    {
                        _leader = i;
                        break;
                    }
                }
            }
            else
            {
                _leader = leader;
            }
            Monitor.Exit(_slots);
        }

        public bool addPlayer(Account player)
        {
            lock (_slots)
            {
                for (int i = 0; i < formação; i++)
                {
                    SlotMatch slot = _slots[i];
                    if (slot._playerId == 0 && (int)slot.state == 0)
                    {
                        slot._playerId = player.player_id;
                        slot.state = SlotMatchState.Normal;
                        player._match = this;
                        player.matchSlot = i;
                        player._status.updateClanMatch((byte)friendId);
                        AllUtils.syncPlayerToClanMembers(player);
                        return true;
                    }
                }
            }
            return false;
        }

        public Account getPlayerBySlot(SlotMatch slot)
        {
            try
            {
                long id = slot._playerId;
                return id > 0 ? AccountManager.getAccount(id, true) : null;
            }
            catch
            {
                return null;
            }
        }

        public Account getPlayerBySlot(int slotId)
        {
            try
            {
                long id = _slots[slotId]._playerId;
                return id > 0 ? AccountManager.getAccount(id, true) : null;
            }
            catch
            {
                return null;
            }
        }

        public List<Account> getAllPlayers(int exception)
        {
            List<Account> list = new List<Account>();
            lock (_slots)
            {
                for (int i = 0; i < 8; i++)
                {
                    long id = _slots[i]._playerId;
                    if (id > 0 && i != exception)
                    {
                        Account p = AccountManager.getAccount(id, true);
                        if (p != null)
                        {
                            list.Add(p);
                        }
                    }
                }
            }
            return list;
        }

        public List<Account> getAllPlayers()
        {
            List<Account> list = new List<Account>();
            lock (_slots)
            {
                for (int i = 0; i < 8; i++)
                {
                    long id = _slots[i]._playerId;
                    if (id > 0)
                    {
                        Account p = AccountManager.getAccount(id, true);
                        if (p != null)
                        {
                            list.Add(p);
                        }
                    }
                }
            }
            return list;
        }

        public void SendPacketToPlayers(SendPacket packet)
        {
            List<Account> players = getAllPlayers();
            if (players.Count == 0)
            {
                return;
            }

            byte[] data = packet.GetCompleteBytes("Match.SendPacketToPlayers(SendPacket)");
            for (int i = 0; i < players.Count; i++)
            {
                Account pR = players[i];
                pR.SendCompletePacket(data);
            }
        }

        public void SendPacketToPlayers(SendPacket packet, int exception)
        {
            List<Account> players = getAllPlayers(exception);
            if (players.Count == 0)
            {
                return;
            }

            byte[] data = packet.GetCompleteBytes("Match.SendPacketToPlayers(SendPacket,int)");
            for (int i = 0; i < players.Count; i++)
            {
                Account pR = players[i];
                pR.SendCompletePacket(data);
            }
        }

        public Account getLeader()
        {
            try
            {
                return AccountManager.getAccount(_slots[_leader]._playerId, true);
            }
            catch
            {
                return null;
            }
        }

        public int getServerInfo()
        {
            return (channelId + (serverId * 10));
        }

        public int getCountPlayers()
        {
            lock (_slots)
            {
                int count = 0;
                for (int i = 0; i < _slots.Length; i++)
                {
                    SlotMatch s = _slots[i];
                    if (s._playerId > 0)
                    {
                        ++count;
                    }
                }
                return count;
            }
        }

        private void BaseRemovePlayer(Account p)
        {
            lock (_slots)
            {
                SlotMatch slot;
                if (!getSlot(p.matchSlot, out slot))
                {
                    return;
                }
                if (slot._playerId == p.player_id)
                {
                    slot._playerId = 0;
                    slot.state = SlotMatchState.Empty;
                }
            }
        }

        public bool RemovePlayer(Account p)
        {
            Channel ch = ChannelsXml.getChannel(channelId);
            if (ch == null)
            {
                return false;
            }
            BaseRemovePlayer(p);
            if (getCountPlayers() == 0)
            {
                ch.RemoveMatch(_matchId);
            }
            else
            {
                if (p.matchSlot == _leader)
                {
                    setNewLeader(-1, -1);
                }
                using (PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK packet = new PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK(this))
                {
                    SendPacketToPlayers(packet);
                }
            }
            p.matchSlot = -1;
            p._match = null;
            return true;
        }
    }
}