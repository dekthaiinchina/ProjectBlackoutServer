using PointBlank.Game.Data.Managers;
using PointBlank.Game.Data.Model;
using PointBlank.Game.Network.ServerPacket;

namespace PointBlank.Game.Network.ClientPacket
{
    public class PROTOCOL_LOBBY_USER_STATISTICS_REQ : ReceivePacket
    {
        private uint sessionId;

        public PROTOCOL_LOBBY_USER_STATISTICS_REQ(GameClient client, byte[] data)
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
            if (player == null)
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
            _client.SendPacket(new PROTOCOL_LOBBY_USER_STATISTICS_ACK(p != null ? p._statistic : null));
        }
    }
}