using ProjectBlackout.Core;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_LOBBY_GET_ROOMINFOADD_ACK : SendPacket
    {
        private Room room;
        private Account leader;

        public PROTOCOL_LOBBY_GET_ROOMINFOADD_ACK(Room room, Account leader)
        {
            this.room = room;
            this.leader = leader;
        }

        public override void write()
        {
            if (room == null || leader == null)
            {
                return;
            }
            writeH(3084);
            writeC(0);
            writeUnicode(leader.player_name, 66);
            writeC((byte)room.killtime);
            writeC((byte)(room.rounds - 1));
            writeH((ushort)room.getInBattleTime());
            writeC(room.Limit);
            writeC(room.WatchRuleFlag);
            writeH(room.BalanceType);
            writeB(room.RandomMaps);
            writeB(room.RoomLeaderIP);
            writeC(room.KillCam);
        }
    }
}