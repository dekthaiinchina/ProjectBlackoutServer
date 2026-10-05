using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using System;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CLIENT_ENTER_ACK : SendPacket
    {
        private int _type, _clanId;

        public PROTOCOL_CS_CLIENT_ENTER_ACK(int id, int access)
        {
            _clanId = id;
            _type = access;
        }

        public override void write()
        {
            writeH(1794);
            writeD(_clanId);
            writeD(_type);
            if (_clanId == 0 || _type == 0)
            {
                writeD(ClanManager._clans.Count);
                writeC(15);
                writeH((ushort)Math.Ceiling(ClanManager._clans.Count / 15d));
                writeD(uint.Parse(DateTime.Now.ToString("MMddHHmmss")));
            }
        }
    }
}