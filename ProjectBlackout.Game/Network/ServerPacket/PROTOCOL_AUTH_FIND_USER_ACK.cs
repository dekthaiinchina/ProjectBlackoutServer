using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_FIND_USER_ACK : SendPacket
    {
        private uint _erro;
        private Account player;

        public PROTOCOL_AUTH_FIND_USER_ACK(uint erro, Account player)
        {
            _erro = erro;
            this.player = player;
        }

        public override void write()
        {
            writeH(810);
            writeD(_erro);
            if (_erro == 0)
            {
                writeC((byte)player.getRank());
                writeD(ComDiv.GetPlayerStatus(player._status, player._isOnline));
                writeUnicode(ClanManager.getClan(player.clanId)._name, 34);
                writeD(player._statistic.fights);
                writeD(player._statistic.fights_win);
                writeD(player._statistic.fights_lost);
                writeD(player._statistic.fights_draw);
                writeD(player._statistic.kills_count);
                writeD(player._statistic.headshots_count);
                writeD(player._statistic.deaths_count);
                writeD(player._statistic.totalfights_count);
                writeD(player._statistic.totalkills_count);
                writeD(player._statistic.escapes);
                writeD(player._statistic.assist);
                writeD(player._statistic.fights);
                writeD(player._statistic.fights_win);
                writeD(player._statistic.fights_lost);
                writeD(player._statistic.fights_draw);
                writeD(player._statistic.kills_count);
                writeD(player._statistic.headshots_count);
                writeD(player._statistic.deaths_count);
                writeD(player._statistic.totalfights_count);
                writeD(player._statistic.totalkills_count);
                writeD(player._statistic.escapes);
                writeD(player._statistic.assist);
                writeD(player._equip._primary);
                writeD(player._equip._secondary);
                writeD(player._equip._melee);
                writeD(player._equip._grenade);
                writeD(player._equip._special);
                writeD(player._equip._red);
                writeD(player._equip.face);
                writeD(player._equip._helmet);
                writeD(player._equip.jacket);
                writeD(player._equip.poket);
                writeD(player._equip.glove);
                writeD(player._equip.belt);
                writeD(player._equip.holster);
                writeD(player._equip.skin);
                writeD(player._equip._beret);
                writeD(player._equip._red);
                writeD(player._equip._blue);
            }
        }
    }
}