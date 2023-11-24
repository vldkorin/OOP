using System.Collections.Generic;

namespace Lab_1.lab2
{
    public interface IGameAccountService
    {
        void CreateGameAccount(string userName, int initialRating, string type);
        GameAccount ReadGameAccountById(int accountId);
        List<GameAccount> ReadAllGameAccounts();
        void UpdateGameAccount(int accountId,GameAccount gameAccount);
        void DeleteGameAccount(int accountId);
        void WinGame(int accountId, Game game);
        void LoseGame(int accountId, Game game);
        void GetStats(int accountId);
    }
}