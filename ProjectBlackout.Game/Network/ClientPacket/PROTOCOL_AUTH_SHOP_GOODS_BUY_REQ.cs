using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Shop;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_SHOP_GOODS_BUY_REQ : ReceivePacket
    {
        private List<CartGoods> ShopCart = new List<CartGoods>();

        public PROTOCOL_AUTH_SHOP_GOODS_BUY_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            int count = readH();
            for (int i = 0; i < count; i++)
            {
                ShopCart.Add(new CartGoods
                {
                    GoodId = readD(),
                    BuyType = readC(),
                });
                readQ();
            }
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null || p.player_name.Length == 0)
                {
                    _client.SendPacket(new PROTOCOL_AUTH_SHOP_GOODS_BUY_ACK(2147487767));
                    return;
                }
                if (p._inventory._items.Count >= 500)
                {
                    _client.SendPacket(new PROTOCOL_AUTH_SHOP_GOODS_BUY_ACK(2147487929));
                    return;
                }
                int gold, cash;
                List<GoodItem> Items = ShopManager.getGoods(ShopCart, out gold, out cash);
                if (Items.Count == 0)
                {
                    _client.SendPacket(new PROTOCOL_AUTH_SHOP_GOODS_BUY_ACK(2147487767));
                }
                else if (0 > (p._gp - gold) || 0 > (p._money - cash))
                {
                    _client.SendPacket(new PROTOCOL_AUTH_SHOP_GOODS_BUY_ACK(2147487768));
                }
                else if (PlayerManager.updateAccountCashing(p.player_id, (p._gp - gold), (p._money - cash)))
                {
                    p._gp -= gold;
                    p._money -= cash;
                    _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, p, Items));
                    _client.SendPacket(new PROTOCOL_AUTH_SHOP_GOODS_BUY_ACK(1, Items, p));
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_AUTH_SHOP_GOODS_BUY_ACK(2147487769));
                }
            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_AUTH_SHOP_GOODS_BUY_REQ: " + ex.ToString());
            }
        }
    }
}