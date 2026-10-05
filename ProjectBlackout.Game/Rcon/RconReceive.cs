using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Rcon
{
    public abstract class RconReceive
    {
        private string[] _parts;
        private int _offset = 2;
        /// <summary>
        /// Initialize the packet
        /// </summary>
        /// <param name="Parts"></param>
        public void Init(string[] Parts)
        {
            _parts = Parts;
        }

        public string PopString()
        {
            string Next = _parts[_offset];
            _offset++;
            return Next;
        }

        public int PopInt()
        {
            int Next = int.Parse(_parts[_offset]);
            _offset++;
            return Next;
        }

        public long PopLong()
        {
            long Next = long.Parse(_parts[_offset]);
            _offset++;
            return Next;
        }

        public abstract void Run();
    }
}
