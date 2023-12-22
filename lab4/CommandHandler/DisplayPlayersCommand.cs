using lab4.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.CommandHandler
{
    public class DisplayPlayersCommand : IGameCommandHandler
    {
        private readonly IGameAccountService gameAccountService;

        public DisplayPlayersCommand(IGameAccountService gameAccountService)
        {
            this.gameAccountService = gameAccountService;
        }

        public void ExecuteCommand()
        {
            Console.WriteLine("All Players:");
            foreach (var player in gameAccountService.ReadAllGameAccounts())
            {
                Console.WriteLine($"{player.UserName} - {player.CurrentRating}");
            }
        }

        public string ShowInfo()
        {
            return "Display all player";
        }
    }
}
