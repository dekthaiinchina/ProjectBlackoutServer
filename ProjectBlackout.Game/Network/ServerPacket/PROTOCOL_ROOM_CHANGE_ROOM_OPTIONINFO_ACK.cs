using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_CHANGE_ROOM_OPTIONINFO_ACK : SendPacket
    {
        private string Leader;
        private Room Room;

        public PROTOCOL_ROOM_CHANGE_ROOM_OPTIONINFO_ACK(Room room, string leader)
        {
            Room = room;
            Leader = leader;
        }

        public override void write()
        {
            writeH(3894);
            writeC(0);
            writeUnicode(Leader, 66);
            writeD(Room.killtime);
            writeC(Room.Limit);
            writeC(Room.WatchRuleFlag);
            writeH(Room.BalanceType);
            writeB(Room.RandomMaps);
            writeB(Room.RoomLeaderIP);
            writeC(Room.KillCam);
        }
    }
}