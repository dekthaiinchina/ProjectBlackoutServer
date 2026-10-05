using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_MEMBER_CONTEXT_REQ : ReceivePacket
    {
        public PROTOCOL_CS_MEMBER_CONTEXT_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {

        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                int clanId = p.FindClanId;
                if (clanId == 0)
                {
                    _client.SendPacket(new PROTOCOL_CS_MEMBER_CONTEXT_ACK(-1));
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_CS_MEMBER_CONTEXT_ACK(0, PlayerManager.getClanPlayers(clanId)));
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}