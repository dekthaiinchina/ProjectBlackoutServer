
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_URL_LIST_ACK : SendPacket
    {
        public PROTOCOL_BASE_URL_LIST_ACK()
        {

        }

        public override void write()
        {
            string URL1 = "https://empireb.net/pb/banner/";

            writeH(674);
            writeH(514);
            writeH((ushort)(URL1.Length));
            writeD(0);
            writeC(2);
            writeText(URL1, URL1.Length);
            writeQ(0);
        }
    }
}
