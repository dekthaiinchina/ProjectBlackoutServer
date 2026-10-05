using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BATTLE_NOTIFY_CURRENT_KICKVOTE_REQ : ReceivePacket
    {
        private byte type;

        public PROTOCOL_BATTLE_NOTIFY_CURRENT_KICKVOTE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            type = readC();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                Room r = p == null ? null : p._room;
                Slot slot;
                if (r == null || r.RoomState != RoomState.Battle || r.vote.Timer == null || r.votekick == null || !r.getSlot(p._slotId, out slot) || slot.state != SlotState.BATTLE)
                {
                    return;
                }
                Core.Models.Room.VoteKick vote = r.votekick;
                if (vote._votes.Contains(p._slotId))
                {
                    _client.SendPacket(new PROTOCOL_BATTLE_VOTE_KICKVOTE_ACK(0x800010F1));
                    return;
                }
                lock (vote._votes)
                {
                    vote._votes.Add(slot._id);
                }
                if (type == 0)
                {
                    vote.kikar++;
                    if (slot._team == vote.victimIdx % 2)
                    {
                        vote.allies++;
                    }
                    else
                    {
                        vote.enemys++;
                    }
                }
                else vote.deixar++;
                if (vote._votes.Count >= vote.GetInGamePlayers())
                {
                    r.vote.Timer = null;
                    AllUtils.votekickResult(r);
                }
                else
                {
                    using (PROTOCOL_BATTLE_NOTIFY_CURRENT_KICKVOTE_ACK packet = new PROTOCOL_BATTLE_NOTIFY_CURRENT_KICKVOTE_ACK(vote))
                    {
                        r.SendPacketToPlayers(packet, SlotState.BATTLE, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_BATTLE_NOTIFY_CURRENT_KICKVOTE_REQ: " + ex.ToString());
            }
        }
    }
}