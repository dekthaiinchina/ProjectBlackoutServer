using ProjectBlackout.Core.Models.Account;
using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_USER_GIFTLIST_ACK : SendPacket
    {
        private int erro;
        private List<Message> gifts;

        public PROTOCOL_BASE_USER_GIFTLIST_ACK(int erro, List<Message> gifts)
        {
            this.erro = erro;
            this.gifts = gifts;
        }

        public override void write()
        {
            writeH(684);
            writeH(0);
            writeC((byte)gifts.Count);
            for (int i = 0; i < gifts.Count; i++)
            {
                Message gift = gifts[i];

            }
            writeD(uint.Parse(DateTime.Now.ToString("yyMMddHHmm")));
        }
    }
}