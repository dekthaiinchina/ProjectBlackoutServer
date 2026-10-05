using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_SENDPING_ACK : SendPacket
    {
        private byte[] Pings;

        public PROTOCOL_BATTLE_SENDPING_ACK(byte[] Pings)
        {
            this.Pings = Pings;
        }

        public override void write()
        {
            writeH(4123);
            writeB(Pings);
        }
    }
}