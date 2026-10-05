using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_SHOP_ENTER_REQ : ReceivePacket
    {
        private string md5;

        public PROTOCOL_SHOP_ENTER_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            md5 = readS(32);
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
                    room.changeSlotState(p._slotId, SlotState.SHOP, false);
                    room.StopCountDown(p._slotId);
                    room.updateSlotsInfo();
                }

                _client.SendPacket(new PROTOCOL_SHOP_ENTER_ACK());
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}