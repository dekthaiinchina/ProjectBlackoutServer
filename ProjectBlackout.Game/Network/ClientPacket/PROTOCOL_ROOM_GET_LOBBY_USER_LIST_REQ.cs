using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_ROOM_GET_LOBBY_USER_LIST_REQ : ReceivePacket
    {
        public PROTOCOL_ROOM_GET_LOBBY_USER_LIST_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            Account player = _client._player;
            if (player == null)
            {
                return;
            }
            try
            {
                Channel ch = player.getChannel();
                if (ch != null)
                {
                    _client.SendPacket(new PROTOCOL_ROOM_GET_LOBBY_USER_LIST_ACK(ch));
                }
            }
            catch (Exception ex) 
            { 
                Logger.warning("PROTOCOL_ROOM_GET_LOBBY_USER_LIST_REQ: " + ex.ToString()); 
            }
        }
    }
}