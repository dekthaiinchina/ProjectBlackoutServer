using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Servers;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Sync.Server
{
    public class SendFriendInfo
    {
        public static void Load(Account player, Friend friend, int type)
        {
            if (player == null)
            {
                return;
            }

            GameServerModel gs = GameSync.GetServer(player._status);
            if (gs == null)
            {
                return;
            }

            using (SendGPacket pk = new SendGPacket())
            {
                pk.writeH(17);
                pk.writeQ(player.player_id);
                pk.writeC((byte)type);
                pk.writeQ(friend.player_id);

                if (type != 2)
                {
                    pk.writeC((byte)friend.state);
                    pk.writeC(friend.removed);
                }
                GameSync.SendPacket(pk.mstream.ToArray(), gs.Connection);
            }
        }
    }
}