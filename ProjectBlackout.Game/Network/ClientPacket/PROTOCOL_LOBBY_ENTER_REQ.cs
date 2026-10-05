using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_LOBBY_ENTER_REQ : ReceivePacket
    {
        public PROTOCOL_LOBBY_ENTER_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            readC();
        }

        public override void run()
        {
            try
            {
                if (this._client == null)
                    return;
                Account player = this._client._player;
                if (player == null)
                    return;
                player.LastLobbyEnter = DateTime.Now;
                if (player.channelId >= 0)
                    player.getChannel()?.AddPlayer(player.Session);
                Room room = player._room;
                if (room != null)
                {
                    if (player._slotId < 0 || room.RoomState < RoomState.Loading || room._slots[player._slotId].state < SlotState.LOAD)
                        room.RemovePlayer(player, false);
                    else
                        goto label_9;
                }
                AllUtils.syncPlayerToFriends(player, false);
                AllUtils.syncPlayerToClanMembers(player);
                AllUtils.GetXmasReward(player);
                label_9:
                this._client.SendPacket((SendPacket)new PROTOCOL_LOBBY_ENTER_ACK());
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_LOBBY_ENTER_REQ: " + ex.ToString());
            }
        }

        /*public override void run()
        {
            try
            {
                if (_client == null)
                {
                    return;
                }
                Account player = _client._player;
                if (player == null)
                {
                    return;
                }
                player.LastLobbyEnter = DateTime.Now;
                player.channelId = 0;
                if (player.channelId >= 0)
                {
                    Channel ch = player.getChannel();
                    if (ch != null)
                    {
                        ch.AddPlayer(player.Session);
                    }
                }
                Room room = player._room;
                if (room != null)
                {
                    if (player._slotId >= 0 && room.RoomState >= RoomState.Loading && (int)room._slots[player._slotId].state >= 10)
                    {
                        goto JumpToPacket;
                    }
                    else
                    {
                        room.RemovePlayer(player, false);
                    }
                }
                AllUtils.syncPlayerToFriends(player, false);
                AllUtils.syncPlayerToClanMembers(player);
                AllUtils.GetXmasReward(player);
            JumpToPacket:
                _client.SendPacket(new PROTOCOL_LOBBY_ENTER_ACK());
                //_client.SendPacket(new PROTOCOL_BASE_MEGAPHONE_ACK(player.player_name, "Welcome to PointBlank 3.68! Alpha build 0.0.1"));
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_LOBBY_ENTER_REQ: " + ex.ToString());
            }
        }*/
    }
}