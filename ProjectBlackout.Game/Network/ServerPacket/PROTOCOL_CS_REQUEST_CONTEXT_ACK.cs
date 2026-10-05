using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_REQUEST_CONTEXT_ACK : SendPacket
    {
        private uint _erro;
        private int invites;

        public PROTOCOL_CS_REQUEST_CONTEXT_ACK(int clanId)
        {
            if (clanId > 0)
            {
                invites = PlayerManager.getRequestCount(clanId);
            }
            else
            {
                _erro = 4294967295;
            }
        }

        public override void write()
        {
            writeH(1841);
            writeD(_erro);
            if (_erro == 0)
            {
                writeC((byte)invites);
                writeC(13);
                writeC((byte)Math.Ceiling(invites / 13d));
                writeD(uint.Parse(DateTime.Now.ToString("MMddHHmmss")));
            }
        }
    }
}