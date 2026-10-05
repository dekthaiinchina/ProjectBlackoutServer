using ProjectBlackout.Core.Network;
using ProjectBlackout.Core.Models.Enums;

namespace ProjectBlackout.Auth.Network.ServerPacket
{
    public class PROTOCOL_BASE_LOGIN_ACK : SendPacket
    {
        private uint _result;
        private string _login;
        private long _pId;

        public PROTOCOL_BASE_LOGIN_ACK(EventErrorEnum result, string login, long pId)
        {
            _result = (uint)result;
            _login = login;
            _pId = pId;
        }

        public PROTOCOL_BASE_LOGIN_ACK(uint result, string login, long pId)
        {
            _result = result;
            _login = login;
            _pId = pId;
        }

        public PROTOCOL_BASE_LOGIN_ACK(int result, string login, long pId)
        {
            _result = (uint)result;
            _login = login;
            _pId = pId;
        }

        public override void write()
        {
            writeH(259);
            writeB(new byte[14]);

            if (_result == 0)
            {
                writeH(30590);  //?
                writeD(81917926); ////81917926 แคลน  91917926
                writeB(new byte[16]);
                writeC(3);
                writeD(3158579);
                writeC((byte)_login.Length);
                writeS(_login, _login.Length);
                writeQ(_pId);
                writeB(new byte[6]);
            }
            else
            {
                writeC(0);
                writeS("", 0);
                writeC(0);
                writeC(0);
                writeS("", 0);
                writeQ(0);
            }

            writeD(_result);
        }
    }
}