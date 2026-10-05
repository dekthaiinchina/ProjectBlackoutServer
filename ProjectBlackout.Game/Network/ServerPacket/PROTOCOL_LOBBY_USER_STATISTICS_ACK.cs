using PointBlank.Core.Models.Account.Players;
using PointBlank.Core.Network;

namespace PointBlank.Game.Network.ServerPacket
{
    public class PROTOCOL_LOBBY_USER_STATISTICS_ACK : SendPacket
    {
        private PlayerStats st;

        public PROTOCOL_LOBBY_USER_STATISTICS_ACK(PlayerStats stats)
        {
            st = stats;
        }

        public override void write()
        {
            writeH(2640);
            if (st != null)
            {
                writeD(st.fights);
                writeD(st.fights_win);
                writeD(st.fights_lost);
                writeD(st.fights_draw);
                writeD(st.kills_count);
                writeD(st.headshots_count);
                writeD(st.deaths_count);
                writeD(st.totalfights_count);
                writeD(st.totalkills_count);
                writeD(st.escapes);
                writeD(st.fights);
                writeD(st.fights_win);
                writeD(st.fights_lost);
                writeD(st.fights_draw);
                writeD(st.kills_count);
                writeD(st.headshots_count);
                writeD(st.deaths_count);
                writeD(st.totalfights_count);
                writeD(st.totalkills_count);
                writeD(st.escapes);
            }
            else
            {
                writeB(new byte[80]);
            }
        }
    }
}