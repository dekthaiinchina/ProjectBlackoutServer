using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class RefillShop
    {
        public static string SimpleRefill(Account player)
        {
            ShopManager.Reset();
            ShopManager.Load(1);
            Logger.warning(Translation.GetLabel("RefillShopWarn", player.player_name));
            return Translation.GetLabel("RefillShopMsg");
        }

        public static string InstantRefill(Account player)
        {
            ShopManager.Reset();
            ShopManager.Load(1);

            for (int i = 0; i < ShopManager.ShopDataItems.Count; i++)
            {
                ShopData data = ShopManager.ShopDataItems[i];
                player.SendPacket(new PROTOCOL_AUTH_SHOP_ITEMLIST_ACK(data, ShopManager.TotalItems));
            }
            for (int i = 0; i < ShopManager.ShopDataGoods.Count; i++)
            {
                ShopData data = ShopManager.ShopDataGoods[i];
                player.SendPacket(new PROTOCOL_AUTH_SHOP_GOODSLIST_ACK(data, ShopManager.TotalGoods));
            }
            for (int i = 0; i < ShopManager.ShopDataItemRepairs.Count; i++)
            {
                ShopData data = ShopManager.ShopDataItemRepairs[i];
                player.SendPacket(new PROTOCOL_AUTH_SHOP_REPAIRLIST_ACK(data, ShopManager.TotalRepairs));
            }
            int cafe = player.pc_cafe;
            if (cafe == 0)
            {
                for (int i = 0; i < ShopManager.ShopDataMt1.Count; i++)
                {
                    ShopData data = ShopManager.ShopDataMt1[i];
                    player.SendPacket(new PROTOCOL_AUTH_SHOP_MATCHINGLIST_ACK(data, ShopManager.TotalMatching1));
                }
            }
            else
            {
                for (int i = 0; i < ShopManager.ShopDataMt2.Count; i++)
                {
                    ShopData data = ShopManager.ShopDataMt2[i];
                    player.SendPacket(new PROTOCOL_AUTH_SHOP_MATCHINGLIST_ACK(data, ShopManager.TotalMatching2));
                }
            }
            player.SendPacket(new PROTOCOL_SHOP_GET_SAILLIST_ACK(true));

            Logger.warning(Translation.GetLabel("RefillShopWarn", player.player_name));
            return Translation.GetLabel("RefillShopMsg");
        }
    }
}