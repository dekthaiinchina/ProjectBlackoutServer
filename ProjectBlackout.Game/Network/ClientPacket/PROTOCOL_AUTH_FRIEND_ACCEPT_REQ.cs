using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Sync.Server;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_FRIEND_ACCEPT_REQ : ReceivePacket
    {
        private int index;
        private uint erro;

        public PROTOCOL_AUTH_FRIEND_ACCEPT_REQ(GameClient client, byte[] data)
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
                Friend friend = p.FriendSystem.GetFriend(index);
                if (friend != null && friend.state > 0)
                {
                    Account _f = AccountManager.getAccount(friend.player_id, 32);
                    if (_f != null)
                    {
                        if (friend.player == null)
                        {
                            friend.SetModel(_f.player_id, _f._rank, _f.name_color, _f.player_name, _f._isOnline, _f._status);
                        }
                        else
                        {
                            friend.player.SetInfo(_f._rank, _f.name_color, _f.player_name, _f._isOnline, _f._status);
                        }

                        friend.state = 0;
                        PlayerManager.UpdateFriendState(p.player_id, friend);
                        _client.SendPacket(new PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(FriendChangeState.Accept, null, 0, index));
                        _client.SendPacket(new PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(FriendChangeState.Update, friend, index));
                        int idx = -1;
                        Friend fs = _f.FriendSystem.GetFriend(p.player_id, out idx);
                        if (fs != null && fs.state > 0)
                        {
                            if (fs.player == null)
                            {
                                fs.SetModel(p.player_id, p._rank, p.name_color, p.player_name, p._isOnline, p._status);
                            }
                            else
                            {
                                fs.player.SetInfo(p._rank, p.name_color, p.player_name, p._isOnline, p._status);
                            }

                            fs.state = 0;
                            PlayerManager.UpdateFriendState(_f.player_id, fs);
                            SendFriendInfo.Load(_f, fs, 1);
                            _f.SendPacket(new PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(FriendChangeState.Update, fs, idx), false);
                        }
                    }
                    else
                    {
                        erro = 0x80000000;//STR_TBL_GUI_BASE_NO_USER_IN_USERLIST
                    }
                }
                else
                {
                    erro = 0x80000000;//STR_TBL_GUI_BASE_NO_USER_IN_USERLIST
                }
                if (erro > 0)
                {
                    _client.SendPacket(new PROTOCOL_AUTH_FRIEND_ACCEPT_ACK(erro));
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_AUTH_FRIEND_ACCEPT_REQ " + ex.ToString());
            }
        }
    }
}