using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_PERSONAL_TEAM_CHANGE_REQ : ReceivePacket
    {
        private int teamIdx;

        public PROTOCOL_ROOM_PERSONAL_TEAM_CHANGE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            teamIdx = readD();
        }

        public override void run()
        {
            try
            {
                Account player = _client._player;
                Room room = player == null ? null : player._room;
                if (teamIdx < 2 && room != null && !room.changingSlots)
                {
                    Slot slot = room.getSlot(player._slotId);
                    if (slot != null && teamIdx != slot._team && slot.state == SlotState.NORMAL)
                    {
                        Monitor.Enter(room._slots);
                        room.changingSlots = true;
                        List<SlotChange> changeList = new List<SlotChange>();
                        //room.SwitchNewSlot(changeList, player, slot, teamIdx, 0, false);
                        if (changeList.Count > 0)
                        {
                            using (PROTOCOL_ROOM_TEAM_BALANCE_ACK packet = new PROTOCOL_ROOM_TEAM_BALANCE_ACK(changeList, room._leader, 0))
                            {
                                room.SendPacketToPlayers(packet);
                            }
                        }
                        room.changingSlots = false;
                        Monitor.Exit(room._slots);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_ROOM_PERSONAL_TEAM_CHANGE_REQ: " + ex.ToString());
            }
        }
    }
}