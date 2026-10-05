using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_HOLE_CHECK_REQ : ReceivePacket
    {
        public PROTOCOL_BATTLE_HOLE_CHECK_REQ(GameClient client, byte[] data)
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
                /*Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                Room room = p._room;
                Logger.warning("PROTOCOL_BATTLE_HOLE_CHECK_REQ; (PlayerId: " + p.player_id + " Name: " + p.player_name + " Room: " + (p._room != null ? p._room._roomId : -1) + " Channel: " + p.channelId + ")");
                if (room != null)
                {
                    Logger.warning("PROTOCOL_BATTLE_HOLE_CHECK_REQ; Bot: " + room.isBotMode());
                    Slot slot = room.getSlot(p._slotId);
                    if (slot != null)
                    {
                        Logger.warning("SlotId: " + slot._id + " State: " + slot.state);
                    }
                }*/
                _client.SendPacket(new PROTOCOL_BATTLE_HOLE_CHECK_ACK());
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}