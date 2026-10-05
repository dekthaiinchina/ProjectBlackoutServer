using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_MEDAL_GET_INFO_ACK : SendPacket
    {
        private Account p;

        public PROTOCOL_BASE_MEDAL_GET_INFO_ACK(Account p)
        {
            this.p = p;
        }

        public override void write()
        {
            writeH(571);
            if (p != null)
            {
                writeQ(p.player_id);
                writeD(p.brooch);
                writeD(p.insignia);
                writeD(p.medal);
                writeD(p.blue_order);
            }
            else
            {
                writeB(new byte[24]);
            }
        }
    }
}