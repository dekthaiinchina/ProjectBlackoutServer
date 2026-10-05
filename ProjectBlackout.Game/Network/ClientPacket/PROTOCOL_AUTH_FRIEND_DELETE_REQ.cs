using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using ProjectBlackout.Game.Data.Sync.Server;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_FRIEND_DELETE_REQ : ReceivePacket
    {
        private int index;
        private uint erro;

        public PROTOCOL_AUTH_FRIEND_DELETE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            index = readC();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                Friend f = p.FriendSystem.GetFriend(index);
                if (f != null)
                {
                    PlayerManager.DeleteFriend(f.player_id, p.player_id);
                    Account friend = AccountManager.getAccount(f.player_id, 32);
                    if (friend != null)
                    {
                        int idx = -1;
                        Friend f2 = friend.FriendSystem.GetFriend(p.player_id, out idx);
                        if (f2 != null)
                        {
                            f2.removed = true;
                            PlayerManager.UpdateFriendBlock(friend.player_id, f2);
                            SendFriendInfo.Load(friend, f2, 2);
                            friend.SendPacket(new PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(FriendChangeState.Update, f2, idx), false);
                        }
                    }
                    p.FriendSystem.RemoveFriend(f);
                    _client.SendPacket(new PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(FriendChangeState.Delete, null, 0, index));
                }
                else
                {
                    erro = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_AUTH_FRIEND_DELETE_ACK(erro));
                _client.SendPacket(new PROTOCOL_AUTH_FRIEND_INFO_ACK(p.FriendSystem._friends));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_AUTH_FRIEND_DELETE_REQ: " + ex.ToString());
            }
        }
    }
}