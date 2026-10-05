using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Shop;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_SHOP_REPAIR_REQ : ReceivePacket
    {
        private long ObjectId;
        private uint Error = 1;

        public PROTOCOL_SHOP_REPAIR_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            readH();
            ObjectId = readD();
        }

        public override void run()
        {
            if (_client == null || _client._player == null)
            {
                return;
            }
            try
            {
                Account Player = _client._player;
                ItemsModel Item = Player._inventory.getItem(ObjectId);
                if (Item != null)
                {
                    ItemRepair Repair = ShopManager.ItemRepairs.Find(x => x.ItemId == Item._id);
                    if (Repair != null)
                    {
                        int Value = 0, Result = 0, Point = 0, Cash = 0;
                        if ((Repair.Point > 0) && (Repair.Cash == 0))
                        {
                            Value = (Repair.Quantity - (int)Item._count);
                            Result = (Repair.Point * Value);
                            Point = (Player._gp - Result);
                            Cash = Player._money;
                            if (Point < Result)
                            {
                                Error = 0x80000110;
                            }
                        }
                        else if ((Repair.Cash > 0) && (Repair.Point == 0))
                        {
                            Value = (Repair.Quantity - (int)Item._count);
                            Result = (Repair.Cash * Value);
                            Point = Player._gp;
                            Cash = (Player._money - Result);
                            if (Cash < Result)
                            {
                                Error = 0x80000110;
                            }
                        }
                        else
                        {
                            Point = Player._gp;
                            Cash = Player._money;
                        }
                        Player._gp = Point;
                        Player._money = Cash;
                        Item._count = Repair.Quantity;
                        ComDiv.updateDB("players", "gp", Player._gp, "player_id", Player.player_id);
                        ComDiv.updateDB("players", "money", Player._money, "player_id", Player.player_id);
                        ComDiv.updateDB("player_items", "count", Item._count, "object_id", ObjectId);
                        _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(3, Player, Item));
                        _client.SendPacket(new PROTOCOL_SHOP_REPAIR_ACK(Error, Item, Player));
                    }
                    else
                    {
                        _client.SendPacket(new PROTOCOL_SHOP_REPAIR_ACK(0x80000110));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_SHOP_REPAIR_REQ: " + ex.ToString());
                _client.SendPacket(new PROTOCOL_SHOP_REPAIR_ACK(0x80000000));
            }
        }
    }
}
