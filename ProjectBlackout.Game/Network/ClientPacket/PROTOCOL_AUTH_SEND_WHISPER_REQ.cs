using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_SEND_WHISPER_REQ : ReceivePacket
    {
        private long player_id;
        private string receiverName, text;

        public PROTOCOL_AUTH_SEND_WHISPER_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            player_id = readQ();
            receiverName = readUnicode(66);
            text = readUnicode(readH() * 2);
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null || p.player_name == receiverName)
                {
                    return;
                }
                Account pW = AccountManager.getAccount(receiverName, 1, 0);
                if (pW == null || !pW._isOnline)
                {
                    _client.SendPacket(new PROTOCOL_AUTH_SEND_WHISPER_ACK(receiverName, text, 0x80000000));
                }
                else
                {
                    pW.SendPacket(new PROTOCOL_AUTH_RECV_WHISPER_ACK(p.player_name, text, p.UseChatGM()), false);
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}