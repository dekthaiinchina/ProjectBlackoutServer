using Org.BouncyCastle.Asn1.X509;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    class PROTOCOL_BATTLE_ACE_MODE_SLOT_REQ : ReceivePacket
    {
        private int SlotId;

        public PROTOCOL_BATTLE_ACE_MODE_SLOT_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            SlotId = readC();
        }

        public override void run()
        {
            if (_client == null || _client._player == null || _client._player._room == null)
                return;

            Room Room = _client._player._room;
            if (_client._player._slotId == SlotId)
                return;

            Slot Slot = Room.getSlot(_client._player._slotId);
            Slot TargetSlot = Room.getSlot(SlotId);

            // Se lo slot richiesto è già occupato
            if (TargetSlot._playerId > 0)
                return;
            
            // Se lo slot è aperto e vuoto
            if(TargetSlot.state == SlotState.EMPTY)
            {
                
                // Lo muovo sul nuovo slot
                TargetSlot.state = SlotState.NORMAL;
                TargetSlot._playerId = _client._player.player_id;
                TargetSlot._equip = _client._player._equip;

                Slot.state = SlotState.EMPTY;
                Slot._playerId = 0;
                Slot._equip = null;

                List<SlotChange> Changes = new List<SlotChange>();
                Changes.Add(new SlotChange()
                {
                    oldSlot = Slot,
                    newSlot = TargetSlot
                });

                // Se è leader, sistemo la slot leader
                if (_client._player._slotId == Room._leader)
                    Room._leader = SlotId;

                // Aggiorno la slot
                _client._player._slotId = SlotId;

                // Mando il pacchetto
                using (PROTOCOL_ROOM_TEAM_BALANCE_ACK packet = new PROTOCOL_ROOM_TEAM_BALANCE_ACK(Changes, Room._leader, 0))
                {
                    Room.SendPacketToPlayers(packet);
                }
            }
        }
    }
}
