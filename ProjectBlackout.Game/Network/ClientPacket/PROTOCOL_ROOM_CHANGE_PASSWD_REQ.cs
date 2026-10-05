using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_CHANGE_PASSWD_REQ : ReceivePacket
    {
        private string pass;

        public PROTOCOL_ROOM_CHANGE_PASSWD_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            pass = readS(4);
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
                if (room != null && room._leader == player._slotId && room.password != pass)
                {
                    room.password = pass;
                    using (PROTOCOL_ROOM_CHANGE_PASSWD_ACK packet = new PROTOCOL_ROOM_CHANGE_PASSWD_ACK(pass))
                    {
                        room.SendPacketToPlayers(packet);
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