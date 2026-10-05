using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_ROOM_GET_LOBBY_USER_LIST_ACK : SendPacket
    {
        private List<Account> players;
        private List<int> playersIdxs;

        public PROTOCOL_ROOM_GET_LOBBY_USER_LIST_ACK(Channel ch)
        {
            players = ch.getWaitPlayers();
            playersIdxs = GetRandomIndexes(players.Count, players.Count >= 8 ? 8 : players.Count);
        }

        private List<int> GetRandomIndexes(int total, int count)
        {
            if (total == 0 || count == 0)
            {
                return new List<int>();
            }
            Random rnd = new Random();
            List<int> numeros = new List<int>();
            for (int i = 0; i < total; i++)
            {
                numeros.Add(i);
            }
            for (int i = 0; i < numeros.Count; i++)
            {
                int a = rnd.Next(numeros.Count);
                int temp = numeros[i];
                numeros[i] = numeros[a];
                numeros[a] = temp;
            }
            return numeros.GetRange(0, count);
        }

        public override void write()
        {
            writeH(3930);
            writeD(playersIdxs.Count);
            for (int i = 0; i < playersIdxs.Count; i++)
            {
                Account p = players[playersIdxs[i]];
                writeD(p.getSessionId());
                writeD(p.getRank());
                writeC((byte)(p.player_name.Length + 1));
                writeUnicode(p.player_name, true);
                writeC((byte)p.name_color);
            }
        }
    }
}