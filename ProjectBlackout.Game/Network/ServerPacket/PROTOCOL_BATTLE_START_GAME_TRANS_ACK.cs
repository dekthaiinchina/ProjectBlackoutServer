using ProjectBlackout.Core.Models.Account.Title;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_START_GAME_TRANS_ACK : SendPacket
    {
        private Room Room;
        private Slot slot;
        private PlayerTitles title;
        //private Account p;
        public PROTOCOL_BATTLE_START_GAME_TRANS_ACK(/*Account player, */Room Room, Slot slot, PlayerTitles title)
        {
            this.Room = Room;
            this.slot = slot;
            this.title = title;
            //p = player;
        }

        public override void write()
        {
            if (slot._equip == null)
            {
                return;
            }
            writeH(4104);
            writeH(0);
            writeD((uint)slot._playerId);
            writeC((byte)slot._id);
            if (slot._id % 2 == 0)
            {
                writeD(slot._equip._red);
            }
            else
            {
                writeD(slot._equip._blue);
            }
            writeD(slot._equip._primary);
            writeD(slot._equip._secondary);
            writeD(slot._equip._melee is not 0 ? slot._equip._melee : 301001);
            writeD(slot._equip._grenade);
            writeD(slot._equip._special);
            if (Room.RoomType == RoomType.Boss || Room.RoomType == RoomType.CrossCounter)
            {
                if (!Room.swapRound)
                {
                    if (slot._id % 2 == 0)
                    {
                        writeD(slot._equip._dino);
                    }
                    else
                    {
                        writeD(slot._equip._blue);
                    }
                }
                else
                {
                    if (slot._id % 2 == 0)
                    {
                        writeD(slot._equip._blue);
                    }
                    else
                    {
                        writeD(slot._equip._dino);
                    }
                }
            }
            else
            {
                if (slot._id % 2 == 0)
                {
                    writeD(slot._equip._red);
                }
                else
                {
                    writeD(slot._equip._blue);
                }
            }
            writeD(slot._equip.face is not 0 ? slot._equip.face : 1000700000);
            writeD(slot._equip._helmet is not 0 ? slot._equip._helmet : 1000800000);
            writeD(slot._equip.jacket is not 0 ? slot._equip.jacket : 1000900000);
            writeD(slot._equip.poket is not 0 ? slot._equip.poket : 1001000000);
            writeD(slot._equip.glove is not 0 ? slot._equip.glove : 1001100000);
            writeD(slot._equip.belt is not 0 ? slot._equip.belt : 1001200000);
            writeD(slot._equip.holster is not 0 ? slot._equip.holster : 1001300000);
            writeD(slot._equip.skin is not 0 ? slot._equip.skin : 1001400000);
            writeD(slot._equip._beret);
            writeC(100);
            writeC(100);
            writeC(100);
            writeC(100);
            writeC(100);
            writeC((byte)title.Equiped1);
            writeC((byte)title.Equiped2);
            writeC((byte)title.Equiped3);
            writeD(slot._equip.accessory);
        }
    }
}