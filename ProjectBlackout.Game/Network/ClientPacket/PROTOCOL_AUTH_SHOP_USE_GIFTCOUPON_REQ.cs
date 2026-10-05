using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Gift;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_SHOP_USE_GIFTCOUPON_REQ : ReceivePacket
    {
        private string Token;
        private uint Error;

        public PROTOCOL_AUTH_SHOP_USE_GIFTCOUPON_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            Token = readS(readC());
        }

        public override void run()
        {
            try
            {
                Account Player = _client._player;
                TicketModel Ticket = TicketManager.GetTickets().Find(x => x.Ticket == Token);
                if (Ticket != null)
                {
                    Error = 0;
                    if (Ticket.Type.HasFlag(TicketType.ITEM))
                    {
                        ItemsModel Item = new ItemsModel(Ticket.ItemId, "Ticket Item", Ticket.Equip, Ticket.Count);
                        _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, Player, Item));
                    }
                    if (Ticket.Type.HasFlag(TicketType.MONEY))
                    {
                        if (Ticket.Point != 0 || Ticket.Cash != 0)
                        {
                            Player._gp += Ticket.Point;
                            Player._money += Ticket.Cash;
                            PlayerManager.updateAccountCashing(Player.player_id, Player._gp, Player._money);
                            _client.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, Player._gp, Player._money));
                        }
                    }
                }
                else
                {
                    Error = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_AUTH_SHOP_USE_GIFTCOUPON_ACK(Error));
            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_AUTH_SHOP_USE_GIFTCOUPON_REQ: " + ex.ToString());
            }
        }
    }
}
