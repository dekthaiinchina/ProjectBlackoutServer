using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_CLAN_LIST_DETAIL_INFO_REQ : ReceivePacket
    {
        private int ClanId, Unk;

        public PROTOCOL_CS_CLAN_LIST_DETAIL_INFO_REQ(GameClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            ClanId = readD();
            Unk = readC();
        }

        public override void run()
        {
            try
            {
                Account Player = _client._player;
                if (Player == null)
                {
                    return;
                }
                Player.FindClanId = ClanId;
                Clan Clan = ClanManager.getClan(ClanId);
                if (Clan._id > 0)
                {
                    _client.SendPacket(new PROTOCOL_CS_CLAN_LIST_DETAIL_INFO_ACK(Unk, Clan));
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CS_CLAN_LIST_DETAIL_INFO_REQ: " + ex.ToString());
            }
        }
    }
}
