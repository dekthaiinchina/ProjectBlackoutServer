using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CHAR_CHANGE_STATE_ACK : SendPacket
    {
        private Character Character;

        public PROTOCOL_CHAR_CHANGE_STATE_ACK(Character Character)
        {
            this.Character = Character;
        }

        public override void write()
        {
            writeH(6153);
            writeH(0);
            writeD(0);
            writeC(20);
            writeC((byte)Character.Slot);
        }
    }
}
