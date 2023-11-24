using System.Collections.Generic;

namespace Lab_1.lab2
{
    public interface IGameRepository
    {
        void CreateGame(Game game);
        Game ReadGameById(int gameId);
        List<Game> ReadAllGames();

        void UpdateGame(int gameId,Game game);
        void DeleteGame(int gameId);
        void PrintAllGame();
    }
}