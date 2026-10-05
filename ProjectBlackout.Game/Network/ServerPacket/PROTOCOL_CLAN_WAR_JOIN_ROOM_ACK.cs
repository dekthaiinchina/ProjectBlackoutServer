using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CLAN_WAR_JOIN_ROOM_ACK : SendPacket
    {
        private Match _mt;
        private int _roomId, _team;
        public PROTOCOL_CLAN_WAR_JOIN_ROOM_ACK(Match match, int roomId, int team)
        {
            _mt = match;
            _roomId = roomId;
            _team = team;
        }

        public override void write()
        {
            writeH(1566);
            writeD(_roomId);
            writeH((ushort)_team);
            writeH((ushort)_mt.getServerInfo());
        }
    }
}