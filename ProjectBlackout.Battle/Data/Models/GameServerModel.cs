using System.Net;

namespace ProjectBlackout.Battle.Data.Models
{
    public class GameServerModel
    {
        public int _state, _id, _type, _lastCount, _maxPlayers;
        public string _ip;
        public ushort _port, _syncPort;
        public IPEndPoint Connection;

        public GameServerModel(string ip, ushort syncPort)
        {
            _ip = ip;
            _syncPort = syncPort;
            Connection = new IPEndPoint(IPAddress.Parse(ip), syncPort);
        }
    }
}