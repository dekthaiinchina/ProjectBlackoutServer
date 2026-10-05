using ProjectBlackout.Battle.Data.Configs;
using SharpDX;
using System;
using System.Text;

namespace ProjectBlackout.Battle.Network
{
    public class ReceivePacket
    {
        private byte[] _buffer;
        private int _offset;

        public ReceivePacket(byte[] buff)
        {
            _buffer = buff;
        }

        public ReceivePacket(int offset, byte[] buff)
        {
            _offset = offset;
            _buffer = buff;
        }

        protected internal byte[] getBuffer()
        {
            return _buffer;
        }

        protected internal int getOffset()
        {
            return _offset;
        }

        protected internal void setOffset(int offset)
        {
            _offset = offset;
        }

        protected internal void Advance(int bytes)
        {
            _offset += bytes;
            if (_offset > _buffer.Length)
            {
                Logger.warning("Advance crashed.");
                throw new Exception("Offset ultrapassou o valor do buffer.");
            }
        }

        protected internal int readD()
        {
            int num = BitConverter.ToInt32(_buffer, _offset);
            _offset += 4;
            return num;
        }

        protected internal uint readUD()
        {
            uint num = BitConverter.ToUInt32(_buffer, _offset);
            _offset += 4;
            return num;
        }

        protected internal Half3 readUHVector()
        {
            return new Half3(readUH(), readUH(), readUH());
        }

        protected internal Half3 readTVector()
        {
            return new Half3(readT(), readT(), readT());
        }

        protected internal byte readC(out bool exception)
        {
            try
            {
                byte num = _buffer[_offset++];
                exception = false;
                return num;
            }
            catch
            {
                exception = true;
                return 0;
            }
        }

        protected internal byte readC()
        {
            try
            {
                byte num = _buffer[_offset++];
                return num;
            }
            catch
            {
                return 0;
            }
        }

        protected internal byte[] readB(int Length)
        {
            try
            {
                byte[] result = new byte[Length];
                Array.Copy(_buffer, _offset, result, 0, Length);
                _offset += Length;
                return result;
            }
            catch
            {
                return new byte[0];
            }
        }

        protected internal short readH()
        {
            short num = BitConverter.ToInt16(_buffer, _offset);
            _offset += 2;
            return num;
        }

        protected internal ushort readUH()
        {
            ushort num = BitConverter.ToUInt16(_buffer, _offset);
            _offset += 2;
            return num;
        }

        protected internal float readT()
        {
            float num = BitConverter.ToSingle(_buffer, _offset);
            _offset += 4;
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

        protected internal string readS(int Length)
        {
            string str = "";
            try
            {
                str = BattleConfig.EncodeText.GetString(_buffer, _offset, Length);
                int length = str.IndexOf((char)0);
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
            string result = "";
            try
            {
                int count = (_buffer.Length - _offset);
                result = Encoding.Unicode.GetString(_buffer, _offset, count);
                int idx = result.IndexOf(char.MinValue);
                if (idx != -1)
                {
                    result = result.Substring(0, idx);
                }
                _offset += result.Length + 1;
            }
            catch
            {

            }
            return result;
        }
    }
}