using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Sync.Server;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_CREATE_CLAN_REQ : ReceivePacket
    {
        private uint erro;
        private string clanName, clanInfo;

        public PROTOCOL_CS_CREATE_CLAN_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            readD();
            clanName = readUnicode(34);
            clanInfo = readUnicode(510);
            readD();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                Clan clan = new Clan
                {
                    _name = clanName,
                    _info = clanInfo,
                    _logo = 0,
                    owner_id = p.player_id,
                    creationDate = int.Parse(DateTime.Now.ToString("yyyyMMdd"))
                };
                if (p.clanId > 0 || PlayerManager.getRequestClanId(p.player_id) > 0)
                {
                    erro = 0x8000105C;
                }
                else if (0 > p._gp - GameConfig.minCreateGold || GameConfig.minCreateRank > p._rank)
                {
                    erro = 0x8000104A;
                }
                else if (ClanManager.isClanNameExist(clan._name))
                {
                    erro = 0x8000105A;
                    return;
                }
                else if (ClanManager._clans.Count > GameConfig.maxActiveClans)
                {
                    erro = 0x80001055;
                }
                else if (PlayerManager.CreateClan(out clan._id, clan._name, clan.owner_id, clan._info, clan.creationDate) && PlayerManager.updateAccountGold(p.player_id, p._gp - GameConfig.minCreateGold))
                {
                    clan.BestPlayers.SetDefault();
                    p.clanDate = clan.creationDate;
                    if (ComDiv.updateDB("players", "player_id", p.player_id, new string[] { "clanaccess", "clandate", "clan_id" }, 1, clan.creationDate, clan._id))
                    {
                        if (clan._id > 0)
                        {
                            p.clanId = clan._id;
                            p.clanAccess = 1;
                            ClanManager.AddClan(clan);
                            SendClanInfo.Load(clan, 0);
                            p._gp -= GameConfig.minCreateGold;
                        }
                        else
                        {
                            erro = 0x8000104B;
                        }
                    }
                    else
                    {
                        erro = 0x80001048;
                    }
                }
                else
                {
                    erro = 0x80001048;
                }
                _client.SendPacket(new PROTOCOL_CS_CREATE_CLAN_ACK(erro, clan, p));
            }
            catch (Exception ex)
            {
                Console.WriteLine("PROTOCOL_CS_CREATE_CLAN_REQ: " + ex.ToString());
            }
            /*
             * 80001055 - STBL_IDX_CLAN_MESSAGE_FAIL_CREATING_OVERFLOW
             * 8000105C - STBL_IDX_CLAN_MESSAGE_FAIL_CREATING_ALREADY
             * 8000105A - STBL_IDX_CLAN_MESSAGE_FAIL_CREATING_OVERLAPPING
             * 80001048 - STBL_IDX_CLAN_MESSAGE_FAIL_CREATING
             * Padrão: STBL_IDX_CLAN_MESSAGE_FAIL_CREATING_ADMIN
             */
        }
    }
}
        /*public override void read()
        {
            readD();
            clanName = readUnicode(34);
            clanInfo = readUnicode(510);
            readD();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                Clan clan = new Clan
                {
                    _name = clanName,
                    _info = clanInfo,
                    _logo = 0,
                    owner_id = p.player_id,
                    creationDate = int.Parse(DateTime.Now.AddYears(-10).ToString("yyyyMMdd"))
                };
                if (p.clanId > 0 || PlayerManager.getRequestClanId(p.player_id) > 0)
                {
                    erro = 0x8000105C;
                }
                else if (0 > p._gp - GameConfig.minCreateGold || GameConfig.minCreateRank > p._rank)
                {
                    erro = 0x8000104A;
                }
                else if (ClanManager.isClanNameExist(clan._name))
                {
                    erro = 0x8000105A;
                    return;
                }
                else if (ClanManager._clans.Count > GameConfig.maxActiveClans)
                {
                    erro = 0x80001055;
                }
                else if (PlayerManager.CreateClan(out clan._id, clan._name, clan.owner_id, clan._info, clan.creationDate) && PlayerManager.updateAccountGold(p.player_id, p._gp - GameConfig.minCreateGold))
                {
                    clan.BestPlayers.SetDefault();
                    p.clanDate = clan.creationDate;
                    if (ComDiv.updateDB("players", "player_id", p.player_id, new string[] { "clanaccess", "clandate", "clan_id" }, 1, clan.creationDate, clan._id))
                    {
                        if (clan._id > 0)
                        {
                            p.clanId = clan._id;
                            p.clanAccess = 1;
                            ClanManager.AddClan(clan);
                            SendClanInfo.Load(clan, 0);
                            p._gp -= GameConfig.minCreateGold;
                        }
                        else
                        {
                            erro = 0x8000104B;
                        }
                    }
                    else
                    {
                        erro = 0x80001048;
                    }
                }
                else
                {
                    erro = 0x80001048;
                }
                _client.SendPacket(new PROTOCOL_CS_CREATE_CLAN_ACK(erro, clan, p));
            }
            catch (Exception ex)
            {
                Logger.warning("PROTOCOL_CS_CREATE_CLAN_REQ: " + ex.ToString());
            }
            /*
             * 80001055 - STBL_IDX_CLAN_MESSAGE_FAIL_CREATING_OVERFLOW
             * 8000105C - STBL_IDX_CLAN_MESSAGE_FAIL_CREATING_ALREADY
             * 8000105A - STBL_IDX_CLAN_MESSAGE_FAIL_CREATING_OVERLAPPING
             * 80001048 - STBL_IDX_CLAN_MESSAGE_FAIL_CREATING
             * Padrão: STBL_IDX_CLAN_MESSAGE_FAIL_CREATING_ADMIN
             *
        }
    }
}*/