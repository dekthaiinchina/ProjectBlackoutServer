using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Shop;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Sync.Server;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_INVENTORY_GET_INFO_ACK : SendPacket
    {
        private int Type;
        private List<ItemsModel> Items = new List<ItemsModel>();

        public PROTOCOL_INVENTORY_GET_INFO_ACK(int Type, Account Player, ItemsModel Item)
        {
            this.Type = Type;
            AddItems(Player, Item);
        }

        public PROTOCOL_INVENTORY_GET_INFO_ACK(int Type, Account Player, List<GoodItem> Items)
        {
            this.Type = Type;
            AddItems(Player, Items);
        }

        public override void write()
        {
            writeH(3334);
            writeH(0);
            writeH((short)Items.Count);
            for (int i = 0; i < Items.Count; i++)
            {
                ItemsModel Item = Items[i];
                writeD((uint)Item._objId);
                writeD(Item._id);
                writeC((byte)Item._equip);
                writeD((int)Item._count);
            }
            writeC((byte)Type);
        }

        private void AddItems(Account Player, ItemsModel Item)
        {
            try
            {
                ItemsModel Model = new ItemsModel(Item) { _objId = Item._objId };
                if (Type == 0)
                {
                    PlayerManager.tryCreateItem(Model, Player._inventory, Player.player_id);
                }
                SendItemInfo.LoadItem(Player, Model);
                Items.Add(Model);
            }
            catch (Exception ex)
            {
                Player.Close(0);
                Logger.warning("PROTOCOL_INVENTORY_GET_INFO_ACK: " + ex.ToString());
            }
        }

        private void AddItems(Account Player, List<GoodItem> Goods)
        {
            GoodItem g2 = null;
            try
            {
                foreach (GoodItem Good in Goods)
                {
                    g2 = Good;
                    ItemsModel iv = Player._inventory.getItem(Good._item._id);
                    ItemsModel Model = new ItemsModel(Good._item);
                    if (Type == 0)
                    {
                        PlayerManager.tryCreateItem(Model, Player._inventory, Player.player_id);
                    }
                    SendItemInfo.LoadItem(Player, Model);
                    Items.Add(Model);
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_INVENTORY_GET_INFO_ACK: " + ex.ToString());
            }
        }
    }
}