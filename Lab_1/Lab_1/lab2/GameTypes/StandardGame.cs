using Lab1;


namespace lab2.GameTypes
{
    public class StandardGame : Game
    {
        public StandardGame(string opponentName, int rating) : base(opponentName, rating) { }

        public override int CalculatePoints()
        {
            return Rating;
        }
    }
}
