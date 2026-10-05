using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    internal class PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_REQ : ReceivePacket
    {
        private List<Slot> slots = new List<Slot>();

        public PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                Room room = p == null ? null : p._room;
                if (room != null && room._leader == p._slotId && room.RoomState == RoomState.Ready)
                {
                    lock (room._slots)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            Slot slot = room._slots[i];
                            if (slot._playerId > 0 && i != room._leader)
                            {
                                slots.Add(slot);
                            }
                        }
                    }
                    if (slots.Count > 0)
                    {
                        Slot slot = slots[new Random().Next(slots.Count)];
                        Account player = room.getPlayerBySlot(slot);
                        if (player != null)
                        {
                            room.setNewLeader(slot._id, 0, room._leader, false);
                            using (PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_ACK packet = new PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_ACK(slot._id))
                            {
                                room.SendPacketToPlayers(packet);
                            }
                            room.updateSlotsInfo();
                        }
                        else
                        {
                            _client.SendPacket(new PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_ACK(0x80000000));
                        }
                        slots = null;
                    }
                    else
                    {
                        _client.SendPacket(new PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_ACK(0x80000000));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.info("ROOM_RANDOM_HOST2_REC: " + ex.ToString());
            }
        }
    }
}