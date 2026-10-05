using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_LOBBY_NEW_VIEW_USER_ITEM_ACK : SendPacket
    {
        private Account ac;

        public PROTOCOL_LOBBY_NEW_VIEW_USER_ITEM_ACK(long player)
        {
            ac = AccountManager.getAccount(player, true);
        }

        public override void write()
        {
            List<ItemsModel> Coupons = ac._inventory.getItemsByType(4);
            writeH(3094);
            writeH(0);
            writeH((short)Coupons.Count);
            for (int i = 0; i < Coupons.Count; i++)
            {
                ItemsModel Item = Coupons[i];
                writeD(Item._id);
            }
            writeD(ac._equip._dino);
            writeC(15); // Size
            writeD(ac._equip._primary);
            writeD(ac._equip._secondary);
            writeD(ac._equip._melee);
            writeD(ac._equip._grenade);
            writeD(ac._equip._special);
            writeD(ac._equip._red);
            writeD(ac._equip.face);
            writeD(ac._equip._helmet);
            writeD(ac._equip.jacket);
            writeD(ac._equip.poket);
            writeD(ac._equip.glove);
            writeD(ac._equip.belt);
            writeD(ac._equip.holster);
            writeD(ac._equip.skin);
            writeD(ac._equip._beret);
            writeC(2); // Size
            writeD(ac._equip._red);
            writeD(ac._equip._blue);
        }
    }
}