using ProjectBlackout.Core;
using ProjectBlackout.Game;
using ProjectBlackout.Game.Data.Configs;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class ChangeServerMode
    {
        public static string EnableTestMode()
        {
            if (GameConfig.isTestMode)
            {
                return Translation.GetLabel("AlreadyTestModeOn");
            }
            else
            {
                GameConfig.isTestMode = true;
                return Translation.GetLabel("TestModeOn");
            }
        }

        public static string EnablePublicMode()
        {
            if (!GameConfig.isTestMode)
            {
                return Translation.GetLabel("AlreadyTestModeOff");
            }
            else
            {
                GameConfig.isTestMode = false;
                return Translation.GetLabel("TestModeOff");
            }
        }
    }
}