using ProjectBlackout.Core.Managers.Events;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_PLAYER_TIME_ACK : SendPacket
    {
        private int _type;
        private PlayTimeModel ev;

        public PROTOCOL_BATTLE_PLAYER_TIME_ACK(int type, PlayTimeModel eventPt)
        {
            _type = type;
            ev = eventPt;
        }

        public override void write()
        {
            writeH(3911);
            writeC((byte)_type);
            writeS(ev._title, 30);
            writeD(ev._goodReward1);
            writeD(ev._goodReward2);
            writeQ(ev._time);
        }
    }
}