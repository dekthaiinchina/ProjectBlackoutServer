using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Title;
using ProjectBlackout.Core.Xml;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_USER_TITLE_EQUIP_REQ : ReceivePacket
    {
        private byte slotIdx, titleId;
        private uint erro;

        public PROTOCOL_BASE_USER_TITLE_EQUIP_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            slotIdx = readC();
            titleId = readC();
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
                PlayerTitles t = p._titles;
                TitleQ titleQ = TitlesXml.getTitle(titleId), eq1, eq2, eq3;
                TitlesXml.get3Titles(t.Equiped1, t.Equiped2, t.Equiped3, out eq1, out eq2, out eq3, false);
                if (slotIdx >= 3 || titleId >= 45 || t == null || titleQ == null || titleQ._classId == eq1._classId && slotIdx != 0 || titleQ._classId == eq2._classId && slotIdx != 1 || titleQ._classId == eq3._classId && slotIdx != 2 || !t.Contains(titleQ._flag) || t.Equiped1 == titleId || t.Equiped2 == titleId || t.Equiped3 == titleId)
                {
                    erro = 0x80000000;
                }
                else
                {
                    if (TitleManager.getInstance().updateEquipedTitle(t.ownerId, slotIdx, titleId))
                    {
                        t.SetEquip(slotIdx, titleId);
                    }
                    else
                    {
                        erro = 0x80000000;
                    }
                }
                _client.SendPacket(new PROTOCOL_BASE_USER_TITLE_EQUIP_ACK(erro));
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_BASE_USER_TITLE_EQUIP_REQ: " + ex.ToString());
            }
        }
    }
}