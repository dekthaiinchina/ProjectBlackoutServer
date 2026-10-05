using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Shop;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CHAR_CREATE_CHARA_REQ : ReceivePacket
    {
        private string Name;
        private List<CartGoods> ShopCart = new List<CartGoods>();

        public PROTOCOL_CHAR_CREATE_CHARA_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            Name = readUnicode(readC() * 2);
            readC();
            ShopCart.Add(new CartGoods
            {
                GoodId = readD(),
                BuyType = readC()
            });
        }

        public override void run()
        {
            try
            {
                Account Player = _client._player;
                if (Player == null || Player.player_name.Length == 0)
                {
                    _client.SendPacket(new PROTOCOL_CHAR_CREATE_CHARA_ACK(2147487767, 0, null, null));
                    _client.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, _client._player._gp, _client._player._money, _client._player._tag));
                    return;
                }
                if (Player._inventory._items.Count >= 500 || Player.Characters.Count >= 32)
                {
                    _client.SendPacket(new PROTOCOL_CHAR_CREATE_CHARA_ACK(2147487929, 0, null, null));
                    _client.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, _client._player._gp, _client._player._money, _client._player._tag));
                    return;
                }
                int gold, cash;
                List<GoodItem> Items = ShopManager.getGoods(ShopCart, out gold, out cash);
                if (Items.Count == 0)
                {
                    _client.SendPacket(new PROTOCOL_CHAR_CREATE_CHARA_ACK(2147487767, 0, null, null));
                    _client.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, _client._player._gp, _client._player._money));
                }
                else if (0 > (Player._gp - gold) || 0 > (Player._money - cash))
                {
                    _client.SendPacket(new PROTOCOL_CHAR_CREATE_CHARA_ACK(2147487768, 0, null, null));
                    _client.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, _client._player._gp, _client._player._money));
                }
                else if (PlayerManager.updateAccountCashing(Player.player_id, (Player._gp - gold), (Player._money - cash)))
                {
                    Player._gp -= gold;
                    Player._money -= cash;
                    int Slots = Player.Characters.Count;
                    Character Model = new Character();
                    for (int i = 0; i < Items.Count; i++)
                    {
                        GoodItem Good = Items[i];
                        Model.Id = Good._item._id;
                        Model.Name = Name;
                        Model.PlayTime = 0;
                        Model.Slot = Slots++;
                        Model.CreateDate = int.Parse(DateTime.Now.AddYears(-10).ToString("yyMMddHHmm"));
                        if (Player.Characters.Find(x => x.Id == Model.Id) == null)
                        {
                            CharacterManager.Create(Model, Player.player_id);
                            Player.Characters.Add(Model);
                        }
                    }
                    _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, Player, Items));
                    _client.SendPacket(new PROTOCOL_CHAR_CREATE_CHARA_ACK(0, 1, Model, Player));
                    _client.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, _client._player._gp, _client._player._money));
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_CHAR_CREATE_CHARA_ACK(2147487769, 0, null, null));
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }
    }
}
