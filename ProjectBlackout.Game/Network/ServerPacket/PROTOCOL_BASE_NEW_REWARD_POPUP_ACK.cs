using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_NEW_REWARD_POPUP_ACK : SendPacket
    {
        private List<ItemsModel> Items;

        public PROTOCOL_BASE_NEW_REWARD_POPUP_ACK(List<ItemsModel> Items)
        {
            this.Items = Items;
        }

        public override void write()
        {
            writeH(637);
            writeD(0);
            writeC((byte)Items.Count);
            for (int i = 0; i < Items.Count; i++)
            {
                ItemsModel Item = Items[i];
                writeD(Item._id);
                writeD((int)Item._count);
            }
        }
    }
}
