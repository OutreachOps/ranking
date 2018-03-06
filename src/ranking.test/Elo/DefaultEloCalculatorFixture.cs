using Solaris7.Ranking.Elo;
using Xunit;

namespace Solaris7.Ranking.Test.Elo
{
    public class DefaultEloCalculatorFixture
    {
        [Fact]
        public void CanCreateDefaultEloCalculator()
        {
            var calculator = EloCalculatorFactory.Create();

            Assert.NotNull(calculator);
        }

        [Fact]
        public void PlayerADefeatsPlayerB()
        {
            var calculator = EloCalculatorFactory.Create();

            var result = calculator.Calculate(
                new CurrentPlayerRatingDefault {PlayerId = "A", Rating = 1572}
                , new CurrentPlayerRatingDefault {PlayerId = "B", Rating = 1583}, Outcome.PlayerAWin);

            Assert.Equal(1572 + 8,result.PlayerA.Rating);
            Assert.Equal(1583 -8, result.PlayerB.Rating);

        }

        [Fact]
        public void PlayerBDefeatsPlayerA()
        {
            var calculator = EloCalculatorFactory.Create();

            var result = calculator.Calculate(
                new CurrentPlayerRatingDefault { PlayerId = "A", Rating = 1572 }
                , new CurrentPlayerRatingDefault { PlayerId = "B", Rating = 1583 }, Outcome.PlayerBWin);

            Assert.Equal(1572 - 7, result.PlayerA.Rating);
            Assert.Equal(1583 + 7, result.PlayerB.Rating);
        }

        [Fact]
        public void PlayersDraw()
        {
            var calculator = EloCalculatorFactory.Create();

            var result = calculator.Calculate(
                new CurrentPlayerRatingDefault { PlayerId = "A", Rating = 1572 }
                , new CurrentPlayerRatingDefault { PlayerId = "B", Rating = 1583 }, Outcome.Draw);

            Assert.Equal(1572 , result.PlayerA.Rating);
            Assert.Equal(1583 , result.PlayerB.Rating);
        }
    }


}
