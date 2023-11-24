using System.Collections.Generic;

namespace Lab_1.lab2
{
    public interface IGameAccountRepository
    {
        void CreateGameAccount(GameAccount gameAccount);
        GameAccount ReadGameAccountById(int accountId);
        List<GameAccount> ReadAllGameAccounts();
        void UpdateGameAccount(int accountId,GameAccount gameAccount);
        void DeleteGameAccount(int accountId);
    }
}   