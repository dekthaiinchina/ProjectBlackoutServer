using PointBlank.Core.Network;

namespace PointBlank.Game.Network.ServerPacket
{
    public class PROTOCOL_SHOP_PLUS_TAG_ACK : SendPacket
    {
        private int XPEarned, GPEarned;

        public PROTOCOL_SHOP_PLUS_TAG_ACK(int xp_earned, int gp_earned)
        {
            XPEarned = xp_earned;
            GPEarned = gp_earned;
        }

        public override void write()
        {
            writeH(3097);
            writeD(XPEarned);
            writeD(GPEarned);
        }
    }
}