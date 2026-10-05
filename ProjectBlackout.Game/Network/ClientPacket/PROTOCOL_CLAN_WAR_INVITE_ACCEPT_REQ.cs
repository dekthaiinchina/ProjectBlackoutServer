using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_INVITE_ACCEPT_REQ : ReceivePacket
    {
        private int id, serverInfo, type;
        private uint erro;

        public PROTOCOL_CLAN_WAR_INVITE_ACCEPT_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            readD();
            id = readH();
            serverInfo = readH();
            type = readC();
        }

        public override void run()
        {
            try
            {
                Account player = _client._player;
                if (player == null)
                {
                    return;
                }
                Match mt = player._match;
                int channelId = serverInfo - ((serverInfo / 10) * 10);
                Match mt2 = ChannelsXml.getChannel(channelId).getMatch(id);
                if (mt != null && mt2 != null && player.matchSlot == mt._leader)
                {
                    if (type == 1)
                    {
                        if (mt.formação != mt2.formação)
                        {
                            erro = 2147487890;
                        }
                        else if (mt2.getCountPlayers() != mt.formação || mt.getCountPlayers() != mt.formação)
                        {
                            erro = 2147487889;
                        }
                        else if (mt2._state == MatchState.Play || mt._state == MatchState.Play)
                        {
                            erro = 2147487888;
                        }
                        else
                        {
                            mt._state = MatchState.Play;
                            Account pM = mt2.getLeader();
                            if (pM != null && pM._match != null)
                            {
                                pM.SendPacket(new PROTOCOL_CLAN_WAR_ENEMY_INFO_ACK(mt));
                                pM.SendPacket(new PROTOCOL_CLAN_WAR_CREATE_ROOM_ACK(mt));
                                mt2._slots[pM.matchSlot].state = SlotMatchState.Ready;
                            }
                            mt2._state = MatchState.Play;
                        }
                    }
                    else
                    {
                        Account pM = mt2.getLeader();
                        if (pM != null && pM._match != null)
                        {
                            pM.SendPacket(new PROTOCOL_CLAN_WAR_INVITE_ACCEPT_ACK(0x80001093));
                        }
                    }
                }
                else
                {
                    erro = 0x80001094;
                }
                _client.SendPacket(new PROTOCOL_CLAN_WAR_ACCEPT_BATTLE_ACK(erro));
            }
            catch (Exception ex)
            {
                Logger.info("CLAN_WAR_ACCEPT_BATTLE_REC: " + ex.ToString());
            }
        }
    }
}