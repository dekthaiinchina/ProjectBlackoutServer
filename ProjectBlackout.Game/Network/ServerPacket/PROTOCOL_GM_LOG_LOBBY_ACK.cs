using PointBlank.Core.Network;
using PointBlank.Game.Data.Model;

namespace PointBlank.Game.Network.ServerPacket
{
    public class PROTOCOL_GM_LOG_LOBBY_ACK : SendPacket
    {
        private Account player;

        public PROTOCOL_GM_LOG_LOBBY_ACK(Account p)
        {
            player = p;
        }

        public override void write()
        {
            writeH(2685);
            writeD(0);
            writeQ(player.player_id);
        }
    }
}