using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_INVENTORY_ENTER_REQ : ReceivePacket
    {
        public PROTOCOL_INVENTORY_ENTER_REQ(GameClient client, byte[] data)
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
                Room room = p == null ? null : p._room;
                if (room != null)
                {
                    room.changeSlotState(p._slotId, SlotState.INVENTORY, false);
                    room.StopCountDown(p._slotId);
                    room.updateSlotsInfo();
                }

                _client.SendPacket(new PROTOCOL_INVENTORY_ENTER_ACK());
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
        }
    }
}