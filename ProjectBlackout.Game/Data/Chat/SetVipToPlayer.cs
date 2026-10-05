using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class SetVipToPlayer
    {
        public static string SetVipPlayer(string str)
        {           
            string txt = str.Substring(str.IndexOf(" ") + 1);
            string[] split = txt.Split(' ');
            long player_id = Convert.ToInt64(split[0]);
            int vip = Convert.ToInt32(split[1]);

            Account pR = AccountManager.getAccount(player_id, 0);
            if (pR == null)
            {
                return Translation.GetLabel("[*]SetVip_Fail4");
            }
            if (vip < 0 || vip > 2)
            {
                return Translation.GetLabel("[*]SetVip_Fail4");
            }
            if (PlayerManager.updateAccountVip(pR.player_id, vip))
            {
                try
                {
                    pR.pc_cafe = vip;
                    return Translation.GetLabel("SetVipS", vip, pR.player_name);
                }
                catch
                {
                    return Translation.GetLabel("SetVipF");
                }
            }
            else
            {
                return Translation.GetLabel("SetVipF");
            }
        }
    }
}