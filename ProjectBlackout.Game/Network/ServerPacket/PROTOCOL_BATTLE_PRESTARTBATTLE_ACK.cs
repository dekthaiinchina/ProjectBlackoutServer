using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_PRESTARTBATTLE_ACK : SendPacket
    {
        private Account Player, Leader;
        private Room Room;
        private bool isPreparing, LoadHits;
        private uint UniqueRoomId, Seed;

        public PROTOCOL_BATTLE_PRESTARTBATTLE_ACK(Account Player, Account Leader, bool LoadHits)
        {
            this.Player = Player;
            this.Leader = Leader;
            this.LoadHits = LoadHits;
            this.Room = Player._room;
            if (Room != null)
            {
                isPreparing = Room.isPreparing();
                UniqueRoomId = Room.UniqueRoomId;
                Seed = Room.Seed;
            }
        }

        public PROTOCOL_BATTLE_PRESTARTBATTLE_ACK()
        {

        }

        public override void write()
        {
            writeH(4106);
            writeD(isPreparing);
            if (!isPreparing)
            {
                return;
            }
            writeD(Player._slotId);
            if (Room.RoomType != RoomType.Tutorial)
            {
                writeC((byte)GameConfig.udpType);
            }
            else
            {
                writeC(1);
            }
            writeIP(Room.UdpServer.Connection.Address);
            writeH((ushort)Room.UdpServer.Port);
            writeD(UniqueRoomId);
            writeD(Seed);
            if (LoadHits)
            {
                writeB(new byte[35]
                {
                    0x15, 0x0A, 0x0B, 0x0C,
                    0x0D, 0x0E, 0x06, 0x10,
                    0x11, 0x12, 0x0f, 0x14,
                    0x21, 0x16, 0x03, 0x13,
                    0x19, 0x1A, 0x1B, 0x1C,
                    0x1D, 0x1E, 0x1F, 0x20,
                    0x09, 0x22, 0x00, 0x01,
                    0x02, 0x17, 0x04, 0x05,
                    0x18, 0x07, 0x08,
                });
            }
        }
    }
}