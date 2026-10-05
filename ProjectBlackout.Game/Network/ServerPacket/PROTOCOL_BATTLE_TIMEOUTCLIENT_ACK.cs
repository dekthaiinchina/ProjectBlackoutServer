using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_TIMEOUTCLIENT_ACK : SendPacket
    {
        public PROTOCOL_BATTLE_TIMEOUTCLIENT_ACK()
        {

        }

        public override void write()
        {
            writeH(4120);
        }
    }
}
