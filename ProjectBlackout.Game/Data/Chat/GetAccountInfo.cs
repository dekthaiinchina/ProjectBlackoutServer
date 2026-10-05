using ProjectBlackout.Core;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class GetAccountInfo
    {
        public static string getById(string str, Account player)
        {
            Account p = AccountManager.getAccount(long.Parse(str.Substring(5)), 2);
            return BaseCode(p, player);
        }

        public static string getByNick(string str, Account player)
        {
            Account p = AccountManager.getAccount(str.Substring(5), 1, 2);
            return BaseCode(p, player);
        }

        private static string BaseCode(Account p, Account player)
        {
            if (p == null || player == null)
            {
                return Translation.GetLabel("GI_Fail");
            }
            DateTime LastLogin;
            if (p.LastLoginDate == 0)
            {
                LastLogin = new DateTime();
            }
            else
            {
                LastLogin = DateTime.ParseExact(p.LastLoginDate.ToString(), "yyMMddHHmm", CultureInfo.InvariantCulture);
            }

            string info = Translation.GetLabel("GI_Title");
            info += "\n" + Translation.GetLabel("GI_Id", p.player_id);
            info += "\n" + Translation.GetLabel("GI_Nick", p.player_name);
            info += "\n" + Translation.GetLabel("GI_Rank", p._rank);
            info += "\n" + Translation.GetLabel("GI_Fights", p._statistic.fights, p._statistic.fights_win, p._statistic.fights_lost, p._statistic.fights_draw);
            info += "\n" + Translation.GetLabel("GI_KD", p._statistic.GetKDRatio());
            info += "\n" + Translation.GetLabel("GI_HS", p._statistic.GetHSRatio());
            info += "\n" + Translation.GetLabel("GI_LastLogin", (LastLogin == new DateTime() ? "Nunca" : LastLogin.ToString("dd/MM/yy HH:mm")));
            info += "\n" + Translation.GetLabel("GI_LastIP", ((int)player.access >= 5 ? p.PublicIP.ToString() : Translation.GetLabel("GI_BlockedInfo")));
            info += "\n" + Translation.GetLabel("GI_BanObj", player.ban_obj_id);
            if ((int)player.access >= 5)
            {
                info += "\n" + Translation.GetLabel("GI_HaveAccess2", p.access);
            }
            else
            {
                info += "\n" + Translation.GetLabel("GI_HaveAccess1", (p.HaveGMLevel() ? Translation.GetLabel("GI_Yes") : Translation.GetLabel("GI_No")));
            }
            info += "\n" + Translation.GetLabel("GI_UsingFake", (p._bonus != null && p._bonus.fakeRank != 55 ? Translation.GetLabel("GI_Yes") : Translation.GetLabel("GI_No")));
            info += "\n" + Translation.GetLabel("GI_Channel", (p.channelId >= 0 ? string.Format("{0:0##}", (p.channelId + 1)) : Translation.GetLabel("GI_None1")));
            info += "\n" + Translation.GetLabel("GI_Room", (p._room != null ? string.Format("{0:0##}", (p._room._roomId + 1)) : Translation.GetLabel("GI_None2")));
            player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(info));
            return Translation.GetLabel("GI_Success");
        }

        public static string getByIPAddress(string str, Account player)
        {
            List<string> accs = AccountManager.getAccountsByIP(str.Substring(6));
            string acc = Translation.GetLabel("AccIP_Title");
            foreach (string ac in accs)
            {
                acc += "\n" + ac;
            }
            player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(acc));
            return Translation.GetLabel("AccIP_Result", accs.Count);
        }
    }
}