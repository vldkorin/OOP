﻿using Lab1;
using System;
using System.Collections.Generic;

public abstract class GameAccount
{
    public string UserName { get; set; }
    protected int currentRating;
    public int CurrentRating
    {
        get { return currentRating; }
        protected set
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

    protected List<Game> gameHistory;

    public GameAccount(string userName, int initialRating)
    {
        UserName = userName;
        CurrentRating = initialRating;

        gameHistory = new List<Game>();
    }

    public abstract void WinGame(Game game);

    public abstract void LoseGame(Game game);

    public void GetStats()
    {
        Console.WriteLine($"↓ Game history for {UserName} ↓");
        Console.WriteLine("┌────────────┬────────┬───────────────┬────────────┐");
        Console.WriteLine("│  Opponent  │ Result │ Rating change │ Game index │");
        Console.WriteLine("├────────────┼────────┼───────────────┼────────────┤");
        for (int i = 0; i < gameHistory.Count; i++)
        {
            string outcome = gameHistory[i].Won ? "Win" : "Lose";
            int ratingChange = Math.Abs(gameHistory[i].Rating);
            Console.WriteLine($"│ {gameHistory[i].OpponentName,-10} │ {outcome,-6} │ {ratingChange,-14}│{gameHistory[i].GameId,-11} │");
        }
        Console.WriteLine("└────────────┴────────┴───────────────┴────────────┘");
        Console.WriteLine($"Total games played: {GamesCount}");
        Console.WriteLine($"Current Rating: {CurrentRating}");
    }
}



