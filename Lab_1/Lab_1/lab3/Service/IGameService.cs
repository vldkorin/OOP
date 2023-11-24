using System.Collections.Generic;

namespace Lab_1.lab2
{
    public interface IGameService
    {
        void StartGame(string typeGame, GameAccount player1, GameAccount player2, int rate);
        Game ReadGameById(int gameId);
        List<Game> ReadAllGames();
        void UpdateGame(int gameId,Game game);
        void DeleteGame(int gameId);
        void PrintAllGame();
    }
}