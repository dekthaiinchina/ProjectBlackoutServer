using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Sync.Client
{
    public class InventorySync
    {
        public static void Load(ReceiveGPacket p)
        {
            long playerId = p.readQ();
            long objId = p.readQ();
            int itemid = p.readD();
            int equip = p.readC();
            int category = p.readC();
            long count = p.readQ();
            Account player = AccountManager.getAccount(playerId, true);
            if (player == null)
            {
                return;
            }
            ItemsModel item = player._inventory.getItem(objId);
            if (item == null)
            {
                player._inventory.AddItem(new ItemsModel { _objId = objId, _id = itemid, _equip = equip, _count = count, _category = category, _name = "" });
            }
            else
            {
                item._count = count;
            }
        }
    }
}