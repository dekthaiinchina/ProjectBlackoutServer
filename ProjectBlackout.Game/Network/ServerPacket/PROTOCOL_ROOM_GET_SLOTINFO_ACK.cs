using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_GET_SLOTINFO_ACK : SendPacket
    {
        private Room room;

        public PROTOCOL_ROOM_GET_SLOTINFO_ACK(Room r)
        {
            room = r;
        }

        public override void write()
        {
            try
            {
                if (room == null)
                {
                    return;
                }
                writeH(3848);
                if (room.getLeader() == null)
                {
                    room.setNewLeader(-1, 0, room._leader, false);
                }
                if (room.getLeader() != null)
                {
                    writeC((byte)room._leader);
                    for (int i = 0; i < 16; i++)
                    {
                        Slot slot = room._slots[i];
                        Account pR = room.getPlayerBySlot(slot);
                        if (pR != null)
                        {
                            uint Coupon = (uint)pR.effects;
                            Clan clan = ClanManager.getClan(pR.clanId);
                            writeH(29);
                            writeC((byte)slot.state);
                            writeC((byte)pR.getRank());
                            writeD(clan._id);
                            writeD(pR.clanAccess);
                            writeC((byte)clan._rank);
                            writeD(clan._logo);
                            writeC((byte)pR.pc_cafe);
                            writeC((byte)pR.tourneyLevel);
                            writeD((uint)pR.effects);
                            writeC((byte)clan.effect);
                            writeC(0);
                            writeH(210);
                            writeD(0);
                            writeC((byte)(clan._name.Length * 2));
                            writeUnicode(clan._name, clan._name.Length *2);
                        }
                        else
                        {
                            writeH(29);
                            writeC((byte)slot.state);
                            writeB(new byte[10]);
                            writeD(4294967295);
                            writeB(new byte[15]);
                        }
                    }
                    if (room.RoomType == RoomType.FreeForAll)
                    {
                        for (int Id = 0; Id < 16; Id++)
                        {
                            Slot slot = room._slots[Id];
                            writeC((byte)slot.Costume);
                        }
                    }
                    else
                    {
                        for (int Id = 0; Id < 16; Id++)
                        {
                            Slot slot = room._slots[Id];
                            int SlotId = slot._id % 2;
                            writeC((byte)SlotId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_ROOM_GET_SLOTINFO_ACK: " + ex.ToString());
            }
        }
    }
}