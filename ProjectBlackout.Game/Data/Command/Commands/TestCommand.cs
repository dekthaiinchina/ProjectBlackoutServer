using Microsoft.Win32;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBlackout.Game.Data.Command.Commands
{
    class TestCommand : ICommand
    {
        public string Execute(string[] Params, GameClient Client, Account Account)
        {
            if (Params.Length != 2)
                return "Wrong usate. Type :commands to check the correct usage";

            int Count;
            if (!int.TryParse(Params[1], out Count))
                return "Count must be a int input!";

            Account.testBytes = Count;

            return "Test bytes count: " + Count.ToString();
        }
    }
}
