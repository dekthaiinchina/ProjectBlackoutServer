using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Account.Title;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_USER_TITLE_CHANGE_REQ : ReceivePacket
    {
        private int titleIdx;
        private uint erro;

        public PROTOCOL_BASE_USER_TITLE_CHANGE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            titleIdx = readC();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null || titleIdx >= 45)
                {
                    return;
                }
                if (p._titles.ownerId == 0)
                {
                    TitleManager.getInstance().CreateTitleDB(p.player_id);
                    p._titles = new PlayerTitles { ownerId = p.player_id };
                }
                TitleQ t1 = TitlesXml.getTitle(titleIdx);
                if (t1 != null)
                {
                    TitleQ tr1, tr2;
                    TitlesXml.get2Titles(t1._req1, t1._req2, out tr1, out tr2, false);
                    if ((t1._req1 == 0 || tr1 != null) &&
                        (t1._req2 == 0 || tr2 != null) &&
                        p._rank >= t1._rank &&
                        p.brooch >= t1._brooch &&
                        p.medal >= t1._medals &&
                        p.blue_order >= t1._blueOrder &&
                        p.insignia >= t1._insignia &&
                        !p._titles.Contains(t1._flag) &&
                        p._titles.Contains(tr1._flag) &&
                        p._titles.Contains(tr2._flag))
                    {
                        p.brooch -= t1._brooch;
                        p.medal -= t1._medals;
                        p.blue_order -= t1._blueOrder;
                        p.insignia -= t1._insignia;
                        long flags = p._titles.Add(t1._flag);
                        TitleManager.getInstance().updateTitlesFlags(p.player_id, flags);
                        List<ItemsModel> items = TitleAwardsXml.getAwards(titleIdx);
                        if (items.Count > 0)
                        {
                            for (int i = 0; i < items.Count; i++)
                            {
                                ItemsModel Item = items[i];
                                if (Item._id != 0)
                                {
                                    _client.SendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(0, p, Item));
                                }
                            }
                        }
                        _client.SendPacket(new PROTOCOL_BASE_MEDAL_GET_INFO_ACK(p));
                        TitleManager.getInstance().updateRequi(p.player_id, p.medal, p.insignia, p.blue_order, p.brooch);
                        if (p._titles.Slots < t1._slot)
                        {
                            p._titles.Slots = t1._slot;
                            ComDiv.updateDB("player_titles", "titleslots", p._titles.Slots, "owner_id", p.player_id);
                        }
                    }
                    else
                    {
                        erro = 0x80001083;
                    }
                }
                else
                {
                    erro = 0x80001083;
                }
                _client.SendPacket(new PROTOCOL_BASE_USER_TITLE_CHANGE_ACK(erro, p._titles.Slots));
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_BASE_USER_TITLE_CHANGE_REQ: " + ex.ToString());
            }
        }
    }
}