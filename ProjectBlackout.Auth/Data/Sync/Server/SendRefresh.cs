using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Servers;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using ProjectBlackout.Auth.Data.Managers;
using ProjectBlackout.Auth.Data.Model;

namespace ProjectBlackout.Auth.Data.Sync.Server
{
    public static class SendRefresh
    {
        public static void RefreshAccount(Account player, bool isConnect)
        {
            AuthSync.UpdateGSCount(0);
            AccountManager.getInstance().getFriendlyAccounts(player.FriendSystem);
            for (int i = 0; i < player.FriendSystem._friends.Count; i++)
            {
                Friend friend = player.FriendSystem._friends[i];
                PlayerInfo info = friend.player;
                if (info != null)
                {
                    GameServerModel gs = ServersXml.getServer(info._status.serverId);
                    if (gs == null)
                    {
                        continue;
                    }

                    SendRefreshPacket(0, player.player_id, friend.player_id, isConnect, gs);
                }
            }
            if (player.clan_id > 0)
            {
                for (int i = 0; i < player._clanPlayers.Count; i++)
                {
                    Account member = player._clanPlayers[i];
                    if (member != null && member._isOnline)
                    {
                        GameServerModel gs = ServersXml.getServer(member._status.serverId);
                        if (gs == null)
                        {
                            continue;
                        }

                        SendRefreshPacket(1, player.player_id, member.player_id, isConnect, gs);
                    }
                }
            }
        }

        public static void SendRefreshPacket(int type, long playerId, long memberId, bool isConnect, GameServerModel gs)
        {
            using (SendGPacket pk = new SendGPacket())
            {
                pk.writeH(11);
                pk.writeC((byte)type);
                pk.writeC(isConnect);
                pk.writeQ(playerId);
                pk.writeQ(memberId);
                AuthSync.SendPacket(pk.mstream.ToArray(), gs.Connection);
            }
        }
    }
}