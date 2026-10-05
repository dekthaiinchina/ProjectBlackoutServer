using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Randombox;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_SHOP_ITEM_AUTH_REQ : ReceivePacket
    {
        private long objId;
        private int itemId;
        private long oldCOUNT;
        private uint erro = 1;

        public PROTOCOL_AUTH_SHOP_ITEM_AUTH_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            objId = readD();
        }

        public override void run()
        {
            if (_client == null || _client._player == null)
            {
                return;
            }
            try
            {
                Account p = _client._player;
                ItemsModel itemObj = p._inventory.getItem(objId);
                if (itemObj != null)
                {
                    itemId = itemObj._id;
                    oldCOUNT = itemObj._count;
                    if (itemObj._category == 3 && p._inventory._items.Count >= 500)
                    {
                        _client.SendPacket(new PROTOCOL_AUTH_SHOP_ITEM_AUTH_ACK(0x80001029));
                        //Logger.warning("Player Inventory: '" + p.player_name + "' it's too full!");
                        return;
                    }
                    if (itemId == 1800049)
                    {
                        if (PlayerManager.updateKD(p.player_id, 0, 0, p._statistic.headshots_count, p._statistic.totalkills_count))
                        {
                            p._statistic.kills_count = 0;
                            p._statistic.deaths_count = 0;
                            _client.SendPacket(new PROTOCOL_BASE_GET_MYINFO_RECORD_ACK(p._statistic));
                        }
                        else
                        {
                            erro = 0x80000000;
                        }
                    }
                    else if (itemId == 1800048)
                    {
                        if (PlayerManager.updateFights(0, 0, 0, 0, p._statistic.totalfights_count, p.player_id))
                        {
                            p._statistic.fights = 0;
                            p._statistic.fights_win = 0;
                            p._statistic.fights_lost = 0;
                            p._statistic.fights_draw = 0;
                            _client.SendPacket(new PROTOCOL_BASE_GET_MYINFO_RECORD_ACK(p._statistic));
                        }
                        else
                        {
                            erro = 0x80000000;
                        }
                    }
                    else if (itemId == 1800050)
                    {
                        if (ComDiv.updateDB("players", "escapes", 0, "player_id", p.player_id))
                        {
                            p._statistic.escapes = 0;
                            _client.SendPacket(new PROTOCOL_BASE_GET_MYINFO_RECORD_ACK(p._statistic));
                        }
                        else
                        {
                            erro = 0x80000000;
                        }
                    }
                    else if (itemId == 1800053)
                    {
                        if (PlayerManager.updateClanBattles(p.clanId, 0, 0, 0))
                        {
                            Clan c = ClanManager.getClan(p.clanId);
                            if (c._id > 0 && c.owner_id == _client.player_id)
                            {
                                c.partidas = 0;
                                c.vitorias = 0;
                                c.derrotas = 0;
                                _client.SendPacket(new PROTOCOL_CS_RECORD_RESET_RESULT_ACK());
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
                    else if (itemId == 1800055)
                    {
                        Clan c = ClanManager.getClan(p.clanId);
                        if (c._id > 0 && c.owner_id == _client.player_id)
                        {
                            if (c.maxPlayers + 50 <= 250 && ComDiv.updateDB("clans", "max_players", c.maxPlayers + 50, "clan_id", p.clanId))
                            {
                                c.maxPlayers += 50;
                                _client.SendPacket(new PROTOCOL_CS_REPLACE_PERSONMAX_ACK(c.maxPlayers));
                            }
                            else
                            {
                                erro = 0x80001056;
                            }
                        }
                        else
                        {
                            erro = 0x80001056;
                        }
                    }
                    else if (itemId == 1800056)
                    {
                        Clan c = ClanManager.getClan(p.clanId);
                        if (c._id > 0 && c._pontos != 1000)
                        {
                            if (ComDiv.updateDB("clans", "pontos", 1000.0f, "clan_id", p.clanId))
                            {
                                c._pontos = 1000;
                                _client.SendPacket(new PROTOCOL_CS_POINT_RESET_RESULT_ACK());
                            }
                            else
                            {
                                erro = 0x80001056;
                            }
                        }
                        else
                        {
                            erro = 0x80001056;
                        }
                    }
                    else if (itemId > 1800113 && itemId < 1800119)
                    {
                        int goldReceive = itemId == 1800114 ? 500 : (itemId == 1800115 ? 1000 : (itemId == 1800116 ? 5000 : (itemId == 1800117 ? 10000 : 30000)));
                        if (ComDiv.updateDB("players", "gp", p._gp + goldReceive, "player_id", p.player_id))
                        {
                            p._gp += goldReceive;
                            _client.SendPacket(new PROTOCOL_SHOP_PLUS_POINT_ACK(goldReceive, p._gp, 0));
                        }
                        else
                        {
                            erro = 0x80000000;
                        }
                    }

                    /*else if (itemId == 1800999)
                    {
                        if (ComDiv.updateDB("players", "exp", p._exp + 515999, "player_id", p.player_id))
                        {
                            p._exp += 515999;
                            _client.SendPacket(new PROTOCOL_SHOP_PLUS_TAG_ACK(515999, 0));
                        }
                        else
                        {
                            erro = 0x80000000;
                        }
                    }*/
                    else if (itemObj._category == 3 && RandomBoxXml.ContainsBox(itemId))
                    {
                        RandomBoxModel box = RandomBoxXml.getBox(itemId);
                        if (box != null)
                        {
                            List<RandomBoxItem> sortedList = box.getSortedList(GetRandomNumber(1, 100));
                            List<RandomBoxItem> rewardList = box.getRewardList(sortedList, GetRandomNumber(0, sortedList.Count));
                            if (rewardList.Count > 0)
                            {
                                int itemIdx = rewardList[0].index;
                                List<ItemsModel> rewards = new List<ItemsModel>();
                                for (int i = 0; i < rewardList.Count; i++)
                                {
                                    RandomBoxItem cupom = rewardList[i];
                                    if (cupom.item != null)
                                    {
                                        rewards.Add(cupom.item);
                                    }
                                    else if (PlayerManager.updateAccountGold(p.player_id, p._gp + (int)cupom.count))
                                    {
                                        p._gp += (int)cupom.count;
                                        _client.SendPacket(new PROTOCOL_SHOP_PLUS_POINT_ACK((int)cupom.count, p._gp, 0));
                                    }
                                    else
                                    {
                                        erro = 0x80000000;
                                        break;
                                    }
                                    if (cupom.special)
                                    {
                                        using (PROTOCOL_AUTH_SHOP_JACKPOT_ACK packet = new PROTOCOL_AUTH_SHOP_JACKPOT_ACK(p.player_name, itemId, itemIdx))
                                        {
                                            GameManager.SendPacketToAllClients(packet);
                                        }
                                    }
                                }
                                _client.SendPacket(new PROTOCOL_AUTH_SHOP_CAPSULE_ACK(rewards, itemId, itemIdx));
                                if (rewards.Count > 0)
                                {
                                    for (int i = 0; i < rewards.Count; i++)
                                    {
                                        ItemsModel Item = rewards[i];
                                        if (Item._id != 0)
                                        {
                                            _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, p, Item));
                                        }
                                    }
                                }
                            }
                            else
                            {
                                erro = 0x80000000;
                            }
                            sortedList = null;
                            rewardList = null;
                        }
                        else
                        {
                            erro = 0x80000000;
                        }
                    }
                    else
                    {
                        int wclass = ComDiv.getIdStatics(itemObj._id, 1);
                        if (wclass <= 8 || wclass == 27)
                        {
                            if (itemObj._equip == 1)
                            {
                                itemObj._equip = 2;
                                itemObj._count = Convert.ToInt64(DateTime.Now.AddSeconds(itemObj._count).ToString("yyMMddHHmm"));
                                ComDiv.updateDB("player_items", "object_id", objId, "owner_id", p.player_id, new string[] { "count", "equip" }, itemObj._count, itemObj._equip);
                                if (wclass == 6)
                                {
                                    Character Character = p.getCharacter(itemObj._id);
                                    if (Character != null)
                                    {
                                        _client.SendPacket(new PROTOCOL_CHAR_CHANGE_STATE_ACK(Character));
                                    }
                                }
                            }
                            else
                            {
                                erro = 0x80000000;
                            }
                        }
                        else if (wclass == 17)
                        {
                            cupomIncreaseDays(p, itemObj._name);
                        }
                        else if (wclass == 20)
                        {
                            cupomIncreaseGold(p, itemObj._id);
                        }
                        else
                        {
                            erro = 0x80000000;
                        }
                    }
                }
                else
                {
                    erro = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_AUTH_SHOP_ITEM_AUTH_ACK(erro, itemObj, p));
            }
            catch (OverflowException ex)
            {
                Logger.error("Obj: " + objId + " ItemId: " + itemId + " Count: " + oldCOUNT + " PlayerId: " + _client.player_id + " Name: '" + _client._player.player_name + "'\r\n" + ex.ToString());
                _client.SendPacket(new PROTOCOL_AUTH_SHOP_ITEM_AUTH_ACK(0x80000000));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_AUTH_SHOP_ITEM_AUTH_REQ: " + ex.ToString());
                _client.SendPacket(new PROTOCOL_AUTH_SHOP_ITEM_AUTH_ACK(0x80000000));
            }
        }

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();

        private static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return getrandom.Next(min, max);
            }
        }

        private void cupomIncreaseDays(Account p, string originalName)
        {
            int cupomId = ComDiv.CreateItemId(16, 0, ComDiv.getIdStatics(itemId, 3)), days = ComDiv.getIdStatics(itemId, 2);
            CouponEffects eff = p.effects;
            if (cupomId == 1600065 && ((eff & (CouponEffects.Defense5 | CouponEffects.Defense10 | CouponEffects.Defense20)) > 0) ||
                cupomId == 1600079 && ((eff & (CouponEffects.Defense5 | CouponEffects.Defense10 | CouponEffects.Defense90)) > 0) ||
                cupomId == 1600044 && ((eff & (CouponEffects.Defense5 | CouponEffects.Defense20 | CouponEffects.Defense90)) > 0) ||
                cupomId == 1600030 && ((eff & (CouponEffects.Defense20 | CouponEffects.Defense10 | CouponEffects.Defense90)) > 0) ||
                cupomId == 1600078 && ((eff & (CouponEffects.FullMetalJack | CouponEffects.HollowPoint | CouponEffects.JackHollowPoint)) > 0) ||
                cupomId == 1600032 && ((eff & (CouponEffects.JackHollowPoint | CouponEffects.HollowPointPlus | CouponEffects.FullMetalJack)) > 0) ||
                cupomId == 1600031 && ((eff & (CouponEffects.JackHollowPoint | CouponEffects.HollowPointPlus | CouponEffects.HollowPoint)) > 0) ||
                cupomId == 1600036 && ((eff & (CouponEffects.HollowPoint | CouponEffects.HollowPointPlus | CouponEffects.FullMetalJack)) > 0) ||
                cupomId == 1600028 && eff.HasFlag(CouponEffects.HP5) ||
                cupomId == 1600040 && eff.HasFlag(CouponEffects.HP10))
            {
                erro = 0x80000000;
            }
            else
            {
                ItemsModel item = p._inventory.getItem(cupomId);
                if (item == null)
                {
                    bool changed = p._bonus.AddBonuses(cupomId);
                    CouponFlag cupom = CouponEffectManager.getCouponEffect(cupomId);
                    if (cupom != null && cupom.EffectFlag > 0 && !p.effects.HasFlag(cupom.EffectFlag))
                    {
                        p.effects |= cupom.EffectFlag;
                        PlayerManager.updateCupomEffects(p.player_id, p.effects);
                    }
                    if (changed)
                    {
                        PlayerManager.updatePlayerBonus(p.player_id, p._bonus.bonuses, p._bonus.freepass);
                    }
                    _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, p, new ItemsModel(cupomId, 3, originalName + " [Active]", 2, Convert.ToInt64(DateTime.Now.AddDays(days).ToString("yyMMddHHmm")))));
                }
                else
                {
                    DateTime data = DateTime.ParseExact(item._count.ToString(), "yyMMddHHmm", CultureInfo.InvariantCulture);
                    item._count = Convert.ToInt64(data.AddDays(days).ToString("yyMMddHHmm"));
                    ComDiv.updateDB("player_items", "count", item._count, "object_id", item._objId, "owner_id", p.player_id);
                    _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(1, p, item));
                }
            }
        }

        private void cupomIncreaseGold(Account p, int cupomId)
        {
            int gold = ComDiv.getIdStatics(cupomId, 3) * 100;
            gold += ComDiv.getIdStatics(cupomId, 2) * 100000;
            if (PlayerManager.updateAccountGold(p.player_id, p._gp + (gold)))
            {
                p._gp += gold;
                _client.SendPacket(new PROTOCOL_SHOP_PLUS_POINT_ACK(gold, p._gp, 0));
            }
            else
            {
                erro = 0x80000000;
            }
        }
    }
}