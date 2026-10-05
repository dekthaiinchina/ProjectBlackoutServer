using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CLAN_MATCH_RESULT_LIST_ACK : SendPacket
    {
        private List<Match> _c;
        private int _erro;

        public PROTOCOL_CS_CLAN_MATCH_RESULT_LIST_ACK(int erro, List<Match> c)
        {
            _erro = erro;
            _c = c;
        }

        public override void write()
        {
            writeH(1957);
            writeC((byte)(_erro == 0 ? _c.Count : _erro));
            if (_erro > 0 || _c.Count == 0)
            {
                return;
            }
            writeC(1);
            writeC(0);
            writeC((byte)_c.Count);
            for (int i = 0; i < _c.Count; i++)
            {
                Match m = _c[i];
                writeH((short)m._matchId);
                writeH((ushort)m.getServerInfo());
                writeH((ushort)m.getServerInfo());
                writeC((byte)m._state);
                writeC((byte)m.friendId);
                writeC((byte)m.formação);
                writeC((byte)m.getCountPlayers());
                writeC(0);
                writeD(m._leader);
                Account p = m.getLeader();
                if (p != null)
                {
                    writeC((byte)p._rank);
                    writeUnicode(p.player_name, 66);
                    writeQ(p.player_id);
                    writeC((byte)m._slots[m._leader].state);
                }
                else
                {
                    writeB(new byte[76]);
                }
            }
        }
    }
}