using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Auth.Network.ServerPacket;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_GET_SYSTEM_INFO_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_GET_SYSTEM_INFO_REQ(AuthClient lc, byte[] buff)
        {
            makeme(lc, buff);
        }

        public override void read()
        {
            readC();
        }

        public override void run()
        {
            try
            {
                Account player = _client._player;
                _client.SendPacket(new PROTOCOL_BASE_NOTICE_ACK());
                _client.SendPacket(new PROTOCOL_BASE_URL_LIST_ACK());
                //_client.SendPacket(new PROTOCOL_BASE_BOOSTEVENT_INFO_ACK());
                //_client.SendPacket(new PROTOCOL_BASE_STEPUP_MODE_INFO_ACK());
                _client.SendPacket(new PROTOCOL_BASE_CHANNELTYPE_CONDITION_ACK());
                _client.SendPacket(new PROTOCOL_BASE_GET_SYSTEM_INFO_ACK());


                // TODO! Stub, 1 server will always be displayed and not the region selection, I’ll fix it later
                player._config = PlayerManager.getConfigDB(player.player_id);
                if (player._config == null)
                {
                    PlayerManager.CreateConfigDB(player.player_id);
                }//0xFFFFFFFF
                _client.SendPacket(new PROTOCOL_BASE_GET_OPTION_ACK(0, player._config));

                //TODO! Not implemented
                if (player == null || !AuthManager.Config.GiftSystem)
                {
                    return;
                }
                List<Message> gifts = MessageManager.getGifts(player.player_id);
                if (gifts.Count > 0)
                {
                    MessageManager.RecicleMessages(player.player_id, gifts);
                    if (gifts.Count > 0)
                    {
                        //_client.SendPacket(new PBSL_BASE_USER_GIFTLIST_ACK(0, gifts)); // Not Fix
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
        }
    }
}