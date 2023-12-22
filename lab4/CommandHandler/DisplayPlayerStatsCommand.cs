using lab4.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.CommandHandler
{
    public class DisplayPlayerStatsCommand : IGameCommandHandler
    {
        private readonly IGameAccountService gameAccountService;

        public DisplayPlayerStatsCommand(IGameAccountService gameAccountService)
        {
            this.gameAccountService = gameAccountService;
        }

        public void ExecuteCommand()
        {
            Console.WriteLine("Input player id:");
            int playerId = Convert.ToInt32(Console.ReadLine());

            gameAccountService.GetStats(playerId);
        }

        public string ShowInfo()
        {
            return "Display player stats";
        }
    }
}
