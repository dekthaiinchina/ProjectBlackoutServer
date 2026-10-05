using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_CHANGE_COSTUME_REQ : ReceivePacket
    {
        private int Team;

        public PROTOCOL_ROOM_CHANGE_COSTUME_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            Team = readC();
        }

        public override void run()
        {
            try
            {
                Account Player = _client._player;
                Room Room = Player._room;
                Slot Slot = Room.getSlot(Player._slotId);
                if (Slot != null || Player != null)
                {
                    Slot.Costume = Team;
                    _client.SendPacket(new PROTOCOL_ROOM_CHANGE_COSTUME_ACK(Slot));
                }
            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_ROOM_CHANGE_COSTUME_REQ: " + ex.ToString());
            }
        }
    }
}
