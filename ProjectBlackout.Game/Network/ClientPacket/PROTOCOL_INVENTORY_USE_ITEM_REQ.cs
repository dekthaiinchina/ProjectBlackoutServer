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
using System.Text;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_INVENTORY_USE_ITEM_REQ : ReceivePacket
    {
        private long objId;
        private uint value, erro = 1;
        private byte[] info;
        private string txt;

        public PROTOCOL_INVENTORY_USE_ITEM_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            objId = readD();
            info = readB(readC());
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                ItemsModel item = p == null ? null : p._inventory.getItem(objId);
                if (item != null && item._id > 1700000)
                {
                    int cuponId = ComDiv.CreateItemId(16, 0, ComDiv.getIdStatics(item._id, 3));
                    long cuponDays = Convert.ToInt64(DateTime.Now.AddDays(ComDiv.getIdStatics(item._id, 2)).ToString("yyMMddHHmm"));

                    if (cuponId == 1600047 || cuponId == 1600051 || cuponId == 1600010)
                    {
                        txt = ComDiv.arrayToString(info, info.Length);
                    }
                    else if (cuponId == 1600052 || cuponId == 1600005)
                    {
                        value = BitConverter.ToUInt32(info, 0);
                    }
                    else if (info.Length > 0)
                    {
                        value = info[0];
                    }
                    CreateCouponEffects(cuponId, cuponDays, p);
                }
                else
                {
                    erro = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_AUTH_SHOP_ITEM_AUTH_ACK(erro, item, p));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_INVENTORY_USE_ITEM_REQ: " + ex.ToString());
                _client.SendPacket(new PROTOCOL_AUTH_SHOP_ITEM_AUTH_ACK(0x80000000));
            }
        }

        private void CreateCouponEffects(int cupomId, long cuponDays, Account p)
        {
            if (cupomId == 1600051)
            {
                if (string.IsNullOrEmpty(txt) || txt.Length > 16)
                {
                    erro = 0x80000000;
                }
                else
                {
                    Clan c = ClanManager.getClan(p.clanId);
                    if (c._id > 0 && c.owner_id == _client.player_id)
                    {
                        if (!ClanManager.isClanNameExist(txt) && ComDiv.updateDB("clans", "clan_name", txt, "clan_id", p.clanId))
                        {
                            c._name = txt;
                            using (PROTOCOL_CS_REPLACE_NAME_RESULT_ACK packet = new PROTOCOL_CS_REPLACE_NAME_RESULT_ACK(txt))
                            {
                                ClanManager.SendPacket(packet, p.clanId, -1, true, true);
                            }
                        }
                        else
                        {
                            erro = 0x80000000;
                        }
                    }
                    else
                    {
                        erro = 0x80000000;
                    }
                }
            }
            else if (cupomId == 1600052)
            {
                Clan clan = ClanManager.getClan(p.clanId);
                if (clan._id > 0 && clan.owner_id == _client.player_id && !ClanManager.isClanLogoExist(value) && PlayerManager.updateClanLogo(p.clanId, value))
                {
                    clan._logo = value;
                    using (PROTOCOL_CS_REPLACE_MARK_RESULT_ACK packet = new PROTOCOL_CS_REPLACE_MARK_RESULT_ACK(value))
                    {
                        ClanManager.SendPacket(packet, p.clanId, -1, true, true);
                    }
                }
                else
                {
                    erro = 0x80000000;
                }
            }
            else if (cupomId == 1600047)
            {
                if (string.IsNullOrEmpty(txt) || txt.Length < GameConfig.minNickSize || txt.Length > GameConfig.maxNickSize || p._inventory.getItem(1600010) != null)
                {
                    erro = 0x80000000;
                }
                else if (!PlayerManager.isPlayerNameExist(txt))
                {
                    if (ComDiv.updateDB("players", "player_name", txt, "player_id", p.player_id))
                    {
                        NickHistoryManager.CreateHistory(p.player_id, p.player_name, txt, "Name changed (items)");
                        p.player_name = txt;
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
                        erro = 0x80000000;
                    }
                }
                else
                {
                    erro = 2147483923;
                }
            }
            else if (cupomId == 1600006)
            {
                if (ComDiv.updateDB("players", "name_color", (int)value, "player_id", p.player_id))
                {
                    p.name_color = (int)value;
                    _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, p, new ItemsModel(cupomId, 3, "Name Color [Active]", 2, cuponDays, 0)));
                    _client.SendPacket(new PROTOCOL_BASE_GET_MYINFO_BASIC_ACK(p));
                    if (p._room != null)
                    {
                        using (PROTOCOL_ROOM_GET_NICKNAME_ACK packet = new PROTOCOL_ROOM_GET_NICKNAME_ACK(p._slotId, p.player_name, p.name_color))
                        {
                            p._room.SendPacketToPlayers(packet);
                        }
                        using (PROTOCOL_ROOM_GET_COLOR_NICK_ACK packet = new PROTOCOL_ROOM_GET_COLOR_NICK_ACK(p._slotId, p.name_color))
                        {
                            p._room.SendPacketToPlayers(packet);
                        }
                    }
                }
                else
                {
                    erro = 0x80000000;
                }
            }
            else if (cupomId == 1600187)
            {
                if (ComDiv.updateDB("player_bonus", "muzzle", (int)value, "player_id", p.player_id))
                {
                    p._bonus.muzzle = (int)value;
                    _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(info.Length, p));
                    _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, p, new ItemsModel(cupomId, 3, "Muzzle Color [Active]", 2, cuponDays, 0)));
                }
                else
                {
                    erro = 0x80000000;
                }
            }
            else if (cupomId == 1600193)
            {
                Clan c = ClanManager.getClan(p.clanId);
                if (c._id > 0 && c.owner_id == _client.player_id)
                {
                    if (ComDiv.updateDB("clans", "effect", (int)value, "clan_id", p.clanId))
                    {
                        c.effect = (int)value;
                        using (PROTOCOL_CS_REPLACE_MARKEFFECT_RESULT_ACK packet = new PROTOCOL_CS_REPLACE_MARKEFFECT_RESULT_ACK((int)value))
                        {
                            ClanManager.SendPacket(packet, p.clanId, -1, true, true);
                        }
                    }
                    else
                    {
                        erro = 0x80000000;
                    }
                }
                else
                {
                    erro = 0x80000000;
                }
            }
            else if (cupomId == 1600009)
            {
                if ((int)value >= 51 || (int)value < p._rank - 10 || (int)value > p._rank + 10)
                {
                    erro = 0x80000000;
                }
                else if (ComDiv.updateDB("player_bonus", "fakerank", (int)value, "player_id", p.player_id))
                {
                    p._bonus.fakeRank = (int)value;
                    _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(info.Length, p));
                    _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, p, new ItemsModel(cupomId, 3, "Fake Rank [Active]", 2, cuponDays, 0)));
                    if (p._room != null)
                    {
                        using (PROTOCOL_ROOM_GET_RANK_ACK packet = new PROTOCOL_ROOM_GET_RANK_ACK(p._slotId, p.getRank()))
                        {
                            p._room.SendPacketToPlayers(packet);
                        }
                        p._room.updateSlotsInfo();
                    }
                }
                else
                {
                    erro = 0x80000000;
                }
            }
            else if (cupomId == 1600010)
            {
                if (string.IsNullOrEmpty(txt) || txt.Length < GameConfig.minNickSize || txt.Length > GameConfig.maxNickSize)
                {
                    erro = 0x80000000;
                }
                else if (ComDiv.updateDB("player_bonus", "fakenick", p.player_name, "player_id", p.player_id) && ComDiv.updateDB("players", "player_name", txt, "player_id", p.player_id))
                {
                    p._bonus.fakeNick = p.player_name;
                    p.player_name = txt;
                    _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(info.Length, p));
                    _client.SendPacket(new PROTOCOL_AUTH_CHANGE_NICKNAME_ACK(p.player_name));
                    _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, p, new ItemsModel(cupomId, 3, "Fake Nick [Active]", 2, cuponDays, 0)));
                    if (p._room != null)
                    {
                        p._room.updateSlotsInfo();
                    }
                }
                else
                {
                    erro = 0x80000000;
                }
            }
            else if (cupomId == 1600014)
            {
                if (ComDiv.updateDB("player_bonus", "sightcolor", (int)value, "player_id", p.player_id))
                {
                    p._bonus.sightColor = (int)value;
                    _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(info.Length, p));
                    _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, p, new ItemsModel(cupomId, 3, "Sight Color [Active]", 2, cuponDays, 0)));
                }
                else
                {
                    erro = 0x80000000;
                }
            }
            else if (cupomId == 1600005)
            {
                Clan c = ClanManager.getClan(p.clanId);
                if (c._id > 0 && c.owner_id == _client.player_id && ComDiv.updateDB("clans", "color", (int)value, "clan_id", c._id))
                {
                    c._name_color = (int)value;
                    _client.SendPacket(new PROTOCOL_CS_REPLACE_COLOR_NAME_RESULT_ACK((byte)c._name_color));
                }
                else
                {
                    erro = 0x80000000;
                }
            }
            else if (cupomId == 1600085)
            {
                if (p._room != null)
                {
                    Account pR = p._room.getPlayerBySlot((int)value);
                    if (pR != null)
                    {
                        _client.SendPacket(new PROTOCOL_ROOM_GET_USER_ITEM_ACK(pR));
                    }
                    else
                    {
                        erro = 0x80000000;
                    }
                }
                else
                {
                    erro = 0x80000000;
                }
            }
            else
            {
                Logger.error("Coupon effect not found! Id: " + cupomId);
                erro = 0x80000000;
            }
        }
    }
}