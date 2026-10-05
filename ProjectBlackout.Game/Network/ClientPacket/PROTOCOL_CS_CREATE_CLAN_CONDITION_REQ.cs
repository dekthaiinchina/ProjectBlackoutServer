using ProjectBlackout.Game.Network.ServerPacket;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_CREATE_CLAN_CONDITION_REQ : ReceivePacket
    {
        public PROTOCOL_CS_CREATE_CLAN_CONDITION_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            try
            {
                if (_client != null)
                {
                    _client.SendPacket(new PROTOCOL_CS_CREATE_CLAN_CONDITION_ACK());
                }
            }
            catch
            {

            }
        }
    }
}