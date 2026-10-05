using ProjectBlackout.Core.Models.Account.Players;

namespace ProjectBlackout.Core.Models.Account
{
    public class Friend
    {
        public long player_id;
        public int state;
        public bool removed;
        public PlayerInfo player;

        public Friend(long player_id)
        {
            this.player_id = player_id;
            player = new PlayerInfo(player_id);
        }

        public Friend(long player_id, int rank, int name_color, string name, bool isOnline, AccountStatus status)
        {
            this.player_id = player_id;
            SetModel(player_id, rank, name_color, name, isOnline, status);
        }

        public void SetModel(long player_id, int rank, int name_color, string name, bool isOnline, AccountStatus status)
        {
            player = new PlayerInfo(player_id, rank, name_color, name, isOnline, status);
        }
    }
}