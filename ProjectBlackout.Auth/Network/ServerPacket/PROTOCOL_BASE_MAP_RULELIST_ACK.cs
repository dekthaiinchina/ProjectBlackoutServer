using ProjectBlackout.Core.Models.Map;
using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_MAP_RULELIST_ACK : SendPacket
    {
        public PROTOCOL_BASE_MAP_RULELIST_ACK()
        {

        }

        public override void write()
        {
            writeH(670);
            writeH(0);
            writeH((short)MapModel.Rules.Count);
            for (int i = 0; i < MapModel.Rules.Count; i++)
            {
                MapRule Rule = MapModel.Rules[i];
                writeD(Rule.Id);
                writeC(0);
                writeC((byte)Rule.Rule);
                writeC((byte)Rule.StageOptions);
                writeC((byte)Rule.Conditions);
                writeC(0);
                writeS(Rule.Name, 67);
            }
        }
    }
}
