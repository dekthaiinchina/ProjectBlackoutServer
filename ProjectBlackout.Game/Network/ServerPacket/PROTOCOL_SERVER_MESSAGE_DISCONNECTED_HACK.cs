using PointBlank.Core.Network;
using System;

namespace PointBlank.Game.Network.ServerPacket
{
    public class PROTOCOL_SERVER_MESSAGE_DISCONNECTED_HACK : SendPacket
    {
        private uint _erro;
        private bool type;

        public PROTOCOL_SERVER_MESSAGE_DISCONNECTED_HACK(uint erro, bool HackUse)
        {
            _erro = erro;
            type = HackUse;
        }

        public override void write()
        {
            writeH(2062);
            writeD(uint.Parse(DateTime.Now.ToString("MMddHHmmss")));
            writeD(_erro);
            writeD(type);
            if (type)
            {
                writeD(0);
            }
        }
    }
}