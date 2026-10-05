using ProjectBlackout.Core;
using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Auth.Network.ServerPacket;
using System;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_GET_INVEN_INFO_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_GET_INVEN_INFO_REQ(AuthClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                _client.SendPacket(new PROTOCOL_BASE_GET_INVEN_INFO_ACK(p._inventory._items));
                _client.SendPacket(new PROTOCOL_BASE_GET_CHARA_INFO_ACK(p));
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_BASE_GET_INVEN_INFO_REQ: " + ex.ToString());
            }
        }
    }
}