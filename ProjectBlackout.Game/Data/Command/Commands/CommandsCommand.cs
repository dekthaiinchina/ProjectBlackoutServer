using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Data.Command.Commands
{
    class CommandsCommand : ICommand
    {
        public string Execute(string[] Params, GameClient Client, Account Account)
        {
            // Calcolo la index
            int Index = 0;

            if (Params.Length >= 2)
            {
                try
                {
                    // Provo a convertirlo in numero
                    Index = int.Parse(Params[1]) - 1;
                }
                catch
                {
                    Index = 0;
                }
            }

            // Calcolo i comandi e li aggiungo (massimo 4)
            int _subIndex = 0;
            int _subCount = 0;

            string Result = "Commands (page " + (Index + 1) + "):\n";
            foreach (string Entry in UsageCommands(Account))
            {
                _subCount++;

                int _remain = _subCount % 4;
                if (_subIndex == Index)
                {
                    // Questo comando è della pagina chiesta
                    Result += Entry + "\n";
                }

                // Sono arrivato a 4 elementi per pagina
                if (_remain == 0)
                {
                    // Resetto il conteggio, e aumento la pagina
                    _subCount = 0;
                    _subIndex++;
                }
            }

            // Mostro la lista
            Client.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(Result));

            // Scrivo che l'ho mostrato
            return "Displayed page " + (Index + 1).ToString() + " of " + (CommandManager._usage.Count <= 4 ? "1" : GetCount(UsageCommands(Account)));
        }

        private string GetCount(List<string> Commands)
        {
            return Math.Ceiling(
                   (decimal)((decimal) Commands.Count / (decimal)4)
                ).ToString();
        }

        private List<string> UsageCommands(Account Account)
        {
            List<string> UserCommands = new List<string>();
            foreach (KeyValuePair<string, string> entry in CommandManager._usage)
            {
                string permission = (entry.Key + "Command").ToLower();
                if (Account.HavePermission(permission))
                    UserCommands.Add(entry.Value);
            }
            return UserCommands;
        }
    }
}
