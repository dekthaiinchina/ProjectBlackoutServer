using ProjectBlackout.Core.Xml;
using System.Collections.Generic;

namespace ProjectBlackout.Core.Models.Account.Players
{
    public class PlayerInventory
    {
        public List<ItemsModel> _items = new List<ItemsModel>();

        public ItemsModel getItem(int id)
        {
            lock (_items)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    ItemsModel item = _items[i];
                    if (item._id == id)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public ItemsModel getItem(long obj)
        {
            lock (_items)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    ItemsModel item = _items[i];
                    if (item._objId == obj)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public void LoadBasicItems()
        {
            lock (_items)
            {
                _items.AddRange(BasicInventoryXml.basic);
            }
        }

        public List<ItemsModel> getItemsByType(int type)
        {
            List<ItemsModel> list = new List<ItemsModel>();
            lock (_items)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    ItemsModel item = _items[i];
                    if (item._category == type || item._id > 1600000 && item._id < 1700000 && type == 4)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public void RemoveItem(long obj)
        {
            lock (_items)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    ItemsModel item = _items[i];
                    if (item._objId == obj)
                    {
                        _items.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public bool RemoveItem(ItemsModel item)
        {
            lock (_items)
            {
                return _items.Remove(item);
            }
        }

        public void AddItem(ItemsModel item)
        {
            lock (_items)
            {
                _items.Add(item);
            }
        }
    }
}