using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Command.Commands;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Data.Command
{
    public class CommandManager
    {
        public static Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
        public static Dictionary<string, string> _usage = new Dictionary<string, string>();

        public static void Load()
        {
            RegisterCommand("commands", new CommandsCommand(), ":commands %index% - Get list of command");
            RegisterCommand("gift", new GiftCommand(), ":gift %userId% %type% %value% - Send something to user");
            RegisterCommand("update", new UpdateCommand(), ":update %what% - Update part of the emulator"); 
            RegisterCommand("test", new TestCommand(), ":test %count% - Update test bytes"); 
        }

        private static void RegisterCommand(string Command, ICommand CommandClass, string Usage)
        {
            _commands.Add(Command, CommandClass);
            _usage.Add(Command, Usage);
        }

        public static bool ParseCommand(string Text, GameClient Client, Account Account)
        {
            try
            {
                if (!Text.StartsWith(":"))
                {
                    return false; // That's not a command
                }

                // Let's remove :
                string _command = Text.Substring(1, Text.Length - 1);
                string[] _params = new string[1] 
                {
                    _command
                };

                // Is a command with params? Let's check!
                if (_command.Contains(" "))
                {
                    _params = _command.Split(' ');
                    _command = _params[0];
                }

                // Let's create his own handler
                if(_command.Contains(_command))
                {
                    string _permission = _commands[_command].GetType().Name.ToLower();
                    if(Account.HavePermission(_permission))
                    {
                        Client.SendPacket(new PROTOCOL_LOBBY_CHATTING_ACK("Server", 0, 4, false, _commands[_command].Execute(_params, Client, Account)));
                        return true;
                    }

                    return false; // That's a command, but don't have permission
                }
            }
            catch(Exception e)
            {
                Logger.error("Command '" + Text + "', Error: " + e.ToString());
                return false; // That's not a command probably
            }

            return false;            
        }
    }
}
