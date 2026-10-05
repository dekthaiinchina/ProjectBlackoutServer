using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_GET_CHARA_INFO_ACK : SendPacket
    {
        private Account Player;

        public PROTOCOL_BASE_GET_CHARA_INFO_ACK(Account Player)
        {
            this.Player = Player;
        }

        public override void write()
        {
            try
            {
                writeH(661);
                writeH(0);
                writeC((byte)Player.Characters.Count);
                foreach (Character Character in Player.Characters)
                {
                    if (Character != null)
                    {
                        writeC((byte)Character.Slot);
                        if (Character.Slot == 0 || Character.Slot == 1)
                        {
                            writeC(20);
                        }
                        else
                        {
                            writeC(30);
                        }

                        writeD((int)Character.Id);
                        writeD((int)Character.ObjId);

                        //writeD(Character.CreateDate);
                        //writeD((int)Character.PlayTime);
                        //writeD(Character.PlayTime);
                        //writeUnicode(Character.Name, 66);
                    }
                }

                foreach (Character Character in Player.Characters)
                {
                    if (Character != null)
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
                        //writeD((int)Player._inventory.getItem(Character.Id)._objId);
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
                        //writeC(255);
                        //writeC(255);
                        //writeC(255);
                        //writeC(0);
                        //writeC(0);
                        //writeC(0);
                    }
                }
                writeC(0);
            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_BASE_GET_CHARA_INFO_ACK: " + ex.ToString());
            }
        }
    }
}

/*using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_GET_CHARA_INFO_ACK : SendPacket
    {
        private Account Player;

        public PROTOCOL_GET_CHARA_INFO_ACK(Account Player)
        {
            this.Player = Player;
        }

        public override void write()
        {
            try
            {
                writeH(661);
                writeH(0);
                writeC((byte)Player.Characters.Count);
                foreach (Character Character in Player.Characters)
                {
                    if (Character != null)
                    {
                        writeC((byte)Character.Slot);
                        if (Character.Slot == 0 || Character.Slot == 1)
                        {
                            writeC(20);
                        }
                        else
                        {
                            writeC(30);
                        }
                        writeD((int)Character.Id);
                        writeD((int)Character.ObjId);
                    }
                }

                foreach (Character Character in Player.Characters)
                {
                    if (Character != null)
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
                        writeD(Character.PlayTime);  // Example of writing playtime
                        writeS(Character.Data);      // Example of writing data (assuming writeS for string)
                    }
                }


            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_BASE_GET_CHARA_INFO_ACK: " + ex.ToString());
            }
        }
    }
}*/