using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_MISSION_BOMB_INSTALL_ACK : SendPacket
    {
        private int _slot;
        private float _x, _y, _z;
        private byte _zone;

        public PROTOCOL_BATTLE_MISSION_BOMB_INSTALL_ACK(int slot, byte zone, float x, float y, float z)
        {
            _zone = zone;
            _slot = slot;
            _x = x;
            _y = y;
            _z = z;
        }

        public override void write()
        {
            writeH(4133);
            writeD(_slot);
            writeC(_zone);
            writeH(42);
            writeT(_x);
            writeT(_y);
            writeT(_z);
        }
    }
}