using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_GET_RECORD_INFO_DB_ACK : SendPacket
    {
        private PlayerStats st;

        public PROTOCOL_BASE_GET_RECORD_INFO_DB_ACK(PlayerStats stats)
        {
            st = stats;
        }

        public override void write()
        {
            writeH(559);
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
                writeD(st.assist);
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
                writeD(st.assist);
            }
            else
            {
                writeB(new byte[80]);
            }
        }
    }
}