using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_LOBBY_LEAVE_REQ : ReceivePacket
    {
        private uint erro;

        public PROTOCOL_LOBBY_LEAVE_REQ(GameClient client, byte[] data)
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
                if (_client == null || _client._player == null)
                {
                    return;
                }
                Account player = _client._player;
                Channel channel = player.getChannel();
                if (player._room != null || player._match != null)
                {
                    return;
                }
                if (channel == null || player.Session == null || !channel.RemovePlayer(player))
                {
                    erro = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_LOBBY_LEAVE_ACK(erro));
                if (erro == 0)
                {
                    player.ResetPages();
                    player._status.updateChannel(255);
                    AllUtils.syncPlayerToFriends(player, false);
                    AllUtils.syncPlayerToClanMembers(player);
                }
                else
                {
                    _client.Close(1000);
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_LOBBY_LEAVE_REQ: " + ex.ToString());
                _client.SendPacket(new PROTOCOL_LOBBY_LEAVE_ACK(0x80000000));
                _client.Close(1000);
            }
        }
    }
}