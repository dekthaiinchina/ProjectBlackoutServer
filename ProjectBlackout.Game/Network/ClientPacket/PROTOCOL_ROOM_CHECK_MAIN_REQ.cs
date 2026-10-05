using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    internal class PROTOCOL_ROOM_CHECK_MAIN_REQ : ReceivePacket
    {
        private List<Slot> slots = new List<Slot>();
        private uint erro;

        public PROTOCOL_ROOM_CHECK_MAIN_REQ(GameClient client, byte[] data)
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
                        int idx = new Random().Next(slots.Count);
                        Slot result = slots[idx];
                        erro = room.getPlayerBySlot(result) != null ? (uint)result._id : 0x80000000;
                        slots = null;
                    }
                    else
                    {
                        erro = 0x80000000;
                    }
                }
                else
                {
                    erro = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_ROOM_CHECK_MAIN_ACK(erro));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_ROOM_CHECK_MAIN_REQ: " + ex.ToString());
            }
        }
    }
}