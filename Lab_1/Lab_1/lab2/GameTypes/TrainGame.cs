using Lab1;


namespace lab2.GameTypes
{
    public class TrainGame : Game
    {
        public TrainGame(string opponentName, int rating) : base(opponentName, rating) { }

        public override int CalculatePoints()
        {
            Rating = 0;
            return 0;
        }
    }
}
