using ProjectBlackout.Core;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class NickHistory
    {
        public static string GetHistoryById(string str, Account player)
        {
            long playerId = long.Parse(str.Substring(7));
            List<NHistoryModel> hist = NickHistoryManager.getHistory(playerId, 1);
            string comandos = Translation.GetLabel("NickHistory1_Title");
            foreach (NHistoryModel h in hist)
            {
                comandos += "\n" + Translation.GetLabel("NickHistory1_Item", h.from_nick, h.to_nick, h.date, h.motive);
            }
            player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(comandos));
            return Translation.GetLabel("NickHistory1_Result", hist.Count);
        }

        public static string GetHistoryByNewNick(string str, Account player)
        {
            string new_nick = str.Substring(7);
            List<NHistoryModel> hist = NickHistoryManager.getHistory(new_nick, 0);
            string comandos = Translation.GetLabel("NickHistory2_Title");
            foreach (NHistoryModel h in hist)
            {
                comandos += "\n" + Translation.GetLabel("NickHistory2_Item", h.from_nick, h.to_nick, h.player_id, h.date, h.motive);
            }
            player.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(comandos));
            return Translation.GetLabel("NickHistory2_Result", hist.Count);
        }
    }
}