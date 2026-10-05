using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Title;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_USER_TITLE_RELEASE_REQ : ReceivePacket
    {
        private int slotIdx;
        private uint erro;

        public PROTOCOL_BASE_USER_TITLE_RELEASE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            slotIdx = readC();
            readC();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null || slotIdx >= 3 || p._titles == null)
                {
                    return;
                }
                PlayerTitles t = p._titles;
                int titleId = t.GetEquip(slotIdx);
                if (titleId > 0 && TitleManager.getInstance().updateEquipedTitle(t.ownerId, slotIdx, 0))
                {
                    t.SetEquip(slotIdx, 0);
                    if (TitleAwardsXml.Contains(titleId, p._equip._beret) && ComDiv.updateDB("players", "char_beret", 0, "player_id", p.player_id))
                    {
                        p._equip._beret = 0;
                        Room room = p._room;
                        if (room != null)
                        {
                            AllUtils.updateSlotEquips(p, room);
                        }
                    }
                }
                else
                {
                    erro = 0x80000000;
                }
                _client.SendPacket(new PROTOCOL_BASE_USER_TITLE_RELEASE_ACK(erro));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_BASE_USER_TITLE_RELEASE_REQ: " + ex.ToString());
            }
        }
    }
}