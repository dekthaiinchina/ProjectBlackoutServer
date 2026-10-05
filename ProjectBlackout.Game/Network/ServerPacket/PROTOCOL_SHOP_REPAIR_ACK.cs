using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_SHOP_REPAIR_ACK : SendPacket
    {
        private uint Error;
        private ItemsModel Item;
        private Account Player;

        public PROTOCOL_SHOP_REPAIR_ACK(uint Error, ItemsModel Item = null, Account Player = null)
        {
            this.Error = Error;
            if (Error != 1)
            {
                return;
            }
            if (Item != null)
            {
                this.Item = Item;
            }
            else
            {
                Error = 0x80000000;
            }
            this.Player = Player;
        }

        public override void write()
        {
            writeH(1077);
            writeH(0);
            writeD(Error);
            if (Error == 1)
            {
                writeC(0);
                writeD(Item._id);
                writeD(Player._money);
                writeD(Player._gp);
            }
        }
    }
}
