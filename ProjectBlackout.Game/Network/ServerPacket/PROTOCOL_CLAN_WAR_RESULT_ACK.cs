using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CLAN_WAR_RESULT_ACK : SendPacket
    {
        public PROTOCOL_CLAN_WAR_RESULT_ACK()
        {
            
        }

        public override void write()
        {
            writeH(6964);
        }
    }
}
