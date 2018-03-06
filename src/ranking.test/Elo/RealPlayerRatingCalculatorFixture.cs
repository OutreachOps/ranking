using System;
using System.Collections.Generic;
using System.Text;
using Solaris7.Ranking.Elo;
using Xunit;

namespace Solaris7.Ranking.Test.Elo
{

    /// <summary>
    /// https://www.chess.com/blog/wizzy232/how-to-calculate-the-elo-system-of-rating
    /// http://www.3dkingdoms.com/chess/elo.htm 
    /// </summary>
    public class RealPlayerRatingCalculatorFixture
    {
        [Theory]
        [InlineData(52, 1583,1572)]
        [InlineData(48, 1572, 1583)]
        public void CalculateExpectedOutcome(int result, int playerA, int playerB)
        {
            var calculator = new PlayerRatingCalculator();
            Assert.Equal(result, calculator.CalculateExpectedOutcome(playerA, playerB));
        }

        [Theory]
        [InlineData(1583, 15, 52 ,1 ,1590)]
        [InlineData(1572, 15, 48, 0, 1565)]
        [InlineData(1572, 15, 48, 0.5, 1572)]
        public void CalculateNewPlayerRating(int currentRating, int maximumRatingChange, int expectedOutcome, decimal outcome,int newRating)
        {

            var calculator = new PlayerRatingCalculator();

            var result = calculator.CalculateNewRating(currentRating, maximumRatingChange, expectedOutcome, outcome);

            Assert.Equal(newRating,result);

        }

    }
}
