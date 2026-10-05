using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_LOBBY_GET_ROOMLIST_ACK : SendPacket
    {
        private int RoomPage;
        private int PlayerPage;
        private int AllPlayers;
        private int AllRooms;
        private int CountRoom;
        private int CountPlayer;
        private byte[] Rooms;
        private byte[] Players;

        public PROTOCOL_LOBBY_GET_ROOMLIST_ACK(
          int AllRooms,
          int AllPlayers,
          int RoomPage,
          int PlayerPage,
          int CountRoom,
          int CountPlayer,
          byte[] Rooms,
          byte[] Players)
        {
            this.AllRooms = AllRooms;
            this.AllPlayers = AllPlayers;
            this.RoomPage = RoomPage;
            this.PlayerPage = PlayerPage;
            this.Rooms = Rooms;
            this.Players = Players;
            this.CountRoom = CountRoom;
            this.CountPlayer = CountPlayer;
        }

        public override void write()
        {
            this.writeH((short)3078);
            this.writeD(this.AllRooms);
            this.writeD(this.RoomPage);
            this.writeD(this.CountRoom);
            this.writeB(this.Rooms);
            this.writeD(this.AllPlayers);
            this.writeD(this.PlayerPage);
            this.writeD(this.CountPlayer);
            this.writeB(this.Players);
        }
    }
}
