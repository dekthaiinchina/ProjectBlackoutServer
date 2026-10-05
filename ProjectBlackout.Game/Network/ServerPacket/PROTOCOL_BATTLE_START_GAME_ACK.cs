using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_START_GAME_ACK : SendPacket
    {
        private int PlayersCount;
        private Room room;
        private byte[] Data;

        public PROTOCOL_BATTLE_START_GAME_ACK(Room r)
        {
            room = r;
            if (GameConfig.isTestMode && GameConfig.udpType == UdpState.RELAY)
            {
                room._slots[1]._playerId = 0;
                room._slots[1].state = SlotState.EMPTY;
            }
            using (SendGPacket pk = new SendGPacket())
            {
                for (int i = 0; i < 16; i++)
                {
                    Slot slot = room._slots[i];
                    if ((int)slot.state >= 10 && slot._equip != null)
                    {
                        Account player = room.getPlayerBySlot(slot);
                        if (player != null && player._slotId == i)
                        {
                            WriteSlotInfo(slot, player, pk);
                            PlayersCount++;
                        }
                    }
                }
                Data = pk.mstream.ToArray();
            }
        }

        private void WriteSlotInfo(Slot s, Account p, SendGPacket pk)
        {
            pk.writeC((byte)s._id);
            if (s._id % 2 == 0)
            {
                pk.writeD(s._equip._red);
            }
            else
            {
                pk.writeD(s._equip._blue);
            }
            pk.writeD(s._equip._primary);
            pk.writeD(s._equip._secondary);
            pk.writeD(s._equip._melee);
            pk.writeD(s._equip._grenade);
            pk.writeD(s._equip._special);
            if (room.RoomType == RoomType.Boss || room.RoomType == RoomType.CrossCounter)
            {
                if (!room.swapRound)
                {
                    if (s._id % 2 == 0)
                    {
                        pk.writeD(s._equip._dino);
                    }
                    else
                    {
                        pk.writeD(s._equip._blue);
                    }
                }
            }
            else
            {
                if (s._id % 2 == 0)
                {
                    pk.writeD(s._equip._blue);
                }
                else
                {
                    pk.writeD(s._equip._dino);
                }
            }
            pk.writeD(s._equip.face);
            pk.writeD(s._equip._helmet);
            pk.writeD(s._equip.jacket);
            pk.writeD(s._equip.poket);
            pk.writeD(s._equip.glove);
            pk.writeD(s._equip.belt);
            pk.writeD(s._equip.holster);
            pk.writeD(s._equip.skin);
            pk.writeD(s._equip._beret);
            pk.writeC(100);
            pk.writeC(100);
            pk.writeC(100);
            pk.writeC(100);
            pk.writeC(100);
            if (p != null)
            {
                pk.writeC((byte)p._titles.Equiped1);
                pk.writeC((byte)p._titles.Equiped2);
                pk.writeC((byte)p._titles.Equiped3);
            }
            else
            {
                pk.writeB(new byte[3]);
            }
            pk.writeD(p._equip.accessory);
        }

        public override void write()
        {
            writeH(4103);
            writeH(0);
            writeC((byte)PlayersCount);
            for (int i = 0; i < 16; i++)
            {
                Slot slot = room._slots[i];
                if ((int)slot.state >= 9 && slot._equip != null)
                {
                    Account player = room.getPlayerBySlot(slot);
                    if (player != null && player._slotId == i)
                    {
                        writeD((uint)player.player_id);
                    }
                }
            }
            writeC(16);
            for (int i = 0; i < 16; i++)
            {
                writeC(0);
            }
            writeC((byte)PlayersCount);
            writeB(Data);
            writeC((byte)room.mapId);
            writeC((byte)room.rule);
            writeC(room.stage);
            writeC((byte)room.RoomType);
        }
    }
}