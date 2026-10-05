using ProjectBlackout.Auth.Network.ServerPacket;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_GET_MAP_INFO_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_GET_MAP_INFO_REQ(AuthClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            
        }

        public override void run()
        {
            _client.SendPacket(new PROTOCOL_BASE_MAP_RULELIST_ACK());
            var Parts = MapModel.Matchs.Split(100);
            int Total = 0;
            foreach (var Part in Parts)
            {
                Total += 100;
                var List = Part.ToList();
                _client.SendPacket(new PROTOCOL_BASE_MAP_MATCHINGLIST_ACK(List, Total));
            }
        }
    }
}
