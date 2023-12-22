using lab4.DataBase;
using lab4.GameAccounts;
using lab4.GameTypes;
using lab4.Repository;
using lab4.Service;
using lab4.CommandHandler;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;

namespace lab4
{

    internal class Program
    {
        static void Main()
        {
            DbContext dbContext = new DbContext();
            IGameRepository gameRepository = new GameRepository(dbContext);
            IGameAccountRepository gameAccountRepository = new GameAccountRepository(dbContext);

            IGameService gameService = new GameService(gameRepository, new GameAccountService(gameAccountRepository));
            IGameAccountService gameAccountService = new GameAccountService(gameAccountRepository);
            List<IGameCommandHandler> Commands = new List<IGameCommandHandler>
            {
                new DisplayPlayersCommand(gameAccountService),
                new AddNewPlayerCommand(gameAccountService),
                new DisplayPlayerStatsCommand(gameAccountService),
                new PlayGameCommand(gameService, gameAccountService),
                new Exit()
            };


            bool Continue = true;
            while (Continue)
            {
                int choice = -1;
                do
                {
                    Console.WriteLine("Choose command\nAll commands:");
                    for (int i = 0; i < Commands.Count(); i++)
                    {
                        Console.WriteLine($"{i + 1}-Command {Commands[i].ShowInfo()}");
                    }
                   
                    choice = Convert.ToInt32(Console.ReadLine());
                } while (choice > Commands.Count() || choice < 0);
                if (choice != 5)
                {

                    Commands[choice - 1].ExecuteCommand();
                }
                else
                {
                    Continue = false;
                }

            }
        }
    }

}
