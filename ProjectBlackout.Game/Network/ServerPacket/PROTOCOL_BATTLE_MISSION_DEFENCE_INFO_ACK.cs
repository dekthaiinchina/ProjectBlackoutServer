using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_MISSION_DEFENCE_INFO_ACK : SendPacket
    {
        private Room room;

        public PROTOCOL_BATTLE_MISSION_DEFENCE_INFO_ACK(Room room)
        {
            this.room = room;
        }

        public override void write()
        {
            writeH(4157);
            writeH((ushort)room.Bar1);
            writeH((ushort)room.Bar2);
            for (int i = 0; i < 16; i++)
            {
                writeH(room._slots[i].damageBar1);
            }
            for (int i = 0; i < 16; i++)
            {
                writeH(room._slots[i].damageBar2);
            }
        }
    }
}