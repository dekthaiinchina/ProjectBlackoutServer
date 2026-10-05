using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers.Events;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_ATTENDANCE_ACK : SendPacket
    {
        private EventVisitModel _event;
        private PlayerEvent _pev;
        private uint _erro;
        private int day;

        public PROTOCOL_BASE_ATTENDANCE_ACK(EventErrorEnum erro, EventVisitModel ev, PlayerEvent pev, int day)
        {
            _erro = (uint)erro;
            _event = ev;
            _pev = pev;
            this.day = day;
        }

        public override void write()
        {
            writeH(545);
            writeD(_erro);
            if (_erro == 0x80001504)
            {
                writeD(_event.id);
                writeC((byte)(_pev.LastVisitSequence1 + 1));
                writeC(0);//writeC((byte)(_pev.LastVisitSequence2 + 1));
                writeH(1);
                writeC((byte)day); // Day 
            }
        }
    }
}