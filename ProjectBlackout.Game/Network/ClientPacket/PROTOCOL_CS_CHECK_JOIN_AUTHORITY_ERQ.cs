using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_CHECK_JOIN_AUTHORITY_ERQ : ReceivePacket
    {
        private int clanId;
        private uint erro;

        public PROTOCOL_CS_CHECK_JOIN_AUTHORITY_ERQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            clanId = readD();
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
                Clan c = ClanManager.getClan(clanId);
                if (c._id == 0)
                {
                    erro = 0x80000000;
                }
                else if (c.limite_rank > p._rank)
                {
                    erro = 2147487867;
                }
                _client.SendPacket(new PROTOCOL_CS_CHECK_JOIN_AUTHORITY_ACK(erro));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CS_CHECK_JOIN_AUTHORITY_ERQ: " + ex.ToString());
            }
        }
    }
}