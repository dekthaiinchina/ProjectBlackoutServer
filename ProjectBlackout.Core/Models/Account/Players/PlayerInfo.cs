using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Core.Models.Account.Players
{
    public class PlayerInfo
    {
        public int _rank, _name_color;
        public long player_id;
        public string player_name;
        public bool _isOnline;
        public AccountStatus _status;

        public PlayerInfo(long player_id)
        {
            this.player_id = player_id;
            _status = new AccountStatus();
        }

        public PlayerInfo(long player_id, int rank, int name_color, string name, bool isOnline, AccountStatus status)
        {
            this.player_id = player_id;
            SetInfo(rank, name_color, name, isOnline, status);
        }

        public void setOnlineStatus(bool state)
        {
            if (_isOnline != state && ComDiv.updateDB("players", "online", state, "player_id", player_id))
            {
                _isOnline = state;
            }
        }

        public void SetInfo(int rank, int name_color, string name, bool isOnline, AccountStatus status)
        {
            _rank = rank;
            _name_color = name_color;
            player_name = name;
            _isOnline = isOnline;
            _status = status;
        }
    }
}