using ProjectBlackout.Game.Network.ServerPacket;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_SERVER_LIST_REFRESH_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_SERVER_LIST_REFRESH_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            if (_client != null)
            {
                _client.SendPacket(new PROTOCOL_BASE_SERVER_LIST_REFRESH_ACK());
            }
        }
    }
}