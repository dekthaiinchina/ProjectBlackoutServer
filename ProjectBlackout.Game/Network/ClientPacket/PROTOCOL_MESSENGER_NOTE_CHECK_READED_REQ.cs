using ProjectBlackout.Core;
using ProjectBlackout.Core.Network;
using NpgsqlTypes;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_MESSENGER_NOTE_CHECK_READED_REQ : ReceivePacket
    {
        private int msgsCount;
        private List<int> messages = new List<int>();

        public PROTOCOL_MESSENGER_NOTE_CHECK_READED_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            msgsCount = readC();
            for (int i = 0; i < msgsCount; i++)
            {
                messages.Add(readD());
            }
        }

        public override void run()
        {
            try
            {
                if (_client == null || _client._player == null || msgsCount == 0)
                {
                    return;
                }
                ComDiv.updateDB("player_messages", "object_id", messages.ToArray(), "owner_id", _client.player_id, new string[] { "expire", "state" }, long.Parse(DateTime.Now.AddDays(7).ToString("yyMMddHHmm")), 0);
                _client.SendPacket(new PROTOCOL_MESSENGER_NOTE_CHECK_READED_ACK(messages));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_MESSENGER_NOTE_CHECK_READED_REQ: " + ex.ToString());
            }
        }
    }
}