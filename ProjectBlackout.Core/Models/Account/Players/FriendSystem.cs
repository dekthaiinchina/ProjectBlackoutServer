using System.Collections.Generic;

namespace ProjectBlackout.Core.Models.Account.Players
{
    public class FriendSystem
    {
        public List<Friend> _friends = new List<Friend>();
        public bool MemoryCleaned;

        public void CleanList()
        {
            lock (_friends)
            {
                for (int i = 0; i < _friends.Count; i++)
                {
                    Friend friend = _friends[i];
                    friend.player = null;
                }
            }
            MemoryCleaned = true;
        }

        public void AddFriend(Friend friend)
        {
            lock (_friends)
            {
                _friends.Add(friend);
            }
        }

        public bool RemoveFriend(Friend friend)
        {
            lock (_friends)
            {
                return _friends.Remove(friend);
            }
        }

        public void RemoveFriend(int index)
        {
            lock (_friends)
            {
                _friends.RemoveAt(index);
            }
        }

        public void RemoveFriend(long id)
        {
            lock (_friends)
            {
                for (int i = 0; i < _friends.Count; i++)
                {
                    Friend f = _friends[i];
                    if (f.player_id == id)
                    {
                        _friends.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public int GetFriendIdx(long id)
        {
            lock (_friends)
            {
                for (int i = 0; i < _friends.Count; i++)
                {
                    Friend f = _friends[i];
                    if (f.player_id == id)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public Friend GetFriend(int idx)
        {
            lock (_friends)
            {
                try
                {
                    return _friends[idx];
                }
                catch
                {
                    return null;
                }
            }
        }

        public Friend GetFriend(long id)
        {
            lock (_friends)
            {
                for (int i = 0; i < _friends.Count; i++)
                {
                    Friend f = _friends[i];
                    if (f.player_id == id)
                    {
                        return f;
                    }
                }
            }
            return null;
        }

        public Friend GetFriend(long id, out int index)
        {
            lock (_friends)
            {
                for (int i = 0; i < _friends.Count; i++)
                {
                    Friend f = _friends[i];
                    if (f.player_id == id)
                    {
                        index = i;
                        return f;
                    }
                }
            }
            index = -1;
            return null;
        }
    }
}