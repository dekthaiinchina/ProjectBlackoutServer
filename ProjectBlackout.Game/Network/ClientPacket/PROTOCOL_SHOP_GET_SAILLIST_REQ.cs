using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Linq;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_SHOP_GET_SAILLIST_REQ : ReceivePacket
    {
        private string md5;

        public PROTOCOL_SHOP_GET_SAILLIST_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            md5 = readS(32);
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                if (p.LoadedShop)
                {
                    goto SendPacket;
                }
                p.LoadedShop = true;

                var Items = ShopManager.ShopDataItems.Split(808);
                var Goods = ShopManager.ShopDataGoods.Split(153);
                var Repairs = ShopManager.ShopDataItemRepairs.Split(100);
                var Matching1 = ShopManager.ShopDataMt1.Split(513);
                var Matching2 = ShopManager.ShopDataMt2.Split(513);

                foreach (var Item in Items)
                {
                    var List = Item.ToList();
                    for (int i = 0; i < List.Count; i++)
                    {
                        ShopData data = List[i];
                        _client.SendPacket(new PROTOCOL_AUTH_SHOP_ITEMLIST_ACK(data, ShopManager.TotalItems));
                    }
                }
                foreach (var Good in Goods)
                {
                    var List = Good.ToList();
                    for (int i = 0; i < List.Count; i++)
                    {
                        ShopData data = List[i];
                        _client.SendPacket(new PROTOCOL_AUTH_SHOP_GOODSLIST_ACK(data, ShopManager.TotalGoods));
                    }
                }
                foreach (var Repair in Repairs)
                {
                    var List = Repair.ToList();
                    for (int i = 0; i < List.Count; i++)
                    {
                        ShopData data = List[i];
                        _client.SendPacket(new PROTOCOL_AUTH_SHOP_REPAIRLIST_ACK(data, ShopManager.TotalRepairs));
                    }
                }
                _client.SendPacket(new PROTOCOL_BATTLEBOX_GET_LIST_ACK());
                int cafe = p.pc_cafe;
                if (cafe == 0)
                {
                    foreach (var Matching in Matching1)
                    {
                        var List = Matching.ToList();
                        for (int i = 0; i < List.Count; i++)
                        {
                            ShopData data = List[i];
                            _client.SendPacket(new PROTOCOL_AUTH_SHOP_MATCHINGLIST_ACK(data, ShopManager.TotalMatching1));
                        }
                    }
                }
                else
                {
                    foreach (var Matching in Matching2)
                    {
                        var List = Matching.ToList();
                        for (int i = 0; i < List.Count; i++)
                        {
                            ShopData data = List[i];
                            _client.SendPacket(new PROTOCOL_AUTH_SHOP_MATCHINGLIST_ACK(data, ShopManager.TotalMatching2));
                        }
                    }
                }
                _client.SendPacket(new PROTOCOL_SHOP_TAG_INFO_ACK());
            /*if (md5 == "00000000000000000000000000000000")
            {

            }*/
            SendPacket:
                if (ShopManager.ReadFile(Environment.CurrentDirectory + "/Data/Shop/Shop.dat") == md5)
                {
                    _client.SendPacket(new PROTOCOL_SHOP_GET_SAILLIST_ACK(false));
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_SHOP_GET_SAILLIST_ACK(true));
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_SHOP_GET_SAILLIST_REQ: " + ex.ToString());
            }
        }
    }
}