using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK : SendPacket
    {
        private Friend _f;
        private int _index;
        private FriendState _state;
        private FriendChangeState _type;

        public PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(FriendChangeState type, Friend friend, int idx)
        {
            _type = type;
            _state = (FriendState)friend.state;
            _f = friend;
            _index = idx;
        }

        public PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(FriendChangeState type, Friend friend, int state, int idx)
        {
            _type = type;
            _state = (FriendState)state;
            _f = friend;
            _index = idx;
        }

        public PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(FriendChangeState type, Friend friend, FriendState state, int idx)
        {
            _type = type;
            _state = state;
            _f = friend;
            _index = idx;
        }

        public override void write()
        {
            writeH(791);
            writeC((byte)_type);
            writeC((byte)_index);
            if (_type == FriendChangeState.Insert || _type == FriendChangeState.Update)
            {
                PlayerInfo info = _f.player;
                if (info == null)
                {
                    writeB(new byte[15]);
                }
                else
                {
                    writeC((byte)(info.player_name.Length + 1));
                    writeUnicode(info.player_name, true);
                    writeQ(_f.player_id);
                    writeD(ComDiv.GetFriendStatus(_f, _state));
                    writeC((byte)info._rank);
                    writeC(0); // ?
                }
            }
            else
            {
                writeB(new byte[17]);
            }
        }
    }
}