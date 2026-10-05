using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_NOTIFY_KICKVOTE_CANCEL_ACK : SendPacket
    {
        public PROTOCOL_BATTLE_NOTIFY_KICKVOTE_CANCEL_ACK()
        {

        }

        public override void write()
        {
            writeH(3405);
        }
    }
}