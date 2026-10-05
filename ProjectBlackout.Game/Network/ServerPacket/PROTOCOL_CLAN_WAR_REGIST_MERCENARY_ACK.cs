using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK : SendPacket
    {
        private Match m;

        public PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK(Match m)
        {
            this.m = m;
        }

        public override void write()
        {
            writeH(1552);
            writeH((short)m.getServerInfo());
            writeC((byte)m._state);
            writeC((byte)m.friendId);
            writeC((byte)m.formação);
            writeC((byte)m.getCountPlayers());
            writeD(m._leader);
            writeC(0);
            for (int i = 0; i < m._slots.Length; i++)
            {
                SlotMatch s = m._slots[i];
                Account p = m.getPlayerBySlot(s);
                if (p != null)
                {
                    writeC((byte)p._rank);
                    writeS(p.player_name, 33);
                    writeQ(s._playerId);
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