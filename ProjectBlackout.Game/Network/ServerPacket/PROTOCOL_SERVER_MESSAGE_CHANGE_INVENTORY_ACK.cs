using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_SERVER_MESSAGE_CHANGE_INVENTORY_ACK : SendPacket
    {
        private PlayerEquipedItems Equip;
        private Account Player;

        public PROTOCOL_SERVER_MESSAGE_CHANGE_INVENTORY_ACK(Account Player)
        {
            this.Player = Player;
            PlayerManager.CheckEquipedItems(Player._equip, Player._inventory._items);
            Equip = Player._equip;
        }

        public override void write()
        {
            List<ItemsModel> Coupons = Player._inventory.getItemsByType(4);
            writeH(2570);
            writeH(0);
            writeC((byte)Coupons.Count);
            for (int i = 0; i < Coupons.Count; i++)
            {
                ItemsModel Coupon = Coupons[i];
                writeD(Coupon._id);
            }
            writeC((byte)Coupons.Count);
            writeC(0);
            writeC((byte)Player.Characters.Count);
            for (int i = 0; i < Player.Characters.Count; i++)
            {
                Character Character = Player.Characters[i];
                writeC((byte)Character.Slot);
                writeD(Equip._primary);
                writeD((uint)Player._inventory.getItem(Equip._primary)._objId);
                writeD(Equip._secondary);
                writeD((uint)Player._inventory.getItem(Equip._secondary)._objId);
                writeD(Equip._melee);
                writeD((uint)Player._inventory.getItem(Equip._melee)._objId);
                writeD(Equip._grenade);
                writeD((uint)Player._inventory.getItem(Equip._grenade)._objId);
                writeD(Equip._special);
                writeD((uint)Player._inventory.getItem(Equip._special)._objId);
                writeD(Character.Id);
                writeD((uint)Player._inventory.getItem(Character.Id)._objId);
                writeD(Equip.face);
                if (Equip.face == 0)
                {
                    writeD(0);
                }
                else
                {
                    writeD((uint)Player._inventory.getItem(Equip.face)._objId);
                }
                writeD(Equip._helmet);
                if (Equip._helmet == 0)
                {
                    writeD(0);
                }
                else
                {
                    writeD((uint)Player._inventory.getItem(Equip._helmet)._objId);
                }
                writeD(Equip.jacket);
                writeD((uint)Player._inventory.getItem(Equip.jacket)._objId);
                writeD(Equip.poket);
                writeD((uint)Player._inventory.getItem(Equip.poket)._objId);
                writeD(Equip.glove);
                writeD((uint)Player._inventory.getItem(Equip.glove)._objId);
                writeD(Equip.belt);
                writeD((uint)Player._inventory.getItem(Equip.belt)._objId);
                writeD(Equip.holster);
                writeD((uint)Player._inventory.getItem(Equip.holster)._objId);
                writeD(Equip.skin);
                writeD((uint)Player._inventory.getItem(Equip.skin)._objId);
                writeD(Equip._beret);
                if (Equip._beret == 0)
                {
                    writeD(0);
                }
                else
                {
                    writeD((uint)Player._inventory.getItem(Equip._beret)._objId);
                }
            }
            writeD(Equip._dino);
            writeD((uint)Player._inventory.getItem(Equip._dino)._objId);
        }
    }
}