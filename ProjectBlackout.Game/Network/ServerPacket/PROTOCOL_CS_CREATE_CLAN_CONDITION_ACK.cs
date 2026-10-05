using ProjectBlackout.Core;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Configs;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_CREATE_CLAN_CONDITION_ACK : SendPacket
    {
        public PROTOCOL_CS_CREATE_CLAN_CONDITION_ACK()
        {

        }

        public override void write()
        {
            writeH(1937);
            writeC((byte)GameConfig.minCreateRank);
            writeD(GameConfig.minCreateGold);
        }
    }
}