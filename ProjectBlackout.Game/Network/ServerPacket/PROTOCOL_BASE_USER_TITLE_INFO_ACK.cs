using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_USER_TITLE_INFO_ACK : SendPacket
    {
        private Account p;

        public PROTOCOL_BASE_USER_TITLE_INFO_ACK(Account player)
        {
            p = player;
        }

        public override void write()
        {
            writeH(591);
            writeH(0);
            writeB(BitConverter.GetBytes(p.player_id), 0, 4);
            writeQ(p._titles.Flags);
            writeC((byte)p._titles.Equiped1);
            writeC((byte)p._titles.Equiped2);
            writeC((byte)p._titles.Equiped3);
            writeD(p._titles.Slots);
        }
    }
}