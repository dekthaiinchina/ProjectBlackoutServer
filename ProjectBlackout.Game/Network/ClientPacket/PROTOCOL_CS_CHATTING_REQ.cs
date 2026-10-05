using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_CHATTING_REQ : ReceivePacket
    {
        private ChattingType type;
        private string text;

        public PROTOCOL_CS_CHATTING_REQ(GameClient client, byte[] data)
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
                if (p == null || text.Length > 60 || type != ChattingType.Clan)
                {
                    return;
                }
                using (PROTOCOL_CS_CHATTING_ACK packet = new PROTOCOL_CS_CHATTING_ACK(text, p))
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