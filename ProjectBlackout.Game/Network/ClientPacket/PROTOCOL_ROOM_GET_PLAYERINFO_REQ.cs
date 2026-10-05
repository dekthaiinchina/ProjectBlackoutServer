using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_GET_PLAYERINFO_REQ : ReceivePacket
    {
        private int slotId;

        public PROTOCOL_ROOM_GET_PLAYERINFO_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            slotId = readD();
        }

        public override void run()
        {
            Account p = _client._player;
            if (p == null)
            {
                return;
            }
            Room room = p._room;
            try
            {
                _client.SendPacket(new PROTOCOL_ROOM_GET_PLAYERINFO_ACK(room != null ? room.getPlayerBySlot(slotId) : null));
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}