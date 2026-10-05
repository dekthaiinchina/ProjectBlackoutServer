using ProjectBlackout.Core.Network;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_MESSENGER_NOTE_DELETE_ACK : SendPacket
    {
        private uint _erro;
        private List<object> _objs;

        public PROTOCOL_MESSENGER_NOTE_DELETE_ACK(uint erro, List<object> objs)
        {
            _erro = erro;
            _objs = objs;
        }

        public override void write()
        {
            writeH(937);
            writeD(_erro);
            writeC((byte)_objs.Count);
            foreach (int obj in _objs)
            {
                writeD(obj);
            }
        }
    }
}