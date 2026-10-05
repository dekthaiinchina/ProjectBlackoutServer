using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Network.ServerPacket;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    class PROTOCOL_ROOM_GET_ACEMODE_PLAYERINFO_REQ : ReceivePacket
    {
        private int SlotId, Unk;

        public PROTOCOL_ROOM_GET_ACEMODE_PLAYERINFO_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            SlotId = readC();
            Unk = readC();
        }

        public override void run()
        {
            if (_client == null || _client._player == null || _client._player._room == null)
                return;

            Slot Slot = _client._player._room.getSlot(SlotId);
            _client.SendPacket(new PROTOCOL_ROOM_GET_ACEMODE_PLAYERINFO_ACK(_client._player._room.getPlayerBySlot(Slot)));
        }
    }
}
