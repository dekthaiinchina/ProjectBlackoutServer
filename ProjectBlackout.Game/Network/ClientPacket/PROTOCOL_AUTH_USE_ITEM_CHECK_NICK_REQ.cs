using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_REQ : ReceivePacket
    {
        private string name;

        public PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            name = readUnicode(66);
        }

        public override void run()
        {
            try
            {
                if (_client == null || _client._player == null)
                {
                    return;
                }
                _client.SendPacket(new PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_ACK(!PlayerManager.isPlayerNameExist(name) ? 0 : 2147483923));
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}