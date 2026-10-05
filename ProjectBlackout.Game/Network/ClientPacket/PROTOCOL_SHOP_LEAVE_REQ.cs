using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_SHOP_LEAVE_REQ : ReceivePacket
    {
        public PROTOCOL_SHOP_LEAVE_REQ(GameClient client, byte[] data)
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
                if (p == null)
                {
                    return;
                }
                Room room = p._room;
                if (room != null)
                {
                    room.changeSlotState(p._slotId, SlotState.NORMAL, true);
                }
                _client.SendPacket(new PROTOCOL_SHOP_LEAVE_ACK());
                /*if (erro > 0)
                {
                    _client.SendPacket(new PROTOCOL_SERVER_MESSAGE_CHANGE_INVENTORY_ACK(p, 3));
                }*/
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_SHOP_LEAVE_REQ: " + ex.ToString());
            }
        }
    }
}