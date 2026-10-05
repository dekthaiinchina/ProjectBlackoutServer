using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_NEW_JOIN_ROOM_SCORE_REQ : ReceivePacket
    {
        public PROTOCOL_BATTLE_NEW_JOIN_ROOM_SCORE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            if (_client == null || _client._player == null)
            {
                return;
            }
            try
            {
                Account player = _client._player;
                Room room = player._room;
                if (room != null && room.RoomState >= RoomState.Loading && room._slots[player._slotId].state == SlotState.NORMAL)
                {
                    _client.SendPacket(new PROTOCOL_BATTLE_NEW_JOIN_ROOM_SCORE_ACK(room));
                }
            }
            catch
            {

            }
        }
    }
}