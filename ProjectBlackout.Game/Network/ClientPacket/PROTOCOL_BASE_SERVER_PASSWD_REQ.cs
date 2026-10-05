using PointBlank.Game.Data.Configs;
using PointBlank.Game.Network.ServerPacket;

namespace PointBlank.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_SERVER_PASSWD_REQ : ReceivePacket
    {
        private string pass;

        public PROTOCOL_BASE_SERVER_PASSWD_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            pass = readS(readC());
        }

        public override void run()
        {
            if (_client != null)
            {
                _client.SendPacket(new PROTOCOL_BASE_SERVER_PASSWD_ACK(pass != GameConfig.passw ? 0x80000000 : 0));
            }
        }
    }
}