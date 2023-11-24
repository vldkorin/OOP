using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class StandardGame : Game
    {
        public StandardGame(string opponentName, int rating) : base(opponentName, rating) { }

        public override int CalculatePoints()
        {
            return Rating;
        }
    }

    public class TrainGame : Game
    {
        public TrainGame(string opponentName, int rating) : base(opponentName, rating) { }

        public override int CalculatePoints()
        {
            Rating = 0;
            return 0;
        }
    }
    public class DoubleGame : Game
    {
        public DoubleGame(string opponentName, int rating) : base(opponentName, rating) { }

        public override int CalculatePoints()
        {
            Rating = Rating * 2;
            return Rating;
        }
    }

}
