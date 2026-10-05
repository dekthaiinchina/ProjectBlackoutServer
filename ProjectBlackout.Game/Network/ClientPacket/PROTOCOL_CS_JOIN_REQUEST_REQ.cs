using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_JOIN_REQUEST_REQ : ReceivePacket
    {
        private int clanId;
        private string text;
        private uint erro;

        public PROTOCOL_CS_JOIN_REQUEST_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            clanId = readD();
            text = readUnicode(readC() * 2);
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
                ClanInvite invite = new ClanInvite
                {
                    clan_id = clanId,
                    player_id = _client.player_id,
                    text = text,
                    inviteDate = int.Parse(DateTime.Now.AddYears(-10).ToString("yyyyMMdd"))
                };
                if (p.clanId > 0 || p.player_name.Length == 0)
                {
                    erro = 2147487836;
                }
                else if (ClanManager.getClan(clanId)._id == 0)
                {
                    erro = 0x80000000;
                }
                else if (PlayerManager.getRequestCount(clanId) >= 100)
                {
                    erro = 2147487831;
                }
                else if (!PlayerManager.CreateInviteInDb(invite))
                {
                    erro = 2147487848;
                }
                invite = null;
                _client.SendPacket(new PROTOCOL_CS_JOIN_REQUEST_ACK(erro, clanId));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CS_JOIN_REQUEST_REQ: " + ex.ToString());
            }
        }
    }
}