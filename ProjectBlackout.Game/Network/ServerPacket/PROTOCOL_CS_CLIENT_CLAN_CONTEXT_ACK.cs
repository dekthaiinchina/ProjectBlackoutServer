using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CLIENT_CLAN_CONTEXT_ACK : SendPacket
    {
        private int clansCount;

        public PROTOCOL_CS_CLIENT_CLAN_CONTEXT_ACK(int count)
        {
            clansCount = count;
        }

        public override void write()
        {
            writeH(1800);
            writeD(clansCount);
            writeC(15);
            writeH((ushort)Math.Ceiling(clansCount / 15d));
            writeD(uint.Parse(DateTime.Now.ToString("MMddHHmmss")));
        }
    }
}