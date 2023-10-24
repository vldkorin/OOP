using Lab1;


namespace lab2.GameTypes
{
    public class DoublePointsGame : Game
    {
        public DoublePointsGame(string opponentName, int rating) : base(opponentName, rating) { }

        public override int CalculatePoints()
        {
            Rating = Rating * 2;
            return Rating;
        }
    }
}
