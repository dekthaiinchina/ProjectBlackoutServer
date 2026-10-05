using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_FRIEND_INVITED_REQUEST_REQ : ReceivePacket
    {
        private int index;

        public PROTOCOL_AUTH_FRIEND_INVITED_REQUEST_REQ(GameClient client, byte[] data)
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
                Account fr = GetFriend(p);
                if (fr != null)
                {
                    if (fr._status.serverId == 255 || fr._status.serverId == 0)
                    {
                        _client.SendPacket(new PROTOCOL_AUTH_FRIEND_INVITED_ACK(0x80003002));
                        return;
                    }
                    else if (fr.matchSlot >= 0)
                    {
                        _client.SendPacket(new PROTOCOL_AUTH_FRIEND_INVITED_ACK(0x80003003));
                        return;
                    }
                    int pIdx = fr.FriendSystem.GetFriendIdx(p.player_id);
                    if (pIdx == -1)
                    {
                        _client.SendPacket(new PROTOCOL_AUTH_FRIEND_INVITED_ACK(0x8000103E));
                    }
                    else if (fr._isOnline)
                    {
                        fr.SendPacket(new PROTOCOL_AUTH_FRIEND_INVITED_REQUEST_ACK(pIdx), false);
                    }
                    else
                    {
                        _client.SendPacket(new PROTOCOL_AUTH_FRIEND_INVITED_ACK(0x8000103F));
                    }
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_AUTH_FRIEND_INVITED_ACK(0x8000103D));
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_AUTH_FRIEND_INVITED_REQUEST_REQ " + ex.ToString());
            }
        }

        private Account GetFriend(Account p)
        {
            Friend friend = p.FriendSystem.GetFriend(index);
            if (friend == null)
            {
                return null;
            }
            return AccountManager.getAccount(friend.player_id, 32);
        }
    }
}