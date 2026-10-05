using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_MISSION_GENERATOR_INFO_ACK : SendPacket
    {
        private Room _room;

        public PROTOCOL_BATTLE_MISSION_GENERATOR_INFO_ACK(Room room)
        {
            _room = room;
        }

        public override void write()
        {
            writeH(4143);
            writeH((ushort)_room.Bar1);
            writeH((ushort)_room.Bar2);
            for (int i = 0; i < 16; i++)
            {
                writeH(_room._slots[i].damageBar1);
            }
        }
    }
}