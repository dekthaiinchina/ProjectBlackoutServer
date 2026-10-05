using System;
using System.Collections.Generic;

namespace ProjectBlackout.Battle.Data.Models
{
    public class PacketModel
    {
        public int Opcode, Slot, Round, Length, AccountId, Unk, Respawn, RoundNumber;
        public float Time;
        public byte[] Data, withEndData, noEndData;
        public DateTime ReceiveDate;
    }
}