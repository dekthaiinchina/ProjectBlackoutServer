using ProjectBlackout.Core;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Model;
using System.Text;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class SendMsgToPlayers
    {
        public static string SendToAll(string str)
        {
            string msg = str.Substring(5);
            int count = 0;
            using (PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK packet = new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(msg))
            {
                count = GameManager.SendPacketToAllClients(packet);
            }
            return Translation.GetLabel("MsgAllClients", count);
        }

        public static string SendToRoom(string str, Room room)
        {
            string msg = str.Substring(6);
            if (room == null)
            {
                return Translation.GetLabel("GeneralRoomInvalid");
            }
            using (PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK packet = new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(msg))
            {
                room.SendPacketToPlayers(packet);
            }
            return Translation.GetLabel("MsgRoomPlayers");
        }
    }
}