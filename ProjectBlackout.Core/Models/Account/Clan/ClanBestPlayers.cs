using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Core.Models.Account.Clan
{
    public class ClanBestPlayers
    {
        public RecordInfo Exp, Participation, Wins, Kills, Headshot;

        public void SetPlayers(string Exp, string Part, string Wins, string Kills, string Hs)
        {
            string[] expSplit = Exp.Split('-'),
                partSplit = Part.Split('-'),
                winsSplit = Wins.Split('-'),
                killsSplit = Kills.Split('-'),
                hsSplit = Hs.Split('-');

            this.Exp = new RecordInfo(expSplit);
            this.Participation = new RecordInfo(partSplit);
            this.Wins = new RecordInfo(winsSplit);
            this.Kills = new RecordInfo(killsSplit);
            this.Headshot = new RecordInfo(hsSplit);
        }

        public void SetDefault()
        {
            string[] split = new string[] { "0", "0" };

            this.Exp = new RecordInfo(split);
            this.Participation = new RecordInfo(split);
            this.Wins = new RecordInfo(split);
            this.Kills = new RecordInfo(split);
            this.Headshot = new RecordInfo(split);
        }

        public long GetPlayerId(string[] split)
        {
            try
            {
                return long.Parse(split[0]);
            }
            catch
            {
                return 0;
            }
        }

        public int GetPlayerValue(string[] split)
        {
            try
            {
                return int.Parse(split[1]);
            }
            catch
            {
                return 0;
            }
        }

        public void SetBestExp(Slot slot)
        {
            if (slot.exp <= Exp.RecordValue)
            {
                return;
            }

            Exp.PlayerId = slot._playerId;
            Exp.RecordValue = slot.exp;
        }

        public void SetBestHeadshot(Slot slot)
        {
            if (slot.headshots <= Headshot.RecordValue)
            {
                return;
            }

            Headshot.PlayerId = slot._playerId;
            Headshot.RecordValue = slot.headshots;
        }

        public void SetBestKills(Slot slot)
        {
            if (slot.allKills <= Kills.RecordValue)
            {
                return;
            }

            Kills.PlayerId = slot._playerId;
            Kills.RecordValue = slot.allKills;
        }

        public void SetBestWins(PlayerStats stats, Slot slot, bool WonTheMatch)
        {
            if (!WonTheMatch)
            {
                return;
            }
            ComDiv.updateDB("players", "clan_wins_pt", ++stats.ClanWins, "player_id", slot._playerId);

            if (stats.ClanWins <= Wins.RecordValue)
            {
                return;
            }

            Wins.PlayerId = slot._playerId;
            Wins.RecordValue = stats.ClanWins;
        }

        public void SetBestParticipation(PlayerStats stats, Slot slot)
        {
            ComDiv.updateDB("players", "clan_game_pt", ++stats.ClanGames, "player_id", slot._playerId);
            if (stats.ClanGames <= Participation.RecordValue)
            {
                return;
            }

            Participation.PlayerId = slot._playerId;
            Participation.RecordValue = stats.ClanGames;
        }
    }

    public class RecordInfo
    {
        public long PlayerId;
        public int RecordValue;

        public RecordInfo(string[] split)
        {
            PlayerId = GetPlayerId(split);
            RecordValue = GetPlayerValue(split);
        }

        public long GetPlayerId(string[] split)
        {
            try
            {
                return long.Parse(split[0]);
            }
            catch
            {
                return 0;
            }
        }

        public int GetPlayerValue(string[] split)
        {
            try
            {
                return int.Parse(split[1]);
            }
            catch
            {
                return 0;
            }
        }

        public string GetSplit()
        {
            return (PlayerId + "-" + RecordValue);
        }
    }
}