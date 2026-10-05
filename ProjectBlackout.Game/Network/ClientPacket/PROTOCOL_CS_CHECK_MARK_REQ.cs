using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_CHECK_MARK_REQ : ReceivePacket
    {
        private uint logo, erro;

        public PROTOCOL_CS_CHECK_MARK_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            logo = readUD();
        }

        public override void run()
        {
            Account p = _client._player;
            if (p == null || ClanManager.getClan(p.clanId)._logo == logo || ClanManager.isClanLogoExist(logo))
            {
                erro = 0x80000000;
            }
            _client.SendPacket(new PROTOCOL_CS_CHECK_MARK_ACK(erro));
        }
    }
}