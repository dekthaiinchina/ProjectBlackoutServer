using ProjectBlackout.Core;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_SUGGEST_KICKVOTE_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_BATTLE_SUGGEST_KICKVOTE_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(3397);
            writeD(_erro);
        }
    }
}