using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Command
{
    public interface ICommand
    {
        public string Execute(string[] Params, GameClient Client, Account Account);
    }
}
