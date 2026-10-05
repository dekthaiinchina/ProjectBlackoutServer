namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_MISSION_SUCCESS_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_MISSION_SUCCESS_REQ(GameClient client, byte[] data)
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