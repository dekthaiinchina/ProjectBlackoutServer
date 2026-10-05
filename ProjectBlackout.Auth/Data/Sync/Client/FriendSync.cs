using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Auth.Data.Managers;
using ProjectBlackout.Auth.Data.Model;

namespace ProjectBlackout.Auth.Data.Sync.Client
{
    public static class FriendSync
    {
        public static void Load(ReceiveGPacket p)
        {
            long playerId = p.readQ();
            int type = p.readC();

            long friendId = p.readQ();
            int state;
            bool removed;
            Friend friendModel = null;
            if (type <= 1)
            {
                state = p.readC();
                removed = p.readC() == 1;
                friendModel = new Friend(friendId) { state = state, removed = removed };
            }
            if (friendModel == null && type <= 1)
            {
                return;
            }

            Account player = AccountManager.getInstance().getAccount(playerId, true);
            if (player != null)
            {
                if (type <= 1)
                {
                    friendModel.player.player_name = player.player_name;
                    friendModel.player._rank = player._rank;
                    friendModel.player._isOnline = player._isOnline;
                    friendModel.player._status = player._status;
                }

                if (type == 0)
                {
                    player.FriendSystem.AddFriend(friendModel);
                }
                else if (type == 1)
                {
                    Friend myFriend = player.FriendSystem.GetFriend(friendId);
                    if (myFriend != null)
                    {
                        myFriend = friendModel;
                    }
                }
                else if (type == 2)
                {
                    player.FriendSystem.RemoveFriend(friendId);
                }
            }
        }
    }
}