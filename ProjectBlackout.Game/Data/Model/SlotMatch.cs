using ProjectBlackout.Core.Models.Enums;

namespace ProjectBlackout.Game.Data.Model
{
    public class SlotMatch
    {
        public SlotMatchState state;
        public long _playerId, _id;

        public SlotMatch(int slot)
        {
            _id = slot;
        }
    }
}