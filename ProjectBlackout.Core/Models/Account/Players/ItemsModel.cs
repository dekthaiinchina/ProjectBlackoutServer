using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Core.Models.Account.Players
{
    public class ItemsModel
    {
        public int _id;
        public int _category;
        public int _equip;
        public string _name;
        public long _objId;
        public long _count;

        public ItemsModel DeepCopy() => (ItemsModel)this.MemberwiseClone();

        public ItemsModel()
        {
        }

        public ItemsModel(int id)
        {
            this.SetItemId(id);
            this._objId = id + 40;  // objId'yi otomatik olarak id + 40 olarak hesapla
        }

        public ItemsModel(int id, string name, int equip, long count, long objId = 0)
        {
            this.SetItemId(id);
            this._objId = (objId == 0) ? (id + 40) : objId;  // objId'yi id + 40 veya sağlanan objId ile ayarla
            this._name = name;
            this._equip = equip;
            this._count = count;
        }

        public ItemsModel(int id, int category, string name, int equip, long count, long objId = 0)
        {
            this._id = id;
            this._category = category;
            this._name = name;
            this._equip = equip;
            this._count = count;
            this._objId = (objId == 0) ? (id + 40) : objId;  // objId'yi id + 40 veya sağlanan objId ile ayarla
        }

        public ItemsModel(ItemsModel item)
        {
            this._id = item._id;
            this._category = item._category;
            this._name = item._name;
            this._count = item._count;
            this._equip = item._equip;
            this._objId = item._objId;  // objId'yi kopyala
        }

        public void SetItemId(int id)
        {
            this._id = id;
            this._category = ComDiv.GetItemCategory(id);
        }
    }
}