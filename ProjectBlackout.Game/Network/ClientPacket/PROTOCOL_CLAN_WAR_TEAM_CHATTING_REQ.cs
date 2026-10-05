using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_TEAM_CHATTING_REQ : ReceivePacket
    {
        private ChattingType type;
        private string text;

        public PROTOCOL_CLAN_WAR_TEAM_CHATTING_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            type = (ChattingType)readH();
            text = readS(readH());
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null || p._match == null || type != ChattingType.Match)
                {
                    return;
                }
                Match match = p._match;
                serverCommands(p, match);
                using (PROTOCOL_CLAN_WAR_TEAM_CHATTING_ACK packet = new PROTOCOL_CLAN_WAR_TEAM_CHATTING_ACK(p.player_name, text))
                {
                    match.SendPacketToPlayers(packet);
                }
            }
            catch (Exception ex)
            {
                Logger.info("PROTOCOL_CLAN_WAR_TEAM_CHATTING_REQ: " + ex.ToString());
            }
        }

        private bool serverCommands(Account player, Match match)
        {
            try
            {
                if (!player.HaveGMLevel() || !(text.StartsWith(";") || text.StartsWith(@"\") || text.StartsWith(".")))
                {
                    return false;
                }
                string str = text.Substring(1);
                if (str.StartsWith("o") && (int)player.access >= 3)
                {
                    if (match != null)
                    {
                        AccountManager.getAccountDB((long)2, 2);
                        for (int i = 0; i < match.formação; i++)
                        {
                            SlotMatch slot = match._slots[i];
                            if (slot._playerId == 0)
                            {
                                slot._playerId = 2;
                                slot.state = SlotMatchState.Normal;
                            }
                        }
                        using (PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK packet = new PROTOCOL_CLAN_WAR_REGIST_MERCENARY_ACK(match))
                        {
                            match.SendPacketToPlayers(packet);
                        }
                        text = "Disputa preenchida. [Server]";
                    }
                    else
                    {
                        text = "Falha ao encher a disputa. [Server]";
                    }
                }
                else if (str.StartsWith("gg"))
                {
                    match._state = MatchState.Play;
                    match._slots[player.matchSlot].state = SlotMatchState.Ready;
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_ENEMY_INFO_ACK(match));
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_CREATE_ROOM_ACK(match));
                }
                else
                {
                    text = "Falha ao encontrar o comando digitado. [Servidor]";
                }
                return true;
            }
            catch (OverflowException ex)
            {
                ex.ToString();
                return true;
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
                return true;
            }
        }
    }
}