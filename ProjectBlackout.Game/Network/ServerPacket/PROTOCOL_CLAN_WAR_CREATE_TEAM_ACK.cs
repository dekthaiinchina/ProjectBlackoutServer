using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CLAN_WAR_CREATE_TEAM_ACK : SendPacket
    {
        private uint _erro;
        private Match m;

        public PROTOCOL_CLAN_WAR_CREATE_TEAM_ACK(uint erro, Match mt = null)
        {
            _erro = erro;
            m = mt;
        }

        public override void write()
        {
            writeH(1547);
            writeD(_erro);
            if (_erro == 0)
            {
                writeH((short)m._matchId);
                writeH((short)m.getServerInfo());
                writeH((short)m.getServerInfo());
                writeC((byte)m._state);
                writeC((byte)m.friendId);
                writeC((byte)m.formação);
                writeC((byte)m.getCountPlayers());
                writeD(m._leader);
                writeC(0);
            }
        }
    }
}