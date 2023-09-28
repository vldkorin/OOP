namespace Lab1
{
    class Game
    {
        public int GameId { get; }
        public string OpponentName { get; }
        public int Rating { get; }

        private static int gameIdCounter = 0;

        public Game(string opponentName, int rating)
        {
            ++gameIdCounter;
            GameId = gameIdCounter;
            OpponentName = opponentName;
            Rating = rating;
        }
    }
}