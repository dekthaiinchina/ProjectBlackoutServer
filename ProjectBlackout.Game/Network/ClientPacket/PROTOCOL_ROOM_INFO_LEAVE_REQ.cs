using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_INFO_LEAVE_REQ : ReceivePacket
    {
        public PROTOCOL_ROOM_INFO_LEAVE_REQ(GameClient client, byte[] data)
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
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                Room room = p._room;
                if (room != null)
                {
                    room.changeSlotState(p._slotId, SlotState.NORMAL, true);
                }
                _client.SendPacket(new PROTOCOL_ROOM_INFO_LEAVE_ACK());
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}