using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System;
using ProjectBlackout.Core.Models.Enums;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class RefillManager2
    {
        public static string SetAcessPlayer(string str)
        {           
            string txt = str.Substring(str.IndexOf(" ") + 1);
            string[] split = txt.Split(' ');
            long player_id = Convert.ToInt64(split[0]);
            int access = Convert.ToInt32(split[1]);

            Account pR = AccountManager.getAccount(player_id, 0);
            if (pR == null)
            {
                return Translation.GetLabel("[*]SetAcess_Fail4");
            }
            if (access < 0 || access > 6)
            {
                return Translation.GetLabel("[*]SetAcess_Fail4");
            }
            if (PlayerManager.updateAccountAccess(pR.player_id, access))
            {
                try
                {
                    pR.access = (int) (AccessLevel)access;
                    return Translation.GetLabel("SetAcessS", access, pR.player_name);
                }
                catch
                {
                    return Translation.GetLabel("SetAcessF");
                }
            }
            else
            {
                return Translation.GetLabel("SetAcessF");
            }
        }        
    }
}