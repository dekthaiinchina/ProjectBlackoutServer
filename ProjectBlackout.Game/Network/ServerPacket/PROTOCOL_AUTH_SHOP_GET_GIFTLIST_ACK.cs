using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_SHOP_GET_GIFTLIST_ACK : SendPacket
    {
        private uint Error;

        public PROTOCOL_AUTH_SHOP_GET_GIFTLIST_ACK(uint Error)
        {
            this.Error = Error;
        }

        public override void write()
        {
            writeH(1042);
            writeH(0);
            if (Error == 0)
            {

            }
            else
            {
                writeD(Error);
            }
            
        }
    }
}