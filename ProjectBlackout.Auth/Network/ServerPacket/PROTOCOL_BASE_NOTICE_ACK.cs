using ProjectBlackout.Core.Managers.Server;
using ProjectBlackout.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_NOTICE_ACK : SendPacket
    {
        public PROTOCOL_BASE_NOTICE_ACK()
        {

        }

        public override void write()
        {
            ServerConfig Config = AuthManager.Config;
            writeH(663);
            writeH(0);
            writeD(Config.ChatColor);
            writeD(Config.AnnouceColor);
            writeH((ushort)Config.Chat.Length);
            writeText(Config.Chat, Config.Chat.Length);
            writeH((ushort)Config.Annouce.Length);
            writeText(Config.Annouce, Config.Annouce.Length);
        }
    }
}
