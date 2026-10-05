using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_START_KICKVOTE_REQ : ReceivePacket
    {
        private int motive, slotIdx;
        private uint erro;

        public PROTOCOL_BATTLE_START_KICKVOTE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            slotIdx = readC();
            motive = readC();
            //motive 0=NoManner|1=IllegalProgram|2=Abuse|3=ETC
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                Room room = p == null ? null : p._room;
                if (room == null || room.RoomState != RoomState.Battle || p._slotId == slotIdx)
                {
                    return;
                }
                Slot slot = room.getSlot(p._slotId);
                if (slot != null && slot.state == SlotState.BATTLE && room._slots[slotIdx].state == SlotState.BATTLE)
                {
                    int redPlayers, bluePlayers;
                    room.getPlayingPlayers(true, out redPlayers, out bluePlayers);
                    //if (redPlayers < 3 && bluePlayers == 1 ||
                    //bluePlayers < 3 && redPlayers == 1) erro = 0x800010E2;
                    if (p._rank < GameConfig.minRankVote && !p.HaveGMLevel())
                    {
                        erro = 0x800010E4;
                    }
                    else if (room.vote.Timer != null)
                    {
                        erro = 0x800010E0;
                    }
                    else if (slot.NextVoteDate > DateTime.Now)
                    {
                        erro = 0x800010E1;
                    }
                    _client.SendPacket(new PROTOCOL_BATTLE_SUGGEST_KICKVOTE_ACK(erro));
                    if (erro > 0)
                    {
                        return;
                    }
                    slot.NextVoteDate = DateTime.Now.AddMinutes(1);
                    room.votekick = new Core.Models.Room.VoteKick(slot._id, slotIdx)
                    {
                        motive = motive
                    };
                    ChargeVoteKickArray(room);
                    using (PROTOCOL_BATTLE_START_KICKVOTE_ACK packet = new PROTOCOL_BATTLE_START_KICKVOTE_ACK(room.votekick))
                    {
                        room.SendPacketToPlayers(packet, SlotState.BATTLE, 0, p._slotId, slotIdx);
                    }
                    //AllUtils.LogVotekickStart(room, p, slot);
                    room.StartVote();
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_BATTLE_START_KICKVOTE_REQ: " + ex.ToString());
            }
        }

        private void ChargeVoteKickArray(Room room)
        {
            for (int i = 0; i < 16; i++)
            {
                Slot slot = room._slots[i];
                room.votekick.TotalArray[i] = (slot.state == SlotState.BATTLE);
            }
        }
    }
}