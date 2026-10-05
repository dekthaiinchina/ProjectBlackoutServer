using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_MESSENGER_NOTE_DELETE_REQ : ReceivePacket
    {
        private uint erro;
        private List<object> objs = new List<object>();

        public PROTOCOL_MESSENGER_NOTE_DELETE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            int count = readC();
            for (int i = 0; i < count; i++)
            {
                objs.Add(readD());
            }
        }

        public override void run()
        {
            if (_client._player == null)
            {
                return;
            }
            try
            {
                if (!MessageManager.DeleteMessages(objs, _client.player_id))
                {
                    erro = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_MESSENGER_NOTE_DELETE_ACK(erro, objs));
                objs = null;
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_MESSENGER_NOTE_DELETE_REQ: " + ex.ToString());
            }
        }
    }
}