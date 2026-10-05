using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK : SendPacket
    {
        private EventErrorEnum _error;

        public PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK(EventErrorEnum error)
        {
            _error = error;
        }

        public override void write()
        {
            writeH(2564);
            writeD((uint)_error);
            /*
             * State=13 : 0x8000100A [STBL_IDX_EP_BATTLE_FRIST_MAINLOAD_BATTLE] Game exiting since the room host forced a shutdown.
             * State!=13: 0x8000100A [STBL_IDX_EP_BATTLE_FRIST_MAINLOAD] Unable to join the game.
             * 0x8000100B [STBL_IDX_EP_BATTLE_FRIST_HOLE] (Unable to start due to room host's network settings.\nReturning to room.)
             * else [STBL_IDX_EP_BATTLE_FRIST_DEFAULT] (Network settings conflict with the room host.)
             * valor >= 0 [STBL_IDX_EP_ROOM_KICKED] (Kikado pelo dono da sala)
             */
        }
    }
}