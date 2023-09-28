using Lab1;
using System;
using System.Collections.Generic;

class GameAccount
{
    public string UserName { get; set; }
    private int currentRating;
    public int CurrentRating
    {
        get { return currentRating; }
        private set
        {
            if (value < 1)
            {
                currentRating = 1;
            }
            else
            {
                currentRating = value;
            }
        }
    }
    public int GamesCount { get { return gameHistory.Count; } }

    private List<Game> gameHistory;

    public GameAccount(string userName, int initialRating)
    {
        UserName = userName;
        CurrentRating = initialRating;

        gameHistory = new List<Game>();
    }

    public void WinGame(string opponentName, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Rating cannot be negative.");
        }


        CurrentRating += rating;
        gameHistory.Add(new Game(opponentName, rating));
    }

    public void LoseGame(string opponentName, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Rating cannot be negative.");
        }


        CurrentRating -= rating;

        gameHistory.Add(new Game(opponentName, -rating));
    }

    public void GetStats()
    {
        Console.WriteLine($"↓ Game history for {UserName} ↓");
        Console.WriteLine("┌────────────┬────────┬───────────────┬────────────┐");
        Console.WriteLine("│  Opponent  │ Result │ Rating change │ Game index │");
        Console.WriteLine("├────────────┼────────┼───────────────┼────────────┤");
        for (int i = 0; i < gameHistory.Count; i++)
        {
            string outcome = gameHistory[i].Rating > 0 ? "Win" : "Lose";
            int ratingChange = Math.Abs(gameHistory[i].Rating);
            Console.WriteLine($"│ {gameHistory[i].OpponentName,-10} │ {outcome,-6} │ {ratingChange,-14}│{gameHistory[i].GameId,-11} │");
        }
        Console.WriteLine("└────────────┴────────┴───────────────┴────────────┘");
        Console.WriteLine($"Total games played: {GamesCount}");
        Console.WriteLine($"Current Rating: {CurrentRating}");
    }
}