using ProjectBlackout.Game.Network.ServerPacket;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_RESULT_REQ : ReceivePacket
    {
        private int ClanId;

        public PROTOCOL_CLAN_WAR_RESULT_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            ClanId = readD();
        }

        public override void run()
        {
            _client.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK("0xc1d1nah61Not implemented... \n Work in progress :) (C) EmpireB"));
        }
    }
}
