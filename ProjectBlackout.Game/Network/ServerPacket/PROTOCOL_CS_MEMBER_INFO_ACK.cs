using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_MEMBER_INFO_ACK : SendPacket
    {
        private List<Account> _players;

        public PROTOCOL_CS_MEMBER_INFO_ACK(List<Account> players)
        {
            _players = players;
        }
        public override void write()
        {
            writeH(1869);
            writeC((byte)_players.Count);
            for (int i = 0; i < _players.Count; i++)
            {
                Account member = _players[i];
                writeC((byte)(member.player_name.Length + 1));
                writeUnicode(member.player_name, true);
                writeQ(member.player_id);
                writeQ(ComDiv.GetClanStatus(member._status, member._isOnline));
                writeC((byte)member._rank);
                writeC((byte)member.name_color);
            }
        }
    }
}