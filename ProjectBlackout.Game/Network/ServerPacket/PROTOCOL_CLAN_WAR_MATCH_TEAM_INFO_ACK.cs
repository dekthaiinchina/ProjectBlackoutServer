using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CLAN_WAR_MATCH_TEAM_INFO_ACK : SendPacket
    {
        private uint _erro;
        private Clan c;
        private Account leader;

        public PROTOCOL_CLAN_WAR_MATCH_TEAM_INFO_ACK(uint erro, Clan c)
        {
            _erro = erro;
            this.c = c;
            if (this.c != null)
            {
                leader = AccountManager.getAccount(this.c.owner_id, 0);
                if (leader == null)
                {
                    _erro = 0x80000000;
                }
            }
        }

        public PROTOCOL_CLAN_WAR_MATCH_TEAM_INFO_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(1570);
            writeD(_erro);
            if (_erro == 0)
            {
                int players = PlayerManager.getClanPlayers(c._id);
                writeD(c._id);
                writeS(c._name, 17);
                writeC((byte)c._rank);
                writeC((byte)players);
                writeC((byte)c.maxPlayers);
                writeD(c.creationDate);
                writeD(c._logo);
                writeC((byte)c._name_color);
                writeC((byte)c.getClanUnit(players));
                writeD(c._exp);
                writeD(0);
                writeQ(c.owner_id);
                writeS(leader.player_name, 33);
                writeC((byte)leader._rank);
                writeS("", 255);
            }
        }
    }
}