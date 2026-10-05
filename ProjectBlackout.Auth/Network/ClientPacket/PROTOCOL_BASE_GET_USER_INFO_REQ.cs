using ProjectBlackout.Core;
using ProjectBlackout.Auth.Network.ServerPacket;
using System;
using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Auth;
using ProjectBlackout.Auth.Network;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_GET_USER_INFO_REQ : ReceivePacket
    {
        public PROTOCOL_BASE_GET_USER_INFO_REQ(AuthClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            try
            {
                Account Player = _client._player;
                if (Player != null && Player._inventory._items.Count == 0)
                {
                    Player.LoadInventory();
                    Player.LoadMissionList();
                    Player.DiscountPlayerItems();
                    Player.LoadQuickstarts();
                    _client.SendPacket(new PROTOCOL_BASE_GET_USER_INFO_ACK(Player));
                    _client.SendPacket(new PROTOCOL_BASE_GET_CHARA_INFO_ACK(Player));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("PROTOCOL_BASE_GET_USER_INFO_REQ: " + ex.ToString());
            }
        }
    }
}