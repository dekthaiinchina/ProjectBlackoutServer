using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_USER_SOPETYPE_ACK : SendPacket
    {
        private Account Player;

        public PROTOCOL_BATTLE_USER_SOPETYPE_ACK(Account Player)
        {
            this.Player = Player;
        }

        public override void write()
        {
            writeH(4253);
            writeD(Player._slotId);
            writeC((byte)Player.Sight);
        }
    }
}
