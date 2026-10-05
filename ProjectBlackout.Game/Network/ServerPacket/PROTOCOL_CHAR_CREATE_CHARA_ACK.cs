using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CHAR_CREATE_CHARA_ACK : SendPacket
    {
        private Character Character;
        private Account Player;
        private uint Error;
        private int Type;

        public PROTOCOL_CHAR_CREATE_CHARA_ACK(uint Error, int Type, Character Character, Account Player)
        {
            this.Character = Character;
            this.Player = Player;
            this.Error = Error;
            this.Type = Type;
        }

        public override void write()
        {
            writeH(6146);
            writeH(0);
            writeD(Error);
            if (Error == 0)
            {
                writeD(Player._equip._primary);
                writeD((int)Player._inventory.getItem(Player._equip._primary)._objId);
                writeD(Player._equip._secondary);
                writeD((int)Player._inventory.getItem(Player._equip._secondary)._objId);
                writeD(Player._equip._melee);
                writeD((int)Player._inventory.getItem(Player._equip._melee)._objId);
                writeD(Player._equip._grenade);
                writeD((int)Player._inventory.getItem(Player._equip._grenade)._objId);
                writeD(Player._equip._special);
                writeD((int)Player._inventory.getItem(Player._equip._special)._objId);
                writeD(Character.Id);
                writeD((int)Player._inventory.getItem(Character.Id)._objId);
                writeD(Player._equip.face);
                if (Player._inventory.getItem(Player._equip.face) == null)
                {
                    writeD(0);
                }
                else
                {
                    writeD((int)Player._inventory.getItem(Player._equip.face)._objId);
                }
                writeD(Player._equip._helmet);
                if (Player._inventory.getItem(Player._equip._helmet) == null)
                {
                    writeD(0);
                }
                else
                {
                    writeD((int)Player._inventory.getItem(Player._equip._helmet)._objId);
                }
                writeD(Player._equip.jacket);
                writeD((int)Player._inventory.getItem(Player._equip.jacket)._objId);
                writeD(Player._equip.poket);
                writeD((int)Player._inventory.getItem(Player._equip.poket)._objId);
                writeD(Player._equip.glove);
                writeD((int)Player._inventory.getItem(Player._equip.glove)._objId);
                writeD(Player._equip.belt);
                writeD((int)Player._inventory.getItem(Player._equip.belt)._objId);
                writeD(Player._equip.holster);
                writeD((int)Player._inventory.getItem(Player._equip.holster)._objId);
                writeD(Player._equip.skin);
                writeD((int)Player._inventory.getItem(Player._equip.skin)._objId);
                writeD(Player._equip._beret);
                if (Player._inventory.getItem(Player._equip._beret) == null)
                {
                    writeD(0);
                }
                else
                {
                    writeD((int)Player._inventory.getItem(Player._equip._beret)._objId);
                }
                writeC(0);
                writeC(255);
                writeC(255);
                writeC(255);
                writeC(0);
                writeC(0);
                writeC(0);
                writeD((int)Character.ObjId);
                writeD(Character.CreateDate);
                writeD(0);
                writeD(0);
                writeUnicode(Character.Name, 66);
                writeD(Player._money);
                writeD(Player._gp);
                writeC((byte)Type);
                if (Character.Slot == 0 || Character.Slot == 1)
                {
                    writeC(20);
                }
                else
                {
                    writeC(30);
                }
                writeC((byte)Character.Slot);
                writeC(1);
            }
            else
            {
                writeD(Error);
            }
        }
    }
}
