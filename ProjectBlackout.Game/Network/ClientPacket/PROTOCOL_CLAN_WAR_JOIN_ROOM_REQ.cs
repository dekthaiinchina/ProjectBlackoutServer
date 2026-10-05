using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_JOIN_ROOM_REQ : ReceivePacket
    {
        private int match, channel, unk;

        public PROTOCOL_CLAN_WAR_JOIN_ROOM_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            match = readD();
            unk = readH();
            channel = readH();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null || p.clanId == 0 || p._match == null)
                {
                    return;
                }
                Account leader;
                Channel ch;
                if (p != null && p.player_name.Length > 0 && p._room == null && p.getChannel(out ch))
                {
                    Room room = ch.getRoom(match);
                    if (room != null && room.getLeader(out leader))
                    {
                        if (room.password.Length > 0 && !p.HaveGMLevel())
                        {
                            _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(2147487749));
                        }
                        else if (room.Limit == 1 && room.RoomState >= RoomState.CountDown)
                        {
                            _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(2147487763)); //Entrada proibida com partida em andamento
                        }
                        else if (room.kickedPlayers.Contains(p.player_id))
                        {
                            _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(2147487756)); //Você foi expulso dessa sala.
                        }
                        else if (room.addPlayer(p, unk) >= 0)
                        {
                            using (PROTOCOL_ROOM_GET_SLOTONEINFO_ACK packet = new PROTOCOL_ROOM_GET_SLOTONEINFO_ACK(p))
                            {
                                room.SendPacketToPlayers(packet, p.player_id);
                            }
                            _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(0, p, leader));
                        }
                        else
                        {
                            _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(2147487747));
                        }
                    }
                    else
                    {
                        _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(2147487748));
                    }
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_ROOM_JOIN_ACK(2147487748));
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_CLAN_WAR_JOIN_ROOM_REQ: " + ex.ToString());
            }
        }
    }
}