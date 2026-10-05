using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class SearchSessionClient
    {
        public static string genCode1(string str)
        {
            uint sessionId = uint.Parse(str.Substring(13));
            Account player = GameManager.SearchActiveClient(sessionId);
            if (player != null)
            {
                return "";
            }
            else
            {
                return "";
            }
        }
    }
}