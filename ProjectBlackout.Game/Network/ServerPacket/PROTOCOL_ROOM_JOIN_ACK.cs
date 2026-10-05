using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System.Collections.Generic;
using System.Net;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_JOIN_ACK : SendPacket
    {
        private uint erro;
        private Room room;
        private int slotId;
        private Account leader;
        private Account player;

        public PROTOCOL_ROOM_JOIN_ACK(uint erro, Account player = null, Account leader = null)
        {
            this.erro = erro;
            this.player = player;
            if (player != null)
            {
                slotId = player._slotId;
                room = player._room;
                this.leader = leader;
            }
        }

        public override void write()
        {
            writeH(3844);
            writeH(0);
            if (erro == 0 && room != null && leader != null)
            {
                lock (room._slots)
                {
                    WriteData();
                }
            }
            else
            {
                writeD(erro);
            }
        }

        private void WriteData()
        {
            List<Account> roomPlayers = room.getAllPlayers();
            writeD(0);
            writeC(16);
            int SlotId;
            for (int Id = 0; Id < 16; Id++)
            {
                Slot Slot = room.getSlot(Id);
                SlotId = Slot._id % 2;
                writeC((byte)SlotId);
            }
            writeC(16);
            for (int i = 0; i < 16; i++)
            {
                Slot slot = room._slots[i];
                Account player = room.getPlayerBySlot(slot);
                if (player != null)
                {
                    Clan clan = ClanManager.getClan(player.clanId);
                    writeC((byte)slot.state);
                    writeC((byte)player.getRank());
                    writeD(clan._id);
                    writeD(player.clanAccess);
                    writeC((byte)clan._rank);
                    writeD(clan._logo);
                    writeC((byte)player.pc_cafe);
                    writeC((byte)player.tourneyLevel);
                    writeD((uint)player.effects);
                    writeC((byte)clan.effect);
                    writeC(0);
                    writeH(210);
                    writeUnicode(clan._name, 34);
                    writeC((byte)slot._id);
                    writeUnicode(player.player_name, 66);
                    writeC((byte)player.name_color);
                    writeC((byte)player._bonus.muzzle);
                    writeC(0);
                    writeC(255);
                    writeC(255);
                }
                else
                {
                    writeC((byte)slot.state);
                    writeB(new byte[10]);
                    writeD(4294967295);
                    writeB(new byte[44]);
                    writeC((byte)slot._id);
                    writeB(new byte[68]);
                    writeC(0);
                    writeC(255);
                    writeC(255);
                }
            }
            writeC(room.aiType);
            writeC(room.RoomState > RoomState.Ready ? room.IngameAiLevel : room.aiLevel);
            writeC(room.aiCount);
            writeC((byte)roomPlayers.Count);
            writeC((byte)room._leader);
            writeC((byte)room.countdown.getTimeLeft());
            writeC((byte)room.password.Length);
            writeS(room.password, room.password.Length);
            writeB(new byte[17]);
            writeUnicode(leader.player_name, 66);
            writeD(room.killtime);
            writeC(room.Limit);
            writeC(room.WatchRuleFlag);
            writeH(room.BalanceType);
            writeB(room.RandomMaps);
            writeIP(room.getLeader().PublicIP == null ? IPAddress.Parse("127.0.0.1") : room.getLeader().PublicIP);
            writeC(room.KillCam);
            writeD(room._roomId);
            writeUnicode(room.name, 46);
            writeC((byte)room.mapId);
            writeC((byte)room.rule);
            writeC(room.stage);
            writeC((byte)room.RoomType);
            writeC((byte)room.RoomState);
            writeC((byte)roomPlayers.Count);
            writeC((byte)room.getSlotCount());
            writeC((byte)room._ping);
            writeH((ushort)room.weaponsFlag);
            writeD(room.getFlag());
            writeH(0);
            writeB(room.RoomLeaderIP);
            writeC((byte)slotId);
        }
    }
}