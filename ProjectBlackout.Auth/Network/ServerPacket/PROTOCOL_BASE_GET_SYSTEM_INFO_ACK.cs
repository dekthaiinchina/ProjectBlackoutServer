using ProjectBlackout.Auth.Data.Configs;
using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Auth.Data.Xml;
using ProjectBlackout.Battle;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Managers.Server;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Models.Servers;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_GET_SYSTEM_INFO_ACK : SendPacket
    {
        public PROTOCOL_BASE_GET_SYSTEM_INFO_ACK()
        {

        }
        public override void write()
        {
            Console.WriteLine("523");

            // Define the nation codes
            int[] STR_SELECTNATION_NATION = new int[4]
            {
                0,   // Global
                172, // Philippines
                210, // Thailand
                233  // Vietnam
            };

            // Begin writing the packet
            writeH(523); // Packet ID
            writeH(0);
            writeB(new byte[373]); // Reduced from 461 to 373
            for (int i = 0; i < 31; i++) // Added 88 bytes back
            {
                writeC(5); // Adjust values as necessary (e.g., 1-5 range).
            }
            writeC(0);   // Unknown
            writeC(5);   // Unknown
            writeC(10);  // Unknown
            writeC(32);  // Unknown
            writeC(4);   // Unknown
            writeC(0);   // Unknown
            //writeC(1);   // Unknown
            writeC((byte)AuthConfig.STR_LOBBY_BACKGROUNG);
            writeC(5);   // Unknown
            writeC(3);   // Unknown
            writeC(6);   // Unknown
            writeC(7);
            writeB(new byte[286]);

            short Mask1 = 0;
            if (AuthManager.Config.ClanEnable) Mask1 += 4096;

            writeH(Mask1); // playtime 256, clan 4096
            //writeH(0); // gift 256, tags 1024

            writeC(3); // Count Event Play Time
            writeD(600); // 600
            writeD(2400); // 2400
            writeD(6000); // 6000

            // Missions
            ServerConfig cfg = AuthManager.Config;
            writeC(cfg.missions);
            writeH((ushort)MissionsXml._missionPage1);
            writeH((ushort)MissionsXml._missionPage2);
            writeH(29890); // Unclear value, needs confirmation
            writeC((byte)ServersXml._servers.Count);

            for (int i = 0; i < ServersXml._servers.Count; i++)
            {
                GameServerModel server = ServersXml._servers[i];
                writeD(server._state);
                writeIP(server.Connection.Address);
                writeIP(server.Connection.Address);
                writeH(server._port);
                writeC((byte)server._type);
                writeH((ushort)server._maxPlayers);
                writeD(server._LastCount);


                if (i == 0)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        writeC(1);
                    }
                }
                else
                {
                    for (int Id = 0; Id < ChannelsXml.getChannels(i).Count; Id++)
                    {
                        Channel channel = ChannelsXml._channels[Id];
                        writeC((byte)channel._type);
                    }
                }

                writeD(3);
            }

            writeC(1);
            writeH((ushort)STR_SELECTNATION_NATION[0]); // Selected nation ID (0 for Global)

            // Exit URL
            writeH((ushort)AuthManager.Config.ExitURL.Length);
            writeS(AuthManager.Config.ExitURL, AuthManager.Config.ExitURL.Length);

            // Award items
            writeC(51);
            for (int Id = 0; Id < 51; Id++)
            {
                List<ItemsModel> Items = RankXml.getAwards(Id);
                writeC((byte)(Id));
                for (int Idx = 0; Idx < Items.Count; Idx++)
                {
                    ItemsModel Item = Items[Idx];
                    if (ShopManager.getItemId(Item._id) == null)
                    {
                        writeD(0);
                    }
                    else
                    {
                        writeD(ShopManager.getItemId(Item._id).id);
                    }
                }
                for (int i = Items.Count; (4 - i) > 0; i++)
                {
                    writeD(0);
                }
            }
        }
    }
}
// Fixed by DavaJ
/*public override void write()
{
    ServerConfig cfg = AuthManager.Config;
    writeH(523);
    writeB(new byte[6]);
    writeQ(16);
    writeD(0);
    writeB(new byte[53]);
    writeH(5);
    writeH(120);
    writeD(33555458);
    writeD(13107459);
    writeH(0);
    writeD(50);
    writeD(50);
    writeD(17033217);
    writeD(153699);
    writeD(256);
    writeB(new byte[371]);
    writeB(new byte[24]
    {
        0x04, 0x05, 0x04, 0xAC,
        0x0D, 0x00, 0x00, 0xAA,
        0x05, 0x00, 0x00, 0x31,
        0x00, 0x00, 0x00, 0x01,
        0x00, 0x00, 0x00, 0x01,
        0x07, 0x01, 0x23, 0x21
    });
    writeB(new byte[54]);
    writeH(2565);
    writeB(new byte[229]);
    writeC(3);
    writeD(600);
    writeD(2400);
    writeD(6000);

    writeC(1);
    writeB(new byte[2] { 0xE2, 0x1F });
    writeH(0);

    writeH(29890);
    writeC((byte)ServersXml._servers.Count);
    foreach (GameServerModel server in ServersXml._servers)
    {
        writeD(server._state);
        writeIP(server.Connection.Address);
        writeIP(server.Connection.Address);
        writeH(server._port);
        writeC((byte)server._type);
        writeH((ushort)server._maxPlayers);
        writeD(server._LastCount);

        foreach (Channel channel in ChannelsXml._channels)
        {
            writeC((byte)ChannelsXml._channels.Count);
        }

        writeC(0xE);
        writeD(server._type);
    }
    writeC(1);
    writeH(0);

    writeH((ushort)AuthManager.Config.ExitURL.Length);
    writeS(AuthManager.Config.ExitURL, AuthManager.Config.ExitURL.Length);

    writeC(51);
    for (int index = 0; index < 52; index++)
    {
        writeC((byte)index);
        List<ItemsModel> Items = RankXml.getAwards(index);

        for (int Idx = 0; Idx < Items.Count; Idx++)
        {
            ItemsModel Item = Items[Idx];
            writeD(ShopManager.getItemId(Item._id) == null ? 0 : ShopManager.getItemId(Item._id).id);
            for (int i = Items.Count; (4 - i) > 0; i++)
                writeD(0);
        }
        writeC(1);
    }
}
}
}*/