using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CREATE_CLAN_ACK : SendPacket
    {
        private Account _p;
        private Clan clan;
        private uint _erro;

        public PROTOCOL_CS_CREATE_CLAN_ACK(uint erro, Clan clan, Account player)
        {
            _erro = erro;
            this.clan = clan;
            _p = player;
        }

        public override void write()
        {
            writeH(1831);
            writeD(_erro);
            if (_erro == 0)
            {
                writeD(clan._id);
                writeUnicode(clan._name, 34);
                writeC((byte)clan._rank);
                writeC((byte)PlayerManager.getClanPlayers(clan._id));
                writeC((byte)clan.maxPlayers);
                writeD(clan.creationDate);
                writeD(clan._logo);
                writeB(new byte[11]);
                writeQ(clan.owner_id);
                writeS(_p.player_name, 66);
                writeC((byte)_p.name_color);
                writeC((byte)_p._rank);
                writeUnicode(clan._info, 510);
                writeUnicode("Temp", 42);
                writeC((byte)clan.limite_rank);
                writeC((byte)clan.limite_idade);
                writeC((byte)clan.limite_idade2);
                writeC((byte)clan.autoridade);
                writeUnicode("", 510);
                writeB(new byte[44]);
                writeF(clan._pontos);
                writeF(60);
                writeB(new byte[16]);
                writeF(clan._pontos);
                writeF(60);
                writeB(new byte[80]);
                writeB(new byte[66]);
                writeD(_p._gp);
            }
        }
    }
}