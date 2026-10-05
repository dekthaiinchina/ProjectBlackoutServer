using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_CREATE_REQ : ReceivePacket
    {
        private uint erro;
        private Room room;
        private Account p;

        public PROTOCOL_ROOM_CREATE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            p = _client._player;
            Channel channel = p == null ? null : p.getChannel();
            try
            {
                if (p == null || channel == null || p.player_name.Length == 0 || p._room != null || p._match != null)
                {
                    erro = 0x80000000;
                    return;
                }
                lock (channel._rooms)
                {
                    for (int i = 0; i < 300; i++)
                    {
                        if (channel.getRoom(i) == null)
                        {
                            room = new Room(i, channel);
                            readD();
                            room.name = readUnicode(46);
                            room.mapId = (MapIdEnum)readC();
                            room.rule = readC();
                            room.stage = readC();
                            room.RoomType = (RoomType)readC();
                            if (room.RoomType == 0)
                            {
                                break;
                            }
                            room.State = readC();
                            readC();
                            room.initSlotCount(readC());
                            readC();
                            room.weaponsFlag = (RoomWeaponsFlag)readH();
                            if ((byte)room.weaponsFlag <= 47 && (byte)room.weaponsFlag > 15)
                            {
                                room.SniperMode = true;
                            }
                            else if ((byte)room.weaponsFlag <= 79 && (byte)room.weaponsFlag > 47)
                            {
                                room.ShotgunMode = true;
                            }
                            room.Flag = (RoomStageFlag)readD();
                            bool isBotMode = room.isBotMode();
                            if (isBotMode && room._channelType == 4)
                            {
                                erro = 0x8000107D;
                                return;
                            }
                            readC();
                            readC();
                            readC();
                            readB(4);
                            readUnicode(66);
                            room.killtime = readD();
                            room.Limit = readC();
                            room.WatchRuleFlag = readC();
                            room.BalanceType = readH();
                            if (channel._type == 4)
                            {
                                room.Limit = 1;
                                room.BalanceType = 0;
                            }
                            room.RandomMaps = readB(16);
                            room.RoomLeaderIP = readB(4);
                            room.KillCam = readC();
                            room.password = readS(4);
                            if (isBotMode)
                            {
                                room.aiCount = readC();
                                room.aiLevel = readC();
                                room.aiType = readC();
                            }
                            room.addPlayer(p);
                            p.ResetPages();
                            room.SetSeed();
                            channel.AddRoom(room);
                            room.RoomState = RoomState.Ready;
                            return;
                        }
                    }
                    erro = 0x80000000;
                }
            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_LOBBY_CREATE_ROOM_REQ: " + ex.ToString());
                erro = 0x80000000;
            }
        }
        public override void run()
        {
            _client.SendPacket(new PROTOCOL_ROOM_CREATE_ACK(erro, room, p));
        }
    }
}