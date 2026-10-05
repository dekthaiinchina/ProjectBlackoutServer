using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_SENDPING_REQ : ReceivePacket
    {
        private byte[] slots;
        private int ReadyPlayersCount;

        public PROTOCOL_BATTLE_SENDPING_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            slots = readB(16);
        }

        public override void run()
        {
            try
            {
                Account player = _client._player;
                if (player == null)
                {
                    return;
                }
                Room room = player._room;
                if (room != null && room._slots[player._slotId].state >= SlotState.BATTLE_READY)
                {
                    if (room.RoomState == RoomState.Battle)
                    {
                        room._ping = 5/*slots[room._leader]*/;
                    }
                    using (PROTOCOL_BATTLE_SENDPING_ACK packet = new PROTOCOL_BATTLE_SENDPING_ACK(slots))
                    {
                        List<Account> players = room.getAllPlayers(SlotState.READY, 1);
                        if (players.Count == 0)
                        {
                            return;
                        }

                        byte[] data = packet.GetCompleteBytes("PROTOCOL_BATTLE_SENDPING_REQ");
                        foreach (Account pR in players)
                        {
                            if ((int)room._slots[pR._slotId].state >= 14)
                            {
                                pR.SendCompletePacket(data);
                            }
                            else
                            {
                                ++ReadyPlayersCount;
                            }
                        }
                    }
                    if (ReadyPlayersCount == 0)
                    {
                        room.SpawnReadyPlayers();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_BATTLE_SENDPING_REQ: " + ex.ToString());
            }
        }
    }
}