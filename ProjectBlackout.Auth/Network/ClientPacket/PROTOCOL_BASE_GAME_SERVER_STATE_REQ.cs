using ProjectBlackout.Auth.Network.ServerPacket;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_GAME_SERVER_STATE_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_GAME_SERVER_STATE_REQ(AuthClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            _client.SendPacket(new PROTOCOL_BASE_GAME_SERVER_STATE_ACK(2500000));
        }
    }
}
