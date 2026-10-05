using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_GET_USER_SUBTASK_ACK : SendPacket
    {
        private uint sessionId;
        public PROTOCOL_BASE_GET_USER_SUBTASK_ACK(uint sessionId)
        {
            this.sessionId = sessionId;
        }

        public override void write()
        {
            writeH(656);
            writeH(0);
            writeD(0);
            writeD(sessionId);
            writeC(0);
        }
    }
}