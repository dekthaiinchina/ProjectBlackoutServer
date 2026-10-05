using ProjectBlackout.Battle.Data.Enums;

namespace ProjectBlackout.Battle.Data.Models
{
    public class ActionModel
    {
        public ushort Slot, Length;
        public UDP_GAME_EVENTS Flag;
        public UDP_SUB_HEAD SubHead;
        public byte[] Data;
    }
}