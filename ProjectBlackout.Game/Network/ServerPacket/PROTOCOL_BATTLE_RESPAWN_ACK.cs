using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_RESPAWN_ACK : SendPacket
    {
        private Slot slot;
        private Room room;

        public PROTOCOL_BATTLE_RESPAWN_ACK(Room r, Slot slot)
        {
            this.slot = slot; 
            this.room = r;
        }

        public override void write()
        {
            bool Team = slot._id % 2 == 0;
            writeH(4114);
            writeD(slot._id);
            writeD(room.spawnsCount++); 
            writeD(++slot.spawnsCount);
            writeD(slot._equip._primary);
            writeD(slot._equip._secondary);
            writeD(slot._equip._melee);
            writeD(slot._equip._grenade);
            writeD(slot._equip._special);
            writeB(new byte[5] { 100, 100, 100, 100, 100 });
            if (room.RoomType == RoomType.Boss || room.RoomType == RoomType.CrossCounter)
            {
                if (!room.swapRound)
                {
                    if (Team)
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
                    if (Team)
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
                if (Team)
                {
                    writeD(slot._equip._red);
                }
                else
                {
                    writeD(slot._equip._blue);
                }
            }
            writeD(slot._equip.face);
            writeD(slot._equip._helmet);
            writeD(slot._equip.jacket);
            writeD(slot._equip.poket);
            writeD(slot._equip.glove);
            writeD(slot._equip.belt);
            writeD(slot._equip.holster);
            writeD(slot._equip.skin);
            writeD(slot._equip._beret);
            writeD(slot._equip.accessory);
            if (room.RoomType == RoomType.Boss || room.RoomType == RoomType.CrossCounter)
            {
                List<int> pL = AllUtils.getDinossaurs(room, false, slot._id);
                int TRex = pL.Count == 1 || room.RoomType == RoomType.CrossCounter ? 255 : room.TRex;
                writeC((byte)TRex);
                writeC(10);
                for (int i = 0; i < pL.Count; i++)
                {
                    int slotId = pL[i];
                    if (slotId != room.TRex && room.RoomType == RoomType.Boss || room.RoomType == RoomType.CrossCounter)
                    {
                        writeC((byte)slotId);
                    }
                }
                int Fault = 8 - pL.Count - (TRex == 255 ? 1 : 0);
                for (int i = 0; i < Fault; i++)
                {
                    writeC(255);
                }
                writeC(255);
            }
        }
    }
}