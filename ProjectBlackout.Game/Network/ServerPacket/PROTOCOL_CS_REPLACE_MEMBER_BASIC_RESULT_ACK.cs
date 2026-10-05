using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_REPLACE_MEMBER_BASIC_RESULT_ACK : SendPacket
    {
        private Account p;
        private ulong status;

        public PROTOCOL_CS_REPLACE_MEMBER_BASIC_RESULT_ACK(Account pl)
        {
            p = pl;
            status = ComDiv.GetClanStatus(pl._status, pl._isOnline);
        }

        public override void write()
        {
            writeH(1900);
            writeQ(p.player_id);
            writeUnicode(p.player_name, 66);
            writeC((byte)p._rank);
            writeC((byte)p.clanAccess);
            writeQ(status);
            writeD(p.clanDate);
            writeC((byte)p.name_color);
            writeD(0); // ?
            writeD(0); // ?
        }
    }
}