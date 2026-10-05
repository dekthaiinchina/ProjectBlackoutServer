
using ProjectBlackout.Game.Network.ServerPacket;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_URL_LIST_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_URL_LIST_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            //_client.SendPacket(new PROTOCOL_BASE_URL_LIST_ACK());
        }
    }
}
