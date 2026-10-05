using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_READYBATTLE_ACK : SendPacket
    {
        private uint _erro;

        public PROTOCOL_BATTLE_READYBATTLE_ACK(uint erro)
        {
            _erro = erro;
        }

        public override void write()
        {
            writeH(4100);
            writeC(0);
            writeH(0);
            writeD(_erro);
            /*
             * 0x80001008 STBL_IDX_EP_ROOM_NO_REAL_IP_S
             * 0x80001009 STBL_IDX_EP_ROOM_NO_READY_TEAM_S
             * 0x80001012 STBL_IDX_EP_ROOM_NO_START_FOR_UNDER_NAT
             * 0x80001071 STBL_IDX_EP_ROOM_NO_START_FOR_NO_CLAN_TEAM
             * 0x80001072 STBL_IDX_EP_ROOM_NO_START_FOR_TEAM_NOTFULL
             * 0x80001098 STBL_IDX_EP_ROOM_NO_START_FOR_NOT_ALL_READY
             * 0x800010AB STBL_IDX_EP_ROOM_ERROR_READY_WEAPON_EQUIP
             */
        }
    }
}