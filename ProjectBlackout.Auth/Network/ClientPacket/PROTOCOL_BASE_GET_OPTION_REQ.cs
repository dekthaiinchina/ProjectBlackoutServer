using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Auth.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_GET_OPTION_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_GET_OPTION_REQ(AuthClient client, byte[] data)
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
                if (p == null || p._myConfigsLoaded)
                {
                    return;
                }
                SendMessagesList(p);
                _client.SendPacket(new PROTOCOL_BASE_GET_OPTION_ACK(0, p._config));
                if (p.FriendSystem._friends.Count > 0)
                {
                    _client.SendPacket(new PROTOCOL_AUTH_FRIEND_INFO_ACK(p.FriendSystem._friends));
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_BASE_GET_OPTION_REQ: " + ex.ToString());
            }
        }

        private void SendMessagesList(Account p)
        {
            List<Message> msgs = MessageManager.getMessages(p.player_id);
            if (msgs.Count == 0)
            {
                return;
            }
            MessageManager.RecicleMessages(p.player_id, msgs);
            if (msgs.Count == 0)
            {
                return;
            }
            int pages = (int)Math.Ceiling(msgs.Count / 25d);
            for (int i = 0; i < pages; i++)
            {
                _client.SendPacket(new PROTOCOL_MESSENGER_NOTE_LIST_ACK(i, msgs));
            }
        }
    }
}