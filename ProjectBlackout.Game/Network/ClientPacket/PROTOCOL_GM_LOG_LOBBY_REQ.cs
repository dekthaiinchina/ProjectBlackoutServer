using PointBlank.Game.Data.Managers;
using PointBlank.Game.Data.Model;
using PointBlank.Game.Network.ServerPacket;

namespace PointBlank.Game.Network.ClientPacket
{
    public class PROTOCOL_GM_LOG_LOBBY_REQ : ReceivePacket
    {
        private uint sessionId;

        public PROTOCOL_GM_LOG_LOBBY_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            sessionId = readUD();
        }

        public override void run()
        {
            Account player = _client._player;
            if (player == null || !player.IsGM())
            {
                return;
            }
            Account p = null;
            try
            {
                p = AccountManager.getAccount(player.getChannel().getPlayer(sessionId)._playerId, true);
            }
            catch
            {

            }
            if (p != null)
            {
                _client.SendPacket(new PROTOCOL_GM_LOG_LOBBY_ACK(p));
            }
        }
    }
}