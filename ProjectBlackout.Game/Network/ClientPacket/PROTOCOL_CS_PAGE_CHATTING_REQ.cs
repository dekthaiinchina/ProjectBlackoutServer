using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Core.Models.Enums;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_PAGE_CHATTING_REQ : ReceivePacket
    {
        private ChattingType type;
        private string text;

        public PROTOCOL_CS_PAGE_CHATTING_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            type = (ChattingType)readH();
            text = readUnicode(readH() * 2);
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null || type != ChattingType.Clan_Member_Page)
                {
                    return;
                }
                using (PROTOCOL_CS_PAGE_CHATTING_ACK packet = new PROTOCOL_CS_PAGE_CHATTING_ACK(p, text))
                {
                    ClanManager.SendPacket(packet, p.clanId, -1, true, true);
                }
            }
            catch
            {

            }
        }
    }
}