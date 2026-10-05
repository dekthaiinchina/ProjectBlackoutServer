using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_CREATE_NICK_ACK : SendPacket
    {
        private uint _erro;
        private string _name;

        public PROTOCOL_BASE_CREATE_NICK_ACK(uint erro, string name)
        {
            _erro = erro;
            _name = name;
        }

        public override void write()
        {
            writeH(535);
            writeH(0);
            writeD(1500511);
            writeD(1075242335);
            writeC((byte)_name.Length);
            writeUnicode(_name, _name.Length * 2);
            writeD(_erro);
        }
    }
}