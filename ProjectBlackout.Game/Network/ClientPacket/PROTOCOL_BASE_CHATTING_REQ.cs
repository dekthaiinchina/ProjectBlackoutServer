using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Chat;
using ProjectBlackout.Game.Data.Command;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Text;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_CHATTING_REQ : ReceivePacket
    {
        private string text;
        private ChattingType type;
        public bool SendAll;
        public bool SendMe;

        public PROTOCOL_BASE_CHATTING_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            type = (ChattingType)readH();
            text = readUnicode(readH() * 2);
            SendAll = false;
        }

        public override void run()
        {
            try
            {
                Account player = _client._player;
                if (player == null || string.IsNullOrEmpty(text) || text.Length > 60 || player.player_name.Length == 0)
                {
                    return;
                }
                Room room = player._room;
                Slot sender;
                switch (type)
                {
                    case ChattingType.Team:
                        {
                            if (room == null)
                            {
                                return;
                            }

                            sender = room._slots[player._slotId];
                            int[] array = room.GetTeamArray(sender._team);
                            using (PROTOCOL_ROOM_CHATTING_ACK packet = new PROTOCOL_ROOM_CHATTING_ACK((int)type, sender._id, player.UseChatGM(), text))
                            {
                                byte[] data = packet.GetCompleteBytes("PROTOCOL_BASE_CHATTING_REQ-1");
                                lock (room._slots)
                                {
                                    for (int i = 0; i < array.Length; i++)
                                    {
                                        int slotIdx = array[i];
                                        Slot receiver = room._slots[slotIdx];
                                        Account pR = room.getPlayerBySlot(receiver);
                                        if (pR != null && SlotValidMessage(sender, receiver))
                                        {
                                            pR.SendCompletePacket(data);
                                        }
                                    }
                                }
                            }
                            break;
                        }

                    case ChattingType.All:
                    case ChattingType.Lobby:
                        {
                            if (room != null)
                            {
                                if (!CommandManager.ParseCommand(text, _client, player))
                                {
                                    sender = room._slots[player._slotId];
                                    using (PROTOCOL_ROOM_CHATTING_ACK packet = new PROTOCOL_ROOM_CHATTING_ACK((int)type, sender._id, player.UseChatGM(), text))
                                    {
                                        byte[] data = packet.GetCompleteBytes("PROTOCOL_BASE_CHATTING_REQ-2");
                                        lock (room._slots)
                                        {
                                            for (int slotIdx = 0; slotIdx < 16; ++slotIdx)
                                            {
                                                Slot receiver = room._slots[slotIdx];
                                                Account pR = room.getPlayerBySlot(receiver);
                                                if (pR != null && SlotValidMessage(sender, receiver))
                                                {
                                                    pR.SendCompletePacket(data);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Channel channel = player.getChannel();
                                if (channel == null)
                                {
                                    return;
                                }

                                if (!CommandManager.ParseCommand(text, _client, player))
                                {
                                    using (PROTOCOL_LOBBY_CHATTING_ACK packet = new PROTOCOL_LOBBY_CHATTING_ACK(player, text))
                                    {
                                        channel.SendPacketToWaitPlayers(packet);
                                    }
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
        }

        private bool SlotValidMessage(Slot sender, Slot receiver)
        {
            return (((int)sender.state == 8 || (int)sender.state == 9) && ((int)receiver.state == 8 || (int)receiver.state == 9) ||
                    ((int)sender.state >= 10 && (int)receiver.state >= 10) && (receiver.specGM ||
                    sender.specGM ||
                    sender._deathState.HasFlag(DeadEnum.UseChat) ||
                    sender._deathState.HasFlag(DeadEnum.Dead) && receiver._deathState.HasFlag(DeadEnum.Dead) ||
                    sender.espectador && receiver.espectador ||
                    sender._deathState.HasFlag(DeadEnum.Alive) && receiver._deathState.HasFlag(DeadEnum.Alive) && (sender.espectador && receiver.espectador || !sender.espectador && !receiver.espectador)));
        }
    }
}