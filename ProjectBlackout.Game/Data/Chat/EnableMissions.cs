using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers.Server;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class EnableMissions
    {
        public static string genCode1(string str, Account player)
        {
            bool activate = bool.Parse(str.Substring(8));
            bool result = ServerConfigSyncer.updateMission(GameManager.Config, activate);
            if (result)
            {
                Logger.warning(Translation.GetLabel("ActivateMissionsWarn", activate, player.player_name));
                return Translation.GetLabel("ActivateMissionsMsg1");
            }
            else
            {
                return Translation.GetLabel("ActivateMissionsMsg2");
            }
        }
    }
}