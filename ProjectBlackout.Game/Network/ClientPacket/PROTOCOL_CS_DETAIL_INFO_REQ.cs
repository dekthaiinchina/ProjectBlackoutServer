using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_DETAIL_INFO_REQ : ReceivePacket
    {
        private int clanId, unk;

        public PROTOCOL_CS_DETAIL_INFO_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            clanId = readD();
            unk = readC(); //1 = Always | 0 = Not Owner
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
                p.FindClanId = clanId;
                Clan c = ClanManager.getClan(clanId);
                if (c._id > 0)
                {
                    _client.SendPacket(new PROTOCOL_CS_DETAIL_INFO_ACK(unk, c));
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CS_DETAIL_INFO_REQ: " + ex.ToString());
            }
        }
    }
}