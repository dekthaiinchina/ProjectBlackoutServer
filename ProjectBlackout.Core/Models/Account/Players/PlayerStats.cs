using System;

namespace ProjectBlackout.Core.Models.Account.Players
{
    public class PlayerStats
    {
        public int fights, fights_win, fights_lost, fights_draw, kills_count, totalkills_count, totalfights_count, deaths_count, escapes, headshots_count, assist, mvp;
        public int ClanGames, ClanWins, ClanLoses;

        public int GetKDRatio()
        {
            if (headshots_count <= 0 && kills_count <= 0)
            {
                return 0;
            }
            return (int)Math.Floor((kills_count * 100 + 0.5) / (double)(kills_count + deaths_count));
        }

        public int GetHSRatio()
        {
            if (kills_count <= 0)
            {
                return 0;
            }
            return (int)Math.Floor((headshots_count * 100) / (double)kills_count + 0.5);
        }
    }
}