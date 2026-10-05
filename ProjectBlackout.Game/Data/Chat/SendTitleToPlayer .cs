using PointBlank.Core;
using PointBlank.Core.Managers;
using PointBlank.Core.Models.Account.Title;
using PointBlank.Core.Network;
using PointBlank.Core.Xml;
using PointBlank.Game.Data.Managers;
using PointBlank.Game.Data.Model;
using PointBlank.Game.Network.ServerPacket;
using System;

namespace Game.data.chat
{
    public static class SendTitleToPlayer
    {
        public static string SendTitlePlayer(string str)
        {
            string txt = str.Substring(str.IndexOf(" ") + 1);
            string[] split = txt.Split(' ');
            long player_id = Convert.ToInt64(split[0]);

            Account p = AccountManager.getAccount(player_id, 0);
            if (p._titles.ownerId == 0)
            {
                TitleManager.getInstance().CreateTitleDB(p.player_id);
                p._titles = new PlayerTitles { ownerId = p.player_id };
            }
            PlayerTitles titles = p._titles;
            int count = 0;
            for (int i = 1; i <= 44; i++)
            {
                TitleQ title = TitlesXML.getTitle(i, true);
                if (title != null && !titles.Contains(title._flag))
                {
                    count++;
                    titles.Add(title._flag);
                    if (titles.Slots < title._slot)
                        titles.Slots = title._slot;
                }
            }
            if (count > 0)
            {
                ComDiv.updateDB("player_titles", "titleslots", titles.Slots, "owner_id", p.player_id);
                TitleManager.getInstance().updateTitlesFlags(p.player_id, titles.Flags);
                p.SendPacket(new BASE_2626_PAK(p));
            }
            return Translation.GetLabel("TitleAcquisiton", count);
        }
    }
}