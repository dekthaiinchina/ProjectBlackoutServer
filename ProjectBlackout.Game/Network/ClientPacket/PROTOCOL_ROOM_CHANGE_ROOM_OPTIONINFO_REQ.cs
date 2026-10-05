using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_CHANGE_ROOM_OPTIONINFO_REQ : ReceivePacket
    {
        private string leader;

        public PROTOCOL_ROOM_CHANGE_ROOM_OPTIONINFO_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            try
            {
                Account player = _client._player;
                Room room = player == null ? null : player._room;
                if (room != null && room._leader == player._slotId && room.RoomState == RoomState.Ready)
                {
                    leader = readS(33);
                    room.killtime = readD();
                    room.Limit = readC();
                    room.WatchRuleFlag = readC();
                    room.BalanceType = readH();
                    using (PROTOCOL_ROOM_CHANGE_ROOM_OPTIONINFO_ACK packet = new PROTOCOL_ROOM_CHANGE_ROOM_OPTIONINFO_ACK(room, leader))
                    {
                        room.SendPacketToPlayers(packet);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }

        public override void run()
        {

        }
    }
}