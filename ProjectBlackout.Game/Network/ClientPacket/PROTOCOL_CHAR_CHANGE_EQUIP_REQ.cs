using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
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
    public class PROTOCOL_CHAR_CHANGE_EQUIP_REQ : ReceivePacket
    {
        private Account Player;
        private PlayerEquipedItems Equip;
        private uint Error;
        private int CharCount, ItemEnable, ItemDisable;

        public PROTOCOL_CHAR_CHANGE_EQUIP_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            Equip = new PlayerEquipedItems();
            Player = _client._player;
            ItemDisable = readC();
            for (int i = 0; i < ItemDisable; i++)
            {
                ReadAndUpdateItemDisable(Player);
            }
            readC(); // Item Disable Count
            readC(); // Unk
            ItemEnable = readC();
            for (int i = 0; i < ItemEnable; i++)
            {
                ReadAndUpdateItemEnable(Player);
            }
            readC(); // Item Enable Count
            readC(); // Unk
            CharCount = readC();
            for (int i = 0; i < CharCount; i++)
            {
                ReadAndUpdateCharacterEquipment(Player, Equip);
            }
            readC(); // Character Update Count
            ReadAndUpdateSlot(Player, Equip);
        }

        public override void run()
        {
            DBQuery Query = new DBQuery();
            Room Room = Player._room;
            if (Room != null)
            {
                AllUtils.updateSlotEquips(Player, Room);
            }
            if (Equip._dino == 0)
            {
                Equip._dino = Player._equip._dino;
            }
            if (Player != null)
            {
                if (CharCount > 0)
                {
                    PlayerManager.updateWeapons(Equip, Player._equip, Query);
                    PlayerManager.updateChars(Equip, Player._equip, Query);
                }
                else
                {
                    PlayerManager.updateCharSlots(Equip, Player._equip, Query);
                }
            }
            else
            {
                Error = 0x80000000;
            }
            if (ComDiv.updateDB("players", "player_id", Player.player_id, Query.GetTables(), Query.GetValues()))
            {
                Update(Player);
            }
            _client.SendPacket(new PROTOCOL_CHAR_CHANGE_EQUIP_ACK(Error));
        }

        private void ReadAndUpdateItemDisable(Account Player)
        {
            int CouponId = readD();
            ItemsModel Item = Player._inventory._items.FirstOrDefault(x => x._id == CouponId);
            if (Item != null)
            {
                CouponFlag Effect = CouponEffectManager.getCouponEffect(Item._id);
                if (Effect != null && Effect.EffectFlag > 0 && Player.effects.HasFlag(Effect.EffectFlag))
                {
                    Player.effects -= Effect.EffectFlag;
                    PlayerManager.updateCupomEffects(Player.player_id, Player.effects);
                }
            }
        }

        private void ReadAndUpdateItemEnable(Account Player)
        {
            int CouponId = readD();
            ItemsModel Item = Player._inventory._items.FirstOrDefault(x => x._id == CouponId);
            if (Item != null)
            {
                bool Changed = Player._bonus.AddBonuses(Item._id);
                CouponFlag Effect = CouponEffectManager.getCouponEffect(Item._id);
                if (Effect != null && Effect.EffectFlag > 0 && !Player.effects.HasFlag(Effect.EffectFlag))
                {
                    Player.effects |= Effect.EffectFlag;
                    PlayerManager.updateCupomEffects(Player.player_id, Player.effects);
                }
                if (Changed)
                {
                    PlayerManager.updatePlayerBonus(Player.player_id, Player._bonus.bonuses, Player._bonus.freepass);
                }
            }
        }

        private void ReadAndUpdateSlot(Account Player, PlayerEquipedItems Equip)
        {
            Equip._dino = readD();
            //readD();
            readC(); // Count Dino
            int Count = readC();
            for (int i = 0; i < Count; i++)
            {
                int Slot = readC();
                Character Character = Player.getCharacterSlot(Slot);
                if (Character != null)
                {
                    if (i == 0)
                    {
                        Equip._red = Character.Id;
                    }
                    else if (i == 1)
                    {
                        Equip._blue = Character.Id;
                    }
                }
            }
        }

        private void ReadAndUpdateCharacterEquipment(Account Player, PlayerEquipedItems Equip)
        {
            int Index = readC();
            Character Character = Player.getCharacterSlot(Index);
            for (int i = 0; i < 14; i++)
            {
                int ItemId = readD();
                int StoredId = readD();
                ItemsModel Item = Player._inventory._items.FirstOrDefault(x => x._id == ItemId);
                if (Item != null)
                {
                    switch (i)
                    {
                        case 0:
                            Equip._primary = ItemId;
                            break;
                        case 1:
                            Equip._secondary = ItemId;
                            break;
                        case 2:
                            Equip._melee = ItemId;
                            break;
                        case 3:
                            Equip._grenade = ItemId;
                            break;
                        case 4:
                            Equip._special = ItemId;
                            break;
                        case 5:
                            if (ComDiv.getIdStatics(ItemId, 2) == 1)
                            {
                                Equip._red = ItemId;
                                Equip._blue = Player._equip._blue;
                            }
                            else if (ComDiv.getIdStatics(ItemId, 2) == 2)
                            {
                                Equip._red = Player._equip._red;
                                Equip._blue = ItemId;
                            }
                            break;
                        case 6:
                            Equip.face = ItemId;
                            break;
                        case 7:
                            Equip._helmet = ItemId;
                            break;
                        case 8:
                            Equip.jacket = ItemId;
                            break;
                        case 9:
                            Equip.poket = ItemId;
                            break;
                        case 10:
                            Equip.glove = ItemId;
                            break;
                        case 11:
                            Equip.belt = ItemId;
                            break;
                        case 12:
                            Equip.holster = ItemId;
                            break;
                        case 13:
                            Equip.skin = ItemId;
                            break;
                        case 14:
                            Equip.accessory = ItemId;
                            break;
                    }
                }
            }
            Equip._beret = readD();
            readD();
        }

        private void Update(Account p)
        {
            if (CharCount > 0)
            {
                p._equip._primary = Equip._primary;
                p._equip._secondary = Equip._secondary;
                p._equip._melee = Equip._melee;
                p._equip._grenade = Equip._grenade;
                p._equip._special = Equip._special;
                p._equip._red = Equip._red;
                p._equip._blue = Equip._blue;
                p._equip._helmet = Equip._helmet;
                p._equip._beret = Equip._beret;
                p._equip._dino = Equip._dino;
                p._equip.face = Equip.face;
                p._equip.jacket = Equip.jacket;
                p._equip.poket = Equip.poket;
                p._equip.glove = Equip.glove;
                p._equip.belt = Equip.belt;
                p._equip.holster = Equip.holster;
                p._equip.skin = Equip.skin;
                p._equip.accessory = Equip.accessory;
            }
            else
            {
                p._equip._red = Equip._red;
                p._equip._blue = Equip._blue;
                p._equip._dino = Equip._dino;
            }
        }
    }
}
