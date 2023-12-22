using lab4.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.CommandHandler
{
    public class AddNewPlayerCommand : IGameCommandHandler
    {
        private readonly IGameAccountService gameAccountService;

        public AddNewPlayerCommand(IGameAccountService gameAccountService)
        {
            this.gameAccountService = gameAccountService;
        }

        public void ExecuteCommand()
        {
            Console.WriteLine("Input player name:");
            string playerName = Console.ReadLine();
            Console.WriteLine("Input player raiting:");
            int initialRating = Convert.ToInt32(Console.ReadLine());
            string accountType;
            do
            {
                Console.WriteLine("Input account type:Standard,WinStreak,ReducedPenalty:");
                accountType = Console.ReadLine();
            } while (accountType != "ReducedPenalty" && accountType != "Standard" && accountType != "WinStreak");

            gameAccountService.CreateGameAccount(playerName, initialRating, accountType);
        }

        public string ShowInfo()
        {
            return "Add new player";
        }
    }
}
