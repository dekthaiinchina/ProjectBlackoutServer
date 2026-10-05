using ProjectBlackout.Core;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class KickPlayer
    {
        public static string KickByNick(string str, Account player)
        {
            string playerName = str.Substring(3);
            Account victim = AccountManager.getAccount(playerName, 1, 0);
            return BaseKick(player, victim);
        }

        public static string KickById(string str, Account player)
        {
            Account victim = AccountManager.getAccount(long.Parse(str.Substring(4)), 0);
            return BaseKick(player, victim);
        }

        private static string BaseKick(Account player, Account victim)
        {
            if (victim == null)
            {
                return Translation.GetLabel("PlayerKickNotFound");
            }
            else if ((int)victim.access > (int)player.access)
            {
                return Translation.GetLabel("PlayerBanAccessInvalid");
            }
            else if (victim.player_id == player.player_id)
            {
                return Translation.GetLabel("PlayerKickKickYourself");
            }
            else if (victim._connection != null)
            {
                victim.SendPacket(new PROTOCOL_AUTH_ACCOUNT_KICK_ACK(2), false);
                victim.Close(1000, true);
                return Translation.GetLabel("PlayerKickSuccess", victim.player_name);
            }
            else
            {
                return Translation.GetLabel("PlayerKickOffline", victim.player_name);
            }
        }
    }
}