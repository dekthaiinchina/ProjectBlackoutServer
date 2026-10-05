using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_SHOP_ITEM_AUTH_ACK : SendPacket
    {
        private uint erro;
        private ItemsModel item;

        public PROTOCOL_AUTH_SHOP_ITEM_AUTH_ACK(uint erro, ItemsModel item = null, Account p = null)
        {
            this.erro = erro;
            if (erro != 1)
            {
                return;
            }
            if (item != null)
            {
                int wclass = ComDiv.getIdStatics(item._id, 1);
                if (wclass == 17 || wclass == 18 || wclass == 20)
                {
                    if (item._count > 1 && item._equip == 1)
                    {
                        ComDiv.updateDB("player_items", "count", --item._count, "object_id", item._objId, "owner_id", p.player_id);
                    }
                    else
                    {
                        PlayerManager.DeleteItem(item._objId, p.player_id);
                        p._inventory.RemoveItem(item);
                        item._id = 0;
                        item._count = 0;
                    }
                }
                else
                {
                    item._equip = 2;
                }
                this.item = item;
            }
            else
            {
                this.erro = 0x80000000;
            }
        }

        public override void write()
        {
            writeH(1048);
            writeD(erro);
            if (erro == 1)
            {
                writeD(uint.Parse(DateTime.Now.ToString("yyMMddHHmm")));
                writeD((int)item._objId);
                if (item._category == 3 && item._equip == 2)
                {
                    writeD(0);
                    writeC(1);
                    writeD(0);
                }
                else
                {
                    writeD(item._id);
                    writeC((byte)item._equip);
                    writeD((int)item._count);
                }
            }
            //0x80001086 STR_TBL_GUI_BASE_NO_EQUIP_PRE_DESIGNATION
        }
    }
}