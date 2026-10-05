using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_INVITE_LOBBY_USER_LIST_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_ROOM_INVITE_LOBBY_USER_LIST_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(3930);
            writeD(_erro);
        }
    }
}