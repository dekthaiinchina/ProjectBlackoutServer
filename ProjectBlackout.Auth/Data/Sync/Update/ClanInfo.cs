using ProjectBlackout.Auth.Data.Model;

namespace ProjectBlackout.Auth.Data.Sync.Update
{
    public class ClanInfo
    {
        public static void AddMember(Account player, Account member)
        {
            lock (player._clanPlayers)
            {
                player._clanPlayers.Add(member);
            }
        }

        public static void RemoveMember(Account player, long id)
        {
            lock (player._clanPlayers)
            {
                for (int i = 0; i < player._clanPlayers.Count; i++)
                {
                    Account pC = player._clanPlayers[i];
                    if (pC.player_id == id)
                    {
                        player._clanPlayers.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public static void ClearList(Account p)
        {
            lock (p._clanPlayers)
            {
                p.clan_id = 0;
                p.clanAccess = 0;
                p._clanPlayers.Clear();
            }
        }
    }
}