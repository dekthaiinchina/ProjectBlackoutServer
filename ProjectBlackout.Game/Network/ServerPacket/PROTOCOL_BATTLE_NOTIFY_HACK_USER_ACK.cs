using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_NOTIFY_HACK_USER_ACK : SendPacket
    {
        private int slotId;

        public PROTOCOL_BATTLE_NOTIFY_HACK_USER_ACK(int slot)
        {
            slotId = slot;
        }

        public override void write()
        {
            writeH(3413);
            writeC((byte)slotId); // Slot Hacker
            writeC(1); //?
            writeD(1); //?
        }
    }
}