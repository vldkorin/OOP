using lab2.GameAccounts;
using System;


namespace Lab1
{
    class Program
    {
        static void Main()
        {
            GameAccount player1 = new WinStreakGameAccount("Max", 1000);
            GameAccount player2 = new ReducedPenaltyGameAccount("Mykola", 1600);
            GameAccount player3 = new StandardGameAccount("Lily", 700);
            GameAccount player4 = new StandardGameAccount("Yura", 900);
            StartGame("Standard", player1, player2, 50);
            StartGame("Train", player3, player4, 50);
            StartGame("Train", player2, player3, 60);
            StartGame("Standard", player2, player4, 120);
            StartGame("DoublePoints", player3, player1, 120);
            StartGame("Standard", player1, player3, 50);
            StartGame("Standard", player1, player4, 50);
            StartGame("Standard", player1, player2, 50);
            player1.GetStats();
            Console.WriteLine();
            player2.GetStats();
            Console.WriteLine();
            player3.GetStats();
            Console.WriteLine();
            player4.GetStats();
            Console.WriteLine();
            
        }
        static void StartGame(string typeGame, GameAccount player1, GameAccount player2, int rate)
        {
            var gameWin = GameFactory.CreateGame(typeGame, player2, rate);
            player1.WinGame(gameWin);
            Game.gameIdCounter--;
            var gameLose = GameFactory.CreateGame(typeGame, player1, rate);
            player2.LoseGame(gameLose);
        }
    }
}
