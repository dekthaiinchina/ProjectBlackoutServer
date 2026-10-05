using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Managers.Events;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Sync;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Data.Command.Commands
{
    class UpdateCommand : ICommand
    {
        public string Execute(string[] Params, GameClient Client, Account Account)
        {
            if (Client == null || Account == null)
                return "Error occured.";

            if (Params.Length != 2)
                return "Wrong usage. Type :commands to check the correct usage.";

            string Type = Params[1].Trim().ToLower();

            switch(Type)
            {
                case "shop":
                case "items":
                case "item":
                case "goods":
                case "good":
                    ShopManager.Reset();
                    ShopManager.Load(1);

                    for (int i = 0; i < ShopManager.ShopDataItems.Count; i++)
                    {
                        ShopData data = ShopManager.ShopDataItems[i];
                        Account.SendPacket(new PROTOCOL_AUTH_SHOP_ITEMLIST_ACK(data, ShopManager.TotalItems));
                    }
                    for (int i = 0; i < ShopManager.ShopDataGoods.Count; i++)
                    {
                        ShopData data = ShopManager.ShopDataGoods[i];
                        Account.SendPacket(new PROTOCOL_AUTH_SHOP_GOODSLIST_ACK(data, ShopManager.TotalGoods));
                    }
                    for (int i = 0; i < ShopManager.ShopDataItemRepairs.Count; i++)
                    {
                        ShopData data = ShopManager.ShopDataItemRepairs[i];
                        Account.SendPacket(new PROTOCOL_AUTH_SHOP_REPAIRLIST_ACK(data, ShopManager.TotalRepairs));
                    }
                    int cafe = Account.pc_cafe;
                    if (cafe == 0)
                    {
                        for (int i = 0; i < ShopManager.ShopDataMt1.Count; i++)
                        {
                            ShopData data = ShopManager.ShopDataMt1[i];
                            Account.SendPacket(new PROTOCOL_AUTH_SHOP_MATCHINGLIST_ACK(data, ShopManager.TotalMatching1));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ShopManager.ShopDataMt2.Count; i++)
                        {
                            ShopData data = ShopManager.ShopDataMt2[i];
                            Account.SendPacket(new PROTOCOL_AUTH_SHOP_MATCHINGLIST_ACK(data, ShopManager.TotalMatching2));
                        }
                    }
                    Account.SendPacket(new PROTOCOL_SHOP_GET_SAILLIST_ACK(true));

                    break;

                case "event":
                case "events":
                    EventLoader.ReloadAll();
                    GameSync.UpdatePartOfAuth(1);
                    break;

                case "permission":
                case "permissions":
                    PermissionManager.Load();
                    GameSync.UpdatePartOfAuth(2);
                    break;

                default: return "Unknown type '" + Type + "'";
            }

            return "'" + Type + "' updated.";
        }
    }
}
