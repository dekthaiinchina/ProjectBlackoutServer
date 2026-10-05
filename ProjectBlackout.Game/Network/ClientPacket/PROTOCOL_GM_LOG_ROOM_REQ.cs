using PointBlank.Game.Data.Model;
using PointBlank.Game.Network.ServerPacket;

namespace PointBlank.Game.Network.ClientPacket
{
    public class PROTOCOL_GM_LOG_ROOM_REQ : ReceivePacket
    {
        private int slot;

        public PROTOCOL_GM_LOG_ROOM_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            slot = readC();
        }

        public override void run()
        {
            Account p = _client._player, pR;
            if (p == null || !p.IsGM())
            {
                return;
            }
            Room room = p._room;
            if (room != null && room.getPlayerBySlot(slot, out pR))
            {
                _client.SendPacket(new PROTOCOL_GM_LOG_ROOM_ACK(pR));
            }
        }
    }
}