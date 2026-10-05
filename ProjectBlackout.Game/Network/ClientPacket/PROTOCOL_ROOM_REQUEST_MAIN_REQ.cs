using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_REQUEST_MAIN_REQ : ReceivePacket
    {
        public PROTOCOL_ROOM_REQUEST_MAIN_REQ(GameClient client, byte[] data)
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
                if (_client == null)
                {
                    return;
                }
                Account p = _client._player;
                Room r = p == null ? null : p._room;
                if (r != null)
                {
                    if (r.RoomState != RoomState.Ready || r._leader == p._slotId)
                    {
                        return;
                    }
                    List<Account> players = r.getAllPlayers();
                    if (players.Count == 0)
                    {
                        return;
                    }

                    if ((int)p.access >= 4)
                    {
                        ChangeLeader(r, players, p._slotId);
                    }
                    else
                    {
                        if (!r.requestHost.Contains(p.player_id))
                        {
                            r.requestHost.Add(p.player_id);
                            if (r.requestHost.Count() < (players.Count / 2) + 1)
                            {
                                using (PROTOCOL_ROOM_REQUEST_MAIN_ACK packet = new PROTOCOL_ROOM_REQUEST_MAIN_ACK(p._slotId))
                                {
                                    SendPacketToRoom(packet, players);
                                }
                            }
                        }
                        if (r.requestHost.Count() >= (players.Count / 2) + 1)
                        {
                            ChangeLeader(r, players, p._slotId);
                        }
                    }
                }
                else _client.SendPacket(new PROTOCOL_ROOM_REQUEST_MAIN_ACK(0x80000000));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_ROOM_REQUEST_MAIN_REQ: " + ex.ToString());
            }
        }

        private void ChangeLeader(Room r, List<Account> players, int slotId)
        {
            r.setNewLeader(slotId, 0, -1, false);
            using (PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_WHO_ACK packet = new PROTOCOL_ROOM_REQUEST_MAIN_CHANGE_WHO_ACK(slotId))
            {
                SendPacketToRoom(packet, players);
            }
            r.updateSlotsInfo();
            r.requestHost.Clear();
        }

        private void SendPacketToRoom(SendPacket packet, List<Account> players)
        {
            byte[] data = packet.GetCompleteBytes("PROTOCOL_ROOM_REQUEST_MAIN_REQ");
            for (int i = 0; i < players.Count; i++)
            {
                Account pR = players[i];
                pR.SendCompletePacket(data);
            }
        }
    }
}