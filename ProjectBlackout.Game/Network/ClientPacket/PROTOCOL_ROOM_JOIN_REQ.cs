using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_JOIN_REQ : ReceivePacket
    {
        private int roomId, type;
        private string password;

        public PROTOCOL_ROOM_JOIN_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            roomId = readD();
            password = readS(4);
            type = readC2();
            readC();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player, leader;
                Channel ch;
                if (p != null && p.player_name.Length > 0 && p._room == null && p._match == null && p.getChannel(out ch))
                {
                    Room room = ch.getRoom(roomId);
                    if (room != null && room.getLeader(out leader))
                    {
                        if (room.RoomType == RoomType.Tutorial)
                        {
                            _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(0x8000107C));
                        }
                        else if (room.password.Length > 0 && password != room.password && p._rank != 53 && !p.HaveGMLevel() && type != 1)
                        {
                            _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(0x80001005));
                        }
                        else if (room.Limit == 1 && room.RoomState >= RoomState.CountDown && !p.HaveGMLevel())
                        {
                            _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(0x80001013));
                        }
                        else if (room.kickedPlayers.Contains(p.player_id) && !p.HaveGMLevel())
                        {
                            _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(0x8000100C));
                        }
                        else if (room.addPlayer(p) >= 0)
                        {
                            p.ResetPages();
                            using (PROTOCOL_ROOM_GET_SLOTONEINFO_ACK packet = new PROTOCOL_ROOM_GET_SLOTONEINFO_ACK(p))
                            {
                                room.SendPacketToPlayers(packet, p.player_id);
                            }
                            _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(0, p, leader));
                        }
                        else
                        {
                            _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(0x80001003)); //SLOTFULL
                        }
                    }
                    else
                    {
                        _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(0x80001004)); //INVALIDROOM
                    }
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(0x80001004));
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_LOBBY_JOIN_ROOM_REQ: " + ex.ToString());
            }
        }
    }
}