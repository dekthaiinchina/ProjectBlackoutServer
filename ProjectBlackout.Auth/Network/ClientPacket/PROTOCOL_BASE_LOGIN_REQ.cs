using ProjectBlackout.Auth.Data.Configs;
using ProjectBlackout.Auth.Data.Managers;
using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Auth.Data.Sync;
using ProjectBlackout.Auth.Data.Sync.Server;
using ProjectBlackout.Auth.Network.ServerPacket;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Managers.Server;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_LOGIN_REQ : ReceivePacket
    {
        private string _login, _token;
        private string GameVersion, PublicIP;
        private ClientLocale GameLocale;
        public PhysicalAddress MacAddress;

        string HexDump(byte[] data, int bytesPerLine = 16)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                result.Append($"{data[i]:X2} ");
                if ((i + 1) % bytesPerLine == 0)
                    result.AppendLine();
            }
            Logger.debug(result.ToString());
            return result.ToString().Trim();
        }

        public PROTOCOL_BASE_LOGIN_REQ(AuthClient client, byte[] data)
        {
            makeme(client, data);

            if (AuthConfig.debugMode)
                Logger.debug(HexDump(data));
        }

        public static string FormatMacAddress(PhysicalAddress macAddress)
        {
            byte[] bytes = macAddress.GetAddressBytes();
            StringBuilder formattedMac = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                formattedMac.Append(bytes[i].ToString("X2"));

                if (i < bytes.Length - 1)
                {
                    formattedMac.Append(":");
                }
            }
            return formattedMac.ToString();
        }
        public override void read()
        {
            readB(110);
            GameVersion = readC() + "." + readC();
            readB(3);
            _token = Encoding.ASCII.GetString(readB(readC()));
            _login = Encoding.ASCII.GetString(readB(readC()));

            PublicIP = _client.GetIPAddress();
            GameLocale = ClientLocale.Russia;
        }

        public override void run()
        {
            try
            {
                /*if (PublicIP == null || _token.Trim().Length == 0)
                {
                    _client.SendPacket(new PROTOCOL_BASE_LOGIN_ACK(EventErrorEnum.LOGIN_USER_PASS_FAIL, "", 0));
                    Logger.error("PublicIP or Token is null");
                    _client.Close(1000, true);
                }*/
                Logger.debug("IP: " + PublicIP);
                Logger.debug("Token: " + _token);

                ServerConfig cfg = AuthManager.Config;
                if (cfg == null || !AuthConfig.isTestMode && !AuthConfig.GameLocales.Contains(GameLocale) || _token.Length < AuthConfig.minTokenSize /*|| GameVersion != cfg.ClientVersion*/)
                {
                    string msg = "";
                    if (cfg == null)
                    {
                        msg = "Invalid server setting [" + _login + "]";
                    }
                    else if (!AuthConfig.isTestMode && !AuthConfig.GameLocales.Contains(GameLocale))
                    {
                        msg = GameLocale + " blocked [" + _login + "]";
                    }
                    else if (_token.Length < AuthConfig.minTokenSize)
                    {
                        msg = "[" + _login + "] Token < Size [" + _login + "]";
                    }
                    else if (GameVersion != cfg.ClientVersion)
                    {
                        msg = "Version: " + GameVersion + " not compatible [" + _login + "]";
                    }
                    _client.SendPacket(new PROTOCOL_SERVER_MESSAGE_DISCONNECTIONSUCCESS_ACK(2147483904, false));
                    _client.Close(1000, true);
                }
                else
                {
                    _client._player = AccountManager.getInstance().getAccountDB(_login, _token, 2, 0);
                    Account p = _client._player;

                    Logger.debug("Success");
                    p.SetPlayerId(p.player_id, 31);
                    p._clanPlayers = ClanManager.getClanPlayers(p.clan_id, p.player_id);
                    //_client.SendPacket(new PROTOCOL_BASE_LOGIN_ACK(EventErrorEnum.LOGIN_BLOCK_ACCOUNT, "", 0));
                    _client.SendPacket(new PROTOCOL_BASE_LOGIN_ACK(0, p.login, p.player_id));
                    _client.SendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(0, p._gp, p._money, p._tag));
                    if (p.clan_id > 0)
                    {
                        _client.SendPacket(new PROTOCOL_CS_MEMBER_INFO_ACK(p._clanPlayers));
                    }
                    p._status.SetData(4294967295, p.player_id);
                    p._status.updateServer(0);
                    p.setOnlineStatus(true);
                    SendRefresh.RefreshAccount(p, true);
                    ComDiv.updateDB("players", "ban_obj_id", 0, "player_id", p.player_id);

                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_BASE_LOGIN_REQ: " + ex.ToString());
            }
        }

        public bool CheckHwId(string PlayerHwId)
        {
            foreach (string HwId in BanManager.GetHwIdList())
            {
                if (PlayerHwId.Length != 0 || HwId.Length != 0 || HwId != null || HwId == "")
                {
                    if (PlayerHwId == HwId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}