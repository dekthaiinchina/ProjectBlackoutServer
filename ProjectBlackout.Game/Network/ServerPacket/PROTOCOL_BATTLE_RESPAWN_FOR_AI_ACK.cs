using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_RESPAWN_FOR_AI_ACK : SendPacket
    {
        private int _slot;

        public PROTOCOL_BATTLE_RESPAWN_FOR_AI_ACK(int slot)
        {
            _slot = slot;
        }

        public override void write()
        {
            writeH(4151);
            writeD(_slot);
        }
    }
}