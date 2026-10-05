using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_AUTH_SHOP_DELETE_ITEM_REQ : ReceivePacket
    {
        private long objId;
        private uint erro = 1;

        public PROTOCOL_AUTH_SHOP_DELETE_ITEM_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            objId = readD();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                ItemsModel item = p._inventory.getItem(objId);
                PlayerBonus bonus = p._bonus;
                if (item == null)
                {
                    erro = 0x80000000;
                }
                else if (ComDiv.getIdStatics(item._id, 1) == 16)
                {
                    if (bonus == null)
                    {
                        _client.SendPacket(new PROTOCOL_AUTH_SHOP_DELETE_ITEM_ACK(0x80000000));
                        return;
                    }
                    bool changed = bonus.RemoveBonuses(item._id);
                    if (!changed)
                    {
                        if (item._id == 1600014)
                        {
                            if (ComDiv.updateDB("player_bonus", "sightcolor", 4, "player_id", p.player_id))
                            {
                                bonus.sightColor = 4;
                                _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(0, p));
                            }
                            else
                            {
                                erro = 0x80000000;
                            }
                        }
                        else if (item._id == 1600010)
                        {
                            if (bonus.fakeNick.Length == 0)
                            {
                                erro = 0x80000000;
                            }
                            else
                            {
                                if (ComDiv.updateDB("players", "player_name", bonus.fakeNick, "player_id", p.player_id) && ComDiv.updateDB("player_bonus", "fakenick", "", "player_id", p.player_id))
                                {
                                    p.player_name = bonus.fakeNick;
                                    bonus.fakeNick = "";
                                    _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(0, p));
                                    _client.SendPacket(new PROTOCOL_AUTH_CHANGE_NICKNAME_ACK(p.player_name));
                                }
                                else
                                {
                                    erro = 0x80000000;
                                }
                            }
                        }
                        else if (item._id == 1600009)
                        {
                            if (ComDiv.updateDB("player_bonus", "fakerank", 55, "player_id", p.player_id))
                            {
                                bonus.fakeRank = 55;
                                _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(0, p));
                            }
                            else
                            {
                                erro = 0x80000000;
                            }
                        }
                        else if (item._id == 1600187)
                        {
                            if (ComDiv.updateDB("player_bonus", "muzzle", 0, "player_id", p.player_id))
                            {
                                bonus.muzzle = 0;
                                _client.SendPacket(new PROTOCOL_BASE_INV_ITEM_DATA_ACK(0, p));
                            }
                            else
                            {
                                erro = 0x80000000;
                            }
                        }
                        else if (item._id == 1600006)
                        {
                            if (ComDiv.updateDB("players", "name_color", 0, "player_id", p.player_id))
                            {
                                p.name_color = 0;
                                _client.SendPacket(new PROTOCOL_BASE_GET_MYINFO_BASIC_ACK(p));
                                Room room = p._room;
                                if (room != null)
                                {
                                    using (PROTOCOL_ROOM_GET_NICKNAME_ACK packet = new PROTOCOL_ROOM_GET_NICKNAME_ACK(p._slotId, p.player_name, p.name_color))
                                    {
                                        room.SendPacketToPlayers(packet);
                                    }
                                }
                            }
                            else
                            {
                                erro = 0x80000000;
                            }
                        }
                    }
                    else
                    {
                        PlayerManager.updatePlayerBonus(p.player_id, bonus.bonuses, bonus.freepass);
                    }

                    CouponFlag cupom = CouponEffectManager.getCouponEffect(item._id);
                    if (cupom != null && cupom.EffectFlag > 0 && p.effects.HasFlag(cupom.EffectFlag))
                    {
                        p.effects -= cupom.EffectFlag;
                        PlayerManager.updateCupomEffects(p.player_id, p.effects);
                    }
                }
                if (erro == 1 && item != null)
                {
                    if (PlayerManager.DeleteItem(item._objId, p.player_id))
                    {
                        p._inventory.RemoveItem(item);
                    }
                    else
                    {
                        erro = 0x80000000;
                    }
                }
                _client.SendPacket(new PROTOCOL_AUTH_SHOP_DELETE_ITEM_ACK(erro, objId));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_AUTH_SHOP_DELETE_ITEM_ACK: " + ex.ToString());
                _client.SendPacket(new PROTOCOL_AUTH_SHOP_DELETE_ITEM_ACK(0x80000000));
            }
        }
    }
}