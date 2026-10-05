using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_LOBBY_GET_ROOMLIST_REQ : ReceivePacket
    {
        public PROTOCOL_LOBBY_GET_ROOMLIST_REQ(GameClient client, byte[] data)
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
                if (p == null)
                {
                    return;
                }
                Channel channel = p.getChannel();
                if (channel != null)
                {
                    channel.RemoveEmptyRooms();
                    List<Room> Rooms = channel._rooms;
                    List<Account> Waiting = channel.getWaitPlayers();
                    int RoomPages = (int)Math.Ceiling(Rooms.Count / 15d), PlayerPages = (int)Math.Ceiling(Waiting.Count / 10d);
                    if (p.LastRoomPage >= RoomPages)
                    {
                        p.LastRoomPage = 0;
                    }
                    if (p.LastPlayerPage >= PlayerPages)
                    {
                        p.LastPlayerPage = 0;
                    }
                    int RoomsCount = 0, PlayersCount = 0;
                    byte[] RoomsArray = GetRoomListData(p.LastRoomPage, ref RoomsCount, Rooms);
                    byte[] WaitingArray = GetPlayerListData(p.LastPlayerPage, ref PlayersCount, Waiting);
                    _client.SendPacket(new PROTOCOL_LOBBY_GET_ROOMLIST_ACK(Rooms.Count, Waiting.Count, p.LastRoomPage++, p.LastPlayerPage++, RoomsCount, PlayersCount, RoomsArray, WaitingArray));
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_LOBBY_GET_ROOMLIST_REQ: " + ex.ToString());
            }
        }

        private byte[] GetRoomListData(int page, ref int count, List<Room> list)
        {
            int startid = 0;
            if (page == 0)
                startid = 15;
            else
                startid = 16;
            using (SendGPacket p = new SendGPacket())
            {
                for (int i = (page * startid); i < list.Count; i++)
                {
                    WriteRoomData(list[i], p);
                    if (++count == 15)
                    {
                        break;
                    }
                }
                return p.mstream.ToArray();
            }
        }

        private void WriteRoomData(Room room, SendGPacket p)
        {
            p.writeD(room._roomId);
            p.writeUnicode(room.name, 46);
            p.writeC((byte)room.mapId);
            p.writeC((byte)room.rule);
            p.writeC(room.stage);
            p.writeC((byte)room.RoomType);
            p.writeC((byte)room.RoomState);
            p.writeC((byte)room.getAllPlayers().Count);
            p.writeC((byte)room.getSlotCount());
            p.writeC((byte)room._ping);
            p.writeH((ushort)room.weaponsFlag);
            p.writeH((ushort)room.getFlag());
            p.writeC((byte)room._leader);
            p.writeH(200);
            p.writeC(0);
        }

        private void WritePlayerData(Account pl, SendGPacket p)
        {
            Clan clan = ClanManager.getClan(pl.clanId);
            p.writeD(pl.getSessionId());
            p.writeD(clan._logo);
            p.writeC((byte)clan.effect);
            p.writeUnicode(clan._name, 34);
            p.writeH((short)pl.getRank());
            p.writeUnicode(pl.player_name, 66);
            p.writeC((byte)pl.name_color); // 0
            p.writeC(0); //210
            p.writeD(0);
            p.writeC(0);
        }

        private byte[] GetPlayerListData(int page, ref int count, List<Account> list)
        {
            int startid = 0;
            if (page == 0)
                startid = 10;
            else
                startid = 11;
            using (SendGPacket p = new SendGPacket())
            {
                for (int i = (page * startid); i < list.Count; i++)
                {
                    WritePlayerData(list[i], p);
                    if (++count == 10)
                    {
                        break;
                    }
                }
                return p.mstream.ToArray();
            }
        }
    }
}