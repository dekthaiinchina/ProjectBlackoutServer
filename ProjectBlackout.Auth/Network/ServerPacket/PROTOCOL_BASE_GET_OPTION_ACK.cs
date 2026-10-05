using Org.BouncyCastle.Asn1.Mozilla;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_GET_OPTION_ACK : SendPacket
    {
        private int error;
        private PlayerConfig c;
        private bool isValid;

        public PROTOCOL_BASE_GET_OPTION_ACK(int error, PlayerConfig config)
        {
            this.error = error;
            c = config;
            isValid = (c != null);
        }

        public PROTOCOL_BASE_GET_OPTION_ACK(int error)
        {
            this.error = error;
        }

        // Fixed by DavaJ
        public override void write()
        {
            writeH(529);
            writeH(0);
            writeD(error);
            if (error < 0)
                return;

            if (isValid)
            {
                writeB(new byte[12]);
                writeH(49);
                writeB(new byte[] { 0x39, 0xF8, 0x10, 0x00 });
                writeB(c.keys);
                writeH((short)c.blood);
                writeC((byte)c.sight);
                writeC((byte)c.hand);
                writeD(c.config);
                writeB(new byte[5]
                {
                    0x00, 0x37,
                    0x00, 0x00, 0x00
                });
                writeD(c.audio_enable);
                writeH(0);
                writeC((byte)c.audio1);
                writeC((byte)c.audio2);
                writeC((byte)c.fov);
                writeC(0);
                writeC((byte)c.sensibilidade);
                writeC((byte)c.mouse_invertido);
                writeH(0);
                writeC((byte)c.msgConvite);
                writeC((byte)c.chatSussurro);
                writeD(c.macro);

            }
            else
            {
                writeB(new byte[39]);
                writeC(!isValid);
            }

        }
    }
}