using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_STARTBATTLE_REQ : ReceivePacket
    {
        public PROTOCOL_BATTLE_STARTBATTLE_REQ(GameClient client, byte[] data)
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
                if (_client == null)
                {
                    return;
                }
                Account player = _client._player;
                Room room = player == null ? null : player._room;
                if (room != null && room.isPreparing())
                {
                    bool isBotMode = room.isBotMode();
                    Slot slot = room.getSlot(player._slotId);
                    if (slot == null)
                    {
                        return;
                    }
                    if (slot.state == SlotState.PRESTART)
                    {
                        room.changeSlotState(slot, SlotState.BATTLE_READY, true);
                        slot.StopTiming();
                        if (isBotMode)
                        {
                            _client.SendPacket(new PROTOCOL_BATTLE_CHANGE_DIFFICULTY_LEVEL_ACK(room));
                        }
                        _client.SendPacket(new PROTOCOL_ROOM_CHANGE_ROOMINFO_ACK(room, isBotMode));
                    }
                    else
                    {
                        _client.SendPacket(new PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK(EventErrorEnum.BATTLE_FIRST_HOLE));
                        _client.SendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(player, 0));
                        room.changeSlotState(slot, SlotState.NORMAL, true);
                        AllUtils.BattleEndPlayersCount(room, isBotMode);
                        return;
                    }
                    int blue12 = 0, red12 = 0, total = 0, red9 = 0, blue9 = 0;
                    for (int i = 0; i < 16; i++)
                    {
                        Slot slotR = room._slots[i];
                        if ((int)slotR.state >= 10)
                        {
                            total++;
                            if (slotR._team == 0)
                            {
                                red9++;
                            }
                            else
                            {
                                blue9++;
                            }
                            if ((int)slotR.state >= 14)
                            {
                                if (slotR._team == 0)
                                {
                                    red12++;
                                }
                                else
                                {
                                    blue12++;
                                }
                            }
                        }
                    }
                    /*
                    string txt = Translation.GetLabel("PlayerReady", player.player_name, (red + blue), total);
                    using (SERVER_MESSAGE_ANNOUNCE_PAK packet = new SERVER_MESSAGE_ANNOUNCE_PAK(txt))
                    {
                        room.SendPacketToPlayers(packet, SLOT_STATE.RENDEZVOUS, 1);
                    }
                    */
                    if (room.RoomState == RoomState.Battle ||
                        (int)room._slots[room._leader].state >= 14 && isBotMode &&
                        (room._leader % 2 == 0 && red12 > red9 / 2 || room._leader % 2 == 1 && blue12 > blue9 / 2) ||

                        (int)room._slots[room._leader].state >= 14 &&

                        ((!GameConfig.isTestMode || (int)GameConfig.udpType != 3) &&
                        blue12 > blue9 / 2 && red12 > red9 / 2 ||
                        GameConfig.isTestMode && (int)GameConfig.udpType == 3))
                    {
                        room.SpawnReadyPlayers(isBotMode);
                    }
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK(EventErrorEnum.BATTLE_FIRST_HOLE));
                    _client.SendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK());
                    if (room != null)
                    {
                        room.changeSlotState(player._slotId, SlotState.NORMAL, true);
                    }
                    if (room == null && player != null)
                    {
                        _client.SendPacket(new PROTOCOL_LOBBY_ENTER_ACK());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_BATTLE_STARTBATTLE_REQ: " + ex.ToString());
            }
        }
    }
}