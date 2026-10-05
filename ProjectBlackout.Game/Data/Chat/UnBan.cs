using ProjectBlackout.Core;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class UnBan
    {
        public static string UnbanByNick(string str, Account player)
        {
            Account victim = AccountManager.getAccount(str.Substring(4), 1, 0);
            return BaseUnbanNormal(player, victim);
        }

        public static string UnbanById(string str, Account player)
        {
            Account victim = AccountManager.getAccount(long.Parse(str.Substring(5)), 0);
            return BaseUnbanNormal(player, victim);
        }

        public static string SuperUnbanByNick(string str, Account player)
        {
            Account victim = AccountManager.getAccount(str.Substring(5), 1, 0);
            return BaseUnbanSuper(player, victim);
        }

        public static string SuperUnbanById(string str, Account player)
        {
            Account victim = AccountManager.getAccount(long.Parse(str.Substring(6)), 0);
            return BaseUnbanSuper(player, victim);
        }

        private static string BaseUnbanNormal(Account player, Account victim)
        {
            if (victim == null)
            {
                return Translation.GetLabel("PlayerBanUserInvalid");
            }
            else if ((int)victim.access == -1)
            {
                return Translation.GetLabel("PlayerUnbanAccessInvalid");
            }
            else if (victim.ban_obj_id == 0)
            {
                return Translation.GetLabel("PlayerUnbanNoBan");
            }
            else if (victim.player_id == player.player_id)
            {
                return Translation.GetLabel("PlayerUnbanSimilarId");
            }
            else if (ComDiv.updateDB("ban_history", "expire_date", DateTime.Now, "object_id", victim.ban_obj_id))
            {
                return Translation.GetLabel("PlayerUnbanSuccess");
            }
            else
            {
                return Translation.GetLabel("PlayerUnbanFail");
            }
        }

        private static string BaseUnbanSuper(Account player, Account victim)
        {
            if (victim == null)
            {
                return Translation.GetLabel("PlayerBanUserInvalid");
            }
            else if ((int)victim.access != -1)
            {
                return Translation.GetLabel("PlayerUnbanAccessInvalid");
            }
            else if (victim.player_id == player.player_id)
            {
                return Translation.GetLabel("PlayerUnbanSimilarId");
            }
            else if (ComDiv.updateDB("players", "access_level", 0, "player_id", victim.player_id))
            {
                victim.access = 0;
                return Translation.GetLabel("PlayerUnbanSuccess");
            }
            else
            {
                return Translation.GetLabel("PlayerUnbanFail");
            }
        }
    }
}