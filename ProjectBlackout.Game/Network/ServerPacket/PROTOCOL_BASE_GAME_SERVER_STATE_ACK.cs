using ProjectBlackout.Core.Network;
using System;
using System.Text;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_GAME_SERVER_STATE_ACK : SendPacket
    {
        public int server_state;

        public PROTOCOL_BASE_GAME_SERVER_STATE_ACK(int server_state)
        {
            Console.WriteLine("Opcode 608 >> PROTOCOL_BASE_GAME_SERVER_STATE_ACK >> " + server_state);
        }

        public override void write()
        {
            writeH(608);
            writeD(server_state);
        }
    }
}