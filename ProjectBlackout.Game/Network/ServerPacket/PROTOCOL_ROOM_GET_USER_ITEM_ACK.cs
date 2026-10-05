using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_GET_USER_ITEM_ACK : SendPacket
    {
        private Account p;

        public PROTOCOL_ROOM_GET_USER_ITEM_ACK(Account p)
        {
            this.p = p;
        }

        public override void write()
        {
            List<ItemsModel> Coupons = p._inventory.getItemsByType(4);
            writeH(3900);
            writeH(0);
            writeH((short)Coupons.Count);
            for (int i = 0; i < Coupons.Count; i++)
            {
                ItemsModel Item = Coupons[i];
                writeD(Item._id);
            }
            writeD(p._equip._dino);
            writeD((int)p._inventory.getItem(p._equip._dino)._objId);
            writeD(p._equip._primary);
            writeD((int)p._inventory.getItem(p._equip._primary)._objId);
            writeD(p._equip._secondary);
            writeD((int)p._inventory.getItem(p._equip._secondary)._objId);
            writeD(p._equip._melee);
            writeD((int)p._inventory.getItem(p._equip._melee)._objId);
            writeD(p._equip._grenade);
            writeD((int)p._inventory.getItem(p._equip._grenade)._objId);
            writeD(p._equip._special);
            writeD((int)p._inventory.getItem(p._equip._special)._objId);
            if (p._slotId % 2 == 0)
            {
                writeD(p._equip._red);
                writeD((int)p._inventory.getItem(p._equip._red)._objId);
            }
            else
            {
                writeD(p._equip._blue);
                writeD((int)p._inventory.getItem(p._equip._blue)._objId);
            }
            writeD(p._equip.face);
            if (p._equip.face == 0)
            {
                writeD(0);
            }
            else
            {
                writeD((uint)p._inventory.getItem(p._equip.face)._objId);
            }
            writeD(p._equip._helmet);
            if (p._equip._helmet == 0)
            {
                writeD(0);
            }
            else
            {
                writeD((uint)p._inventory.getItem(p._equip._helmet)._objId);
            }
            writeD(p._equip.jacket);
            writeD((uint)p._inventory.getItem(p._equip.jacket)._objId);
            writeD(p._equip.poket);
            writeD((uint)p._inventory.getItem(p._equip.poket)._objId);
            writeD(p._equip.glove);
            writeD((uint)p._inventory.getItem(p._equip.glove)._objId);
            writeD(p._equip.belt);
            writeD((uint)p._inventory.getItem(p._equip.belt)._objId);
            writeD(p._equip.holster);
            writeD((uint)p._inventory.getItem(p._equip.holster)._objId);
            writeD(p._equip.skin);
            writeD((uint)p._inventory.getItem(p._equip.skin)._objId);
            writeD(p._equip._beret);
            if (p._equip._beret == 0)
            {
                writeD(0);
            }
            else
            {
                writeD((uint)p._inventory.getItem(p._equip._beret)._objId);
            }
            if (p._equip.accessory == 0)
            {
                writeD(0);
            }
            else
            {
                writeD((uint)p._inventory.getItem(p._equip.accessory)._objId);
            }
        }
    }
}