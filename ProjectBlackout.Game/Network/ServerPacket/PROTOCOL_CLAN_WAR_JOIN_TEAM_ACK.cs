using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CLAN_WAR_JOIN_TEAM_ACK : SendPacket
    {
        private Match m;
        private uint _erro;

        public PROTOCOL_CLAN_WAR_JOIN_TEAM_ACK(uint erro, Match m = null)
        {
            _erro = erro;
            this.m = m;
        }

        public override void write()
        {
            writeH(1549);
            writeD(_erro);
            if (_erro == 0)
            {
                writeH((short)m._matchId);
                writeH((ushort)m.getServerInfo());
                writeH((ushort)m.getServerInfo());
                writeC((byte)m._state);
                writeC((byte)m.friendId);
                writeC((byte)m.formação);
                writeC((byte)m.getCountPlayers());
                writeD(m._leader);
                writeC(0);
                writeD(m.clan._id);
                writeC((byte)m.clan._rank);
                writeD(m.clan._logo);
                writeS(m.clan._name, 17);
                writeT(m.clan._pontos);
                writeC((byte)m.clan._name_color);
                for (int i = 0; i < m.formação; i++)
                {
                    SlotMatch s = m._slots[i];
                    Account pS = m.getPlayerBySlot(s);
                    if (pS != null)
                    {
                        writeC((byte)pS._rank);
                        writeS(pS.player_name, 33);
                        writeQ(pS.player_id);
                        writeC((byte)s.state);
                    }
                    else
                    {
                        writeB(new byte[43]);
                    }
                }
            }
        }
    }
}