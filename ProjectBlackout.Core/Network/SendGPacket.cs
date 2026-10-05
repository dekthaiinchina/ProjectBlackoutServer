using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ProjectBlackout.Core.Network
{
    public class SendGPacket : IDisposable
    {
        public MemoryStream mstream = new MemoryStream();
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            mstream.Dispose();
            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }

        public SendGPacket()
        {

        }

        public SendGPacket(long length)
        {
            mstream.SetLength(length);
        }

        public void writeB(byte[] value)
        {
            mstream.Write(value, 0, value.Length);
        }

        public void writeB(byte[] value, int offset, int length)
        {
            mstream.Write(value, offset, length);
        }

        public void writeD(int value)
        {
            writeB(BitConverter.GetBytes(value));
        }

        public void writeD(uint value)
        {
            writeB(BitConverter.GetBytes(value));
        }

        public void writeH(short value)
        {
            writeB(BitConverter.GetBytes(value));
        }

        public void writeH(ushort value)
        {
            writeB(BitConverter.GetBytes(value));
        }

        public void writeH(int offset, ushort value)
        {
            mstream.Position = offset;
            writeB(BitConverter.GetBytes(value));
        }

        public void writeC(byte value)
        {
            mstream.WriteByte(value);
        }

        public void writeC(int offset, byte value)
        {
            mstream.Position = offset;
            mstream.WriteByte(value);
        }

        public void writeC(bool value)
        {
            mstream.WriteByte(Convert.ToByte(value));
        }

        public void writeF(double value)
        {
            writeB(BitConverter.GetBytes(value));
        }

        public void writeQ(long value)
        {
            writeB(BitConverter.GetBytes(value));
        }

        public void writeQ(ulong value)
        {
            writeB(BitConverter.GetBytes(value));
        }

        public void writeS(string value)
        {
            if (value != null)
            {
                writeB(Encoding.Unicode.GetBytes(value));
            }
        }

        public void writeS(string name, int count)
        {
            if (name == null)
            {
                return;
            }
            writeB(Config.EncodeText.GetBytes(name));
            writeB(new byte[count - name.Length]);
        }

        public void writeS(string name, int count, int CodePage)
        {
            if (name == null)
            {
                return;
            }
            writeB(Encoding.GetEncoding(CodePage).GetBytes(name));
            writeB(new byte[count - name.Length]);
        }

        public void writeUnicode(string name, int count)
        {
            if (name == null)
            {
                return;
            }
            writeB(Encoding.Unicode.GetBytes(name));
            writeB(new byte[count - (name.Length * 2)]);
        }

        public void writeUnicode(string name, bool active)
        {
            if (name == null)
            {
                return;
            }
            writeB(Encoding.Unicode.GetBytes(name));
            if (active)
            {
                writeH(0);
            }
        }
    }
}