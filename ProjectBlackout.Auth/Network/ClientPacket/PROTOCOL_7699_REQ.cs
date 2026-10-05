using ProjectBlackout.Auth.Network.ServerPacket;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_7699_REQ : ReceivePacket
    {
        public PROTOCOL_7699_REQ(AuthClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {

            if (_client._player != null)
            {
                _client.SendPacket(new PROTOCOL_7699_ACK(0, null));
            }
            _client.SendPacket(new PROTOCOL_7699_ACK(0, _client._player.player_name));
        }
    }
}
