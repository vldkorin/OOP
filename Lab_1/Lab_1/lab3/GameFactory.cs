using lab2.GameTypes;
using Lab_1.lab2;
namespace Lab1
{
    public class GameFactory
    {
        public static Game CreateGame(string type, GameAccount firtOpponent,GameAccount secondOpponent, int rating)
        {
            if (type == "Train")
            {
                return new TrainGame(firtOpponent.UserName,secondOpponent.UserName, rating);
            }
            if (type == "DoublePoints")
            {
                return new DoublePointsGame(firtOpponent.UserName, secondOpponent.UserName, rating);
            }
            if (type == "Standard") {
                return new StandardGame(firtOpponent.UserName, secondOpponent.UserName, rating);
            }
            else
            {
                return null;
            }
        }

    }

}
