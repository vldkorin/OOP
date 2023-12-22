using lab4.GameAccounts;
using lab4.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.CommandHandler
{
    public class PlayGameCommand : IGameCommandHandler
    {
        private readonly IGameService gameService;
        private readonly IGameAccountService gameAccountService;

        public PlayGameCommand(IGameService gameService, IGameAccountService gameAccountService)
        {
            this.gameService = gameService;
            this.gameAccountService = gameAccountService;
        }

        public void ExecuteCommand()
        {
            string gameType;
            do
            {
                Console.WriteLine("Input game type:Standard,Train,DoublePoints:");
                gameType = Console.ReadLine();
            } while (gameType != "Train" && gameType != "DoublePoints" && gameType != "Standard");
            Console.WriteLine("Input 1 player id:");
            int player1Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input 2 player id:");
            int player2Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input game raiting:");
            int rating = Convert.ToInt32(Console.ReadLine());
            GameAccount player1 = gameAccountService.ReadGameAccountById(player1Id);
            GameAccount player2 = gameAccountService.ReadGameAccountById(player2Id);
            gameService.StartGame(gameType, player1, player2, rating);
        }

        public string ShowInfo()
        {
            return "Play game";
        }
    }
}
