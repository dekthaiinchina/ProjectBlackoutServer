using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_CHANGE_PASSWD_ACK : SendPacket
    {
        private string _pass;

        public PROTOCOL_ROOM_CHANGE_PASSWD_ACK(string pass)
        {
            _pass = pass;
        }

        public override void write()
        {
            writeH(3859);
            writeS(_pass, 4);
        }
    }
}