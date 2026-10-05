using ProjectBlackout.Core;
using System;
using System.Text;

namespace ProjectBlackout.Auth.Network
{
    public abstract class ReceivePacket
    {
        private byte[] _buffer;
        private int _offset = 4;
        public AuthClient _client;

        protected internal void makeme(AuthClient client, byte[] buffer)
        {
            _client = client;
            _buffer = buffer;
            read();
        }

        protected internal int readD()
        {
            int num = BitConverter.ToInt32(_buffer, _offset);
            _offset += 4;
            return num;
        }

        protected internal byte readC()
        {
            byte num = _buffer[_offset];
            _offset++;
            return num;
        }

        protected internal byte[] readB(int Length)
        {
            byte[] result = new byte[Length];
            Array.Copy(_buffer, _offset, result, 0, Length);
            _offset += Length;
            return result;
        }

        protected internal short readH()
        {
            short num = BitConverter.ToInt16(_buffer, _offset);
            _offset += 2;
            return num;
        }

        protected internal double readF()
        {
            double num = BitConverter.ToDouble(_buffer, _offset);
            _offset += 8;
            return num;
        }

        protected internal long readQ()
        {
            long num = BitConverter.ToInt64(_buffer, _offset);
            _offset += 8;
            return num;
        }

        protected internal ulong readUQ()
        {
            ulong num = BitConverter.ToUInt64(_buffer, _offset);
            _offset += 8;
            return num;
        }

        protected internal string readS(int Length)
        {
            string str = "";
            try
            {
                str = Config.EncodeText.GetString(_buffer, _offset, Length);
                int length = str.IndexOf(char.MinValue);
                if (length != -1)
                {
                    str = str.Substring(0, length);
                }
                _offset += Length;
            }
            catch
            {

            }
            return str;
        }

        protected internal string readS(int Length, int CodePage)
        {
            string str = "";
            try
            {
                str = Encoding.GetEncoding(CodePage).GetString(_buffer, _offset, Length);
                int length = str.IndexOf(char.MinValue);
                if (length != -1)
                {
                    str = str.Substring(0, length);
                }
                _offset += Length;
            }
            catch
            {

            }
            return str;
        }

        protected internal string readS()
        {
            string str = "";
            try
            {
                str = Encoding.Unicode.GetString(_buffer, _offset, _buffer.Length - _offset);
                int length = str.IndexOf(char.MinValue);
                if (length != -1)
                {
                    str = str.Substring(0, length);
                }
                _offset += str.Length + 1;
            }
            catch
            {

            }
            return str;
        }

        protected internal string readUnicode(int Length)
        {
            string res = "";
            try
            {
                res = Encoding.Unicode.GetString(_buffer, _offset, Length);

                int idx = res.IndexOf((char)0x00);
                if (idx != -1)
                {
                    res = res.Substring(0, idx);
                }
                _offset += Length;
            }
            catch
            {
                
            }
            return res;
        }

        public abstract void read();
        public abstract void run();
    }
}