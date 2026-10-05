using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_TIMEOUTCLIENT_REQ : ReceivePacket
    {
        private int Slot;

        public PROTOCOL_BATTLE_TIMEOUTCLIENT_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            Slot = readD();
        }

        public override void run()
        {
            try
            {
                Account Player = _client._player;
                Room Room = Player._room;
                if (Player != null && Room != null)
                {
                    if (Player._slotId == Slot)
                    {
                        Player._connection.SendPacket(new PROTOCOL_BATTLE_TIMEOUTCLIENT_ACK());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_BATTLE_TIMEOUTCLIENT_REQ: " + ex.ToString());
            }
        }
    }
}
