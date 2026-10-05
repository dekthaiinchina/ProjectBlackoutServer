using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_SHOP_AUTH_GIFT_ACK : SendPacket
    {
        private uint _erro;
        private List<ItemsModel> charas = new List<ItemsModel>(), weapons = new List<ItemsModel>(), cupons = new List<ItemsModel>();

        public PROTOCOL_AUTH_SHOP_AUTH_GIFT_ACK(uint erro, ItemsModel item = null, Account p = null)
        {
            _erro = erro;
            if (_erro == 1)
            {
                get(item, p);
            }
        }

        public override void write()
        {
            writeH(541);
            writeD(_erro);
            if (_erro == 1)
            {
                writeD(charas.Count);
                writeD(weapons.Count);
                writeD(cupons.Count);
                writeD(0);
                for (int chara = 0; chara < charas.Count; chara++)
                {
                    ItemsModel item = charas[chara];
                    writeQ(item._objId);
                    writeD(item._id);
                    writeC((byte)item._equip);
                    writeD((int)item._count);
                }
                for (int weapon = 0; weapon < weapons.Count; weapon++)
                {
                    ItemsModel item = weapons[weapon];
                    writeQ(item._objId);
                    writeD(item._id);
                    writeC((byte)item._equip);
                    writeD((int)item._count);
                }
                for (int cupon = 0; cupon < cupons.Count; cupon++)
                {
                    ItemsModel item = cupons[cupon];
                    writeQ(item._objId);
                    writeD(item._id);
                    writeC((byte)item._equip);
                    writeD((int)item._count);
                }
            }
        }

        private void get(ItemsModel item, Account p)
        {
            try
            {
                ItemsModel modelo = new ItemsModel(item) { _objId = item._objId };
                PlayerManager.tryCreateItem(modelo, p._inventory, p.player_id);
                if (modelo._category == 1)
                {
                    weapons.Add(modelo);
                }
                else if (modelo._category == 2)
                {
                    charas.Add(modelo);
                }
                else if (modelo._category == 3)
                {
                    cupons.Add(modelo);
                }
            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_AUTH_SHOP_AUTH_GIFT_ACK: " + ex.ToString());
            }
        }
    }
}