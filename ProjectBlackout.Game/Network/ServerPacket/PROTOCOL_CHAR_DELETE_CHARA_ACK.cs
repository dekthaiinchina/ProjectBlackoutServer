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
    public class PROTOCOL_CHAR_DELETE_CHARA_ACK : SendPacket
    {
        private uint Error;
        private int Slot;
        private Account Player;
        private ItemsModel Item;

        public PROTOCOL_CHAR_DELETE_CHARA_ACK(uint Error, int Slot = 0, Account Player = null, ItemsModel Item = null)
        {
            this.Error = Error;
            this.Slot = Slot;
            this.Player = Player;
            this.Item = Item;
        }

        public override void write()
        {
            writeH(6152);
            writeD(Error);
            if (Error == 0)
            {
                int Type = ComDiv.getIdStatics(Item._id, 2);
                writeC((byte)Slot);
                writeD((int)Item._objId);
                if (Type == 1)
                {
                    writeD(Player.getCharacter(Player._equip._red).Slot);
                }
                else if (Type == 2)
                {
                    writeD(Player.getCharacter(Player._equip._blue).Slot);
                }
            }
        }
    }
}
