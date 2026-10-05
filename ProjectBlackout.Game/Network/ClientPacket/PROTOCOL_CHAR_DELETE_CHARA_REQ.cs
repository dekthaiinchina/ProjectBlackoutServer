using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CHAR_DELETE_CHARA_REQ : ReceivePacket
    {
        private int Slot;

        public PROTOCOL_CHAR_DELETE_CHARA_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            Slot = readC();
        }

        public override void run()
        {
            try
            {
                Account Player = _client._player;
                if (Player != null)
                {
                    Character Character = Player.getCharacterSlot(Slot);
                    if (Character != null)
                    {
                        ItemsModel Item = Player._inventory.getItem(Character.Id);
                        if (Item != null)
                        {
                            int Index = 0;
                            for (int i = 0; i < Player.Characters.Count; i++)
                            {
                                Character Chara = Player.Characters[i];
                                if (Chara.Slot != Character.Slot)
                                {
                                    Chara.Slot = Index;
                                    CharacterManager.Update(Index, Chara.ObjId);
                                    Index++;
                                }
                            }
                            _client.SendPacket(new PROTOCOL_CHAR_DELETE_CHARA_ACK(0, Slot, Player, Item));
                            if (CharacterManager.Delete(Character.ObjId, Player.player_id))
                            {
                                Player.Characters.Remove(Character);
                            }
                            if (PlayerManager.DeleteItem(Item._objId, Player.player_id))
                            {
                                Player._inventory.RemoveItem(Item);
                            }
                        }
                        else
                        {
                            _client.SendPacket(new PROTOCOL_CHAR_DELETE_CHARA_ACK(0x800010A7));
                        }
                    }
                    else
                    {
                        _client.SendPacket(new PROTOCOL_CHAR_DELETE_CHARA_ACK(0x800010A7));
                    }
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_CHAR_DELETE_CHARA_ACK(0x800010A7));
                }
            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_CHAR_DELETE_CHARA_REQ: " + ex.ToString());
            }
        }
    }
}
