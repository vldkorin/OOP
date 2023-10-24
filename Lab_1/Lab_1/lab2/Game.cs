

namespace Lab1
{
    public abstract class Game
    {
        public int GameId { get; set; }
        public string OpponentName { get; set; }
        public int Rating { get; set; }
        public bool Won { get; set; }

        public static int gameIdCounter = 0;

        public Game(string opponentName, int rating)
        {
            ++gameIdCounter;
            GameId = gameIdCounter;
            OpponentName = opponentName;
            Rating = rating;
        }

        public abstract int CalculatePoints();
    }

}
