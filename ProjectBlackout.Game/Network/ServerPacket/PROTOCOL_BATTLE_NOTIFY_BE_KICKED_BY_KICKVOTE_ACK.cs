using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_NOTIFY_BE_KICKED_BY_KICKVOTE_ACK : SendPacket
    {
        public PROTOCOL_BATTLE_NOTIFY_BE_KICKED_BY_KICKVOTE_ACK()
        {

        }

        public override void write()
        {
            writeH(3409);
        }
    }
}