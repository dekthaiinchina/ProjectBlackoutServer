using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_LOBBY_NEW_VIEW_USER_ITEM_REQ : ReceivePacket
    {
        private uint sessionId;

        public PROTOCOL_LOBBY_NEW_VIEW_USER_ITEM_REQ(GameClient client, byte[] data)
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
            long playerId = 0;
            try
            {
                playerId = player.getChannel().getPlayer(sessionId)._playerId;
            }
            catch
            {

            }
            _client.SendPacket(new PROTOCOL_LOBBY_NEW_VIEW_USER_ITEM_ACK(playerId));
        }
    }
}