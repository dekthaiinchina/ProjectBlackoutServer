using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_CREATE_ROOM_REQ : ReceivePacket
    {
        private Match MyMatch, EnemyMatch;
        private int roomId = -1;

        public PROTOCOL_CLAN_WAR_CREATE_ROOM_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            Account p = _client._player;
            if (p == null || p.clanId == 0)
            {
                return;
            }
            Channel channel = p.getChannel();
            MyMatch = p._match;
            if (channel == null || MyMatch == null)
            {
                return;
            }
            int match = readH();
            int channel1 = readD();
            int channel2 = readD();
            EnemyMatch = channel.getMatch(match);
            try
            {
                if (EnemyMatch == null)
                {
                    return;
                }
                lock (channel._rooms)
                {
                    for (int i = 0; i < 300; i++)
                    {
                        if (channel.getRoom(i) == null)
                        {
                            Room room = new Room(i, channel);
                            readH();
                            room.name = readS(23);
                            room.mapId = (MapIdEnum)readH();
                            room.stage = readC();
                            room.RoomType = (RoomType)readC();
                            readH();
                            room.initSlotCount(readC());
                            readC();
                            room.weaponsFlag = (RoomWeaponsFlag)readC();
                            room.Flag = (RoomStageFlag)readC();
                            room.password = "";
                            room.killtime = 3;
                            room.addPlayer(p);
                            channel.AddRoom(room);
                            _client.SendPacket(new PROTOCOL_ROOM_CREATE_ACK(0, room, p));
                            roomId = i;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public override void run()
        {
            if (roomId == -1)
            {
                return;
            }
            using (PROTOCOL_CLAN_WAR_ENEMY_INFO_ACK packet = new PROTOCOL_CLAN_WAR_ENEMY_INFO_ACK(EnemyMatch))
            using (PROTOCOL_CLAN_WAR_JOIN_ROOM_ACK packet2 = new PROTOCOL_CLAN_WAR_JOIN_ROOM_ACK(EnemyMatch, roomId, 0))
            {
                byte[] data = packet.GetCompleteBytes("PROTOCOL_CLAN_WAR_CREATE_ROOM_REQ-1");
                byte[] data2 = packet2.GetCompleteBytes("PROTOCOL_CLAN_WAR_CREATE_ROOM_REQ-2");
                for (int i = 0; i < MyMatch.getAllPlayers(MyMatch._leader).Count; i++)
                {
                    Account pM = MyMatch.getAllPlayers(MyMatch._leader)[i];
                    if (pM._match != null)
                    {
                        pM.SendCompletePacket(data);
                        pM.SendCompletePacket(data2);
                        MyMatch._slots[pM.matchSlot].state = SlotMatchState.Ready;
                    }
                }
            }
            using (PROTOCOL_CLAN_WAR_ENEMY_INFO_ACK packet = new PROTOCOL_CLAN_WAR_ENEMY_INFO_ACK(MyMatch))
            using (PROTOCOL_CLAN_WAR_JOIN_ROOM_ACK packet2 = new PROTOCOL_CLAN_WAR_JOIN_ROOM_ACK(MyMatch, roomId, 1))
            {
                byte[] data = packet.GetCompleteBytes("PROTOCOL_CLAN_WAR_CREATE_ROOM_REQ-3");
                byte[] data2 = packet2.GetCompleteBytes("PROTOCOL_CLAN_WAR_CREATE_ROOM_REQ-4");
                for (int idx = 0; idx < EnemyMatch.getAllPlayers().Count; idx++)
                {
                    Account pM = EnemyMatch.getAllPlayers()[idx];
                    if (pM._match != null)
                    {
                        pM.SendCompletePacket(data);
                        pM.SendCompletePacket(data2);
                        MyMatch._slots[pM.matchSlot].state = SlotMatchState.Ready;
                    }
                }
            }
        }
    }
}