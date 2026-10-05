using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CLAN_WAR_LEAVE_TEAM_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_CLAN_WAR_LEAVE_TEAM_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(1551);
            writeD(_erro);
        }
    }
}