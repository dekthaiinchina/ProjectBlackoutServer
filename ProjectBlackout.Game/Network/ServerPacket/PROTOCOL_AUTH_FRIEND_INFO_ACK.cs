using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_FRIEND_INFO_ACK : SendPacket
    {
        private List<Friend> friends;

        public PROTOCOL_AUTH_FRIEND_INFO_ACK(List<Friend> frie)
        {
            friends = frie;
        }

        public override void write()
        {
            writeH(786);
            writeC((byte)friends.Count);
            for (int i = 0; i < friends.Count; i++)
            {
                Friend f = friends[i];
                PlayerInfo info = f.player;
                if (info == null)
                {
                    writeB(new byte[15]);
                }
                else
                {
                    writeC((byte)(info.player_name.Length + 1));
                    writeUnicode(info.player_name, true);
                    writeQ(f.player_id);
                    writeD(ComDiv.GetFriendStatus(f));
                    writeC((byte)info._rank);
                    writeC(0); // ?
                }
            }
        }
    }
}