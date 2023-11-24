using Lab1;
using Lab_1.lab2;

namespace lab2.GameTypes
{
    public class TrainGame : Game
    {
        public TrainGame(string firstOpponentName, string secondOpponentName, int rating) : base(firstOpponentName, secondOpponentName, rating) { }

        public override int CalculatePoints()
        {
            Rating = 0;
            return 0;
        }
    }
}
