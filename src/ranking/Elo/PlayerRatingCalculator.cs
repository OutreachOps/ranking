using System;

namespace Solaris7.Ranking.Elo
{
    internal class PlayerRatingCalculator
    {
        public int CalculateExpectedOutcome(int playerA, int playerB)
        {
            double ratingDifference = playerB - playerA;

            return (int)Math.Round(1 / (Math.Pow(10, ratingDifference / 400) + 1) * 100, MidpointRounding.ToEven);
        }

        public int CalculateNewRating(int playerRating, int k ,decimal expectedOutcome, decimal playerOutcome)
        {
            var ratingChange = k * (playerOutcome - expectedOutcome / 100);
            return playerRating + (int) Math.Round(ratingChange);
        }


    }
}
