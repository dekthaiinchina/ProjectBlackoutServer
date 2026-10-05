using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_GET_POINT_CASH_REQ : ReceivePacket
    {
        public PROTOCOL_AUTH_GET_POINT_CASH_REQ(GameClient client, byte[] data)
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
                _client.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, p._gp, p._money, p._tag));
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}