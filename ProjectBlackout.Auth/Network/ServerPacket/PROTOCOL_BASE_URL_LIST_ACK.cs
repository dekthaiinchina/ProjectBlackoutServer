using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_URL_LIST_ACK : SendPacket
    {
        public PROTOCOL_BASE_URL_LIST_ACK()
        {

        }

        public override void write()
        {
            // TODO: Make out url configurable
            string URL1 = "";
            string URL2 = "";

            writeH(672);
            writeC(1);
            writeC(2);
            writeH((ushort)(URL1.Length));
            writeQ(4);
            writeText(URL1, URL1.Length);
            writeH((ushort)(URL2.Length));
            writeQ(3);
            writeText(URL2, URL2.Length);
        }
    }
}