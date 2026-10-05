using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Shop;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Data.Command.Commands
{
    class GiftCommand : ICommand
    {
        public string Execute(string[] Params, GameClient Client, Account Account)
        {
            if (Client == null || Account == null)
                return "Error occured.";

            if (Params.Length != 4)
            {
                return "Wrong usage. Type :commands to check the correct usage.";
            }

            int UserId;
            if (!int.TryParse(Params[1], out UserId))
                return "Wrong usage. Type :commands to check the correct usage.";

            Account Recipient = AccountManager.getAccount(UserId, 0);
            if (Recipient == null)
                return "User id is wrong or user is offline.";

            int Count;

            string Type = Params[2].Trim().ToLower();
            switch(Type)
            {
                case "good":
                case "item":
                    int GoodId;
                    if (!int.TryParse(Params[3], out GoodId))
                        return "Wrong usage. Type :commands to check the correct usage.";

                    foreach (GoodItem good in ShopManager.ShopBuyableList)
                    {
                        if(good.id == GoodId)
                        {
                            int category = ComDiv.GetItemCategory(good._item._id);
                            if (category == 2)
                                return "You can't send characters as a gift.";

                            Recipient.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, Recipient, new List<GoodItem>()
                            {
                                good
                            }));

                            return "Item " + good._item._name + " sended correctly.";
                        }
                    }

                    return "Item not founded.";

                case "cash":
                case "moneys":
                case "money":


                    if (!int.TryParse(Params[3], out Count))
                        return "Wrong usage. Type :commands to check the correct usage.";

                    if (PlayerManager.updateAccountCash(UserId, Count + Recipient._money))
                    {
                        Recipient._money += Count;
                        Recipient.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, Recipient._gp, Recipient._money));
                        Recipient.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK("You've received " + Count + " moneys"));
                        return Count + " money sended. User money: " + Recipient._money;
                    }
                    else return "Error occured. Impossible to update money count.";

                case "gold":
                case "points":
                case "point":


                    if (!int.TryParse(Params[3], out Count))
                        return "Wrong usage. Type :commands to check the correct usage.";

                    if (PlayerManager.updateAccountGold(UserId, Count + Recipient._gp))
                    {
                        Recipient._gp += Count;
                        Recipient.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, Recipient._gp, Recipient._money));
                        Recipient.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK("You've received " + Count + " points"));
                        return Count + " points sended. User points: " + Recipient._gp;
                    }
                    else return "Error occured. Impossible to update points count.";
            }

            return "Wrong usage. Type :commands to check the correct usage.";
        }
    }
}
