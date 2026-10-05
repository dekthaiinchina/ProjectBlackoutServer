using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_MEMBER_INFO_INSERT_ACK : SendPacket
    {
        private Account p;
        private ulong status;

        public PROTOCOL_CS_MEMBER_INFO_INSERT_ACK(Account pl)
        {
            p = pl;
            status = ComDiv.GetClanStatus(pl._status, pl._isOnline);
        }

        public override void write()
        {
            writeH(1871);
            writeC((byte)(p.player_name.Length + 1));
            writeUnicode(p.player_name, true);
            writeQ(p.player_id);
            writeQ(status);
            writeC((byte)p._rank);
            writeC((byte)p.name_color);
        }
    }
}