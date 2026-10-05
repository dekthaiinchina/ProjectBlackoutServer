using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CLAN_WAR_ENEMY_INFO_ACK : SendPacket
    {
        public Match mt;
        public PROTOCOL_CLAN_WAR_ENEMY_INFO_ACK(Match match)
        {
            mt = match;
        }

        public override void write()
        {
            writeH(1574);
            writeH((short)mt.getServerInfo());
            writeC((byte)mt._matchId);
            writeC((byte)mt.friendId);
            writeC((byte)mt.formação);
            writeC((byte)mt.getCountPlayers());
            writeD(mt._leader);
            writeC(0);
            writeD(mt.clan._id);
            writeC((byte)mt.clan._rank);
            writeD(mt.clan._logo);
            writeS(mt.clan._name, 17);
            writeT(mt.clan._pontos);
            writeC((byte)mt.clan._name_color);
        }
    }
}