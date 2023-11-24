using lab2.GameAccounts;
using System;
using Lab_1.lab2;

namespace Lab1
{
    class Program
    {
        static void Main()
        {
            DbContext dbContext = new DbContext();
            IGameRepository gameRepository = new GameRepository(dbContext);
            IGameAccountRepository gameAccountRepository = new GameAccountRepository(dbContext);

            IGameService gameService = new GameService(gameRepository, new GameAccountService(gameAccountRepository));
            IGameAccountService gameAccountService = new GameAccountService(gameAccountRepository);

            gameAccountService.CreateGameAccount("Player1", 1500, "standard");
            gameAccountService.CreateGameAccount("Player2", 1600, "winstreak");
            gameAccountService.CreateGameAccount("Player3", 1400, "reducedpenalty");

            Console.WriteLine("All Players:");
            foreach (var player in gameAccountService.ReadAllGameAccounts())
            {
                Console.WriteLine($"{player.UserName} - {player.CurrentRating}");
            }

            GameAccount player1 = gameAccountService.ReadGameAccountById(1);
            GameAccount player2 = gameAccountService.ReadGameAccountById(2);
            GameAccount player3 = gameAccountService.ReadGameAccountById(3);

            gameService.StartGame("Standard", player1, player2, 50);
            gameService.StartGame("Standard", player2, player1, 50);
            gameService.StartGame("DoublePoints", player1, player3, 40);
            gameService.StartGame("Standard", player2, player1, 50);
            gameService.StartGame("Standard", player2, player1, 50);
            gameService.StartGame("Train", player2, player1, 50);

            Console.WriteLine("\nPlayer1 Stats:");
            gameAccountService.GetStats(1);

            Console.WriteLine("\nPlayer2 Stats:");
            gameAccountService.GetStats(2);

            Console.WriteLine("\nPlayer3 Stats:");
            gameAccountService.GetStats(3);

            Console.WriteLine("\nAll games info:");
            gameService.PrintAllGame();
            Console.ReadLine();

        }
        
    }
}
