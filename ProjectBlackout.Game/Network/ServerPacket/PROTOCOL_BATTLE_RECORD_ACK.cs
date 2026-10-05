using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_RECORD_ACK : SendPacket
    {
        private Room _r;

        public PROTOCOL_BATTLE_RECORD_ACK(Room r)
        {
            _r = r;
        }

        public override void write()
        {
            writeH(4139);
            writeH((ushort)_r._redKills);
            writeH((ushort)_r._redDeaths);
            writeH((ushort)_r._redAssists);
            writeH((ushort)_r._blueKills);
            writeH((ushort)_r._blueDeaths);
            writeH((ushort)_r._blueAssists);
            for (int i = 0; i < 16; i++)
            {
                Slot slot = _r._slots[i];
                writeH((ushort)slot.allKills);
                writeH((ushort)slot.allDeaths);
                writeH((ushort)slot.allAssists);
            }
        }
    }
}