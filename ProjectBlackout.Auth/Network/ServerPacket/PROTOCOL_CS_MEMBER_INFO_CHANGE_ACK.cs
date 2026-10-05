using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Auth.Data.Model;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK : SendPacket
    {
        private ulong status;
        private Account member;

        public PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK(Account player)
        {
            member = player;
            status = ComDiv.GetClanStatus(player._status, player._isOnline);
        }

        public PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK(Account player, FriendState st)
        {
            member = player;
            if (st == 0)
            {
                status = ComDiv.GetClanStatus(player._status, player._isOnline);
            }
            else
            {
                status = ComDiv.GetClanStatus(st);
            }
        }

        public override void write()
        {
            writeH(1875);
            writeQ(member.player_id);
            writeQ(status);
        }
    }
}