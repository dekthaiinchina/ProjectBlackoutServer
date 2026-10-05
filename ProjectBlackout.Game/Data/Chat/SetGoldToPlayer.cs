using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Sync.Server;
using System;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class SetGoldToPlayer
    {
        public static string SetGdToPlayer(string str)
        {           
            string txt = str.Substring(str.IndexOf(" ") + 1);
            string[] split = txt.Split(' ');
            long player_id = Convert.ToInt64(split[0]);
            int gold = Convert.ToInt32(split[1]);

            Account pR = AccountManager.getAccount(player_id, 0);
            if (pR == null)
            {
                return Translation.GetLabel("[*]SendGold_Fail4");
            }
            if (pR._gp + gold > 999999999 || gold < 0)
            {
                return Translation.GetLabel("[*]SendGold_Fail4");
            }
            if (PlayerManager.updateAccountCash(pR.player_id, pR._gp = gold))
            {
                pR._gp = gold;
                pR.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, pR._gp, pR._money), false);
                SendItemInfo.LoadGoldCash(pR);
                return Translation.GetLabel("GiveGoldSuccessD", pR._gp, pR.player_name);
            }
            else
            {
                return Translation.GetLabel("[*]GiveGoldFail2");
            }
        }
    }
}