using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_WHO_REQ : ReceivePacket
    {
        private int slotId;

        public PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_WHO_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            slotId = readD();
        }

        public override void run()
        {
            Account player = _client._player;
            Room room = player == null ? null : player._room;
            try
            {
                if (room == null || room._leader == slotId || room._slots[slotId]._playerId == 0)
                {
                    _client.SendPacket(new PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_WHO_ACK(0x80000000));
                }
                else if (room.RoomState == RoomState.Ready && room._leader == player._slotId)
                {
                    room.setNewLeader(slotId, 0, room._leader, false);
                    using (PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_WHO_ACK packet = new PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_WHO_ACK(slotId))
                    {
                        room.SendPacketToPlayers(packet);
                    }
                    room.updateSlotsInfo();
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_WHO_REQ: " + ex.ToString());
            }
        }
    }
}