using ProjectBlackout.Auth.Data.Model;
using ProjectBlackout.Auth.Data.Xml;
using ProjectBlackout.Core.Models.Servers;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_GAME_SERVER_INFO_ACK : SendPacket
    {
        public Nations nations;
        public PROTOCOL_GAME_SERVER_INFO_ACK(Nations nations)
        {
            this.nations = nations;
        }
        public override void write()
        {
            writeH(2400);
            Console.WriteLine("Trying opcode >> 2400");
            writeC((byte)ServersXml._servers.Count);
            for (int i = 0; i < ServersXml._servers.Count; i++)
            {
                GameServerModel server = ServersXml._servers[i];
                writeD(server._state);
                writeIP(server.Connection.Address);
                writeH(server._port);
                writeH(server._port);
                writeH(server._port);

                writeC((byte)server._type);
                //writeD(0);
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
                writeD(0);
            }
            writeC(0);

        }
        public enum Nations
        {
            Global = 0,
            Philipines = 172,
            Thailand = 210,
            Vietna = 233
        }
    }
}
