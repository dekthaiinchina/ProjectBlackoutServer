using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Sync.Server;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class SendCashToPlayer
    {
        public static string SendByNick(string str)
        {
            Account pR = AccountManager.getAccount(str.Substring(3), 1, 0);
            return BaseGiveCash(pR);
        }

        public static string SendById(string str)
        {
            Account pR = AccountManager.getAccount(long.Parse(str.Substring(4)), 0);
            return BaseGiveCash(pR);
        }

        private static string BaseGiveCash(Account pR)
        {
            if (pR == null)
            {
                return Translation.GetLabel("GiveCashFail");
            }
            if (PlayerManager.updateAccountCash(pR.player_id, pR._money + 3000))
            {
                pR._money += 3000;
                pR.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, pR._gp, pR._money), false);
                SendItemInfo.LoadGoldCash(pR);
                return Translation.GetLabel("GiveCashSuccess", pR.player_name);
            }
            else
            {
                return Translation.GetLabel("GiveCashFail2");
            }
        }
    }
}