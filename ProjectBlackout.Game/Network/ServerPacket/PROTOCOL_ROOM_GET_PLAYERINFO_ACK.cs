using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_GET_PLAYERINFO_ACK : SendPacket
    {
        private Account p;

        public PROTOCOL_ROOM_GET_PLAYERINFO_ACK(Account player)
        {
            p = player;
        }

        public override void write()
        {
            writeH(3842);
            if (p == null || p._slotId == -1)
            {
                writeD(0x80000000);
                return;
            }
            Clan clan = ClanManager.getClan(p.clanId);
            writeD(p._slotId);
            writeS(p.player_name, 66); //33
            writeD(p._exp);
            writeD(p.getRank());
            writeD(p._rank);
            writeD(p._gp);
            writeD(p._money);
            writeD(clan._id);
            writeD(p.clanAccess);
            writeD(0);
            writeD(0);
            //writeC((byte)p.pc_cafe);
            writeC((byte)p.tourneyLevel);
            writeC((byte)p.name_color);
            //writeS(clan._name, 34); //17  MiThG
            writeC((byte)clan._rank);
            writeC((byte)clan.getClanUnit());
            writeD(uint.MinValue); //clan.logo 
            writeC(0); //clan.effect
            writeC((byte)clan._name_color);
            writeC(0);//210
            writeD(0);//namecard
            writeD(0); //writeC(0);
            writeD(p.LastRankUpDate);
            writeD(p._statistic.mvp); // MiTHG
            writeD(p._statistic.fights);
            writeD(p._statistic.fights_win);
            writeD(p._statistic.fights_lost);
            writeD(p._statistic.fights_draw);
            writeD(p._statistic.kills_count);
            writeD(p._statistic.headshots_count);
            writeD(p._statistic.deaths_count);
            writeD(p._statistic.totalfights_count);
            writeD(p._statistic.totalkills_count);
            writeD(p._statistic.escapes);
            writeD(p._statistic.mvp); // MiThG
            writeD(p._statistic.fights);
            writeD(p._statistic.fights_win);
            writeD(p._statistic.fights_lost);
            writeD(p._statistic.fights_draw);
            writeD(p._statistic.kills_count);
            writeD(p._statistic.headshots_count);
            writeD(p._statistic.deaths_count);
            writeD(p._statistic.totalfights_count);
            writeD(p._statistic.totalkills_count);
            writeD(p._statistic.escapes);
            writeD(p._equip._red);
            writeD(p._equip._blue);
            writeD(p._equip._helmet);
            writeD(p._equip._beret);
            writeD(p._equip._dino);
            writeD(p._equip._primary);
            writeD(p._equip._secondary);
            writeD(p._equip._melee);
            writeD(p._equip._grenade);
            writeD(p._equip._special);
            writeD(p._titles.Equiped1);
            writeD(p._titles.Equiped2);
            writeD(p._titles.Equiped3);
            writeD(p._equip.accessory);
        }
    }
}