using ProjectBlackout.Game.Network.ServerPacket;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_GAME_SERVER_STATE_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_GAME_SERVER_STATE_REQ(GameClient client, byte[] data)
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
