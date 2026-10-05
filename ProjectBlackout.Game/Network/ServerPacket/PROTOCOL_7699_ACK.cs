using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_7699_ACK : SendPacket
    {
        public int erro;
        public string player_name;

        public PROTOCOL_7699_ACK(int erro, string player_name)
        {
            this.erro = erro;
        }

        public override void write()
        {
            writeH(7700);
            //writeS(player_name);
            writeD(erro);
        }
    }
}