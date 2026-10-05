using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_LEAVE_TEAM_REQ : ReceivePacket
    {
        private uint erro;

        public PROTOCOL_CLAN_WAR_LEAVE_TEAM_REQ(GameClient client, byte[] data)
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
                Match mt = p == null ? null : p._match;
                if (mt == null || !mt.RemovePlayer(p))
                {
                    erro = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_CLAN_WAR_LEAVE_TEAM_ACK(erro));
                if (erro == 0)
                {
                    p._status.updateClanMatch(255);
                    AllUtils.syncPlayerToClanMembers(p);
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}