namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_PACKET_EMPTY_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_PACKET_EMPTY_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {

        }
    }
}