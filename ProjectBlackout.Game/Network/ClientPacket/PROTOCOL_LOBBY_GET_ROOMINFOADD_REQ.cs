using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_LOBBY_GET_ROOMINFOADD_REQ : ReceivePacket
    {
        private int roomId;

        public PROTOCOL_LOBBY_GET_ROOMINFOADD_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            roomId = readD();
        }

        public override void run()
        {
            if (_client == null)
            {
                return;
            }
            try
            {
                Account p = _client._player, leader;
                if (p == null)
                {
                    return;
                }
                Channel ch = p.getChannel();
                if (ch != null)
                {
                    Room room = ch.getRoom(roomId);
                    if (room != null && room.getLeader(out leader))
                    {
                        _client.SendPacket(new PROTOCOL_LOBBY_GET_ROOMINFOADD_ACK(room, leader));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_LOBBY_GET_ROOMINFOADD_REQ: " + ex.ToString());
            }
        }
    }
}