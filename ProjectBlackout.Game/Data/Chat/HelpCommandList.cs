using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class HelpCommandList
    {
        public static string GetList3(Account player)
        {
            if ((int)player.access >= 3)
            {
                if (InGame(player))
                {
                    return Translation.GetLabel("InGameBlock");
                }
                string comandos = Translation.GetLabel("HelpListTitle3");
                comandos += "\n" + Translation.GetLabel("NickHistoryByID");
                comandos += "\n" + Translation.GetLabel("IDHistoryByNick");
                comandos += "\n" + Translation.GetLabel("FakeRank");
                comandos += "\n" + Translation.GetLabel("ChangeNick");
                comandos += "\n" + Translation.GetLabel("KickPlayer");
                comandos += "\n" + Translation.GetLabel("EnableDisableGMColor");
                comandos += "\n" + Translation.GetLabel("AntiKickActive");
                comandos += "\n" + Translation.GetLabel("RoomUnlock");
                comandos += "\n" + Translation.GetLabel("AFKCounter");
                comandos += "\n" + Translation.GetLabel("AFKKick");
                comandos += "\n" + Translation.GetLabel("PlayersCountInServer");
                comandos += "\n" + Translation.GetLabel("PlayersCountInServer2");
                comandos += "\n" + Translation.GetLabel("Ping");
                player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(comandos));
                return Translation.GetLabel("HelpListList3");
            }
            else
            {
                return Translation.GetLabel("HelpListNoLevel");
            }
        }

        public static string GetList4(Account player)
        {
            if ((int)player.access >= 4)
            {
                if (InGame(player))
                {
                    return Translation.GetLabel("InGameBlock");
                }
                string comandos = Translation.GetLabel("HelpListTitle4");
                comandos += "\n\n" + Translation.GetLabel("MsgToAllServer");
                comandos += "\n" + Translation.GetLabel("MsgToAllRoom");
                comandos += "\n" + Translation.GetLabel("ChangeMapId");
                comandos += "\n" + Translation.GetLabel("ChangeRoomTime");
                comandos += "\n" + Translation.GetLabel("Give10Cash");
                comandos += "\n" + Translation.GetLabel("Give10Gold");
                comandos += "\n" + Translation.GetLabel("KickAll");
                comandos += "\n" + Translation.GetLabel("SendGift");
                comandos += "\n" + Translation.GetLabel("GoodsFound");
                comandos += "\n" + Translation.GetLabel("SimpleBanNormal");
                comandos += "\n" + Translation.GetLabel("AdvancedBanNormal");
                comandos += "\n" + Translation.GetLabel("UnbanNormal");
                comandos += "\n" + Translation.GetLabel("GetPlayersByIP");
                comandos += "\n" + Translation.GetLabel("BanReason");
                comandos += "\n" + Translation.GetLabel("GetPlayerInfos");
                comandos += "\n" + Translation.GetLabel("OpenRoomSlot");
                comandos += "\n" + Translation.GetLabel("OpenRandomRoomSlot");
                comandos += "\n" + Translation.GetLabel("OpenAllClosedRoomSlots");
                comandos += "\n" + Translation.GetLabel("TakeTitles");

                player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(comandos));
                return Translation.GetLabel("HelpListList4");
            }
            else
            {
                return Translation.GetLabel("HelpListNoLevel");
            }
        }

        public static string GetList5(Account player)
        {
            if ((int)player.access >= 5)
            {
                if (InGame(player))
                {
                    return Translation.GetLabel("InGameBlock");
                }
                string comandos = Translation.GetLabel("HelpListTitle5");
                comandos += "\n\n" + Translation.GetLabel("ChangeRank");
                comandos += "\n" + Translation.GetLabel("SimpleBanEtern");
                comandos += "\n" + Translation.GetLabel("AdvancedBanEtern");
                comandos += "\n" + Translation.GetLabel("GetBanInfo");
                comandos += "\n" + Translation.GetLabel("UnbanEtern");
                comandos += "\n" + Translation.GetLabel("CreateItemPt1");
                comandos += "\n" + Translation.GetLabel("CreateItemPt2");
                comandos += "\n" + Translation.GetLabel("CreateGoldItem");
                comandos += "\n" + Translation.GetLabel("ReloadShop");
                comandos += "\n" + Translation.GetLabel("V2ReloadShop");
                comandos += "\n" + Translation.GetLabel("ChangeAnnounce");
                comandos += "\n" + Translation.GetLabel("SetCashD");
                comandos += "\n" + Translation.GetLabel("SetGoldD");
                comandos += "\n" + Translation.GetLabel("CashPlayerD");
                comandos += "\n" + Translation.GetLabel("GoldPlayerD");
                comandos += "\n" + Translation.GetLabel("SetVip");
                comandos += "\n" + Translation.GetLabel("SetAcess");
                player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(comandos));
                return Translation.GetLabel("HelpListList5");
            }
            else
            {
                return Translation.GetLabel("HelpListNoLevel");
            }
        }

        public static string GetList6(Account player)
        {
            if ((int)player.access >= 6)
            {
                if (InGame(player))
                {
                    return Translation.GetLabel("InGameBlock");
                }
                string comandos = Translation.GetLabel("HelpListTitle6");
                comandos += "\n\n" + Translation.GetLabel("Pausar");
                comandos += "\n" + Translation.GetLabel("EndRoom");
                comandos += "\n" + Translation.GetLabel("ChangeRoomType");
                comandos += "\n" + Translation.GetLabel("ChangeRoomSpecial");
                comandos += "\n" + Translation.GetLabel("ChangeRoomWeapons");
                comandos += "\n" + Translation.GetLabel("ChangeUDP");
                comandos += "\n" + Translation.GetLabel("EnableTestMode");
                comandos += "\n" + Translation.GetLabel("EnablePublicMode");
                comandos += "\n" + Translation.GetLabel("EnableMissions");
                player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(comandos));
                return Translation.GetLabel("HelpListList6");
            }
            else
            {
                return Translation.GetLabel("HelpListNoLevel");
            }
        }        

        private static bool InGame(Account player)
        {
            Room room = player._room;
            Slot slot;
            if (room != null && room.getSlot(player._slotId, out slot) && (int)slot.state >= 9)
            {
                return true;
            }
            return false;
        }
    }
}