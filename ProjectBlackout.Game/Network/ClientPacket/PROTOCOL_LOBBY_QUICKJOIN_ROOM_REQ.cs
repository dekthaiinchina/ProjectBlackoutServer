using Npgsql;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Models.Servers;
using ProjectBlackout.Core.Sql;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_LOBBY_QUICKJOIN_ROOM_REQ : ReceivePacket
    {
        private int Select;
        private List<Room> Rooms = new List<Room>();
        private List<QuickStart> Quicks = new List<QuickStart>();
        private QuickStart QuickSelect;

        public PROTOCOL_LOBBY_QUICKJOIN_ROOM_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            Select = readC();
            Logger.warning(Select.ToString());
            for (int i = 0; i < 3; i++)
            {
                QuickStart Quick = new QuickStart();
                Quick.MapId = readC();
                Quick.Rule = readC();
                Quick.StageOptions = readC();
                Quick.Type = readC();
                Quicks.Add(Quick);
            }
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }

                p.Quickstarts[Select] = Quicks[Select];

                using (NpgsqlConnection connection = SqlConnection.getInstance().conn())
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    connection.Open();

                    command.CommandText = "UPDATE player_quickstart SET " +
                        "map_" + Select + " = '" + Quicks[Select].MapId + "', rule_" + Select + " = '" + Quicks[Select].Rule + "', stage_" + Select + " = '" + Quicks[Select].StageOptions + "', type_" + Select + " = '" + Quicks[Select].Type + "' WHERE owner_id = '" + p.player_id + "';";

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }

                Channel ch;
                if (p != null && p.player_name.Length > 0 && p._room == null && p._match == null && p.getChannel(out ch))
                {
                    lock (ch._rooms)
                    {
                        for (int ridx = 0; ridx < ch._rooms.Count; ridx++)
                        {
                            Room room = ch._rooms[ridx];
                            if (room.RoomType == RoomType.Tutorial)
                            {
                                continue;
                            }
                            QuickSelect = Quicks[Select];
                            if (QuickSelect.MapId == (int)room.mapId && QuickSelect.Rule == room.rule && QuickSelect.StageOptions == room.stage && QuickSelect.Type == (int)room.RoomType && room.password.Length == 0 && room.Limit == 0 && (!room.kickedPlayers.Contains(p.player_id) || p.HaveGMLevel()))
                            {
                                for (int sidx = 0; sidx < 16; sidx++)
                                {
                                    Slot slot = room._slots[sidx];
                                    if (slot._playerId == 0 && (int)slot.state == 0)
                                    {
                                        Rooms.Add(room);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                if (Rooms.Count == 0)
                {
                    _client.SendPacket(new PROTOCOL_LOBBY_QUICKJOIN_ROOM_ACK(0x80000000, Quicks));
                }
                else
                {
                    getRandomRoom(p);
                }
                Rooms = null;
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_LOBBY_QUICKJOIN_ROOM_REQ: " + ex.ToString());
            }
        }

        private void getRandomRoom(Account player)
        {
            if (player != null)
            {
                Room room = Rooms[new Random().Next(Rooms.Count)];
                Account leader;
                if (room != null && room.getLeader(out leader) && room.addPlayer(player) >= 0)
                {
                    player.ResetPages();
                    using (PROTOCOL_ROOM_GET_SLOTONEINFO_ACK packet = new PROTOCOL_ROOM_GET_SLOTONEINFO_ACK(player))
                    {
                        room.SendPacketToPlayers(packet, player.player_id);
                    }
                    _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(0, player, leader));
                    _client.SendPacket(new PROTOCOL_LOBBY_QUICKJOIN_ROOM_ACK(0, Quicks, QuickSelect, room));
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_LOBBY_QUICKJOIN_ROOM_ACK(0x80000000));
                }
            }
            else
            {
                _client.SendPacket(new PROTOCOL_LOBBY_QUICKJOIN_ROOM_ACK(0x80000000));
            }
        }
    }
}