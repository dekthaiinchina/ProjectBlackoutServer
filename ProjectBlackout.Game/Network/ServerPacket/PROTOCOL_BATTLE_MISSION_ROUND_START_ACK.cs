using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_MISSION_ROUND_START_ACK : SendPacket
    {
        private Room _r;

        public PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(Room r)
        {
            _r = r;
        }

        public override void write()
        {
            writeH(4129);
            writeC((byte)_r.rounds);
            writeD(_r.getInBattleTimeLeft());
            writeH(AllUtils.getSlotsFlag(_r, true, false));
            writeC(0);
        }
    }
}