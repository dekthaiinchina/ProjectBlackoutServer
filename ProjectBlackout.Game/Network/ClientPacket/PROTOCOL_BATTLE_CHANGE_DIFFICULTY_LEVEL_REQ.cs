using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_CHANGE_DIFFICULTY_LEVEL_REQ : ReceivePacket
    {
        public PROTOCOL_BATTLE_CHANGE_DIFFICULTY_LEVEL_REQ(GameClient client, byte[] data)
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
                if (room == null || room.RoomState != RoomState.Battle || room.IngameAiLevel >= 10)
                {
                    return;
                }
                Slot slot = room.getSlot(p._slotId);
                if (slot == null || slot.state != SlotState.BATTLE)
                {
                    return;
                }
                if (room.IngameAiLevel <= 9)
                {
                    room.IngameAiLevel++;
                }
                using (PROTOCOL_BATTLE_CHANGE_DIFFICULTY_LEVEL_ACK packet = new PROTOCOL_BATTLE_CHANGE_DIFFICULTY_LEVEL_ACK(room))
                {
                    room.SendPacketToPlayers(packet, SlotState.READY, 1);
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_BATTLE_CHANGE_DIFFICULTY_LEVEL_REQ: " + ex.ToString());
            }
        }
    }
}