using System.Collections.Generic;
using ProjectBlackout.Auth;
using ProjectBlackout.Core.Managers.Events;
using ProjectBlackout.Core.Managers.Server;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Servers;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Auth.Data.Managers;
using System;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_GET_USER_INFO_ACK : SendPacket
    {
        private Account Player;
        private Clan Clan;
        private uint Error;

        public PROTOCOL_BASE_GET_USER_INFO_ACK(Account Player)
        {
            this.Player = Player;
            if (Player != null)
            {
                Clan = ClanManager.getClanDB(Player.clan_id, 1);
            }
            else
            {
                Error = 0x80000000;
            }
        }

        public override void write()
        {
            ServerConfig cfg = AuthManager.Config;
            EventVisitModel ev = EventVisitSyncer.getRunningEvent();

            PlayerEvent playerEvent = this.Player._event;
            bool showEvents = (ev != null && (playerEvent.LastVisitSequence1 < ev.checks && playerEvent.NextVisitDate <= int.Parse(DateTime.Now.ToString("yyMMdd")) || playerEvent.LastVisitSequence2 < ev.checks && playerEvent.LastVisitSequence2 != playerEvent.LastVisitSequence1));

            writeH(525);
            writeH(0);
            writeD(Error);
            if (Error != 0)
            {
                return;
            }
            writeB(new byte[55]); //secret
            writeC((byte)Player.Characters.Count);
            writeH(210);
            writeC((byte)Player.Quickstarts.Count);
            for (int i = 0; i < Player.Quickstarts.Count; i++)
            {
                QuickStart Quick = Player.Quickstarts[i];
                writeC((byte)Quick.MapId);
                writeC((byte)Quick.Rule);
                writeC((byte)Quick.StageOptions);
                writeC((byte)Quick.Type);
            }
            writeB(new byte[34]);
            writeC(4);//only 4? what is it?
            writeD(0);
            writeD(0);
            writeD(0);
            writeD(0);
            writeD(0);
            writeD(Player._titles.Slots);
            writeC(3); //Player Equiped titles
            writeC((byte)Player._titles.Equiped1);
            writeC((byte)Player._titles.Equiped2);
            writeC((byte)Player._titles.Equiped3);
            writeQ(Player._titles.Flags);
            writeC(160);
            writeB(Player._mission.list1);
            writeB(Player._mission.list2);
            writeB(Player._mission.list3);
            writeB(Player._mission.list4);
            writeC((byte)Player._mission.actualMission);
            writeC((byte)Player._mission.card1);
            writeC((byte)Player._mission.card2);
            writeC((byte)Player._mission.card3);
            writeC((byte)Player._mission.card4);
            writeB(ComDiv.getCardFlags(Player._mission.mission1, Player._mission.list1));
            writeB(ComDiv.getCardFlags(Player._mission.mission2, Player._mission.list2));
            writeB(ComDiv.getCardFlags(Player._mission.mission3, Player._mission.list3));
            writeB(ComDiv.getCardFlags(Player._mission.mission4, Player._mission.list4));
            writeC((byte)Player._mission.mission1);
            writeC((byte)Player._mission.mission2);
            writeC((byte)Player._mission.mission3);
            writeC((byte)Player._mission.mission4);
            writeD(Player.blue_order);
            writeD(Player.medal);
            writeD(Player.insignia);
            writeD(Player.brooch);
            writeB(new byte[11]);
            writeIP("127.0.0.1"); //public ip
            writeD(uint.Parse(DateTime.Now.ToString("yyMMddHHmm")));
            if (Player.Characters.Count == 0)
            {
                writeC(0);
                writeC(1);
            }
            else
            {
                writeC((byte)(Player.getCharacter(Player._equip._red) == null ? 0 : Player.getCharacter(Player._equip._red).Slot));
                writeC((byte)(Player.getCharacter(Player._equip._blue) == null ? 1 : Player.getCharacter(Player._equip._blue).Slot));
            }
            writeD(Player._equip._dino);
            if (Player._inventory.getItem(Player._equip._dino) == null)
            {
                writeD(0);
            }
            else
            {
                writeD((uint)Player._inventory.getItem(Player._equip._dino)._objId);
            }

            writeD(0); //secret
            writeD(0); //secret objid
            writeD(0); //secret
            writeD(0); //secret objid

            writeD(0); //flags

            writeD(0);
            writeD(0);
            writeC(0);
            writeD(0);
            writeD(0);
            writeC(0);
            writeC((byte)Player.name_color);//+
            writeD(Player._bonus.fakeRank);//+
            writeD(Player._bonus.fakeRank);//++
            writeUnicode(Player._bonus.fakeNick, 66);
            writeH((short)Player._bonus.sightColor);
            writeH((short)Player._bonus.muzzle);
            writeC(0);
            writeD(Player._statistic.fights);
            writeD(Player._statistic.fights_win);
            writeD(Player._statistic.fights_lost);
            writeD(Player._statistic.fights_draw);
            writeD(Player._statistic.kills_count);
            writeD(Player._statistic.headshots_count);
            writeD(Player._statistic.deaths_count);
            writeD(Player._statistic.totalfights_count);
            writeD(Player._statistic.totalkills_count);
            writeD(Player._statistic.escapes);
            writeD(Player._statistic.assist);
            writeD(667); //mvp
            writeD(Player._statistic.fights);
            writeD(Player._statistic.fights_win);
            writeD(Player._statistic.fights_lost);
            writeD(Player._statistic.fights_draw);
            writeD(Player._statistic.kills_count);
            writeD(Player._statistic.headshots_count);
            writeD(Player._statistic.deaths_count);
            writeD(Player._statistic.totalfights_count);
            writeD(Player._statistic.totalkills_count);
            writeD(Player._statistic.escapes);
            writeD(Player._statistic.assist);
            writeD(667); //mvp
            writeUnicode(Player.player_name, 66);//731
            writeD(Player._rank);
            writeD(Player._rank);
            writeD(Player._gp);
            writeD(Player._exp); //624 byte rus 3.16 -621
            writeB(new byte[15]);
            writeD(777); //tags
            writeD(0);
            writeH(0);
            writeH(0); //secret
            writeD(Player._money);
            writeD(Clan._id);
            writeD(Player.clanAccess);
            writeQ(Player.Status());
            writeC((byte)Player.pc_cafe);
            writeC((byte)Player.tourneyLevel);
            writeUnicode(Clan._name, 34);
            writeC((byte)Clan._rank);
            writeC((byte)Clan.getClanUnit());
            writeD(Clan._logo);
            writeC((byte)Clan._name_color);
            writeC(41); //player_age
        }
    }
}
