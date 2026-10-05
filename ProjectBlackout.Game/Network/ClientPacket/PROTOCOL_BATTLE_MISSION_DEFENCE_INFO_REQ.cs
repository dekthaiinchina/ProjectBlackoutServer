using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Sync.Client;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_MISSION_DEFENCE_INFO_REQ : ReceivePacket
    {
        private ushort tanqueA, tanqueB;
        private List<ushort> _damag1 = new List<ushort>(), _damag2 = new List<ushort>();

        public PROTOCOL_BATTLE_MISSION_DEFENCE_INFO_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            tanqueA = readUH();
            tanqueB = readUH();
            for (int i = 0; i < 16; i++)
            {
                _damag1.Add(readUH());
            }
            for (int i = 0; i < 16; i++)
            {
                _damag2.Add(readUH());
            }
        }

        public override void run()
        {
            try
            {
                Account player = _client._player;
                Room room = player == null ? null : player._room;
                if (room != null && room.round.Timer == null && room.RoomState == RoomState.Battle && !room.swapRound)
                {
                    Slot slot = room.getSlot(player._slotId);
                    if (slot == null || slot.state != SlotState.BATTLE)
                    {
                        return;
                    }
                    room.Bar1 = tanqueA;
                    room.Bar2 = tanqueB;
                    for (int i = 0; i < 16; i++)
                    {
                        Slot slotR = room._slots[i];
                        if (slotR._playerId > 0 && (int)slotR.state == 15)
                        {
                            slotR.damageBar1 = _damag1[i];
                            slotR.damageBar2 = _damag2[i];
                        }
                    }
                    using (PROTOCOL_BATTLE_MISSION_DEFENCE_INFO_ACK packet = new PROTOCOL_BATTLE_MISSION_DEFENCE_INFO_ACK(room))
                    {
                        room.SendPacketToPlayers(packet, SlotState.BATTLE, 0);
                    }
                    if (tanqueA == 0 && tanqueB == 0)
                    {
                        RoomSabotageSync.EndRound(room, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}