using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_INV_ITEM_DATA_ACK : SendPacket
    {
        private int Type;
        private PlayerBonus Bonus;
        private Account Player;

        public PROTOCOL_BASE_INV_ITEM_DATA_ACK(int Type, Account Player)
        {
            this.Type = Type;
            this.Player = Player;
            this.Bonus = Player._bonus;
        }

        public override void write()
        {
            writeH(603);
            writeC((byte)Type);
            writeC((byte)Player.name_color);
            writeD(Bonus.fakeRank);
            writeD(Bonus.fakeRank);
            writeUnicode(Bonus.fakeNick, 66);
            writeH((short)Bonus.sightColor);
            writeH((short)Bonus.muzzle);
        }
    }
}