using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CLAN_LIST_DETAIL_INFO_ACK : SendPacket
    {
        private Clan Clan;
        private int Error;

        public PROTOCOL_CS_CLAN_LIST_DETAIL_INFO_ACK(int Error, Clan Clan)
        {
            this.Error = Error;
            this.Clan = Clan;
        }

        public override void write()
        {
            Account Player = AccountManager.getAccount(Clan.owner_id, 0);
            int players = PlayerManager.getClanPlayers(Clan._id);
            writeH(1947);
            writeD(Error);
            writeD(Clan._id);
            writeUnicode(Clan._name, 34);
            writeC((byte)Clan._rank);
            writeC((byte)players);
            writeC((byte)Clan.maxPlayers);
            writeD(Clan.creationDate);
            writeD(Clan._logo);
            writeC((byte)Clan._name_color);
            writeC((byte)Clan.effect);
            writeC((byte)Clan.getClanUnit());
            writeD(Clan._exp);
            writeD(10);
            writeQ(Clan.owner_id);
            writeUnicode(Player != null ? Player.player_name : "", 66);
            writeC((byte)(Player != null ? Player.name_color : 0));
            writeC((byte)(Player != null ? Player._rank : 0));
            writeUnicode(Clan._info, 510);
            writeUnicode("Temp", 42);
            writeC((byte)Clan.limite_rank);
            writeC((byte)Clan.limite_idade);
            writeC((byte)Clan.limite_idade2);
            writeC((byte)Clan.autoridade);
            writeUnicode(Clan._news, 510);
            writeD(Clan.partidas);
            writeD(Clan.vitorias);
            writeD(Clan.derrotas);
            writeD(Clan.partidas);
            writeD(Clan.vitorias);
            writeD(Clan.derrotas);

            writeD(0); // ?

            // Old Ranking
            writeD(0); // Fights
            writeD(0); // Win
            writeD(0); // Lose
            writeD(0);
            writeF(Clan._pontos);
            writeF(0); // ?

            // Last Season
            writeD(0); // Fights
            writeD(0); // Win
            writeD(0); // Lose
            writeD(0); // ?
            writeF(Clan._pontos);
            writeF(0); // ?

            writeQ(Clan.BestPlayers.Exp.PlayerId);
            writeQ(Clan.BestPlayers.Exp.PlayerId);
            writeQ(Clan.BestPlayers.Wins.PlayerId);
            writeQ(Clan.BestPlayers.Wins.PlayerId);
            writeQ(Clan.BestPlayers.Kills.PlayerId);
            writeQ(Clan.BestPlayers.Kills.PlayerId);
            writeQ(Clan.BestPlayers.Headshot.PlayerId);
            writeQ(Clan.BestPlayers.Headshot.PlayerId);
            writeQ(Clan.BestPlayers.Participation.PlayerId);
            writeQ(Clan.BestPlayers.Participation.PlayerId);
            writeB(new byte[66]);
        }
    }
}
