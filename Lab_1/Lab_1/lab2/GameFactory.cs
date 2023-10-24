using lab2.GameTypes;

namespace Lab1
{
    public class GameFactory
    {
        public static Game CreateGame(string type, GameAccount opponent, int rating)
        {
            if (type == "Train")
            {
                return new TrainGame(opponent.UserName, rating);
            }
            if (type == "DoublePoints")
            {
                return new DoublePointsGame(opponent.UserName, rating);
            }
            if (type == "Standard") {
                return new StandardGame(opponent.UserName, rating);
            }
            else
            {
                return null;
            }
        }

    }

}
