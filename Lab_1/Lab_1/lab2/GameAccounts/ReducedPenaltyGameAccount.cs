﻿using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.GameAccounts
{
    public class ReducedPenaltyGameAccount : GameAccount
    {
        public ReducedPenaltyGameAccount(string userName, int initialRating) : base(userName, initialRating) { }

        public override void WinGame(Game game)
        {
            int ratingChange = game.CalculatePoints();
            CurrentRating += ratingChange;
            game.Won = true;
            gameHistory.Add(game);
        }

        public override void LoseGame(Game game)
        {
            int ratingChange = game.CalculatePoints();
            if (ratingChange > 0)
            {
                ratingChange = ratingChange / 2; 
            }
            CurrentRating -= ratingChange;
            game.Rating = ratingChange;
            game.Won = false;
            gameHistory.Add(game);
        }
    }
}
