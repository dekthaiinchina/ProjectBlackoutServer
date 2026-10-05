using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_SERVER_MESSAGE_DISCONNECTIONSUCCESS_ACK : SendPacket
    {
        private uint _erro;
        private bool type;

        public PROTOCOL_SERVER_MESSAGE_DISCONNECTIONSUCCESS_ACK(uint erro, bool HackUse)
        {
            _erro = erro;
            type = HackUse;
        }

        public override void write()
        {
            writeH(2562);
            writeD(uint.Parse(DateTime.Now.ToString("MMddHHmmss")));
            writeD(_erro);
            writeD(type); //Se for igual a 1, novo writeD (Da DC no cliente, Programa ilegal)
            if (type)
            {
                writeD(0);
            }
        }
    }
}