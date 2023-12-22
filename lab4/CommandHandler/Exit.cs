using lab4.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.CommandHandler
{
    public class Exit : IGameCommandHandler
    {
        public void ExecuteCommand()
        {
            Console.WriteLine("Close program");

        }

        public string ShowInfo()
        {
            return "Exit";
        }
    }
}
