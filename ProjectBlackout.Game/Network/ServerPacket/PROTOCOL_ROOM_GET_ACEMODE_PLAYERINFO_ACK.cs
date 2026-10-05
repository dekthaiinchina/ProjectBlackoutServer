using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    class PROTOCOL_ROOM_GET_ACEMODE_PLAYERINFO_ACK : SendPacket
    {
        private Account Player;
        public PROTOCOL_ROOM_GET_ACEMODE_PLAYERINFO_ACK(Account Player)
        {
            this.Player = Player;
        }

        public override void write()
        {
            Clan Clan = ClanManager.getClan(Player.clanId);
            writeH(3935);

            writeD(Player._slotId);
            writeD(0);
            writeH(10);

            writeD(2); // win
            writeD(1); // loses
            writeD(10); // kill
            writeD(5); // death
            writeD(5); // hs
            writeD(1); // strike win?

            //writeB(new byte[124]);
            for (int i = 0; i < 62; i++)
                writeH(150);

            writeC(0);
            writeC(0);
            writeC(0);
            writeUnicode(Player.player_name, 66);
            writeD(Player._rank);
            writeD(Player._rank);
            writeD(Player._gp);
            writeD(Player._exp);
            writeD(0);
            writeC(0);
            writeD(0);
            writeQ(0);
            writeH(0);
            writeD(Player._money);
            writeD(Clan._id);
            writeD(Player.clanAccess);
            writeQ(0);
            writeC((byte)Player.pc_cafe);
            writeC((byte)Player.tourneyLevel);
            writeUnicode(Clan._name, 34);
            writeC((byte)Clan._rank);
            writeC((byte)Clan.getClanUnit());
            writeD(Clan._logo);
            writeC((byte)Clan._name_color);
            writeC((byte)Clan.effect);
        }
    }
}
