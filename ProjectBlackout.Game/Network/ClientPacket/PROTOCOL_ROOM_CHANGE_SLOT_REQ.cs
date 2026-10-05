using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Map;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_CHANGE_SLOT_REQ : ReceivePacket
    {
        private int slotInfo;
        private uint erro;

        public PROTOCOL_ROOM_CHANGE_SLOT_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            slotInfo = readD();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                Room room = p == null ? null : p._room;
                if (room != null && room._leader == p._slotId)
                {
                    Slot slot = room.getSlot(slotInfo & 0xFFFFFFF);
                    if (slot == null)
                    {
                        return;
                    }
                    if ((slotInfo & 0x10000000) == 0x10000000)
                    {
                        OpenSlot(room, slot);
                    }
                    else
                    {
                        CloseSlot(room, slot);
                    }
                }
                else
                {
                    erro = 2147484673;
                }
                _client.SendPacket(new PROTOCOL_ROOM_CHANGE_SLOT_ACK(erro));
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_ROOM_CHANGE_SLOT_REQ: " + ex.ToString());
            }
        }

        private void CloseSlot(Room room, Slot slot)
        {
            switch (slot.state)
            {
                case SlotState.EMPTY:
                    room.changeSlotState(slot, SlotState.CLOSE, true);
                    break;
                case SlotState.CLAN:
                case SlotState.NORMAL:
                case SlotState.INFO:
                case SlotState.INVENTORY:
                case SlotState.GACHA:
                case SlotState.GIFTSHOP:
                case SlotState.SHOP:
                case SlotState.READY:
                    Account player = room.getPlayerBySlot(slot);
                    if (player != null && !player.AntiKickGM)
                    {
                        if (((int)slot.state != 9 && (room._channelType == 4 && room.RoomState != RoomState.CountDown || room._channelType != 4) || (int)slot.state == 9 && (room._channelType == 4 && room.RoomState == RoomState.Ready || room._channelType != 4)))
                        {
                            player.SendPacket(new PROTOCOL_SERVER_MESSAGE_KICK_PLAYER_ACK());
                            room.RemovePlayer(player, slot, false);
                        }
                    }
                    break;
            }
        }

        private void OpenSlot(Room room, Slot slot)
        {
            int SlotCount = 0;
            for (int i = 0; i < MapModel.Matchs.Count; i++)
            {
                MapMatch Match = MapModel.Matchs[i];
                if (Match.Id == (int)room.mapId && MapModel.getRule(Match.Mode).Rule == room.rule)
                {
                    SlotCount = Match.Limit;
                }
            }
            if (((slotInfo & 0x10000000) != 0x10000000) || slot.state != SlotState.CLOSE || (slotInfo & 0xFFFFFFF) >= SlotCount)
            {
                return;
            }
            room.changeSlotState(slot, SlotState.EMPTY, true);
        }
    }
}