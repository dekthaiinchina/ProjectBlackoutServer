using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_GET_RECORD_INFO_DB_REQ : ReceivePacket
    {
        private long objId;

        public PROTOCOL_BASE_GET_RECORD_INFO_DB_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            objId = readQ();
        }

        public override void run()
        {
            if (_client._player == null)
            {
                return;
            }
            try
            {
                Account player = AccountManager.getAccount(objId, 0);
                _client.SendPacket(new PROTOCOL_BASE_GET_RECORD_INFO_DB_ACK(player != null ? player._statistic : null));
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}