using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_SHOP_ITEM_CHANGE_DATA_REQ : ReceivePacket
    {
        private long ObjId;
        private uint Value, Error = 0;
        private byte[] Info;
        private string Text;

        public PROTOCOL_AUTH_SHOP_ITEM_CHANGE_DATA_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            ObjId = readD();
            Info = readB(readC());
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                ItemsModel item = p == null ? null : p._inventory.getItem(ObjId);
                if (item != null && item._id > 1600000)
                {
                    int cuponId = ComDiv.CreateItemId(16, 0, ComDiv.getIdStatics(item._id, 3));
                    if (cuponId == 1610047 || cuponId == 1610051 || cuponId == 1600010)
                    {
                        Text = ComDiv.arrayToString(Info, Info.Length);
                    }
                    else if (cuponId == 1610052 || cuponId == 1600005)
                    {
                        Value = BitConverter.ToUInt32(Info, 0);
                    }
                    else if (Info.Length > 0)
                    {
                        Value = Info[0];
                    }
                    CreateCouponEffects(cuponId, p);
                }
                else
                {
                    Error = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_AUTH_SHOP_ITEM_CHANGE_DATA_ACK(Error));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_AUTH_SHOP_ITEM_CHANGE_DATA_REQ: " + ex.ToString());
                _client.SendPacket(new PROTOCOL_AUTH_SHOP_ITEM_CHANGE_DATA_ACK(0x80000000));
            }
        }

        private void CreateCouponEffects(int cupomId, Account p)
        {
            if (cupomId == 1610051)
            {
                if (string.IsNullOrEmpty(Text) || Text.Length > 16)
                {
                    Error = 0x80000000;
                }
                else
                {
                    Clan c = ClanManager.getClan(p.clanId);
                    if (c._id > 0 && c.owner_id == _client.player_id)
                    {
                        if (!ClanManager.isClanNameExist(Text) && ComDiv.updateDB("clans", "clan_name", Text, "clan_id", p.clanId))
                        {
                            c._name = Text;
                            using (PROTOCOL_CS_REPLACE_NAME_RESULT_ACK packet = new PROTOCOL_CS_REPLACE_NAME_RESULT_ACK(Text))
                            {
                                ClanManager.SendPacket(packet, p.clanId, -1, true, true);
                            }
                        }
                        else
                        {
                            Error = 0x80000000;
                        }
                    }
                    else
                    {
                        Error = 0x80000000;
                    }
                }
            }
            else if (cupomId == 1610052)
            {
                Clan clan = ClanManager.getClan(p.clanId);
                if (clan._id > 0 && clan.owner_id == _client.player_id && !ClanManager.isClanLogoExist(Value) && PlayerManager.updateClanLogo(p.clanId, Value))
                {
                    clan._logo = Value;
                    using (PROTOCOL_CS_REPLACE_MARK_RESULT_ACK packet = new PROTOCOL_CS_REPLACE_MARK_RESULT_ACK(Value))
                    {
                        ClanManager.SendPacket(packet, p.clanId, -1, true, true);
                    }
                }
                else
                {
                    Error = 0x80000000;
                }
            }
            else if (cupomId == 1800047)
            {
                if (string.IsNullOrEmpty(Text) || Text.Length < GameConfig.minNickSize || Text.Length > GameConfig.maxNickSize || p._inventory.getItem(1600010) != null)
                {
                    Error = 0x80000000;
                }
                else if (!PlayerManager.isPlayerNameExist(Text))
                {
                    if (ComDiv.updateDB("players", "player_name", Text, "player_id", p.player_id))
                    {
                        NickHistoryManager.CreateHistory(p.player_id, p.player_name, Text, "Name changed (items)");
                        p.player_name = Text;
                        if (p._room != null)
                        {
                            using (PROTOCOL_ROOM_GET_NICKNAME_ACK packet = new PROTOCOL_ROOM_GET_NICKNAME_ACK(p._slotId, p.player_name, p.name_color))
                            {
                                p._room.SendPacketToPlayers(packet);
                            }
                        }
                        _client.SendPacket(new PROTOCOL_AUTH_CHANGE_NICKNAME_ACK(p.player_name));
                        if (p.clanId > 0)
                        {
                            using (PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK packet = new PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK(p))
                            {
                                ClanManager.SendPacket(packet, p.clanId, -1, true, true);
                            }
                        }
                        AllUtils.syncPlayerToFriends(p, true);
                    }
                    else
                    {
                        Error = 0x80000000;
                    }
                }
                else
                {
                    Error = 2147483923;
                }
            }
            else if (cupomId == 1600006)
            {
                if (ComDiv.updateDB("players", "name_color", (int)Value, "player_id", p.player_id))
                {
                    p.name_color = (int)Value;
                    _client.SendPacket(new PROTOCOL_BASE_GET_MYINFO_BASIC_ACK(p));
                    if (p._room != null)
                    {
                        using (PROTOCOL_ROOM_GET_NICKNAME_ACK packet = new PROTOCOL_ROOM_GET_NICKNAME_ACK(p._slotId, p.player_name, p.name_color))
                        {
                            p._room.SendPacketToPlayers(packet);
                        }
                    }
                }
                else
                {
                    Error = 0x80000000;
                }
            }
            else if (cupomId == 1600187)
            {
                if (ComDiv.updateDB("player_bonus", "muzzle", (int)Value, "player_id", p.player_id))
                {
                    p._bonus.muzzle = (int)Value;
                    _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(Info.Length, p));
                }
                else
                {
                    Error = 0x80000000;
                }
            }
            else if (cupomId == 1600009)
            {
                if ((int)Value >= 51 || (int)Value < p._rank - 10 || (int)Value > p._rank + 10)
                {
                    Error = 0x80000000;
                }
                else if (ComDiv.updateDB("player_bonus", "fakerank", (int)Value, "player_id", p.player_id))
                {
                    p._bonus.fakeRank = (int)Value;
                    _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(Info.Length, p));
                    if (p._room != null)
                    {
                        p._room.updateSlotsInfo();
                    }
                }
                else
                {
                    Error = 0x80000000;
                }
            }
            else if (cupomId == 1600010)
            {
                if (string.IsNullOrEmpty(Text) || Text.Length < GameConfig.minNickSize || Text.Length > GameConfig.maxNickSize)
                {
                    Error = 0x80000000;
                }
                else if (ComDiv.updateDB("player_bonus", "fakenick", p.player_name, "player_id", p.player_id) && ComDiv.updateDB("players", "player_name", Text, "player_id", p.player_id))
                {
                    p._bonus.fakeNick = p.player_name;
                    p.player_name = Text;
                    _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(Info.Length, p));
                    _client.SendPacket(new PROTOCOL_AUTH_CHANGE_NICKNAME_ACK(p.player_name));
                    if (p._room != null)
                    {
                        p._room.updateSlotsInfo();
                    }
                }
                else
                {
                    Error = 0x80000000;
                }
            }
            else if (cupomId == 1600014)
            {
                if (ComDiv.updateDB("player_bonus", "sightcolor", (int)Value, "player_id", p.player_id))
                {
                    p._bonus.sightColor = (int)Value;
                    _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(Info.Length, p));
                }
                else
                {
                    Error = 0x80000000;
                }
            }
            else if (cupomId == 1600005)
            {
                Clan c = ClanManager.getClan(p.clanId);
                if (c._id > 0 && c.owner_id == _client.player_id && ComDiv.updateDB("clans", "color", (int)Value, "clan_id", c._id))
                {
                    c._name_color = (int)Value;
                    _client.SendPacket(new PROTOCOL_CS_REPLACE_COLOR_NAME_RESULT_ACK((byte)c._name_color));
                }
                else
                {
                    Error = 0x80000000;
                }
            }
            else if (cupomId == 1610085)
            {
                if (p._room != null)
                {
                    Account pR = p._room.getPlayerBySlot((int)Value);
                    if (pR != null)
                    {
                        _client.SendPacket(new PROTOCOL_ROOM_GET_USER_ITEM_ACK(pR));
                    }
                    else
                    {
                        Error = 0x80000000;
                    }
                }
                else
                {
                    Error = 0x80000000;
                }
            }
            else
            {
                Logger.error("Coupon effect not found! Id: " + cupomId);
                Error = 0x80000000;
            }
        }
    }
}
