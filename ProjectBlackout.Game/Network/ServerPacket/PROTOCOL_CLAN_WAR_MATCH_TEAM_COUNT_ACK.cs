using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CLAN_WAR_MATCH_TEAM_COUNT_ACK : SendPacket
    {
        private int count;

        public PROTOCOL_CLAN_WAR_MATCH_TEAM_COUNT_ACK(int count)
        {
            this.count = count;
        }

        public override void write()
        {
            writeH(6915);
            writeH((short)count);
            writeC(13);
            writeH((short)Math.Ceiling(count / 13d));
        }
    }
}