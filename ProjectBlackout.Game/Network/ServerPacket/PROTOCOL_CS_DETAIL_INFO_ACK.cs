using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_DETAIL_INFO_ACK : SendPacket
    {
        private Clan clan;
        private int _erro;

        public PROTOCOL_CS_DETAIL_INFO_ACK(int erro, Clan c)
        {
            _erro = erro;
            clan = c;
        }

        public override void write()
        {
            Account p = AccountManager.getAccount(clan.owner_id, 0);
            int players = PlayerManager.getClanPlayers(clan._id);
            writeH(1825);
            writeD(_erro);
            writeD(clan._id);
            writeUnicode(clan._name, 34);
            writeC((byte)clan._rank);
            writeC((byte)players);
            writeC((byte)clan.maxPlayers);
            writeD(clan.creationDate);
            writeD(clan._logo);
            writeC((byte)clan._name_color);
            writeC((byte)clan.effect);
            writeC((byte)clan.getClanUnit());
            writeD(clan._exp);
            writeD(10);
            writeQ(clan.owner_id);
            writeUnicode(p != null ? p.player_name : "", 66);
            writeC((byte)(p != null ? p.name_color : 0));
            writeC((byte)(p != null ? p._rank : 0));
            writeUnicode(clan._info, 510);
            writeUnicode("Temp", 42);
            writeC((byte)clan.limite_rank);
            writeC((byte)clan.limite_idade);
            writeC((byte)clan.limite_idade2);
            writeC((byte)clan.autoridade);
            writeUnicode(clan._news, 510);
            writeD(clan.partidas);
            writeD(clan.vitorias);
            writeD(clan.derrotas);
            writeD(clan.partidas); 
            writeD(clan.vitorias);
            writeD(clan.derrotas);

            writeD(0); // ?

            // Old Ranking
            writeD(clan.partidas); // Fights
            writeD(clan.vitorias); // Win
            writeD(clan.derrotas); // Lose
            writeD(0);
            writeF(clan._pontos);
            writeF(60); // ?

            // Last Season
            writeD(clan.partidas); // Fights
            writeD(clan.vitorias); // Win
            writeD(clan.derrotas); // Lose
            writeD(0); // ?
            writeF(clan._pontos);
            writeF(60); // ?

            writeQ(clan.BestPlayers.Exp.PlayerId);
            writeQ(clan.BestPlayers.Exp.PlayerId);
            writeQ(clan.BestPlayers.Wins.PlayerId);
            writeQ(clan.BestPlayers.Wins.PlayerId);
            writeQ(clan.BestPlayers.Kills.PlayerId);
            writeQ(clan.BestPlayers.Kills.PlayerId);
            writeQ(clan.BestPlayers.Headshot.PlayerId);
            writeQ(clan.BestPlayers.Headshot.PlayerId);
            writeQ(clan.BestPlayers.Participation.PlayerId);
            writeQ(clan.BestPlayers.Participation.PlayerId);
            writeB(new byte[66]);
        }
    }
}