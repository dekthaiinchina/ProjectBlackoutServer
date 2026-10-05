using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_CREATE_ACK : SendPacket
    {
        private Account leader;
        private Room room;
        private uint erro;

        public PROTOCOL_ROOM_CREATE_ACK(uint err, Room r, Account p)
        {
            erro = err;
            room = r;
            leader = p;
        }

        public override void write()
        {
            writeH(3842);
            writeD(erro == 0 ? (uint)room._roomId : erro);
            if (erro == 0)
            {
                writeD(room._roomId);
                writeUnicode(room.name, 46);
                writeC((byte)room.mapId);
                writeC((byte)room.rule);
                writeC(room.stage);
                writeC((byte)room.RoomType);
                writeC((byte)room.RoomState);
                writeC((byte)room.getAllPlayers().Count);
                writeC((byte)room.getSlotCount());
                writeC((byte)room._ping);
                writeH((ushort)room.weaponsFlag);
                writeD(room.getFlag());
                writeC(0);
                writeC(0);
                writeC(0);
                writeC(0);
                writeC(0);
                writeC(0);
                writeC(5);
                writeUnicode(leader.player_name, 66);
                writeD(room.killtime);
                writeC(room.Limit);
                writeC(room.WatchRuleFlag);
                writeH(room.BalanceType);
                writeB(new byte[16]);
            }
        }
    }
}