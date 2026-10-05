using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Core.Models.Shop;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class ShopSearch
    {
        public static string SearchGoods(string str, Account player)
        {
            string key = str.Substring(6);
            int count = 0;
            string text = Translation.GetLabel("SearchGoodTitle");
            foreach (GoodItem good in ShopManager.ShopBuyableList)
            {
                if (good._item._name.Contains(key))
                {
                    text += "\n" + Translation.GetLabel("SearchGoodInfo", good.id, good._item._name);
                    if (++count >= 15)
                    {
                        break;
                    }
                }
            }
            player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(text));
            return Translation.GetLabel("SearchGoodSuccess", count);
        }
    }
}