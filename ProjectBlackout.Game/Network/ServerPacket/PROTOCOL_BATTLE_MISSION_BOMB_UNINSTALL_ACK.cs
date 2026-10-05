using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_MISSION_BOMB_UNINSTALL_ACK : SendPacket
    {
        private int _slot;

        public PROTOCOL_BATTLE_MISSION_BOMB_UNINSTALL_ACK(int slot)
        {
            _slot = slot;
        }

        public override void write()
        {
            writeH(4135);
            writeD(_slot);
        }
    }
}